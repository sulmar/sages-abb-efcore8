using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Sakila.Domain.Abstractions;
using Sakila.Domain.Model;
using Sakila.Intrastructure;

namespace Sakila.Infrastructure;


public class DbEntityRepository<T>(SakilaContext context) : IEntityRepository<T>
    where T : BaseEntity, new()
{
    public async Task AddAsync(T item)
    {
        context.ChangeTracker.TrackGraph(item, node =>
        {
            if (node.Entry.IsKeySet)
            {
                node.Entry.State = EntityState.Unchanged;
            }
            else
            {
                node.Entry.State = EntityState.Added;
            }
        });
   
        await context.Set<T>().AddAsync(item);

        Console.WriteLine(context.ChangeTracker.DebugView.LongView);

        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await context.Set<T>().AsNoTracking().ToListAsync();
    }

    public ValueTask<T?> GetAsync(int id)
    {
        return context.Set<T>().FindAsync(id);
    }

    public async Task RemoveAsync(int id)
    {
        //T item = new T();

        //var entityType = context.Model.FindEntityType(typeof(T));

        //var key = entityType.FindPrimaryKey();

        //var columnNames = key.Properties.Select(p=>p.GetColumnName()).ToList();

        //var name = columnNames.First();

        //context.Entry(item).Property(name).CurrentValue = id;

        var item = await GetAsync(id);

        context.Remove(item);

   
    }
}
