using FluentValidation;
using PatikaCohortsProject.API.Model;

namespace PatikaCohortsProject.API.Validators;

public class ProductValidator: AbstractValidator<ProductEntity>
{
    public ProductValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Ürün adı boş geçilemez!")
            .MinimumLength(3)
            .MaximumLength(50)
            .WithMessage("Ürün adı minimum 3 karakter olmalıdır!")
            .WithMessage("Ürün adı maksimum 50 karakter olmalıdır!");
        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Ürün açıklaması boş geçilemez!")
            .MinimumLength(3)
            .MaximumLength(500)
            .WithMessage("Ürün açıklaması minimum 3 karakter olmalıdır!")
            .WithMessage("Ürün adı maksimum 500 karakter olmalıdır!");
        RuleFor(x => x.Price)
            .NotEmpty()
            .WithMessage("Fiyat bilgisi boş geçilemez!")
            .GreaterThan(0)
            .WithMessage("Fiyat bilgisi sıfırdan farklı olmalıdır!");
        RuleFor(x => x.Stock)
            .NotEmpty()
            .WithMessage("Stok bilgisi boş geçilemez!")
            .GreaterThan(0)
            .WithMessage("Stok sıfırdan farklı olmalıdır!");
    }
}
