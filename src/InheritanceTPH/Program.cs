// See https://aka.ms/new-console-template for more information
using InheritanceTPH.Infrastructure;
using InheritanceTPH.Model;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");


string connectionString = "Data Source=(local);Initial Catalog=InheritanceTPHDb;Integrated Security=True;TrustServerCertificate=True";

// Microsoft.EntityFrameworkCore.SqlServer
DbContextOptions dbContextOptions = new DbContextOptionsBuilder()
    .UseSqlServer(connectionString)
    .Options;

var context = new AppDbContext(dbContextOptions);

if (!context.Attachments.Any())
{
    context.Database.EnsureDeleted();
}


context.Database.EnsureCreated();

var myAttachments = context.Attachments.ToList();

var audios = context.Attachments.OfType<Audio>().ToList();

var attachments = new List<Attachment>
{
    new Audio  { Title = "audio 1", Description = "lorem", Bitrate = 200 },
    new Audio  { Title = "audio 2", Description = "lorem", Bitrate = 100 },
    new Audio  { Title = "audio 3", Description = "lorem", Bitrate = 48 },
    new Video  { Title = "video 1", Description = "lorem", Lenght = 120, Rating = "A"},
};

await context.Attachments.AddRangeAsync(attachments);

await context.SaveChangesAsync();