using PatikaCohortsProject.API.Base;

namespace PatikaCohortsProject.API.Model;

public class ProductEntity: BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}
