
namespace Models
{
    public class Topic
    {
        public int TopicId { get; set; }
        public required string TopicName { get; set; }

        public List<Article>? Articles { get; set; }
    }
}
