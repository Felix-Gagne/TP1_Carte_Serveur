using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Moq;
using Super_Cartes_Infinies.Models.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Super_Cartes_Infinies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserManager<IdentityUser> userManager;
        SignInManager<IdentityUser> signInManager;

        public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterDTO register)
        {
            if(register.Password != register.PasswordConfirm)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    new { Error = "Le mot de passe et le mot de passe de confirmation ne sont pas identique" });
            }

            IdentityUser user = new IdentityUser()
            {
                Email = register.Email,
            };

            IdentityResult identityResult = await this.userManager.CreateAsync(user, register.Password);

            if(!identityResult.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = identityResult.Errors });
            }

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginDTO login)
        {
            var user = await userManager.FindByNameAsync(login.Username);

            if (user == null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized,
                    new { Error = "Nom d'utilisateur incorrect" });
            }

            var signInResult = await signInManager.PasswordSignInAsync(user, login.Password, false, false);

            if (!signInResult.Succeeded)
            {
                return StatusCode(StatusCodes.Status401Unauthorized,
                    new { Error = "Mot de passe incorrect" });
            }

            return RedirectToAction("Index", "Home");
        }








    }
}
