using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public enum TipoProducto
    {
        comestible = 1,
        bebible = 3
    }

    [Table("Productos")]
    public class Producto
    {
        public Producto()
        {
            OrdenesReposicion = new HashSet<OrdenReposicionDetalle>();
            PuntosVenta = new HashSet<PuntoVentaProducto>();
        }

        public int Id { get; set; }

        [Required]
        public TipoProducto TipoProducto { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(30)]
        public string Codigo { get; set; }

        [MaxLength(255)]
        public string Descripcion { get; set; }

        [Required]
        public double PrecioCosto { get; set; }

        public string Foto { get; set; }

        public virtual ICollection<OrdenReposicionDetalle> OrdenesReposicion { get; set; }

        public virtual ICollection<PuntoVentaProducto> PuntosVenta { get; set; }
    }
}
