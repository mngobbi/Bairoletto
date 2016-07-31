using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    [Table("PuntosVentaProductos")]
    public class PuntoVentaProducto
    {
        public int Id { get; set; }

        public int PuntoVentaId { get; set; }

        public int ProductoId { get; set; }

        public int? Stock { get; set; }

        public float? Precio { get; set; }

        public virtual PuntoVenta PuntoVenta { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
