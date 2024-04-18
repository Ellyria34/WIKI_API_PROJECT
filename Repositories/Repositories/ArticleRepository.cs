using DTOs;
using IRepositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Models;
using Repositories.Contexts;
using System.Data;

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


        public async Task DeleteArticleAsync(Article article)
        {
            var nbRow = await _context.Articles.Where(a => a.ArticleId == article.ArticleId).ExecuteDeleteAsync();
            
        }


        public async Task<List<GetAllArticleDTO>> GetAllArticleAsync()
        {
            var articles = await _context.Articles.Include(a => a.Topic)
                .Include(a => a.ArticleAuthor)
                .Select(a => new GetAllArticleDTO
                {
                    Id = a.ArticleId,
                    Title = a.Title,
                    AuthorName = a.ArticleAuthor.UserName,
                    ArticleCreationDate = a.ArticleCreationDate,
                    TopicName = a.Topic.TopicName
                })
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

        public async Task<Article> GetArticleByIdAsync(int id)
        {
            Article article = await _context.Articles.FindAsync(id);
            if (article != null)
            {
                return article;
            }
            throw new ArgumentException();
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

        public async Task<UpdateArticleDTO> UpdateArticleAsync(UpdateArticleDTO article)
        {
            var nbRow = await _context.Articles
                .Where(a => a.ArticleId == article.id).ExecuteUpdateAsync (
                updates => updates
                    .SetProperty(a => a.Title, article.Title)
                    .SetProperty(a => a.ArticleContent, article.ArticleContent)
                    .SetProperty(a => a.TopicId, article.TopicId));

            if (nbRow > 0)
                return article;
            else throw new Exception(); 
        }
    }

}
