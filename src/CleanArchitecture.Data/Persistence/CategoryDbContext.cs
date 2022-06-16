using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class CategoryDbContext : DbContext
    {
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Item>? Items { get; set; }

        public CategoryDbContext(DbContextOptions<CategoryDbContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder
        //        .UseSqlServer(
        //            @"Data Source = GEORGE-PC\SQLEXPRESS2019; Initial Catalog = Category; Integrated Security = True;")
        //        .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
        //        .EnableSensitiveDataLogging();
        //}

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedAt = DateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
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