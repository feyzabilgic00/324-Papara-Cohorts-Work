namespace PatikaCohortsProject.API.Base;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public string CreatedUser { get; set; } = "System";
    public DateTime CreatedDate{ get; set; }
    public string UpdatedUser { get; set; } = "System";
    public DateTime UpdatedDate { get; set; }
    public bool IsActive { get; set; }
}
