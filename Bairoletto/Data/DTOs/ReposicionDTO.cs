using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Data
{
    public class ReposicionResumenDTO
    {
        public int id { get; set; }
        public PuntoVentaResumenDTO punto_venta { get; set; }
        public int numero_orden { get; set; }
        public OrdenReposicionEstado estado { get; set; }
        public DateTime fecha_solicitud { get; set; }
        public DateTime? fecha_procesada { get; set; }
        public DateTime? fecha_entrega { get; set; }
        public DateTime? fecha_entrega_estimada { get; set; }
        public DateTime? fecha_entrega_deseada { get; set; }
        public string comentario { get; set; }

        public ReposicionResumenDTO() { }

        public ReposicionResumenDTO(OrdenReposicion rep)
        {
            id = rep.Id;
            numero_orden = rep.Numero;
            estado = rep.Estado;
            fecha_solicitud = rep.FechaSolicitud;
            fecha_procesada = rep.FechaProcesada;
            fecha_entrega = rep.FechaEntrega;
            fecha_entrega_estimada = rep.FechaEntegaEstimada;
            fecha_entrega_deseada = rep.FechaEntregaDeseada;
            comentario = rep.Comentario;
        }

        public ReposicionResumenDTO(OrdenReposicion rep, PuntoVenta pv) : this(rep)
        {
            punto_venta = new PuntoVentaResumenDTO(pv);
        }
    }

    public class ReposicionDTO : ReposicionResumenDTO
    {
        public ProductoReposicionDTO[] productos { get; set; }
        public CamionDTO camion_asignado { get; set; }
        public EventoDTO[] eventos { get; set; }

        public ReposicionDTO()
        {
            productos = new ProductoReposicionDTO[] { };
            eventos = new EventoDTO[] { };
        }

        public ReposicionDTO(OrdenReposicion rep, PuntoVenta pv, IEnumerable<OrdenReposicionDetalle> prod, Camion cam) : base(rep, pv)
        {
            productos = prod.Select(x => new ProductoReposicionDTO(x, x.Producto)).ToArray();
            eventos = rep.GetEventosPublicos().Select(x => new EventoDTO(x)).ToArray();
            if (cam != null) camion_asignado = new CamionDTO(cam);
        }
    }

    public class ReposicionNuevaDTO
    {
        [Required]
        public int planta_elaboracion_id { get; set; }

        [Required]
        public int punto_venta_id { get; set; }

        public DateTime? fecha_entrega_deseada { get; set; }

        [MaxLength(255)]
        public string comentario { get; set; }

        [Required]
        public ProductoReposicionNuevoDTO[] productos { get; set; }
    }

    public class ReposicionAprobarDTO
    {
        [Required]
        public int reposicion_id { get; set; }

        public DateTime? fecha_entrega_estimada { get; set; }

        public string comentario { get; set; }
    }

    public class ReposicionRechazarDTO
    {
        [Required]
        public int reposicion_id { get; set; }

        [Required]
        public OrdenReposicionCancelacionCausa causa { get; set; }

        public string comentario { get; set; }
    }

    public class ReposicionAgendarDTO
    {
        [Required]
        public int reposicion_id { get; set; }

        [Required]
        public DateTime fecha_agenda { get; set; }

        public string comentario { get; set; }
    }

    public class ReposicionEnviarDTO
    {
        [Required]
        public int reposicion_id { get; set; }

        [Required]
        public int camion_id { get; set; }

        public string comentario;
    }

    public class ReposicionComentarioDTO
    {
        [Required]
        public int reposicion_id { get; set; }

        public string comentario { get; set; }
    }
}
