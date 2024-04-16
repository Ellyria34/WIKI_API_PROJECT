using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        [MaxLength(100)]
        public string CommentText { get; set; } = string.Empty;

        //public string CommentAuthor { get; set; }

        public DateOnly CommentCreationDate { get; set; }

        public DateOnly CommentModificationDate { get; set; }

        [ForeignKey(name:"AppUser")]
        public string CommentAuthorId { get; set; }
        public AppUser CommentAuthor { get; set; }

        public int ArticleId { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public Article Article { get; set; }
    }
}
