using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using Models;
using System.Data;


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

        /// <summary>
        /// Create User account method
        /// </summary>
        /// <param name="appUserDTO"></param>
        /// <returns></returns>
        [HttpPost]
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


        /// <summary>
        /// Login to an account
        /// </summary>
        /// <param name="loginDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public async Task<ActionResult> Login(LoginDTO loginDTO)
        {
            var appUser = await _userManager.FindByNameAsync(loginDTO.UserName);

            if (appUser == null) { return BadRequest("No account exists with this username. Verify your login or create an account"); }

            if (appUser != null && await _userManager.CheckPasswordAsync(appUser, loginDTO.Password))
            {
                // Vous pouvez créer un jeton d'authentification ici si vous le souhaitez

                return Ok($"Successful connection! Welcome {loginDTO.UserName}");
            }
            else
            {
                return BadRequest("Incorrect username or password.");
            }
        }


        /// <summary>
        /// Create an "ADMIN" role if it does not already exist in the database.
        /// </summary>
        /// <returns></returns>

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> CreateRoleAdmin()
        {
            if (!await _roleManager.RoleExistsAsync("ADMIN"))
            {
                var result = await _roleManager.CreateAsync(new IdentityRole { Name = "ADMIN", NormalizedName = "ADMIN" });

                if (result.Succeeded)
                {
                    return Ok("The admin role has been created.");
                }
                else
                    return Problem(string.Join(" | ", result.Errors.Select(e => e.Description)));
            }
            return Ok("The admin role has been already created.");
        }


        //    /// <summary>
        //    /// Add the currently logged-in user to the "ADMIN" role
        //    /// </summary>
        //    /// <returns></returns>
        //    [HttpGet]
        //    [Authorize(Roles = "ADMIN")]
        //    public async Task<IActionResult> AddUserToRoleAdmin()
        //    {
        //        var appUser = await _userManager.GetUserAsync(User);

        //        await _userManager.AddToRoleAsync(appUser, "ADMIN");

        //        return Ok($"{User.Identity.Name} is now Admin");
        //    }



        //    /// <summary>
        //    /// Check whether the user currently logged in belongs to the "ADMIN" role
        //    /// </summary>
        //    /// <returns></returns>
        //    [HttpGet]
        //    public async Task<ActionResult> IsUserInRole()
        //    {
        //        var appUser = await _userManager.GetUserAsync(User);

        //        return Ok($"{_userManager.IsInRoleAsync(appUser, "ADMIN")}");
        //    }
    }
}
