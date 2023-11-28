﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Library.Data;

#nullable disable

namespace WorkoutApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231122124113_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WorkoutApp.Models.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BlogId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BlogId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("WorkoutApp.Models.ExercisesAPI", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Difficulty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "difficulty");

                    b.Property<string>("Equipment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "equipment");

                    b.Property<string>("Instructions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "instructions");

                    b.Property<string>("Muscle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "muscle");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "type");

                    b.Property<int>("WorkoutId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkoutId");

                    b.ToTable("ExercisesAPIs");
                });

            modelBuilder.Entity("WorkoutApp.Models.Nutrition", b =>
                {
                    b.Property<float>("Calories")
                        .HasColumnType("real")
                        .HasAnnotation("Relational:JsonPropertyName", "calories");

                    b.Property<float>("CarbohydratesPerGram")
                        .HasColumnType("real")
                        .HasAnnotation("Relational:JsonPropertyName", "carbohydrates_total_g");

                    b.Property<float>("Cholesterol")
                        .HasColumnType("real")
                        .HasAnnotation("Relational:JsonPropertyName", "cholesterol_mg");

                    b.Property<float>("FatTotalGram")
                        .HasColumnType("real")
                        .HasAnnotation("Relational:JsonPropertyName", "fat_total_g");

                    b.Property<float>("FiberPerGram")
                        .HasColumnType("real")
                        .HasAnnotation("Relational:JsonPropertyName", "fiber_g");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.Property<float>("PotassiumMilligram")
                        .HasColumnType("real")
                        .HasAnnotation("Relational:JsonPropertyName", "potassium_mg");

                    b.Property<float>("ProteinGram")
                        .HasColumnType("real")
                        .HasAnnotation("Relational:JsonPropertyName", "protein_g");

                    b.Property<float>("SaturatedGram")
                        .HasColumnType("real")
                        .HasAnnotation("Relational:JsonPropertyName", "fat_saturated_g");

                    b.Property<float>("ServingSizePerGram")
                        .HasColumnType("real")
                        .HasAnnotation("Relational:JsonPropertyName", "serving_size_g");

                    b.Property<float>("SodiumMilligram")
                        .HasColumnType("real")
                        .HasAnnotation("Relational:JsonPropertyName", "sodium_mg");

                    b.Property<float>("Sugar")
                        .HasColumnType("real")
                        .HasAnnotation("Relational:JsonPropertyName", "sugar_g");

                    b.ToTable("Nutritions");
                });

            modelBuilder.Entity("WorkoutApp.Models.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Week")
                        .HasColumnType("int");

                    b.Property<int>("WeekDay")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("WorkoutApp.Models.UrlResource", b =>
                {
                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("UrlResources");
                });

            modelBuilder.Entity("WorkoutApp.Models.Workout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ScheduleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Workouts");
                });

            modelBuilder.Entity("WorkoutApp.Models.ExercisesAPI", b =>
                {
                    b.HasOne("WorkoutApp.Models.Workout", "Workout")
                        .WithMany("ExercisesAPIs")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("WorkoutApp.Models.Workout", b =>
                {
                    b.HasOne("WorkoutApp.Models.Schedule", null)
                        .WithMany("Workouts")
                        .HasForeignKey("ScheduleId");
                });

            modelBuilder.Entity("WorkoutApp.Models.Schedule", b =>
                {
                    b.Navigation("Workouts");
                });

            modelBuilder.Entity("WorkoutApp.Models.Workout", b =>
                {
                    b.Navigation("ExercisesAPIs");
                });
#pragma warning restore 612, 618
        }
    }
}
