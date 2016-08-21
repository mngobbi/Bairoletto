using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public enum UsuarioRoles
    {

    }

    [Table("Usuarios")]
    public class Usuario
    {
        public Usuario() {
            Activo = true;
            FechaAlta = DateTime.UtcNow;
        }

        public int Id { get; set; }
        public int? PlantaElaboracionId { get; set; }
        public int? PuntoVentaId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(50)]
        public string NombreUsuario { get; set; }
        [MaxLength(30)]
        public string Password { get; set; }
        public UsuarioRoles Rol { get; set; }
        [MaxLength(50)]
        public string Puesto { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaAlta { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string Telefono { get; set; }
        [MaxLength(50)]
        public string Direccion { get; set; }
        [MaxLength(50)]
        public string Ciudad { get; set; }
        [MaxLength(20)]
        public string Provincia { get; set; }
        [MaxLength(20)]
        public string Pais { get; set; }
        public string Foto { get; set; }

        public virtual PuntoVenta PuntoVenta { get; set; }
        public virtual PlantaElaboracion PlantaElaboracion { get; set; }
    }
}
