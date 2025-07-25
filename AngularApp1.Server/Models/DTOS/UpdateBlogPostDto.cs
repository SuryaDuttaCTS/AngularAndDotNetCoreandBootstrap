﻿namespace AngularApp1.Server.Models.DTOS
{
    public class UpdateBlogPostDto
    {
        public  string Title { get; set; }
        
        public  string ShortDescription { get; set; }
       
        public  string Content { get; set; }
        
        public  string UrlHandle { get; set; }
        
        public  string FeaturedImageUrl { get; set; }
        
        public  DateOnly DateCreated { get; set; }
        
        public  string Author { get; set; }
        
        public  bool IsVisible { get; set; }

        public List<Guid> Categories { get; set; } = new List<Guid>();
    }
}
