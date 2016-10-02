using System;

namespace Data
{
    public interface IEventoPublico
    {
        string Tipo { get; }
        string Nombre { get; }
        string Descripcion { get; }
        DateTime Fecha { get; }
        UsuarioDTO Usuario { get; }
    }

    public abstract class EventoPublicoBase : IEventoPublico
    {
        public EventoPublicoBase() { }

        public EventoPublicoBase(Evento ev)
        {
            evento = ev;
        }

        protected Evento evento;

        public abstract string Nombre { get; }
        public virtual string Descripcion
        {
            get { return evento.Descripcion; }
        }
        public string Tipo {
            get { return evento.GetTipoStr(); }
        }
        public virtual DateTime Fecha
        {
            get { return evento.Fecha; }
        }
        public virtual UsuarioDTO Usuario
        {
            get { return evento.Usuario; }
        }

        public Evento GetEvento()
        {
            return evento;
        } 
    }
}
