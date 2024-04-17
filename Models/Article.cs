using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Models
{
    public class Article
    {
        public int ArticleId { get; set; }

        [Length(10, 50, ErrorMessage ="Le titre doit comporter entre 10 et 50 caractères.")]
        public string Title { get; set; }

        public string? ArticleContent { get; set; }

        //public required string ArticleAuthor { get; set; }

        public DateOnly ArticleCreationDate { get; set; }

        public DateOnly ArticleModificationDate { get; set; }

        public Priority ArticlePriority { get; set; }

        [ForeignKey(name: "AppUser")]
        public string ArticleAuthorId { get; set; }
        public AppUser ArticleAuthor { get; set; }

        public int TopicId { get; set; }

        [DefaultValue("DefaultTopic")]
        public Topic Topic { get; set; }

        public List<Comment>? Comments { get; set; }
    }
}
