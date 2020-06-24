﻿// <auto-generated />
using System;
using BooksAsync.API.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BooksAsync.API.Migrations
{
    [DbContext(typeof(BookContext))]
    [Migration("20200624083715_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BooksAsync.API.Entities.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("Author");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            FirstName = "George",
                            LastName = "RR Martin"
                        },
                        new
                        {
                            Id = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b46"),
                            FirstName = "Stephen",
                            LastName = "Fry"
                        },
                        new
                        {
                            Id = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b57"),
                            FirstName = "James",
                            LastName = "Elroy"
                        },
                        new
                        {
                            Id = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b68"),
                            FirstName = "Douglas",
                            LastName = "Adams"
                        });
                });

            modelBuilder.Entity("BooksAsync.API.Entities.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(2500)")
                        .HasMaxLength(2500);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b11"),
                            AuthorId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            Description = "The book that seems impossible to write",
                            Title = "The winds of winter"
                        },
                        new
                        {
                            Id = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b22"),
                            AuthorId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            Description = "It is a novel",
                            Title = "A Game of Thrones"
                        },
                        new
                        {
                            Id = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b33"),
                            AuthorId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b46"),
                            Description = "The greek myths",
                            Title = "Mythos"
                        },
                        new
                        {
                            Id = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b44"),
                            AuthorId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b57"),
                            Description = "Is a 1995 novel",
                            Title = "American Tabloid"
                        },
                        new
                        {
                            Id = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b55"),
                            AuthorId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b68"),
                            Description = "Is guide to the galaxy",
                            Title = "The hitchhiker"
                        });
                });

            modelBuilder.Entity("BooksAsync.API.Entities.Book", b =>
                {
                    b.HasOne("BooksAsync.API.Entities.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
