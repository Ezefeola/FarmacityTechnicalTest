namespace Farmacity.Shared.DTOs.Request.CodigoBarra;

public class CodigoBarraCreateRequestDto
{
    public string Codigo { get; set; } = default!;
    public bool Activo { get; set; }
}
