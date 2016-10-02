namespace Data
{
    public class OrdenReposicionEventoComentario:EventoPublicoBase
    {
        public override string Nombre
        {
            get
            {
                return "Nuevo comentario";
            }
        }

        public OrdenReposicionEventoComentario(OrdenReposicionEvento ev): base(ev)
        {

        }

        public OrdenReposicionEventoComentario(OrdenReposicion r, UsuarioDTO usuario, string comentario): base()
        {
            evento = new OrdenReposicionEvento(r, OrdenReposicionEventoTipo.comentario, usuario, comentario);
        }
    }
}
