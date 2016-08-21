using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public enum OrdenReposicionEventoTipo
    {

    }

    public class OrdenReposicionEvento: Evento
    {
        public int OrdenReposicionId { get; set; }
        public virtual OrdenReposicion OrdenReposicion { get; set; }

        public OrdenReposicionEvento()
        {
            Fecha = DateTime.UtcNow;
        }

        public OrdenReposicionEvento(OrdenReposicion r, OrdenReposicionEventoTipo tipo_evento, int usuario_id, string comentario = null) : this()
        {
            OrdenReposicionId = r.Id;
            OrdenReposicion = r;
            UsuarioId = usuario_id;

            if (comentario != null) Descripcion = comentario;
        }

    }
}
