using DTOs;
using Microsoft.AspNetCore.Mvc;
using Models;


namespace IRepositories
{
    public interface TopicIRepository
    {
        /// <summary>
        /// Checks if the topic no exists
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<bool> ExistsAsync(string topicName);

        /// <summary>
        /// Get All topics.
        /// </summary>
        /// <returns>All topics.</returns>
        Task<List<Topic>> GetAllTopicAsync();


        /// <summary>
        /// Get one topic.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>a topic.</returns>
        Task<Topic> GetTopicByIdAsync(int id);


        /// <summary>
        /// Create a new topic.
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        Task CreateAsync(CreateTopicDTO topicDTO);

        /// <summary>
        /// Delete one topic.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteTopicAsync(int id);


        /// <summary>
        /// Update one topic
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        Task<Topic> UpdateTopicAsync(Topic topic);
    }
}
