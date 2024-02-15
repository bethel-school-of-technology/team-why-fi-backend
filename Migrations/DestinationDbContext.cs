using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Migrations;

public DestinationDbContext : DbContext
{
    public DbSet<Post> Post {get; set; }
    public Dbset<User> Users { get; set; }

    public DestinationDbContext(DbContextOptions<DestinationDbContext> options)
        : base(options)
        {
        }

        Protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
           base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.PostId);
            entity.Property(e => e.Message).IsRequired();
            entity.Property(e => e.PostTime).IsRequired();
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