using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Data
{
    public class CategoryDbContext : DbContext
    {
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Item>? Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(
                    @"Data Source = GEORGE-PC\SQLEXPRESS2019; Initial Catalog = Category; Integrated Security = True;")
                .LogTo(Console.WriteLine, new[] {DbLoggerCategory.Database.Command.Name}, LogLevel.Information)
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(m => m.Items)
                .WithOne(m => m.Category)
                .HasForeignKey(m => m.CategoryId) // En caso de que se haya declarado con otro nombre
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}