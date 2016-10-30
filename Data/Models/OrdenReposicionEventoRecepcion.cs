using System;

namespace Data
{
    public class OrdenReposicionEventoRecepcion : EventoPublicoBase
    {
        public override string Nombre
        {
            get
            {
                return "Orden de reposición entregada el día " + evento.IndexedDateTime.Value.ToLocalTime().ToString("dd/MM/yyyy HH:mm");
            }
        }

        public OrdenReposicionEventoRecepcion(OrdenReposicionEvento ev) : base (ev)
        {

        }

        public OrdenReposicionEventoRecepcion(OrdenReposicion r, DateTime? fecha, UsuarioDTO usuario, string comentario = null) : base()
        {
            evento = new OrdenReposicionEvento(r, OrdenReposicionEventoTipo.recepcion, usuario, comentario);
            evento.IndexedDateTime = fecha;
        }

    }
}
