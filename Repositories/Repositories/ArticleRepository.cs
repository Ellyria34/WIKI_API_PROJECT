using IRepositories;
using Models;
using Repositories.Contexts;

namespace Repositories.Repositories
{
    public class ArticleRepository : ArticleIRepository
    {
        private readonly WIKI_API_PROJECTDbContext _context;
        public ArticleRepository(WIKI_API_PROJECTDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Create a new article
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task CreateAsync(Article article, int AppUserId)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }
            else
            {
                article.ArticleCreationDate = DateOnly.FromDateTime(DateTime.UtcNow);
                _context.Articles.AddAsync(article);
                await _context.SaveChangesAsync();
            }
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Article>> GetAllArticleAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Article>> GetAllArticleByAuthorsAscAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Article>> GetAllArticleByAuthorsDescAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Article> GetArticleByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Article>> GetArticlesByTopicAscAsync(string topicName)
        {
            throw new NotImplementedException();
        }

        public Task<List<Article>> GetArticlesByTopicDescAsync(string topicName)
        {
            throw new NotImplementedException();
        }

        public Task<Article> GetByIdAndAllCommentsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Article> UpdateAsync(Article article)
        {
            throw new NotImplementedException();
        }
    }
}
