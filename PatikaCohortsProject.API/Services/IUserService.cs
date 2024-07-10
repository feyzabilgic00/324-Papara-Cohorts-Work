using PatikaCohortsProject.API.Base;
using PatikaCohortsProject.API.Base.Services;
using PatikaCohortsProject.API.Model;

namespace PatikaCohortsProject.API.Services;

public interface IUserService : IGenericService<UserEntity>
{
    Task<bool> Login(string email, string password);
}
