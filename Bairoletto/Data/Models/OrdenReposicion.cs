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
            FechaSolicitud = DateTime.Now;
            Estado = OrdenReposicionEstado.nueva;
            Productos = new HashSet<OrdenReposicionDetalle>();
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

        public DateTime? FechaEntrega { get; set; }

        public DateTime? FechaEntregaDeseada { get; set; }

        public DateTime? FechaEntegaEstimada { get; set; }

        [MaxLength(255)]
        public string Comentario { get; set; }

        public virtual ICollection<OrdenReposicionDetalle> Productos { get; set; }

        public virtual PuntoVenta PuntoVenta { get; set; }

        public virtual PlantaElaboracion PlantaElaboracion { get; set; }

        public virtual Camion Camion { get; set; }
    }
}
