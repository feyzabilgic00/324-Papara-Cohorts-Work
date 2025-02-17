﻿namespace PatikaCohortsProject.API.DTOs.Book
{
    public class GetByIdBookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }
        public decimal Price { get; set; }
        public string Genre { get; set; }
        public int Stock { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
