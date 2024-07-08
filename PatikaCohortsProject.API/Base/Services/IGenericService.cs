namespace PatikaCohortsProject.API.Base.Services;

public interface IGenericService<T>
{
    Task<T> CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task<bool> DeleteAsync(int id);
    Task<T> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
}
