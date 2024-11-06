using Farmacity.Shared.DTOs.Request.Producto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacity.Application.Utilities.Validators.Producto
{
    public class ProductoCreateValidator : AbstractValidator<ProductoCreateRequestDto>
    {
        public ProductoCreateValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El campo {PropertyName} es requerido");

            RuleFor(x => x.CantidadEnStock)
                .GreaterThanOrEqualTo(0).WithMessage("El campo {PropertyName} no puede tener valores negativos, debe ser mayor o igual a 0.");

            RuleFor(x => x.Precio)
            .NotEmpty().WithMessage("Debe colocar un {PropertyName}")
            .GreaterThan(0).WithMessage("El {PropertyName} debe ser mayor que 0.");

            RuleFor(x => x.Activo)
                .NotEmpty().WithMessage("El campo {PropertyName} es requerido");
        }
    }
}
