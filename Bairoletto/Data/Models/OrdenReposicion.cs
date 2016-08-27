using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{

    public enum OrdenReposicionEstado
    {
        nueva = 1,
        pendiente = 3,
        confirmada = 5,
        cancelada = 7,
        en_transito = 9,
        entregada = 11
    }

    [Table("OrdenesReposicion")]
    public class OrdenReposicion
    {
        public OrdenReposicion()
        {
            Numero = new Random().Next(99999999);
            FechaSolicitud = DateTime.UtcNow;
            Estado = OrdenReposicionEstado.nueva;
            Productos = new HashSet<OrdenReposicionDetalle>();
            Eventos = new HashSet<OrdenReposicionEvento>();
        }

        public int Id { get; set; }

        public int PuntoVentaId { get; set; }

        public int PlantaElaboracionId { get; set; }

        public int? CamionId { get; set; }

        [Required]
        [Index]
        public int Numero { get; set; }

        [Required]
        public OrdenReposicionEstado Estado { get; set; }

        [Required]
        public DateTime FechaSolicitud { get; set; }

        public DateTime? FechaProcesada { get; set; }

        public DateTime? FechaEntrega { get; set; }

        public DateTime? FechaEntregaDeseada { get; set; }

        public DateTime? FechaEntegaEstimada { get; set; }

        [MaxLength(255)]
        public string Comentario { get; set; }

        public virtual ICollection<OrdenReposicionEvento> Eventos { get; set; }

        public virtual ICollection<OrdenReposicionDetalle> Productos { get; set; }

        public virtual PuntoVenta PuntoVenta { get; set; }

        public virtual PlantaElaboracion PlantaElaboracion { get; set; }

        public virtual Camion Camion { get; set; }

        public IEnumerable<IEventoPublico> GetEventosPublicos()
        {
            var pubs = new List<IEventoPublico>();

            foreach (OrdenReposicionEvento ev in Eventos) {
                switch (ev.Tipo)
                {
                    case (int)OrdenReposicionEventoTipo.confirmacion:
                        pubs.Add(new OrdenReposicionEventoConfirmacion(ev));
                        break;
                    case (int)OrdenReposicionEventoTipo.en_transito:
                        pubs.Add(new OrdenReposicionEventoEnTransito(ev));
                        break;
                    case (int)OrdenReposicionEventoTipo.cancelacion:
                        pubs.Add(new OrdenReposicionEventoCancelacion(ev));
                        break;
                    case (int)OrdenReposicionEventoTipo.recepcion:
                        pubs.Add(new OrdenReposicionEventoRecepcion(ev));
                        break;
                }
            }
            return pubs;
        }
    }
}
