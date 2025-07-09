using AngularApp1.Server.Models.Domain;
using AngularApp1.Server.Models.DTOS;

namespace AngularApp1.Server.Repository
{
    public interface ISQLCategoriesRepository
    {
        Task<List<Category>> GetAllCategoriesAsync();
        Task<Category?> GetCategoryByIdAsync(Guid id);        
        Task<Category> CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task<Category> UpdateCategoryAsync( Category updateCategoryDto);
        Task<Category> DeleteCategoryAsync(Guid id);
    }
}
