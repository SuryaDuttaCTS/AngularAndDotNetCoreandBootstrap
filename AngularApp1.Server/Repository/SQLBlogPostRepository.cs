using AngularApp1.Server.Context;
using AngularApp1.Server.Models.Domain;
using AngularApp1.Server.Models.DTOS;
using Microsoft.EntityFrameworkCore;

namespace AngularApp1.Server.Repository
{
    public class SQLBlogPostRepository : ISQLBlogPostRepository
    {
        private readonly BlogDbContext _dbcontext;

        public SQLBlogPostRepository(BlogDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<BlogPost> CreateBlogPostAsync(AddblogPostRequestDto createblogPostRequestDto)
        {
            var BlogPost = new BlogPost
            {
                Id = Guid.NewGuid(),
                Title = createblogPostRequestDto.Title,
                ShortDescription = createblogPostRequestDto.ShortDescription,
                UrlHandle = createblogPostRequestDto.UrlHandle,
                Content = createblogPostRequestDto.Content,
                FeaturedImageUrl = createblogPostRequestDto.FeaturedImageUrl,
                DateCreated = createblogPostRequestDto.DateCreated,
                Author = createblogPostRequestDto.Author,
                IsVisible = createblogPostRequestDto.IsVisible,
                Categories=new List<Category>()

            };

            foreach (var categoryId in createblogPostRequestDto.Categories)
            {
                var category = await _dbcontext.Categories.FindAsync(categoryId);
                if (category != null)
                {
                    BlogPost.Categories.Add(category);
                }
            }

            await _dbcontext.BlogPosts.AddAsync(BlogPost);
            await _dbcontext.SaveChangesAsync();
            return BlogPost;
        }

        public async Task<BlogPost?> DeleteBlogPostAsync(Guid id)
        {
            var blogPost = await _dbcontext.BlogPosts
                .FirstOrDefaultAsync(b => b.Id == id);
            if (blogPost == null)
                {
                return null; // Blog post not found
            }
            _dbcontext.BlogPosts.Remove(blogPost);
            await _dbcontext.SaveChangesAsync();
            return blogPost;
        }

        public async Task<IEnumerable<BlogPost>> GetAllBlogPostAsync()
        {
            return await _dbcontext.BlogPosts.Include(x => x.Categories).ToListAsync();

        }

        public async Task<BlogPost?> GetBlogPostByIdAsync(Guid id)
        {
           var blogpost = await _dbcontext.BlogPosts.Include(x=>x.Categories)
                .FirstOrDefaultAsync(b => b.Id == id);
            if (blogpost == null)
            {
                return null; // Blog post not found
            }
            return blogpost;
        }

        public async Task<BlogPost?> UpdateBlogPostAsync(BlogPost updateBlogPost)
        {
            var blogpost = await _dbcontext.BlogPosts.Include(x=>x.Categories)
                .FirstOrDefaultAsync(b => b.Id == updateBlogPost.Id);

            if (blogpost == null)
            {
                return null;
            }

            //Update blogpost
            _dbcontext.Entry(blogpost).CurrentValues.SetValues(updateBlogPost);

            //Update categories
            blogpost.Categories= updateBlogPost.Categories;
            await _dbcontext.SaveChangesAsync();

            return updateBlogPost;
        }
    }
}
