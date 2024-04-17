using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using Models;

namespace DTOs
{
    public class CreateArticleDTO
    {
        public string Title { get; set; }

        public string? ArticleContent { get; set; }

        public int TopicId { get; set; }
    }
}
