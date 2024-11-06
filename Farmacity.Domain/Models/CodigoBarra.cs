namespace Farmacity.Domain.Models;

public class CodigoBarra : BaseModel
{
    public int ProductoId { get; set; }
    public string Codigo { get; set; } = default!;
    public bool Activo { get; set; }
    public DateTime FechaAlta { get; set; } = DateTime.Now;
    public DateTime? FechaModificacion { get; set; }

    public virtual Producto? Producto { get; set; }
}
