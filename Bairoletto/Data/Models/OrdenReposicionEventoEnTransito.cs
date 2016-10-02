namespace Data
{
    public class OrdenReposicionEventoEnTransito : EventoPublicoBase
    {
        public override string Nombre
        {
            get
            {
                return "Orden de reposición en tránsito. Camión de entrega número " + evento.IndexedString;
            }
        }

        public OrdenReposicionEventoEnTransito(OrdenReposicionEvento ev) : base(ev)
        {

        }

        public OrdenReposicionEventoEnTransito(OrdenReposicion r, int camion, UsuarioDTO usuario, string comentario = null) : base()
        {
            evento = new OrdenReposicionEvento(r, OrdenReposicionEventoTipo.en_transito, usuario, comentario);
            evento.IndexedString = camion.ToString();
        }
    }
}
