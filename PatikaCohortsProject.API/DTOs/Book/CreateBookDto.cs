using PatikaCohortsProject.API.Enums;

namespace PatikaCohortsProject.API.DTOs.Book;

public class CreateBookDto
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
