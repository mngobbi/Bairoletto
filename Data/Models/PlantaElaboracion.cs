using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    [Table("PlantasElaboracion")]
    public class PlantaElaboracion
    {

        public PlantaElaboracion()
        {
            PuntosVenta = new HashSet<PuntoVenta>();
            OrdenesReposicion = new HashSet<OrdenReposicion>();
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string Codigo { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

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

        public virtual ICollection<PuntoVenta> PuntosVenta { get; set; }

        public virtual ICollection<OrdenReposicion> OrdenesReposicion { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
