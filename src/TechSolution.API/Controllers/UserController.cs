using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using TechSolution.API.Extensions;
using TechSolution.API.Identity;
using TechSolution.API.ViewModels;
using TechSolution.Business.Interfaces;

namespace TechSolution.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/user")]
    public class UserController : MainController
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly TokenSettings _tokenSettings;
        private readonly IUserService _userService;

        public UserController(INotificator notificator,
                              SignInManager<ApplicationUser> signInManager,
                              UserManager<ApplicationUser> userManager,
                              IUserService userService,
                              IOptions<TokenSettings> options) : base(notificator)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenSettings = options.Value;
            _userService = userService;
        }

        [HttpPost("new")]
        public async Task<ActionResult> Create(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new ApplicationUser
            {
                EmailConfirmed = true,
                Email = registerViewModel.Email,
                UserName = registerViewModel.Email,
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName
            };

            var result = await _userManager.CreateAsync(user, registerViewModel.Password);
            
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);

                return CustomResponse(new
                {
                    AcessToken = GenerateToken(),
                    ExpiresIn = DateTime.UtcNow.AddHours(_tokenSettings.ExpiresIn),
                    UserId = _userService.GetUserId()
                });
            }
            else
            {
                foreach (var error in result.Errors)
                    Notify(error.Description);
            }

            return CustomResponse();
        }

        [HttpGet("login")]
        public async Task<ActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, false, false);

            if (result.Succeeded)
            {
                return CustomResponse(new
                {
                    AcessToken = GenerateToken(),
                    ExpiresIn = DateTime.UtcNow.AddHours(_tokenSettings.ExpiresIn),
                    UserId = _userService.GetUserId()
                });
            }

            return NotFound();
        }

        string GenerateToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_tokenSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Audience = _tokenSettings.Auditor,
                Issuer = _tokenSettings.Issuer,
                Expires = DateTime.UtcNow.AddHours(_tokenSettings.ExpiresIn),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            });

            var endodedToken = tokenHandler.WriteToken(token);

            return endodedToken;
        }
    }
}
