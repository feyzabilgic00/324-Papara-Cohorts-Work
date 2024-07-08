using Microsoft.EntityFrameworkCore;
using PatikaCohortsProject.API.Base.Repositories;

namespace PatikaCohortsProject.API.Base.Services;

public class GenericService<T> : IGenericService<T> where T : BaseEntity
{
    private readonly IGenericReadRepository<T> _readRepository;
    private readonly IGenericWriteRepository<T> _writeRepository;
    public GenericService(IGenericReadRepository<T> readRepository, IGenericWriteRepository<T> writeRepository)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
    }
    public async Task<T> CreateAsync(T entity)
    {
        await _writeRepository.AddAsync(entity);
        await _writeRepository.Save();
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        await _writeRepository.Remove(id);
        await _writeRepository.Save();
        return true;
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _readRepository.GetAll().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _readRepository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(T entity)
    {
        await _writeRepository.Update(entity);
        await _writeRepository.Save();
    }
}
