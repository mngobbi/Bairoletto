using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    [Table("OrdenesReposicionDetalle")]
    public class OrdenReposicionDetalle
    {
        public int Id { get; set; }

        public int OrdenReposicionId { get; set; }

        public int ProductoId { get; set; }

        [Required]
        public int CantidadSolicitada { get; set; }

        [Required]
        public double PrecioUnitario { get; set; }

        public virtual OrdenReposicion OrdenReposicion { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
