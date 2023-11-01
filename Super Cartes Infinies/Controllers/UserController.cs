using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Moq;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Models.Dtos;
using Super_Cartes_Infinies.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Super_Cartes_Infinies.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : BaseController
    {

        readonly UserService _userService;
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        private ApplicationDbContext _context;


        public UserController(UserService userService, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, 
            PlayersService playersService, ApplicationDbContext context) : base(playersService)
        {
            _context = context;
            this._userService = userService;
            this._userManager = userManager;    
            this._signInManager = signInManager;
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterDTO register)
        {
            if (register.Password != register.PasswordConfirm)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Error = "Le mot de passe et le mot de passe de confirmation ne sont pas identiques" });
            }

            IdentityUser user = new IdentityUser()
            {
                UserName = register.Username,
                Email = register.Email,
            };

            IdentityResult identityResult = await _userManager.CreateAsync(user, register.Password);

            if(identityResult.Succeeded)
            {
                var registrationResult = await _userService.RegisterUserAsync(register, user);
                if (registrationResult.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    var errors = identityResult.Errors.Concat(registrationResult.Errors);
                    return StatusCode(StatusCodes.Status400BadRequest, new { Message = "vous avez rentrez les mauvaise information" });
                }
            }
            else
            {
                // Handle the case where user creation failed
                return StatusCode(StatusCodes.Status400BadRequest, new { Message = "Failed to create user" });
            }
        }


        [HttpPost]
        public async Task<ActionResult<MonDTO>> Login(LoginDTO login)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(login.Username, login.Password, true, lockoutOnFailure: false);

            if (signInResult.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(login.Username);
                var loginResult = await _userService.LoginUserAsync(login, user);

                if (!loginResult.Success)
                {
                    return NotFound(new { Error = loginResult.Error });
                }
                else
                {
                    return Ok(loginResult.MonDTO);
                }
            }
            else
            {
                // Return a 401 Unauthorized status code with an error message
                return Unauthorized(new { Error = "Invalid username or password." });
            }
        }

        [HttpPost]
        public async Task<ActionResult> SignOut()
        {
            if (!User.Identity.IsAuthenticated)
            {
                // If the user is still authenticated, sign-out failed
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "You can't sign out" });
            }

            await _signInManager.SignOutAsync();


            if (!User.Identity.IsAuthenticated)
            {
                // If the user is still authenticated, sign-out failed
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "Sign-out failed." });
            }

            return Ok();
        }

        [HttpGet]
        public async Task<int> GetMoney()
        {
            Player player = await _context.Players.Where(x => x.IdentityUserId == UserId).FirstOrDefaultAsync();
            return player.Money;
        }
    }

    public class MonDTO
    {
        public string Name { get; set; }
        public string Id { get; set; }
    }
}
