using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public enum OrdenReposicionEventoTipo
    {
        confirmacion = 1,
        cancelacion = 3,
        agenda = 5,
        en_transito = 7,
        recepcion = 9,
        comentario = 11
    }

    [Table("OrdenReposicionEventos")]
    public class OrdenReposicionEvento: Evento
    {
        public int OrdenReposicionId { get; set; }
        public virtual OrdenReposicion OrdenReposicion { get; set; }

        public OrdenReposicionEvento()
        {
            Fecha = DateTime.UtcNow;
        }

        public OrdenReposicionEvento(Evento ev, OrdenReposicion r )
        {
            this.Id = ev.Id;
            this.OrdenReposicion = r;
            this.Fecha = ev.Fecha;
            this.Descripcion = ev.Descripcion;
            this.Tipo = ev.Tipo;
            this.UsuarioId = ev.UsuarioId;
            this.UsuarioNombre = ev.UsuarioNombre;
            this.IndexedDateTime = ev.IndexedDateTime;
            this.IndexedString = ev.IndexedString;
            this.DateTime2 = ev.DateTime2;
            this.String2 = ev.String2;
        }

        public OrdenReposicionEvento(OrdenReposicion r, OrdenReposicionEventoTipo tipo_evento, UsuarioDTO usu, string comentario = null) : this()
        {
            Tipo = (int)tipo_evento;
            OrdenReposicion = r;
            UsuarioId = usu.id;
            UsuarioNombre = usu.nombre_usuario;

            if (comentario != null) Descripcion = comentario;
        }

        public override string GetTipoStr()
        {
            return Enum.ToObject(typeof(OrdenReposicionEventoTipo), Tipo).ToString();
        }

    }
}
