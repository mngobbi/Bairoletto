namespace Data
{
    public class UsuarioDTO
    {
        public string id { get; set; }
        public string nombre_usuario { get; set; }

        public UsuarioDTO() { }

        public UsuarioDTO(string id, string nombre)
        {
            this.id = id;
            this.nombre_usuario = nombre;
        }
    }

}
