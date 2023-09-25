using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    public class UserController : ControllerBase
    {

        readonly UserService _userService;


        public UserController(UserService userService)
        {
           
            this._userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterDTO register)
        {
            if (register.Password != register.PasswordConfirm)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Error = "Le mot de passe et le mot de passe de confirmation ne sont pas identique" });
            }

            var registrationResult = await _userService.RegisterUserAsync(register);

            if(registrationResult.Succeeded)
            {
                return Ok();
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = registrationResult.Errors });

            }
        }

        [HttpPost]
        public async Task<ActionResult<MonDTO>> Login(LoginDTO login)
        {
            var loginResult = await _userService.LoginUserAsync(login);

            if (!loginResult.Success)
            {
                return NotFound(new { Error = loginResult.Error });
            }
            else
            {
                return Ok(loginResult.MonDTO);
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

            await _userService.SignOut();

            if (!User.Identity.IsAuthenticated)
            {
                // If the user is still authenticated, sign-out failed
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "Sign-out failed." });
            }

            return Ok();
        }
    }

    public class MonDTO
    {
        public string Name { get; set; }
        public string Id { get; set; }
    }
}
