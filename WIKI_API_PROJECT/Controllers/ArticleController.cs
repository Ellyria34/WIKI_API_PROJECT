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

        /// <summary>
        /// Get all article
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<GetAllArticleDTO>>> GetAllArticleAsync()
        {
            List<GetAllArticleDTO> articles = await _repository.GetAllArticleAsync();
            if (articles != null)
            {
                return Ok(articles);
            }
            else { return Problem("There are no items in BDD"); }

        }


        /// <summary>
        /// Create an new article
        /// </summary>
        /// <param name="articleDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

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


        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> DeleteArticleAsync(int id)
        {
            var nbRows = await _repository.Where(a => a.Id == id)
                .ExecuteDeleteAsync();

            if (nbRows == 0)
            {
                return NotFound("This article was not found.");
            }

            return Ok("The article has been deleted.");
        }
    }





    //[HttpPut]
    //public async Task<ActionResult<Article>> UpdateArticle(UpdateArticleDTO updateArticleDTO)
    //{
    //    var userconnected = await _userManager.GetUserAsync(User);

    //    if (userconnected == Article.)
    //    {

    //    }

    //}
}
