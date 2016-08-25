using System;
using System.ComponentModel;

namespace Data
{
    public enum OrdenReposicionCancelacionCausa
    {
        [Description("Sin stock")]
        sin_stock = 1,

        [Description("Solicitud incorrecta")]
        solicitud_incorrecta = 3,

        [Description("Otro")]
        otro = 5

    }

    public class OrdenReposicionEventoCancelacion : EventoPublicoBase
    {
        public override string Nombre
        {
            get
            {
                return "Orden de reposición cancelada";
            }
        }

        public OrdenReposicionCancelacionCausa Causa
        {
            get
            {
                return (OrdenReposicionCancelacionCausa)Enum.Parse(typeof(OrdenReposicionCancelacionCausa), evento.IndexedString);
            }
        }

        public OrdenReposicionEventoCancelacion(OrdenReposicionEvento ev) : base(ev)
        {

        }

        public OrdenReposicionEventoCancelacion(OrdenReposicion r, OrdenReposicionCancelacionCausa causa, int usuario_id, string comentario = null) : base()
        {
            evento = new OrdenReposicionEvento(r, OrdenReposicionEventoTipo.cancelacion, usuario_id, comentario);
            evento.IndexedString = causa.ToString();
        }
    }
}
