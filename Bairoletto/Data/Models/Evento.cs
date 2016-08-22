using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class Evento
    {
        private DataContext db = new DataContext();

        public int Id { get; set; }
        public int UsuarioId { get; set; }

        public DateTime Fecha { get; set; }
        public int Tipo { get; set; }
        public abstract string GetTipoStr(); 

        public string Descripcion { get; set; }
        public string IndexedString { get; set; }
        public string String2 { get; set; }
        public DateTime? IndexedDateTime { get; set; }
        public DateTime? DateTime2 { get; set; }

        [NotMapped]
        public Usuario Usuario
        {
            get { return db.Usuarios.Find(UsuarioId); }
        }

    }
}
