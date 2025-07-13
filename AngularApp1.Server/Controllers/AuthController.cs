using AngularApp1.Server.Models.DTOS;
using AngularApp1.Server.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AngularApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenSQLRepository tokenSQLRepository;

        // private readonly IAuthRepository _authRepository;
        public AuthController(UserManager<IdentityUser> userManager, ITokenSQLRepository tokenSQLRepository)
        {
            this.userManager = userManager;
            this.tokenSQLRepository = tokenSQLRepository;
        }

        //POST: {apiBaseUrl}/api/auth/register
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            //Create the identity user object
            var user= new IdentityUser
            {
                UserName = registerRequestDto.Email?.Trim(),
                Email = registerRequestDto.Email?.Trim(),
            };

            var Idenityresult = await userManager.CreateAsync(user, registerRequestDto.Password);

            if (Idenityresult.Succeeded)
            {
                Idenityresult = await userManager.AddToRoleAsync(user, "Reader");
                if (Idenityresult.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    if (Idenityresult.Errors.Any()) 
                    {
                        foreach (var error in Idenityresult.Errors)
                        {
                            ModelState.AddModelError("",error.Description);
                        }
                    }
                }
            }
            else
            {
                if (Idenityresult.Errors.Any())
                {
                    foreach (var error in Idenityresult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return ValidationProblem(ModelState);
        }

        //POST: {apiBaseUrl}/api/auth/login
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDto.Email);
            if (user is not null)
            {
                //check passowrd
                var isPasswordValid = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);
                if (isPasswordValid)
                {
                    var roles = await userManager.GetRolesAsync(user);
                    //Create a token and return it
                    var JwtToken=tokenSQLRepository.CreateJWTtoken(user, roles.ToList());

                    // For simplicity, we are not implementing token generation here.
                    var response = new LoginResponseDto() { 
                    Email= loginRequestDto.Email,
                    Roles = roles.ToList(),
                    Token= JwtToken
                    };

                    return Ok(response);
                }                
            }

            ModelState.AddModelError("", "Invalid login attempt. Please check your email and password.");
            return ValidationProblem(ModelState);

        }
    }

}
