using FluentValidation;
using PatikaCohortsProject.API.DTOs.Book;
using PatikaCohortsProject.API.Model;

namespace PatikaCohortsProject.API.Validators.BookOperations;

public class UpdateBookDtoValidator: AbstractValidator<UpdateBookDto>
{
    public UpdateBookDtoValidator()
    {
        RuleFor(x => x.Price)
            .NotEmpty().GreaterThan(0); 
        RuleFor(x => x.Stock)
            .NotEmpty().GreaterThan(0);
    }
}
