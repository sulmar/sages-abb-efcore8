// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using TableSplitting.Inftrastructure;
using TableSplitting.Model;

Console.WriteLine("Hello, Table Splitting!");

string connectionString = "Data Source=(local);Initial Catalog=TableSplittingDb;Integrated Security=True;TrustServerCertificate=True";

// Microsoft.EntityFrameworkCore.SqlServer
DbContextOptions dbContextOptions = new DbContextOptionsBuilder()
    .UseSqlServer(connectionString)
    .Options;

var context = new AppDbContext(dbContextOptions);

context.Database.EnsureCreated();

var query = context.Attachments.Select(a => new AttachmentInfo
{
    Id = a.Id,
    ContentType = a.ContentType,
    Description = a.Description,
    Title = a.Title,
});


var attachments = context.Attachments.ToList();



foreach (var attachment in attachments)
{
    Console.WriteLine(  attachment.Title);
}

var selectedAttachment = await context.Attachments
    .Include(p=>p.DetailedAttachment)
    .FirstAsync();

Console.WriteLine(selectedAttachment.DetailedAttachment.Content.Length);


for (int i = 0; i < 1000; i++)
{
    var attachment = new Attachment
    {
        Title = "Lorem",
       
        ContentType = "application/pdf",
        Description = "Lorem ipsum",
        DetailedAttachment = new DetailedAttachment
        {
            Filename = "file1.pdf",
            ContentType = "application/pdf",
            Content = Enumerable.Repeat((byte)1, 1_000_000).ToArray()
        }
       
    };

    await context.Attachments.AddAsync(attachment);
}

await context.SaveChangesAsync();

