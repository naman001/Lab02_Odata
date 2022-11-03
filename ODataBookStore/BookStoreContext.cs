using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ODataBookStore.Models;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace ODataBookStore
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Press> Presses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().OwnsOne(c => c.Location);
        }

        public static class DataSource
        {
            private static IList<Book> listBooks { get; set; }
            public static IList<Book> GetBooks()
            {
                if (listBooks != null)
                    return listBooks;
                listBooks = new List<Book>();
                Book book = new Book
                {
                    Id = 1,
                    ISBN = "978-0-321-87758-1",
                    Title = "Essential C#5.0",
                    Author = "Mark Michaelis",
                    Price = 59.99m,
                    Location = new Address
                    {
                        City = "HCM City",
                        Street = "D2, Thu Duc District"
                    },
                    Press = new Press
                    {
                        Id = 1,
                        Name = "Addison-Wesley",
                        Category = Category.Book
                    }
                };
                listBooks.Add(book);
                
                book = new Book
                {
                    Id = 2,
                    ISBN = "978-0-321-87758-1",
                    Title = "Essential C#5.0",
                    Author = "Conan Dolce",
                    Price = 56.89m,
                    Location = new Address
                    {
                        City = "HCM City",
                        Street = "D2, 5 District"
                    },
                    Press = new Press
                    {
                        Id = 2,
                        Name = "Still aint knows the name",
                        Category = Category.Book
                    }
                };
                listBooks.Add(book);

                book = new Book
                {
                    Id = 3,
                    ISBN = "978-0-321-87758-1",
                    Title = "Essential C#5.0",
                    Author = "No Name",
                    Price = 79.99m,
                    Location = new Address
                    {
                        City = "HaNoi City",
                        Street = "D2, Hoang Kiem District"
                    },
                    Press = new Press
                    {
                        Id = 3,
                        Name = "Aint knows the name",
                        Category = Category.Book
                    }
                };
                listBooks.Add(book);

                return listBooks;
            }
        }
    }
}
