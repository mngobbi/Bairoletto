using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class ProductoResumenDTO
    {
        public int id { get; set; }
        public TipoProducto tipo { get; set; }
        public string nombre { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public double precio_costo { get; set; }
        public string foto { get; set; }

        public ProductoResumenDTO() { }

        public ProductoResumenDTO(Producto p)
        {
            id = p.Id;
            tipo = p.TipoProducto;
            nombre = p.Nombre;
            codigo = p.Codigo;
            descripcion = p.Descripcion;
            precio_costo = p.PrecioCosto;
            foto = p.Foto;
        }
    }

    public class ProductoDTO : ProductoResumenDTO
    {
        public int? stock { get; set; }

        public ProductoDTO() { }

        public ProductoDTO(Producto p) : base(p)
        {
            stock = p.Stock;
        }
    }

    public class ProductoPuntoVentaDTO
    {
        public int id { get; set; }
        public ProductoResumenDTO producto { get; set; }
        public int? stock { get; set; }
        public double? precio { get; set; }

        public ProductoPuntoVentaDTO() { }

        public ProductoPuntoVentaDTO(PuntoVentaProducto pvp, Producto p)
        {
            id = pvp.Id;
            producto = new ProductoResumenDTO(p);
            stock = pvp.Stock;
            precio = pvp.Precio;
        }
    }

    public class ProductoReposicionDTO
    {
        public int id { get; set; }
        public ProductoResumenDTO producto { get; set; }
        public int cantidad_solicitada { get; set; }
        public double precio_unitario { get; set; }

        public ProductoReposicionDTO() { }

        public ProductoReposicionDTO(OrdenReposicionDetalle pr, Producto p)
        {
            id = pr.Id;
            producto = new ProductoResumenDTO(p);
            cantidad_solicitada = pr.CantidadSolicitada;
            precio_unitario = pr.PrecioUnitario;
        }
    }

    public class ProductoReposicionNuevoDTO
    {
        [Required]
        public int producto_id { get; set; }
        
        [Required]
        public int cantidad_solicitada { get; set; }

        [Required]
        public double precio_unitario { get; set; }
    }
}
