using IRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Repositories.Contexts;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.Tests
{
    [TestClass()]
    public class ArticleRepositoryTests
    {
        //[TestMethod()]
        //public void CreateAsyncTest()
        //{
        //    //Arange
        //    //ArticleRepository articleRepository = new(new WIKI_API_PROJECTDbContext);
        //    var article = new Article
        //    {
        //        Title = "Titre",
        //        ArticleContent = "contenu de l'article",
        //        ArticleAuthor = "Auteur de l'article",
        //        ArticlePriority = (Priority)1,
        //        ArticleCreationDate = DateOnly.Parse("16 / 04 / 2024"),
        //        ArticleModificationDate = DateOnly.Parse("17 / 04 / 2024"),
        //    };

        //    //Act
            
        //    var createdArticle = ArticleIRepository.CreateAsync(article);

        //    //
        //    Assert.IsNotNull(createdArticle);
        //    Assert.Equals("Titre", createdArticle.Title);
        //    Assert.Equals("contenu de l'article", createdArticle.ArticleContent);
        //    Assert.Equals("Auteur de l'article", createdArticle.ArticleAuthor);
        //    Assert.Equals((Priority)1, createdArticle.ArticlePriority);
        //    Assert.Equals(DateOnly.Parse("16 / 04 / 2024"), createdArticle.ArticleCreationDate);
        //    Assert.Equals(DateOnly.Parse("17 / 04 / 2024"), createdArticle.ArticleModificationDate);
        //}
    }
}