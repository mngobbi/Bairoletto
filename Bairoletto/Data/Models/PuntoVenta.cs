using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public enum PuntoVentaTipo
    {
        sucursal = 1,
        franquicia = 3,
        mayorista = 5
    }

    [Table("PuntosVenta")]
    public class PuntoVenta
    {
        public PuntoVenta()
        {
            OrdenesReposicion = new HashSet<OrdenReposicion>();
            Productos = new HashSet<PuntoVentaProducto>();
        }

        public int Id { get; set; }

        public int? PlantaElaboracionId { get; set; }

        [Required]
        [MaxLength(15)]
        public string Codigo { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required]
        public PuntoVentaTipo Tipo { get; set; }

        [MaxLength(255)]
        public string Descripcion { get; set; }

        public DateTime? FechaAlta { get; set; }

        [MaxLength(100)]
        public string Direccion { get; set; }

        [MaxLength(50)]
        public string Telefono { get; set; }

        [MaxLength(50)]
        public string WebMail { get; set; }

        [MaxLength(50)]
        public string Ciudad { get; set; }

        [MaxLength(20)]
        public string Provincia { get; set; }

        [MaxLength(20)]
        public string Pais { get; set; }

        public virtual ICollection<OrdenReposicion> OrdenesReposicion { get; set; }

        public virtual ICollection<PuntoVentaProducto> Productos { get; set; }

        public virtual PlantaElaboracion PlantaElaboracion { get; set; }
    }
}
