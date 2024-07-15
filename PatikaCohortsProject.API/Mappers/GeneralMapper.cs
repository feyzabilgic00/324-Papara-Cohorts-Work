using AutoMapper;
using PatikaCohortsProject.API.DTOs.Book;
using PatikaCohortsProject.API.Model;

namespace PatikaCohortsProject.API.Mappers;

public class GeneralMapper: Profile
{
    public GeneralMapper()
    {
        CreateMap<BookEntity, GetAllBooksDto>().ReverseMap();
        CreateMap<BookEntity, GetByIdBookDto>().ReverseMap();
        CreateMap<BookEntity, CreateBookDto>().ReverseMap();
        CreateMap<BookEntity, UpdateBookDto>().ReverseMap();
    }
}
