using Farmacity.Shared.DTOs.Request.CodigoBarra;

namespace Farmacity.Shared.DTOs.Request.Producto;

public class ProductoCreateRequestDto
{
    public string Nombre { get; set; } = default!;
    public decimal Precio { get; set; }
    public int CantidadEnStock { get; set; }
    public bool Activo { get; set; }

    public List<CodigoBarraRequestDto>? CodigosBarraRequestDto { get; set; }
}
