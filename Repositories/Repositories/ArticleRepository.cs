using DTOs;
using IRepositories;
using Microsoft.EntityFrameworkCore;
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
        public async Task CreateAsync(Article article, AppUser appUser)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }
            else
            {
                article.ArticleCreationDate = DateOnly.FromDateTime(DateTime.UtcNow);
                article.ArticleAuthor = appUser;
                article.ArticleAuthorId = appUser.Id;


                await _context.Articles.AddAsync(article);
                await _context.SaveChangesAsync();
            }
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
         
        public async Task<List<GetAllArticleDTO>> GetAllArticleAsync()
        {
            var articles= await _context.Articles.Include(a=>a.Topic)
                .Include(a=>a.ArticleAuthor)
                .Select(a=>new GetAllArticleDTO { 
                    Title = a.Title, 
                    AuthorName= a.ArticleAuthor.UserName, 
                    ArticleCreationDate = a.ArticleCreationDate, 
                    TopicName = a.Topic.TopicName})
                .ToListAsync();
            return articles;
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
