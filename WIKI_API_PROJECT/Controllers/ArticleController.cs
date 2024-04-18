using DTOs;
using IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<GetAllArticleDTO>> GetArticleByIdAsync(int id)
        {
            Article articles = await _repository.GetArticleByIdAsync(id);
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

        /// <summary>
        /// Delete an article by his id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> DeleteArticleAsync(int id)
        {
            var userconnected = await _userManager.GetUserAsync(User);
            bool isAdmin = await _userManager.IsInRoleAsync(userconnected, "ADMIN");

            Article article = await _repository.GetArticleByIdAsync(id);

            if (article != null)
            {
                if (isAdmin || article.ArticleAuthorId == userconnected.Id)
                {
                    await _repository.DeleteArticleAsync(article);
                    return Ok($"Article n° {id} has been deleted");
                }
                return Problem("You do not have the authorization to delete this article");
            }
            return BadRequest("No Articles match this id.");
        }




        /// <summary>
        /// Update an article
        /// </summary>
        /// <param name="updateArticleDTO"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Article>> UpdateArticle(UpdateArticleDTO updateArticleDTO)
        {
            var userconnected = await _userManager.GetUserAsync(User);
            bool isAdmin = await _userManager.IsInRoleAsync(userconnected, "ADMIN");

            Article article = await _repository.GetArticleByIdAsync(updateArticleDTO.id);

            if (article != null)
            {
                try
                {
                    if (isAdmin || article.ArticleAuthorId == userconnected.Id)
                    {
                        await _repository.UpdateArticleAsync(updateArticleDTO);
                        return Ok($"Article n° {article.ArticleId} has been modified");
                    }
                    return Problem("You do not have the authorization to update this article");
                }
                catch (Exception ex) { return StatusCode(500, ex.Message); }
                
            }
            return BadRequest("No Articles match this id.");
        }
    }
}
