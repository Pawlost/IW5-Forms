using FormsIW5.Api.DAL.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace FormsIW5.Api.DAL;

public class FormsIW5DbContext(DbContextOptions<FormsIW5DbContext> options) : DbContext(options)
{
    public DbSet<QuestionEntity> Questions { get; set; } = null!;
    public DbSet<FormEntity> Forms { get; set; } = null!;
    public DbSet<AnswerEntity> Answers { get; set; } = null!;
    public DbSet<QuestionOptionEntity> QuestionOptions { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<FormEntity>()
            .HasMany(formEntity => formEntity.Questions)
            .WithOne(questionEntity => questionEntity.Form)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<QuestionEntity>()
            .HasMany(questionEntity => questionEntity.Answers)
            .WithOne(answerEntity => answerEntity.Question);
        
        modelBuilder.Entity<QuestionEntity>()
            .HasMany(questionEntity => questionEntity.AnswerSelections)
            .WithOne(answerEntity => answerEntity.Question);
    }
}
