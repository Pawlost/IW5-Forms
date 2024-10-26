using FormsIW5.Api.DAL.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace FormsIW5.Api.DAL;

public class FormsIW5DbContext(DbContextOptions<FormsIW5DbContext> options) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<QuestionEntity> Questions { get; set; }
    public DbSet<FormEntity> Forms { get; set; }
    public DbSet<AnswerEntity> Answers { get; set; }
    public DbSet<AnswerSelectionEntity> AnswersSelection { get; set; }


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

        modelBuilder.Entity<QuestionEntity>()
            .HasMany(questionEntity => questionEntity.Answers)
            .WithOne(answerEntity => answerEntity.Question);
        
        modelBuilder.Entity<QuestionEntity>()
            .HasMany(questionEntity => questionEntity.AnswerSelections)
            .WithOne(answerEntity => answerEntity.Question);

        modelBuilder.Entity<AnswerSelectionEntity>()
            .HasMany(answerSelection => answerSelection.Answers)
            .WithOne(answerEntity => answerEntity.SelectedAnswer)
            .HasForeignKey(answerEntity => answerEntity.SelectedAnswerId);
    }
}
