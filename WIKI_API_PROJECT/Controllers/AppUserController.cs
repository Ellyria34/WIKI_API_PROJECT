using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;


namespace WIKI_API_PROJECT.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        UserManager<AppUser> _userManager;
        SignInManager<AppUser> _signInManager;
        RoleManager<IdentityRole> _roleManager;
        public AppUserController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> CreateUser(CreateAppUserDTO appUserDTO)
        {
            // Vérifier que l'utilisateur a au moins 18 ans
            var today = DateOnly.FromDateTime(DateTime.UtcNow);
            var age = today.Year - appUserDTO.AppUserBirthDay.Year;

            if (age > 18)
            {
                var appUser = new AppUser
                {
                    UserName = appUserDTO.AppUserName,
                    AppUserBirthDay = appUserDTO.AppUserBirthDay,
                };
                var result = await _userManager.CreateAsync(appUser, appUserDTO.AppUserPasseword);

                if (result.Succeeded)
                {
                    // use appUser to create other item with you context if needed

                    return Ok("User created !");
                }
                else
                    return Problem(string.Join(" | ", result.Errors.Select(e => e.Description)));
            }
            return BadRequest("You must be at least 18 years old to create an account.");
        }


    }
}
