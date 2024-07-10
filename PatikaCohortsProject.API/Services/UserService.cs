using PatikaCohortsProject.API.Base.Repositories;
using PatikaCohortsProject.API.Base.Services;
using PatikaCohortsProject.API.Model;

namespace PatikaCohortsProject.API.Services;

public class UserService : GenericService<UserEntity>, IUserService
{
    public UserService(IGenericReadRepository<UserEntity> readRepository, IGenericWriteRepository<UserEntity> writeRepository) : base(readRepository, writeRepository)
    {
    }
}
