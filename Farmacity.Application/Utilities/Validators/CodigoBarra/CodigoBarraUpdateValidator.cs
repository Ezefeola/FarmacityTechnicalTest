using Farmacity.Shared.DTOs.Request.CodigoBarra;
using FluentValidation;

namespace Farmacity.Application.Utilities.Validators.CodigoBarra;

public class CodigoBarraUpdateValidator : AbstractValidator<CodigoBarraUpdateRequestDto> 
{
    public CodigoBarraUpdateValidator()
    {
        RuleFor(x => x.Codigo)
            .NotEmpty().WithMessage("El campo {PropertyName} es requerido.")
            .MinimumLength(1).WithMessage("El campo {PropertyName} debe tener al menos 1 caracter.")
            .MaximumLength(250).WithMessage("El campo {PropertyName} no puede superar los 250 caracteres.");

        RuleFor(x => x.Activo)
            .NotNull().WithMessage("El campo {PropertyName} no puede ser nulo.");
    }
}
