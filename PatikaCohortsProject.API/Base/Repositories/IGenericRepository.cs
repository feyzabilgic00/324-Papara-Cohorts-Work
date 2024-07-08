using Microsoft.EntityFrameworkCore;

namespace PatikaCohortsProject.API.Base.Repositories;

public interface IGenericRepository<T> where T : BaseEntity
{
    DbSet<T> Table {  get; }
}