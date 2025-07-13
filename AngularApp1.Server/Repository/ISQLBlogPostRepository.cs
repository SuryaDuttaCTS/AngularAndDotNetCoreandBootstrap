using AngularApp1.Server.Models.Domain;
using AngularApp1.Server.Models.DTOS;

namespace AngularApp1.Server.Repository
{
    public interface ISQLBlogPostRepository
    {
        Task<IEnumerable<BlogPost>> GetAllBlogPostAsync();
        Task<BlogPost?> GetBlogPostByIdAsync(Guid id);
        Task<BlogPost> CreateBlogPostAsync(AddblogPostRequestDto createblogPostRequestDto);
        Task<BlogPost?> UpdateBlogPostAsync(BlogPost updateBlogPost);
        Task<BlogPost?> DeleteBlogPostAsync(Guid id);
    }
}
