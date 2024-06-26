﻿using Models;
using DTOs;

namespace IRepositories
{
    public interface ArticleIRepository
    {
        /// <summary>
        /// GetAll Article.
        /// </summary>
        /// <returns>All articles.</returns>
        Task<List<GetAllArticleDTO>> GetAllArticleAsync();

        /// <summary>
        /// Get All article by Author sorted in ascending order.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>All article order.</returns>
        Task<List<GetAllArticleDTO>> GetAllArticleByAuthorsAscAsync();


        /// <summary>
        /// Get All article by Author sorted in descending order.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>All article order.</returns>
        Task<List<GetAllArticleDTO>> GetAllArticleByAuthorsDescAsync();


        /// <summary>
        /// Get one article.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The article.</returns>
        Task <Article> GetArticleByIdAsync(int id);


        /// <summary>
        /// Get All article by Topic sorted in ascending order.
        /// </summary>
        /// <param name="topicName"></param>
        /// <returns>All article with Topic.</returns>
        Task<List<Article>> GetArticlesByTopicAscAsync(string topicName);


        /// <summary>
        /// Get All article by Topic sorted in descending order.
        /// </summary>
        /// <param name="topicName"></param>
        /// <returns>All article with Topic.</returns>
        Task<List<Article>> GetArticlesByTopicDescAsync(string topicName);


        /// <summary>
        /// Get one article with its Comments.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The article and the list of its comments.</returns>
        Task <Article> GetByIdAndAllCommentsAsync(int id);


        /// <summary>
        /// Create a new article.
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        Task CreateAsync(Article article, AppUser appUser);


        /// <summary>
        /// Delete an article.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteArticleAsync(Article article);


        /// <summary>
        /// Update an article.
        /// </summary>
        /// <param name="article"></param>
        /// <returns>The article updated.</returns>
        Task <UpdateArticleDTO> UpdateArticleAsync(UpdateArticleDTO article);
    }
}
