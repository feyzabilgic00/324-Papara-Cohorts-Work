using PatikaCohortsProject.API.Base;
using PatikaCohortsProject.API.Base.Repositories;
using PatikaCohortsProject.API.Base.Services;
using PatikaCohortsProject.API.Model;

namespace PatikaCohortsProject.API.Services;

public class UserService : GenericService<UserEntity>, IUserService
{
    private readonly IGenericReadRepository<UserEntity> _readRepository;
    public UserService(IGenericReadRepository<UserEntity> readRepository, IGenericWriteRepository<UserEntity> writeRepository) : base(readRepository, writeRepository)
    {
        _readRepository = readRepository;
    }

    public async Task<bool> Login(string email, string password)
    {
        var user = await _readRepository.GetSingleAsync(x => x.Email == email && x.Password == password);
        return user is not null;
    }
}
