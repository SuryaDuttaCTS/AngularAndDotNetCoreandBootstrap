using System.ComponentModel.DataAnnotations;

namespace AngularApp1.Server.Models.Domain
{
    public class Category
    {
        
        public Guid Id { get; set; }

        [Required]
        public required string Name { get; set; }
        [Required]
        public required string UrlHandle { get; set; }
    }
}
