using Farmacity.Shared.DTOs.Request.CodigoBarra;

namespace Farmacity.Shared.DTOs.Request.Producto;

public class ProductoUpdateRequestDto
{
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public int CantidadEnStock { get; set; }
    public bool Activo { get; set; }
    public DateTime FechaModificacion { get; set; } = DateTime.UtcNow;
    public List<CodigoBarraRequestDto>? CodigoBarraRequestDto { get; set; }
}
