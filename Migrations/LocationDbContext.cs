using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Migrations;

public class LocationDbContext : DbContext
{
    public DbSet<Post> Post { get; set; }
    public DbSet<User> Users { get; set; }

    public LocationDbContext(DbContextOptions<LocationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.PostId);
            entity.Property(e => e.Message).IsRequired();
        });


        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId);
            entity.Property(e => e.FirstName);
            entity.Property(e => e.LastName);
            entity.Property(e => e.Username).IsRequired();
            entity.HasIndex(x => x.Username).IsUnique();
            entity.Property(e => e.Password).IsRequired();
        });
    }
}