using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public abstract class Evento
    {
        private DataContext db = new DataContext();

        public int Id { get; set; }
        public string UsuarioId { get; set; }
        public string UsuarioNombre { get; set; }

        public DateTime Fecha { get; set; }
        public int Tipo { get; set; }
        public abstract string GetTipoStr(); 

        public string Descripcion { get; set; }
        public string IndexedString { get; set; }
        public string String2 { get; set; }
        public DateTime? IndexedDateTime { get; set; }
        public DateTime? DateTime2 { get; set; }

        [NotMapped]
        public UsuarioDTO Usuario
        {
            get { return new UsuarioDTO(UsuarioId, UsuarioNombre); }
        }
    }
}
