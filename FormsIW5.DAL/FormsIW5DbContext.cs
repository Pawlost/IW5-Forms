using Microsoft.EntityFrameworkCore;

namespace FormsIW5.DAL
{
    public class FormsIW5DbContext : DbContext
    {
        public FormsIW5DbContext(DbContextOptions<FormsIW5DbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
