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
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Super_Cartes_Infinies.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserManager<IdentityUser> userManager;
        SignInManager<IdentityUser> signInManager;
        ApplicationDbContext _context;

        public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this._context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterDTO register)
        {
            if (register.Password != register.PasswordConfirm)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Error = "Le mot de passe et le mot de passe de confirmation ne sont pas identique" });
            }

            IdentityUser user = new IdentityUser()
            {
                UserName = register.Username,
                Email = register.Email,
            };

            IdentityResult identityResult = await this.userManager.CreateAsync(user, register.Password);

            if (!identityResult.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = identityResult.Errors });
            }

            await _context.SaveChangesAsync();

            List<StartingCards> list = await _context.StartingCards.ToListAsync();

            Player player = new Player
            {
                IdentityUserId = user.Id,
                IdentityUser = user,
                Name = register.Username,
                DeckCard = new List<Card>(),
                Money = 0
            };

            foreach (StartingCards startingCard in list)
            {
                if (startingCard != null)
                {
                    player.DeckCard.Add(startingCard.Card);
                }
                else
                {
                    return NotFound(new { Error = "Aucune carte n'existe" });

                }
            }

            await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();


            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<MonDTO>> Login(LoginDTO login)
        {
            var signInResult = await signInManager.PasswordSignInAsync(login.Username, login.Password, true, lockoutOnFailure: false);

            if (signInResult.Succeeded)
            {
                MonDTO test = new MonDTO()
                {
                    Name = login.Username
                };
                return Ok(test);
            }

            return NotFound(new { Error = "L'utilisateur est introuvable ou le mot de passe ne concorde pas."});
        }

        [HttpPost]
        public async Task<ActionResult> SignOut()
        {
            await signInManager.SignOutAsync();

            return Ok();
        }
    }

    public class MonDTO
    {
        public string Name { get; set; }
    }
}
