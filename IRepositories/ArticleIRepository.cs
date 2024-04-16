using Models;

namespace IRepositories
{
    public interface ArticleIRepository
    {
        /// <summary>
        /// GetAll Article.
        /// </summary>
        /// <returns>All articles.</returns>
        Task<List<Article>> GetAllArticleAsync();

        /// <summary>
        /// Get All article by Author sorted in ascending order.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>All article write by this Author.</returns>
        Task<List<Article>> GetAllArticleByAuthorsAscAsync(Guid id);


        /// <summary>
        /// Get All article by Author sorted in descending order.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>All article write by this Author.</returns>
        Task<List<Article>> GetAllArticleByAuthorsDescAsync(Guid id);


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
        Task CreateAsync(Article article);


        /// <summary>
        /// Delete an article.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);


        /// <summary>
        /// Update an article.
        /// </summary>
        /// <param name="article"></param>
        /// <returns>The article updated.</returns>
        Task <Article> UpdateAsync(Article article);
    }
}
