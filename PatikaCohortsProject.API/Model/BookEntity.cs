using PatikaCohortsProject.API.Base;
using PatikaCohortsProject.API.Enums;

namespace PatikaCohortsProject.API.Model
{
    public class BookEntity: BaseEntity
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public GenreEnum Genre { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
