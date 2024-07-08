using System.Linq.Expressions;

namespace PatikaCohortsProject.API.Base.Repositories;

public interface IGenericWriteRepository<T>: IGenericRepository<T> where T : BaseEntity
{
    Task<bool> AddAsync(T entity);
    Task<bool> AddRangeAsync(List<T> entities);
    bool Remove(T entity);
    bool RemoveRange(List<T> entities);
    Task<bool> Remove(int id);
    Task Update(T entity);
    Task Save();
}
