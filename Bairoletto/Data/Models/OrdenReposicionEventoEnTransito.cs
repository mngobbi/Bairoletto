namespace Data.Models
{
    public class OrdenReposicionEventoEnTransito : EventoPublicoBase
    {
        public override string Nombre
        {
            get
            {
                return "Orden de reposición en tránsito";
            }
        }

        public OrdenReposicionEventoEnTransito(OrdenReposicionEvento ev) : base(ev)
        {

        }

        public OrdenReposicionEventoEnTransito(OrdenReposicion r, int usuario_id, string comentario = null) : base()
        {
            evento = new OrdenReposicionEvento(r, OrdenReposicionEventoTipo.en_transito, usuario_id, comentario);
        }
    }
}
