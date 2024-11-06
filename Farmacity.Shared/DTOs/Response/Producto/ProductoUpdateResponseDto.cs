using Farmacity.Shared.DTOs.Response.CodigoBarra;

namespace Farmacity.Shared.DTOs.Response.Producto;

public class ProductoUpdateResponseDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = default!;
    public decimal Precio { get; set; }
    public int CantidadEnStock { get; set; }
    public bool Activo { get; set; }
    public DateTime FechaAlta { get; set; }
    public DateTime? FechaModificacion { get; set; }

    public virtual List<CodigoBarraResponseDto>? CodigoBarraResponseDto { get; set; }
}
