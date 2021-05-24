using BookStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Data
{
    public class AppContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        public static AppContext shared = new AppContext();
        private AppContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = LibraryDB3");
        }
    }
}
