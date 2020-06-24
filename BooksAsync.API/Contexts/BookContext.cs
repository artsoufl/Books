using BooksAsync.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAsync.API.Contexts
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {

        }

        // seed database with data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    FirstName = "George",
                    LastName = "RR Martin"
                },
                new Author()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b46"),
                    FirstName = "Stephen",
                    LastName = "Fry"
                },
                new Author()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b57"),
                    FirstName = "James",
                    LastName = "Elroy"
                },
                new Author()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b68"),
                    FirstName = "Douglas",
                    LastName = "Adams"
                }
                );

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b11"),
                    AuthorId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Title = "The winds of winter",
                    Description = "The book that seems impossible to write"
                },
                new Book
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b22"),
                    AuthorId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Title = "A Game of Thrones",
                    Description = "It is a novel"
                },
                new Book
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b33"),
                    AuthorId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b46"),
                    Title = "Mythos",
                    Description = "The greek myths"
                },
                new Book
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b44"),
                    AuthorId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b57"),
                    Title = "American Tabloid",
                    Description = "Is a 1995 novel"
                },
                new Book
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b55"),
                    AuthorId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b68"),
                    Title = "The hitchhiker",
                    Description = "Is guide to the galaxy"
                }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
