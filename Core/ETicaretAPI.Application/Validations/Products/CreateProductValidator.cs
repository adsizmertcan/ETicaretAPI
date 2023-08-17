using ETicaretAPI.Application.ViewModels.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validations.Products
{
    public class CreateProductValidator : AbstractValidator<ProductCreateVM>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull().WithMessage("Lütfen Ürün Adını Boş Geçmeyiniz.")
                .MaximumLength(150).MinimumLength(3).WithMessage("Lütfen Ürün Adını 3 ile 150 Karakter Arasında Giriniz");

            RuleFor(p => p.Stock).NotEmpty().NotNull().WithMessage("Lütfen Stok Bilgisini Boş Girmeyiniz")
                .Must(s => s >= 0)
                .WithMessage("Stok Bilgisi Negatif Olamaz");

            RuleFor(p => p.Price).NotEmpty().NotNull().WithMessage("Lütfen Fiyat Bilgisini Boş Girmeyiniz")
                .Must(s => s >= 0)
                .WithMessage("Fiyat Bilgisi Negatif Olamaz");
        }
    }
}
