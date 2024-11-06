namespace Farmacity.Domain.Models;

public class Producto : BaseModel
{
    public string Nombre { get; set; } = default!;
    public decimal Precio { get; set; }
    public int CantidadEnStock { get; set; }
    public bool Activo { get; set; }
    public DateTime FechaAlta { get; set; } = DateTime.Now;
    public DateTime? FechaModificacion { get; set; }

    public virtual List<CodigoBarra>? CodigosBarras { get; set; }
}
