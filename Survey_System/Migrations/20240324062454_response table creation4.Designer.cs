﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Survey_System.Data;

#nullable disable

namespace Survey_System.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240324062454_response table creation4")]
    partial class responsetablecreation4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Survey_System.Model.Option", b =>
                {
                    b.Property<int>("OptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("OptionId"));

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("OptionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("Survey_System.Model.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("QuestionId"));

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("surveysSurveyId")
                        .HasColumnType("int");

                    b.HasKey("QuestionId");

                    b.HasIndex("surveysSurveyId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Survey_System.Model.Response", b =>
                {
                    b.Property<int>("ResponseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ResponseId"));

                    b.Property<string>("Answers")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("QuestionsQuestionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SubmittedAt")
                        .HasColumnType("datetime");

                    b.Property<int>("UsersSurveyUserID")
                        .HasColumnType("int");

                    b.Property<int>("surveysSurveyId")
                        .HasColumnType("int");

                    b.HasKey("ResponseId");

                    b.HasIndex("QuestionsQuestionId");

                    b.HasIndex("UsersSurveyUserID");

                    b.HasIndex("surveysSurveyId");

                    b.ToTable("Responses");
                });

            modelBuilder.Entity("Survey_System.Model.Survey", b =>
                {
                    b.Property<int>("SurveyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("SurveyId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("SurveyId");

                    b.ToTable("Surveys");
                });

            modelBuilder.Entity("Survey_System.Model.SurveyUser", b =>
                {
                    b.Property<int>("SurveyUserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("SurveyUserID"));

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("UserEmail")
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("SurveyUserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Survey_System.Model.Option", b =>
                {
                    b.HasOne("Survey_System.Model.Question", "Question")
                        .WithMany("Options")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Survey_System.Model.Question", b =>
                {
                    b.HasOne("Survey_System.Model.Survey", "surveys")
                        .WithMany("Questions")
                        .HasForeignKey("surveysSurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("surveys");
                });

            modelBuilder.Entity("Survey_System.Model.Response", b =>
                {
                    b.HasOne("Survey_System.Model.Question", "Questions")
                        .WithMany()
                        .HasForeignKey("QuestionsQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Survey_System.Model.SurveyUser", "Users")
                        .WithMany("Responses")
                        .HasForeignKey("UsersSurveyUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Survey_System.Model.Survey", "surveys")
                        .WithMany("Responses")
                        .HasForeignKey("surveysSurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Questions");

                    b.Navigation("Users");

                    b.Navigation("surveys");
                });

            modelBuilder.Entity("Survey_System.Model.Question", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("Survey_System.Model.Survey", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("Responses");
                });

            modelBuilder.Entity("Survey_System.Model.SurveyUser", b =>
                {
                    b.Navigation("Responses");
                });
#pragma warning restore 612, 618
        }
    }
}
