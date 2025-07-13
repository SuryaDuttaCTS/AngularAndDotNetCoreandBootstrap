namespace AngularApp1.Server.Models.DTOS
{
    public class LoginResponseDto
    {
        public string Email { get; set; }

        public string Token { get; set; }

        public List<string> Roles { get; set; }
    }
}
