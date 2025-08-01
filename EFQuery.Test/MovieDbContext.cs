using Microsoft.EntityFrameworkCore;

namespace Seamas.EFQuery.Test;

public class MovieDbContext : DbContext
{
    public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        {
            var builder = modelBuilder.Entity<Movie>();
            builder.HasKey(item => item.Id);
            builder.HasIndex(item => item.Url).IsUnique();
            
            builder.Property<int>(item => item.Id).ValueGeneratedOnAdd();
            builder.Property<string>(item => item.Title).HasMaxLength(128).IsUnicode();
            builder.Property<string>(item => item.Url).HasMaxLength(256);
            
            builder.ToTable("Movies"); 
        }
        base.OnModelCreating(modelBuilder);
    }
}