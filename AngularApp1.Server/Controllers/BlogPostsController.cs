using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularApp1.Server.Context;
using AngularApp1.Server.Models.Domain;
using AngularApp1.Server.Repository;
using AngularApp1.Server.Models.DTOS;

namespace AngularApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        private readonly ISQLBlogPostRepository _context;
        private readonly ISQLCategoriesRepository _sQLCategoriesRepository;

        public BlogPostsController(ISQLBlogPostRepository context, ISQLCategoriesRepository sQLCategoriesRepository)
        {
            _context = context;
            _sQLCategoriesRepository = sQLCategoriesRepository;
        }

        // GET: api/BlogPosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogPost>>> GetBlogPosts()
        {
            var blogpost = await _context.GetAllBlogPostAsync();

            var response = new List<BlogPostDto>();
            foreach (var _blogPost in blogpost)
            {
                response.Add( new BlogPostDto
                    {

                Id = _blogPost.Id,
                Title = _blogPost.Title,
                Content = _blogPost.Content,
                ShortDescription = _blogPost.ShortDescription,
                UrlHandle = _blogPost.UrlHandle,
                FeaturedImageUrl = _blogPost.FeaturedImageUrl,
                DateCreated = _blogPost.DateCreated,
                Author = _blogPost.Author,
                IsVisible = _blogPost.IsVisible,
                Categories = _blogPost.Categories.Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    UrlHandle = c.UrlHandle
                }).ToList()

                });
            }
           return Ok(response);
        }

        // GET: api/BlogPosts/5
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetBlogPost([FromRoute]Guid id)
        {
            var blogPosts = await _context.GetBlogPostByIdAsync(id);

            if (blogPosts == null)
            {
                return NotFound();
            }


            // Map Domain Model to DTO
            var response = new BlogPostDto { 
                Id = blogPosts.Id,
                Title = blogPosts.Title,
                Content = blogPosts.Content,
                ShortDescription = blogPosts.ShortDescription,
                UrlHandle = blogPosts.UrlHandle,
                FeaturedImageUrl = blogPosts.FeaturedImageUrl,
                DateCreated = blogPosts.DateCreated,
                Author = blogPosts.Author,
                IsVisible = blogPosts.IsVisible,
                Categories = blogPosts.Categories.Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    UrlHandle = c.UrlHandle
                }).ToList()
            };
                
            
              
            

            return Ok(response);
        }

        // PUT: api/BlogPosts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<ActionResult> PutBlogPost([FromRoute]Guid id, UpdateBlogPostDto request)
        {
            //from Dto to domain model

            var blogpost = new BlogPost
            {
                Id = id,
                Title = request.Title,
                ShortDescription = request.ShortDescription,
                UrlHandle = request.UrlHandle,
                Content = request.Content,
                FeaturedImageUrl = request.FeaturedImageUrl,
                DateCreated = request.DateCreated,
                Author = request.Author,
                IsVisible = request.IsVisible,
                Categories = new List<Category>()
            };

            foreach (var item in request.Categories)
            { 
               var existingCategory= await _sQLCategoriesRepository.GetCategoryByIdAsync(item);
                if (existingCategory != null)
                {
                    blogpost.Categories.Add(existingCategory);
                }
                else
                {
                    // Handle the case where the category does not exist
                    // You might want to throw an exception or return a specific error response
                    return BadRequest($"Category with ID {item} does not exist.");
                }
            }

            var blogposts= await _context.UpdateBlogPostAsync(blogpost);
            if (blogpost == null)
            {
                return NotFound();
            }

            var response = new BlogPostDto
            {
                Id = blogpost.Id,
                Author = blogpost.Author,
                Content = blogpost.Content,
                FeaturedImageUrl = blogpost.FeaturedImageUrl,
                IsVisible = blogpost.IsVisible,
                DateCreated = blogpost.DateCreated,
                ShortDescription = blogpost.ShortDescription,
                Title = blogpost.Title,
                UrlHandle = blogpost.UrlHandle,
                Categories = blogpost.Categories.Select(
                    c => new CategoryDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        UrlHandle = c.UrlHandle
                    }).ToList()
            };

            return Ok(response);
        }

        // POST: api/BlogPosts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BlogPost>> PostBlogPost(AddblogPostRequestDto blogPost)
        {
            

            var blogposts= await _context.CreateBlogPostAsync(blogPost);
            if (blogposts == null)
            {
                return BadRequest();
            }

            // Map DTO to Domain Model

            var newBlogPost = new BlogPost
            {
                Id = Guid.NewGuid(),
                Title = blogPost.Title,
                ShortDescription = blogPost.ShortDescription,
                UrlHandle = blogPost.UrlHandle,
                Content = blogPost.Content,
                FeaturedImageUrl = blogPost.FeaturedImageUrl,
                DateCreated = blogPost.DateCreated,
                Author = blogPost.Author,
                IsVisible = blogPost.IsVisible,
                Categories=new List<Category>()
            };

            return newBlogPost;
        }

        // DELETE: api/BlogPosts/5
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteBlogPost([FromRoute] Guid id)
        {
            var blogpost = await _context.DeleteBlogPostAsync(id);

            if (blogpost == null)
            {
                return NotFound();
            }

            //convert to Blogpost Dto
            var response = new BlogPostDto() {
                Id = blogpost.Id,
                Title = blogpost.Title,
                Content = blogpost.Content,
                ShortDescription = blogpost.ShortDescription,
                UrlHandle = blogpost.UrlHandle,
                FeaturedImageUrl = blogpost.FeaturedImageUrl,
                DateCreated = blogpost.DateCreated,
                Author = blogpost.Author,
                IsVisible = blogpost.IsVisible
            };

            return Ok(response);
        }

       
    }
}
