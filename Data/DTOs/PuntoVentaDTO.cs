using System;
using System.Linq;

namespace Data
{
    public class PuntoVentaResumenDTO
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public PuntoVentaTipo tipo { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string web_mail { get; set; }

        public PuntoVentaResumenDTO() { }

        public PuntoVentaResumenDTO(PuntoVenta pv)
        {
            id = pv.Id;
            codigo = pv.Codigo;
            tipo = pv.Tipo;
            nombre = pv.Nombre;
            direccion = pv.Direccion;
            telefono = pv.Telefono;
            web_mail = pv.WebMail;
        }
    }

    public class PuntoVentaDTO : PuntoVentaResumenDTO
    {
        public string descripcion { get; set; }
        public DateTime? fecha_alta { get; set; }
        public string ciudad { get; set; }
        public string provincia { get; set; }
        public string pais { get; set; }
        public ProductoPuntoVentaDTO[] productos { get; set; }

        public PuntoVentaDTO() {
            productos = new ProductoPuntoVentaDTO[] { };
        }

        public PuntoVentaDTO(PuntoVenta pv) : base (pv)
        {
            descripcion = pv.Descripcion;
            fecha_alta = pv.FechaAlta;
            ciudad = pv.Ciudad;
            provincia = pv.Provincia;
            pais = pv.Pais;
            productos = pv.Productos.Select(p => new ProductoPuntoVentaDTO(p, p.Producto)).ToArray();
        }
    }
}
