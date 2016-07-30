using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public enum CamionEstado
    {
        disponible = 1,
        no_disponible = 3
    }

    public class Camion
    {

        public Camion()
        {
            Estado = CamionEstado.disponible;
            OrdenesReposicion = new HashSet<OrdenReposicion>();
        }

        public int Id { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        public CamionEstado Estado { get; set; }

        public string Patente { get; set; }

        public double Capacidad { get; set; }

        [MaxLength(255)]
        public string Descripcion { get; set; }

        public virtual ICollection<OrdenReposicion> OrdenesReposicion { get; set; }
    }
}
