using System.Data.Entity;
using EFSample.Model;

namespace EFSample.DAL.SqlRepository
{
    public class SampleDBContext : DbContext
    {
        public SampleDBContext()
        {
        }

        public SampleDBContext(string conString)
            : base(conString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // due to a bug in EntityFramework we need to turn off cascade delete on comments
            // since it creates a circular dependency from user->post->comment->user
            modelBuilder.Entity<Comment>().HasRequired(x => x.User).WithMany().WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
