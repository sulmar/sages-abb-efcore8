using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableSplitting.Model;

namespace TableSplitting.Inftrastructure;

internal class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Attachment> Attachments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<DetailedAttachment>(
            da =>
            {
                da.ToTable("Attachments");
                da.Property(p => p.ContentType).HasColumnName(nameof(Attachment.ContentType));
            });

        modelBuilder.Entity<Attachment>(
            a =>
            {
                a.ToTable("Attachments");
                a.Property(p => p.ContentType).HasColumnName(nameof(Attachment.ContentType));

                a.HasOne(da => da.DetailedAttachment).WithOne()
                    .HasForeignKey<DetailedAttachment>(fk => fk.Id);

               // a.Navigation(da => da.DetailedAttachment).IsRequired();
            }
            );

    }
}
