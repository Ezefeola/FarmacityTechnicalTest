namespace Farmacity.Shared.DTOs.Response.CodigoBarra;

public class CodigoBarraUpdateResponseDto
{
    public int ProductoId { get; set; }
    public string Codigo { get; set; } = default!;
    public bool Activo { get; set; }
    public DateTime FechaAlta { get; set; }
    public DateTime? FechaModificacion { get; set; }
}
