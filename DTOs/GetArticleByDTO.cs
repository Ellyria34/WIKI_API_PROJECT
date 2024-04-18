using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class GetArticleByDTO
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string? ArticleContent { get; set; }
        public int TopicId { get; set; }
        public DateOnly ArticleCreationDate { get; set; }
        public DateOnly ArticleModificationDate { get; set; }
    }
}
