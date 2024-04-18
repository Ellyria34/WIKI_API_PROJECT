using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class UpdateArticleDTO
    {
        public int id {  get; set; }
        public string Title { get; set; }
        public string? ArticleContent { get; set; }
        public int TopicId { get; set; }
    }
}
