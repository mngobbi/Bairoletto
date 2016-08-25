namespace Data
{
    public class OrdenReposicionEventoConfirmacion : EventoPublicoBase
    {
        public override string Nombre
        {
            get
            {
                return "Orden de reposición confirmada";
            }
        }

        public OrdenReposicionEventoConfirmacion(OrdenReposicionEvento ev) : base(ev)
        {

        }

        public OrdenReposicionEventoConfirmacion(OrdenReposicion r, int usuario_id, string comentario = null) : base()
        {
            evento = new OrdenReposicionEvento(r, OrdenReposicionEventoTipo.confirmacion, usuario_id, comentario);
        }
    }
}
