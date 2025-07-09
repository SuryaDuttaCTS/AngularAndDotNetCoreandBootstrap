using AngularApp1.Server.Context;
using AngularApp1.Server.Models.Domain;
using AngularApp1.Server.Models.DTOS;
using Microsoft.EntityFrameworkCore;

namespace AngularApp1.Server.Repository
{
    public class SQLCategoriesRepository : ISQLCategoriesRepository
    {
        private readonly BlogDbContext _dbcontext;

        public SQLCategoriesRepository(BlogDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Category> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
           var Category = new Category
            {
                Id = Guid.NewGuid(),
                Name = createCategoryDto.Name,
                UrlHandle = createCategoryDto.UrlHandle
            };
            await _dbcontext.Categories.AddAsync(Category);
            await _dbcontext.SaveChangesAsync();
            return Category;
        }

        public async Task<Category> DeleteCategoryAsync(Guid id)
        {
            var category = await _dbcontext.Categories
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                // Category not found, return false
                return category;
            }
                await _dbcontext.Categories
                .Where(c => c.Id == id)
                .ExecuteDeleteAsync();
            var deleted = await _dbcontext.SaveChangesAsync();

            return category;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            var category = await _dbcontext.Categories.ToListAsync();
            return category;
        }

        public Task<Category?> GetCategoryByIdAsync(Guid id)
        {
            var category = _dbcontext.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null)
            {
                return Task.FromResult<Category?>(null);
            }
            return category;
        }
               

        public async Task<Category> UpdateCategoryAsync( Category updateCategoryDto)
        {
           var category = await _dbcontext.Categories.FirstOrDefaultAsync(c => c.Id == updateCategoryDto.Id);

            if (category == null)
            {
                throw new KeyNotFoundException($"Category with ID {updateCategoryDto.Id} not found.");
            }
            if (string.IsNullOrWhiteSpace(updateCategoryDto.Name) || string.IsNullOrWhiteSpace(updateCategoryDto.UrlHandle))
            {
                throw new ArgumentException("Name and UrlHandle cannot be null or empty.");
            }

            category.Name = updateCategoryDto.Name;
            category.UrlHandle = updateCategoryDto.UrlHandle;
            _dbcontext.Categories.Update(category);
           await _dbcontext.SaveChangesAsync();

            return category;
        }
    }
}
