namespace Data
{
    public class UsuarioResumenDTO
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string nombre_usuario { get; set; }
        public string puesto { get; set; }
        public UsuarioRoles rol { get; set; }
        public bool activo { get; set; }

        public UsuarioResumenDTO() { }

        public UsuarioResumenDTO(Usuario usu)
        {
            id = usu.Id;
            nombre = usu.Nombre;
            nombre_usuario = usu.NombreUsuario;
            puesto = usu.Puesto;
            rol = usu.Rol;
            activo = usu.Activo;
        }
    }
}
