﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Repository.Database;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(GamificationContext))]
    [Migration("20230324162922_init10")]
    partial class init10
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Repository.Models.Database.Student", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("InsertDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Ra")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("ShowNameOnRanking")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Ra")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Repository.Models.Database.Subject", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("InsertDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("StudentId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Repository.Models.Database.Teacher", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("InsertDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasIndex("UserId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Repository.Models.Database.User.ApplicationUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("InsertDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("Type")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Email", "Password")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Repository.Models.Database.Student", b =>
                {
                    b.HasOne("Repository.Models.Database.User.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Repository.Models.Database.Subject", b =>
                {
                    b.HasOne("Repository.Models.Database.Student", null)
                        .WithMany("Subjects")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("Repository.Models.Database.Teacher", b =>
                {
                    b.HasOne("Repository.Models.Database.User.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Repository.Models.Database.Student", b =>
                {
                    b.Navigation("Subjects");
                });
#pragma warning restore 612, 618
        }
    }
}
