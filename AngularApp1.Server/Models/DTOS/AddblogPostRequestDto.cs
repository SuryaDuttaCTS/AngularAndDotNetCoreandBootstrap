using System.ComponentModel.DataAnnotations;

namespace AngularApp1.Server.Models.DTOS
{
    public class AddblogPostRequestDto
    {
       
        [Required]
        public required string Title { get; set; }
        [Required]
        public required string ShortDescription { get; set; }
        [Required]
        public required string Content { get; set; }
        [Required]
        public required string UrlHandle { get; set; }
        [Required]
        public required string FeaturedImageUrl { get; set; }
        [Required]
        public required DateOnly DateCreated { get; set; }
        [Required]
        public required string Author { get; set; }
        [Required]
        public required bool IsVisible { get; set; }

        public Guid[] Categories { get; set; }
    }
}
