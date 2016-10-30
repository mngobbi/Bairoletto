using System;

namespace Data
{
    public class OrdenReposicionEventoAgenda: EventoPublicoBase
    {
        public override string Nombre
        {
            get
            {
                return "Próxima acción el " + evento.IndexedDateTime.Value.ToString("dd/MM/yyyy");
            }
        }

        public OrdenReposicionEventoAgenda(OrdenReposicionEvento ev): base(ev)
        {

        }

        public OrdenReposicionEventoAgenda(OrdenReposicion r, DateTime fecha_agenda, DateTime? fecha_actual, UsuarioDTO usuario, string comentario = null): base()
        {
            evento = new OrdenReposicionEvento(r, OrdenReposicionEventoTipo.agenda, usuario, comentario);
            evento.IndexedDateTime = fecha_agenda;
            evento.DateTime2 = fecha_actual;
        }
    }
}
