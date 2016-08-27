using System;

namespace Data
{
    public class EventoDTO
    {
        public DateTime fecha { get; set; }
        public string descripcion { get; set; }
        public string nombre { get; set; }
        public string tipo { get; set; }
        public UsuarioResumenDTO usuario { get; set; }

        public EventoDTO() { }

        public EventoDTO(IEventoPublico ep) 
        {
            fecha = ep.Fecha;
            descripcion = ep.Descripcion;
            nombre = ep.Nombre;
            tipo = ep.Tipo;
            if (ep.Usuario != null) usuario = new UsuarioResumenDTO(ep.Usuario);
        }
    }

}
