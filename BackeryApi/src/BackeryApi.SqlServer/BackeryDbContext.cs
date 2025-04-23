using BackeryApi.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace BackeryApi.SqlServer;

public class BackeryDbContext(DbContextOptions<BackeryDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Article> Articles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>()
            .Property(typeof(long), "Id")
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<Article>()
            .HasKey("Id");
        modelBuilder.Entity<Article>()
            .Property(typeof(long), "CategoryId")
            .IsRequired();
        
        modelBuilder.Entity<Category>()
            .Property(typeof(long), "Id")
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<Category>()
            .HasKey("Id");
        modelBuilder.Entity<Category>()
            .HasMany(e => e.Articles)
            .WithOne()
            .HasForeignKey("CategoryId");
    }
}