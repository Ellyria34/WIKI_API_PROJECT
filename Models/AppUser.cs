using Microsoft.AspNetCore.Identity;

namespace Models
{
    public class AppUser : IdentityUser
    {
        public DateOnly AppUserBirthDay { get; set; }


        public List<Article>? Articles { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
