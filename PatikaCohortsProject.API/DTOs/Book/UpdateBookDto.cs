using PatikaCohortsProject.API.Enums;

namespace PatikaCohortsProject.API.DTOs.Book
{
    public class UpdateBookDto
    {
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
