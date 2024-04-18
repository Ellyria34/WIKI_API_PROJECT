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
    [Authorize(Roles = "ADMIN")]

    public class TopicController : ControllerBase
    {
        TopicIRepository _repository;
        UserManager<AppUser> _userManager;
        RoleManager<IdentityRole> _roleManager;

        public TopicController(
            TopicIRepository repository,
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _repository = repository;
            _userManager = userManager;
            _roleManager = roleManager;

        }

        /// <summary>
        /// Get all Topics.
        /// </summary>
        /// <returns>The List of topics.</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<Topic>>> GetAllTopic()
        {
            List<Topic> topics = await _repository.GetAllTopicAsync();
            if (topics != null)
            {
                return Ok(topics);
            }
            else { return Problem("There are no items in BDD"); }
        }


        /// <summary>
        /// Get an topic by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Topic>> GetArticleById(int id)
        {
            Topic topic = await _repository.GetTopicByIdAsync(id);
            if (topic != null)
            {
                return Ok(topic);
            }
            else { return Problem("There are no items in BDD"); }
        }


        /// <summary>
        /// Create a new Topic.
        /// </summary>
        /// <param name="topicDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateTopic(CreateTopicDTO topicDTO)
        {
            await _repository.CreateAsync(topicDTO);
            if (topicDTO != null) return Ok("A new topic is created!");
            else return BadRequest("A topic is not created!");
        }


        /// <summary>
        /// Delete an Topic.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> DeleteTopic(int id)
        {
            Topic topic = await _repository.GetTopicByIdAsync(id);

            if (topic != null)
            {
                await _repository.DeleteTopicAsync(topic.TopicId);
                return Ok($"Article n° {topic.TopicId} has been deleted");
            }
            return BadRequest("No Articles match this id.");
        }

        /// <summary>
        /// Uptade an topic.
        /// </summary>
        /// <param name="topic"></param>
        /// <returns>The topic updated.</returns>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Topic>> UpdateTopic(Topic topic)
        {
            Topic topicToUpdate = await _repository.GetTopicByIdAsync(topic.TopicId);

            if (topicToUpdate != null)
            {
                await _repository.UpdateTopicAsync(topic);
                return Ok($"Article n° {topicToUpdate.TopicId} has been modified");
            }
            return Problem("You do not have the authorization to update this article");

        }
    }
}
