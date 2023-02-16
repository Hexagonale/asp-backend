﻿// <auto-generated />
using System;
using Api.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("Api.Database.Comment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("authorid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("content")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("created")
                        .HasColumnType("TEXT");

                    b.Property<int>("postId")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("authorid");

                    b.ToTable("forum_comments");
                });

            modelBuilder.Entity("Api.Database.Like", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("authorid")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("created")
                        .HasColumnType("TEXT");

                    b.Property<int?>("postid")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("authorid");

                    b.HasIndex("postid");

                    b.ToTable("forum_likes");
                });

            modelBuilder.Entity("Api.Database.Post", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("authorid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("content")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("created")
                        .HasColumnType("TEXT");

                    b.Property<string>("title")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("authorid");

                    b.ToTable("forum_posts");
                });

            modelBuilder.Entity("Api.Database.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("password")
                        .HasColumnType("TEXT");

                    b.Property<string>("username")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("forum_users");

                    b.HasData(
                        new
                        {
                            id = 1,
                            isAdmin = true,
                            password = "admin",
                            username = "admin"
                        },
                        new
                        {
                            id = 2,
                            isAdmin = false,
                            password = "user",
                            username = "user"
                        });
                });

            modelBuilder.Entity("Api.Database.Comment", b =>
                {
                    b.HasOne("Api.Database.User", "author")
                        .WithMany()
                        .HasForeignKey("authorid");

                    b.Navigation("author");
                });

            modelBuilder.Entity("Api.Database.Like", b =>
                {
                    b.HasOne("Api.Database.User", "author")
                        .WithMany()
                        .HasForeignKey("authorid");

                    b.HasOne("Api.Database.Post", "post")
                        .WithMany()
                        .HasForeignKey("postid");

                    b.Navigation("author");

                    b.Navigation("post");
                });

            modelBuilder.Entity("Api.Database.Post", b =>
                {
                    b.HasOne("Api.Database.User", "author")
                        .WithMany()
                        .HasForeignKey("authorid");

                    b.Navigation("author");
                });
#pragma warning restore 612, 618
        }
    }
}
