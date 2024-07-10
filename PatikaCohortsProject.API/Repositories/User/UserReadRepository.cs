using PatikaCohortsProject.API.Base.Repositories;
using PatikaCohortsProject.API.Context;
using PatikaCohortsProject.API.Model;

namespace PatikaCohortsProject.API.Repositories.User;

public class UserReadRepository : GenericReadRepository<UserEntity>, IUserReadRepository
{
    public UserReadRepository(AppDbContext context) : base(context)
    {
    }
}
