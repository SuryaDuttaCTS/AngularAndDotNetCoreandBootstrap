using AngularApp1.Server.Models.Domain;

namespace AngularApp1.Server.Repository
{
    public interface ISQLImagerepository
    {
        Task<BlogImage> UploadImageAsync(IFormFile file, BlogImage blogImage);
        Task<IEnumerable<BlogImage>> GetallImageAsync();
        //Task<bool> DeleteImageAsync(Guid imageId);
        //Task<BlogImage> GetImageByIdAsync(Guid imageId);
        //Task<IEnumerable<BlogImage>> GetAllImagesAsync();
        //Task<bool> UpdateImageAsync(BlogImage blogImage);
    }
}
