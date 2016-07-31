using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ReposicionResumenDTO
    {
        public int id { get; set; }
        public PuntoVentaResumenDTO punto_venta { get; set; }
        public int numero_orden { get; set; }
        public OrdenReposicionEstado estado { get; set; }
        public DateTime fecha_solicitud { get; set; }
        public DateTime? fecha_entrega { get; set; }
        public DateTime? fecha_entrega_estimada { get; set; }
        public DateTime? fecha_entrega_deseada { get; set; }
        public string comentario { get; set; }

        public ReposicionResumenDTO() { }

        public ReposicionResumenDTO(OrdenReposicion rep, PuntoVenta pv)
        {
            id = rep.Id;
            punto_venta = new PuntoVentaResumenDTO(pv);
            numero_orden = rep.Numero;
            estado = rep.Estado;
            fecha_solicitud = rep.FechaSolicitud;
            fecha_entrega = rep.FechaEntrega;
            fecha_entrega_estimada = rep.FechaEntegaEstimada;
            fecha_entrega_deseada = rep.FechaEntregaDeseada;
            comentario = rep.Comentario;
        }
    }

    public class ReposicionDTO : ReposicionResumenDTO
    {
        public ProductoReposicionDTO[] productos { get; set; }
        public CamionDTO camion_asignado { get; set; }

        public ReposicionDTO()
        {
            productos = new ProductoReposicionDTO[] { };
        }

        public ReposicionDTO(OrdenReposicion rep, PuntoVenta pv, OrdenReposicionDetalle[] prod, Camion cam) : base(rep, pv)
        {
            productos = prod.Select(x => new ProductoReposicionDTO(x, x.Producto)).ToArray();
            if (cam != null) camion_asignado = new CamionDTO(cam);
        }
    }
}
