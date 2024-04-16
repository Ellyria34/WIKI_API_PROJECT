using Microsoft.AspNetCore.Identity;

namespace Models
{
    public class AppUser : IdentityUser
    {
        public int Age { get; set; }

        public List<Article>? Articles { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
