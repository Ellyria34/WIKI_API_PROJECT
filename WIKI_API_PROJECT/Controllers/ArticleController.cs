using DTOs;
using IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Repositories.Contexts;

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

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<GetAllArticleDTO>>> GetAllArticleAsync()
        {
            List<GetAllArticleDTO> articles = await _repository.GetAllArticleAsync();
            return Ok (articles);
        }


        [HttpPost]
        public async Task<ActionResult> CreateArticle(CreateArticleDTO articleDTO)
        {
            var userconnected = await _userManager.GetUserAsync(User);
            try
            {
                var article = new Article
                {
                    Title = articleDTO.Title,
                    ArticleContent = articleDTO.ArticleContent,
                    TopicId = articleDTO.TopicId,
                };
                await _repository.CreateAsync(article, userconnected);
                return Ok("Article created !");
            }
            catch (Exception ex) { return Problem(ex.Message); }
        }



        [HttpPut]
        public async Task<ActionResult<Article>> UpdateArticle(UpdateArticleDTO updateArticleDTO)
        {
            var userconnected = await _userManager.GetUserAsync(User);

            if (userconnected == Article.)
            {

            }

        }


    }
}
