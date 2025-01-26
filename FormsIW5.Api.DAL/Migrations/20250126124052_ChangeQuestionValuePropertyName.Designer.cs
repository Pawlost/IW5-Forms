﻿// <auto-generated />
using System;
using FormsIW5.Api.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FormsIW5.Api.DAL.Migrations
{
    [DbContext(typeof(FormsIW5DbContext))]
    [Migration("20250126124052_ChangeQuestionValuePropertyName")]
    partial class ChangeQuestionValuePropertyName
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FormsIW5.Api.DAL.Common.Entities.AnswerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("IntegerAnswer")
                        .HasColumnType("int");

                    b.Property<string>("OwnerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("QuestionOptionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TextAnswer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("FormsIW5.Api.DAL.Common.Entities.FormEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("FormEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FormName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FormStartDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("bit");

                    b.Property<string>("OwnerId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Forms");
                });

            modelBuilder.Entity("FormsIW5.Api.DAL.Common.Entities.QuestionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FormId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MaxValue")
                        .HasColumnType("int");

                    b.Property<int>("MinValue")
                        .HasColumnType("int");

                    b.Property<string>("OwnerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuestionText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("FormsIW5.Api.DAL.Common.Entities.QuestionOptionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OwnerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("QuestionOptionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuestionOptions");
                });

            modelBuilder.Entity("FormsIW5.Api.DAL.Common.Entities.AnswerEntity", b =>
                {
                    b.HasOne("FormsIW5.Api.DAL.Common.Entities.QuestionEntity", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("FormsIW5.Api.DAL.Common.Entities.QuestionEntity", b =>
                {
                    b.HasOne("FormsIW5.Api.DAL.Common.Entities.FormEntity", "Form")
                        .WithMany("Questions")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Form");
                });

            modelBuilder.Entity("FormsIW5.Api.DAL.Common.Entities.QuestionOptionEntity", b =>
                {
                    b.HasOne("FormsIW5.Api.DAL.Common.Entities.QuestionEntity", "Question")
                        .WithMany("QuestionOptions")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("FormsIW5.Api.DAL.Common.Entities.FormEntity", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("FormsIW5.Api.DAL.Common.Entities.QuestionEntity", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("QuestionOptions");
                });
#pragma warning restore 612, 618
        }
    }
}
