using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Topic
    {
        public int TopicId { get; set; }
        public required string TopicName { get; set; }

        public List<Article>? Articles { get; set; }
    }
}
