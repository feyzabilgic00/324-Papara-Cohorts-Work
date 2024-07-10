using PatikaCohortsProject.API.Base;
using PatikaCohortsProject.API.Enums;

namespace PatikaCohortsProject.API.Model;

public class UserEntity: BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int Age { get; set; }
    public GenderEnum Gender { get; set; }
}
