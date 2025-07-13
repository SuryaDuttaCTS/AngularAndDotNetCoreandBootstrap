using AngularApp1.Server.Context;
using AngularApp1.Server.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace AngularApp1.Server.Repository
{
    public class SQLImageRepository : ISQLImagerepository
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly BlogDbContext blogDbContext;

        public SQLImageRepository(IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor,
            BlogDbContext blogDbContext)
        {
            _webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.blogDbContext = blogDbContext;
        }

        public async Task<IEnumerable<BlogImage>> GetallImageAsync()
        {
            return await blogDbContext.BlogImages.ToListAsync();
        }

        public async Task<BlogImage> UploadImageAsync(IFormFile file, BlogImage blogImage)
        {
            //1-upload image to api folder API/Images
            var localPath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", $"{blogImage.FileName}{blogImage.FileExtension}");

            using var stream = new FileStream(localPath, FileMode.Create);
            await file.CopyToAsync(stream);

            //2-Update the database
            var httpRequest = httpContextAccessor.HttpContext.Request;
            var urlpath = $"{httpRequest.Scheme}://{httpRequest.Host}{httpRequest.PathBase}/Images/{blogImage.FileName}{blogImage.FileExtension}";
            blogImage.Url = urlpath;

            await blogDbContext.BlogImages.AddAsync(blogImage);
            await blogDbContext.SaveChangesAsync();

            //3-Return the blog post with the image

            return blogImage;


        }
    }
}
