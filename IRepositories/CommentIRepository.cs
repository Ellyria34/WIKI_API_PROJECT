using Models;

namespace IRepositories
{
    public interface CommentIRepository
    {
        /// <summary>
        /// Get All Comment.
        /// </summary>
        /// <returns>All comments.</returns>
        Task<List<Comment>> GetAllAsync();


        /// <summary>
        /// Get All Comment with their author.
        /// </summary>
        /// <returns>All Comments with their author</returns>
        Task<List<Comment>> GetAsyncAndAuthor();


        /// <summary>
        /// Get one comment.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The comment.</returns>
        Task<Comment> GetByIdAsync(int id);


        /// <summary>
        /// Create a new comment.
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        Task CreateAsync(Comment comment);


        /// <summary>
        /// Delete an comment.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);


        /// <summary>
        /// Update an comment.
        /// </summary>
        /// <param name="comment"></param>
        /// <returns>The comment updated.</returns>
        Task <Comment> UpdateAsync(Comment comment);
    }
}
