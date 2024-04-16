using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories.Contexts
{
    public class WIKI_API_PROJECTDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Topic> Topic { get; set; }

        public WIKI_API_PROJECTDbContext(DbContextOptions<WIKI_API_PROJECTDbContext> dbContextOptions) : base(dbContextOptions) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("WIKI_API_PROJECTDbContext");
                optionsBuilder.LogTo(Console.WriteLine);
            }
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //}
    }
}
