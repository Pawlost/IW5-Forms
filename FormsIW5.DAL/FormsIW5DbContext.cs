using FormsIW5.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FormsIW5.DAL;

public class FormsIW5DbContext(DbContextOptions<FormsIW5DbContext> options) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<QuestionEntity> Questions { get; set; }
    public DbSet<FormEntity> Forms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserEntity>()
            .HasMany(userEntity => userEntity.Forms)
            .WithOne(formEntity => formEntity.User)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<FormEntity>()
            .HasMany(formEntity => formEntity.Questions)
            .WithOne(questionEntity => questionEntity.Form)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
