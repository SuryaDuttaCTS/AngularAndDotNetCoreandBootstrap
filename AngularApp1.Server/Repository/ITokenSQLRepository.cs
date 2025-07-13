using Microsoft.AspNetCore.Identity;

namespace AngularApp1.Server.Repository
{
    public interface ITokenSQLRepository
    {
        string CreateJWTtoken(IdentityUser user, List<string> Roles);
    }
}
