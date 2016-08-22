using System;

namespace Data
{
    public enum OrdenReposicionEventoTipo
    {
        confirmacion = 1,
        cancelacion = 3,
        agenda = 5,
        en_transito = 7,
        recepcion = 9
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
            Tipo = Convert.ToInt32(tipo_evento);
            OrdenReposicionId = r.Id;
            OrdenReposicion = r;
            UsuarioId = usuario_id;

            if (comentario != null) Descripcion = comentario;
        }

        public override string GetTipoStr()
        {
            return Enum.ToObject(typeof(OrdenReposicionEventoTipo), Tipo).ToString();
        }

    }
}
