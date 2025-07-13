namespace AngularApp1.Server.Models.DTOS
{
    public class BlogImageDto
    {
        public Guid Id { get; set; }

        public string FileName { get; set; }

        public string FileExtension { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public DateTime dateCreated { get; set; }
    }
}
