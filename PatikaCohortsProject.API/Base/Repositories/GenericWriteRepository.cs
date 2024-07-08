using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PatikaCohortsProject.API.Context;

namespace PatikaCohortsProject.API.Base.Repositories;

public class GenericWriteRepository<T> : IGenericWriteRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _context;
    public GenericWriteRepository(AppDbContext context)
    {
        _context = context;
    }
    public DbSet<T> Table => _context.Set<T>();

    public async Task<bool> AddAsync(T entity)
    {
       EntityEntry<T> entityEntry = await Table.AddAsync(entity);
       return entityEntry.State == EntityState.Added;
    }

    public async Task<bool> AddRangeAsync(List<T> entities)
    {
        await Table.AddRangeAsync(entities);
        return true;
    }

    public bool Remove(T entity)
    {
        EntityEntry<T> entityEntry = Table.Remove(entity);
        return entityEntry.State == EntityState.Deleted;
    }

    public async Task<bool> Remove(int id)
    {
        T entity = await Table.FirstOrDefaultAsync(data => data.Id == id);
         return Remove(entity);
    }

    public bool RemoveRange(List<T> entities)
    {
        Table.RemoveRange(entities);
        return true;
    }
    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }

    public async Task Update(T entity)
    {
       Table.Update(entity);
    }
}
