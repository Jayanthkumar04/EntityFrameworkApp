﻿using EntityFrameworkApp.Model;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkApp.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().HasData(
                new Currency() { Id = 1, Title = "INR", Description = "Indian INR" },
                new Currency() { Id = 2, Title = "Dollar", Description = "Dollar" },
                new Currency() { Id = 3, Title = "Euro", Description = "Euro" },
                new Currency() { Id = 4, Title = "Dinar", Description = "Dinar" }
                );

            modelBuilder.Entity<Language>().HasData(
               new Language() { Id = 1, Title = "Hindi", Description = "Hindi" },
               new Language() { Id = 2, Title = "Tamil", Description = "Tamil" },
               new Language() { Id = 3, Title = "Punjabi", Description = "Punjabi" },
               new Language() { Id = 4, Title = "Urdu", Description = "Urdu" }
               );
        }

        public DbSet<Book> Book { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<BookPrice> BookPrice { get; set; }

        public DbSet<Currency> Currency { get; set; }

        public DbSet<Author> Authors { get; set; }
    }
}
