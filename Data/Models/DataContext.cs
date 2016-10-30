using System.Data.Entity;

namespace Data
{
    public partial class DataContext : DbContext
    {
        public DataContext() : base("name=BairolettoAppDB")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<DataContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Configuration>("BairolettoAppDB"));
        }

        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<PlantaElaboracion> PlantasElaboracion { get; set; }
        public virtual DbSet<PuntoVenta> PuntosVenta { get; set; }
        public virtual DbSet<OrdenReposicion> OrdenesReposicion { get; set; }
        public virtual DbSet<OrdenReposicionEvento> OrdenesReposicionEventos { get; set; }
        public virtual DbSet<OrdenReposicionDetalle> OrdenesReposicionDetalle { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<PuntoVentaProducto> PuntosVentaProductos { get; set; }
        public virtual DbSet<Camion> Camiones { get; set; }
    }
}
