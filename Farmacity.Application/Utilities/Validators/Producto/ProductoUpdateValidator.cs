using Farmacity.Shared.DTOs.Request.Producto;
using FluentValidation;

namespace Farmacity.Application.Utilities.Validators.Producto;

public class ProductoUpdateValidator : AbstractValidator<ProductoUpdateRequestDto>
{
    public ProductoUpdateValidator()
    {
        RuleFor(x => x.Nombre)
            .NotEmpty().WithMessage("El campo {PropertyName} es requerido.")
            .MinimumLength(1).WithMessage("El campo {PropertyName} debe tener al menos 1 caracter.")
            .MaximumLength(250).WithMessage("El campo {PropertyName} no puede superar los 250 caracteres.");

        RuleFor(x => x.Activo)
            .NotNull().WithMessage("El campo {PropertyName} no puede ser nulo.");
    }
}
