using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AngularApp1.Server.Models.DTOS;
using AngularApp1.Server.Models.Domain;
using AngularApp1.Server.Repository;
using Microsoft.AspNetCore.Authorization;

namespace AngularApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
      private readonly ISQLCategoriesRepository _categoriesRepository;
        public CategoriesController(ISQLCategoriesRepository sQLCategoriesRepository)
        {
            _categoriesRepository = sQLCategoriesRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto category)
        {
            //Map DTO to Domain Model
            var category1 = await _categoriesRepository.CreateCategoryAsync(category);

            CreateCategoryDto category2 = new CreateCategoryDto
            {
                Name = category1.Name,
                UrlHandle = category1.UrlHandle
            };

            return Ok(category2);
        }

        [HttpGet]
        [Authorize(Roles ="Writer")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoriesRepository.GetAllCategoriesAsync();
            if (categories == null || !categories.Any())
            {
                return NotFound("No categories found.");
            }

            // Map Domain Model to DTO
            var categoryDtos = categories.Select(c => new Category
            {
                Id = c.Id,
                Name = c.Name,
                UrlHandle = c.UrlHandle
            }).ToList();

            return Ok(categoryDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var category = await _categoriesRepository.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound($"Category with ID {id} not found.");
            }
            // Map Domain Model to DTO
            var categoryDto = new Category
            {
                Id=category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };
            
            return Ok(categoryDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var category = await _categoriesRepository.DeleteCategoryAsync(id);
            if (category is null)
            {
                return NotFound($"Category with ID {id} not found.");
            }

          var  categoryDeleted = new Category() { 
            Id= category.Id,
            Name = category.Name,
            UrlHandle = category.UrlHandle

            };


            return Ok(categoryDeleted);
        }

        [HttpPut]
        [Route("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] Guid id, [FromBody] CreateCategoryDto updateCategory)
        {
            var category = new Category() 
            {     
                Id = id,
                Name = updateCategory.Name,
                UrlHandle = updateCategory.UrlHandle
            };
            var updatedCategory = await _categoriesRepository.UpdateCategoryAsync(category);
            if (updatedCategory == null)
            {
                return NotFound($"Category with ID {category.Id} not found.");
            }
            // Map Domain Model to DTO
            var categoryDto = new Category
            {
                Id= updatedCategory.Id,
                Name = updatedCategory.Name,
                UrlHandle = updatedCategory.UrlHandle
            };
            return Ok(categoryDto);
        }
    }
}
