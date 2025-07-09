using System.ComponentModel.DataAnnotations;

namespace AngularApp1.Server.Models.DTOS
{
    public class CreateCategoryDto
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string UrlHandle { get; set; }
    }
}
