using AngularApp1.Server.Models.Domain;
using AngularApp1.Server.Models.DTOS;
using AngularApp1.Server.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        public ImagesController( ISQLImagerepository sQLImagerepository)
        {
            SQLImagerepository = sQLImagerepository;
        }

        public ISQLImagerepository SQLImagerepository { get; }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file, [FromForm] string fileName,
            [FromForm] string title
            )
        {
            validateFileUpload(file);

            if (ModelState.IsValid)
            {
                //File Upload Logic
                var blogImage = new BlogImage
                {
                    FileExtension=Path.GetExtension(file.FileName).ToLower(),
                    FileName = fileName,
                    Title= title,
                    dateCreated = DateTime.Now
                };
                blogImage = await SQLImagerepository.UploadImageAsync(file, blogImage);

                //Convert this domian model to DTO if needed

                var response = new BlogImageDto
                {
                    Id = blogImage.Id,
                    FileName = blogImage.FileName,
                    FileExtension = blogImage.FileExtension,
                    Title = blogImage.Title,
                    Url = blogImage.Url,
                    dateCreated = blogImage.dateCreated
                };
                return Ok(response);
            }
           
            return BadRequest(ModelState);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllImages()
        {
            var images = await SQLImagerepository.GetallImageAsync();
            var response = images.Select(image => new BlogImageDto
            {
                Id = image.Id,
                FileName = image.FileName,
                FileExtension = image.FileExtension,
                Title = image.Title,
                Url = image.Url,
                dateCreated = image.dateCreated
            }).ToList();
            return Ok(response);
        }
        private void validateFileUpload(IFormFile file)
        { 
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };

            if (!allowedExtensions.Contains(Path.GetExtension(file.FileName).ToLower()))
            {
                ModelState.AddModelError("File", "Invalid file type. Only .jpg, .jpeg, and .png files are allowed.");
            }
            if (file.Length > 10 * 1024 * 1024) // 10 MB limit
            {
                ModelState.AddModelError("File", "File size exceeds the maximum limit of 10 MB.");
            }
            if (file.Length == 0)
            {
                ModelState.AddModelError("File", "File cannot be empty.");
            }

        }
    }
}
