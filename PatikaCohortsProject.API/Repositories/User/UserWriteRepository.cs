using PatikaCohortsProject.API.Base.Repositories;
using PatikaCohortsProject.API.Context;
using PatikaCohortsProject.API.Model;

namespace PatikaCohortsProject.API.Repositories.User;

public class UserWriteRepository : GenericWriteRepository<UserEntity>, IUserWriteRepository
{
    public UserWriteRepository(AppDbContext context) : base(context)
    {
    }
}
