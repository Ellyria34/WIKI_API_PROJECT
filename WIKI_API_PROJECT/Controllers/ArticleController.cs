using DTOs;
using IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace WIKI_API_PROJECT.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [Authorize]

    public class ArticleController : ControllerBase
    {
        ArticleIRepository _repository;
        UserManager<AppUser> _userManager;
        SignInManager<AppUser> _signInManager;
        RoleManager<IdentityRole> _roleManager;
        public ArticleController(
            ArticleIRepository repository,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _repository = repository;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<ActionResult> CreateArticle(CreateArticleDTO articleDTO)
        {
            var userconnected = await _userManager.GetUserAsync(User);
            try
            {
                var article = new Article
                {
                    Title = articleDTO.Title,
                    ArticleContent = articleDTO.ArticleContent
                };
                await _repository.CreateAsync(article, userconnected);
                return Ok("Article created !");
            }
            catch (Exception ex) { return Problem(ex.Message); }
        }


    }
}
