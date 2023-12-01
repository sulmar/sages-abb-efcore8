using InheritanceTPH.Model;
using Microsoft.EntityFrameworkCore;

namespace InheritanceTPH.Infrastructure;

internal class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Attachment> Attachments { get; set; }

    public DbSet<Audio> Audios { get; set; }
    public DbSet<Video> Videos { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Attachment>()
            .HasDiscriminator<string>("ContentType")
            .HasValue<Audio>("audio/mpeg")
            .HasValue<Video>("video/mp4");
    }


}
