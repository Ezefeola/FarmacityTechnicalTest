namespace Farmacity.Shared.DTOs.Request.CodigoBarra;

public class CodigoBarraUpdateRequestDto
{
    public string Codigo { get; set; } = default!;
    public bool Activo { get; set; }
}
