namespace Farmacity.Shared.DTOs.Response.CodigoBarra;

public class CodigoBarraResponseDto
{
    public int ProductoId { get; set; }
    public string Codigo { get; set; } = default!;
    public bool Activo { get; set; }
    public DateTime FechaAlta { get; set; }
    public DateTime? FechaModificacion { get; set; }
}
