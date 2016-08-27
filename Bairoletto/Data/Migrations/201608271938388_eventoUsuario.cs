namespace Data
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventoUsuario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrdenReposicionEventos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrdenReposicionId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Tipo = c.Int(nullable: false),
                        Descripcion = c.String(),
                        IndexedString = c.String(),
                        String2 = c.String(),
                        IndexedDateTime = c.DateTime(),
                        DateTime2 = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrdenesReposicion", t => t.OrdenReposicionId, cascadeDelete: true)
                .Index(t => t.OrdenReposicionId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlantaElaboracionId = c.Int(),
                        PuntoVentaId = c.Int(),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        NombreUsuario = c.String(nullable: false, maxLength: 50),
                        Password = c.String(maxLength: 30),
                        Rol = c.Int(nullable: false),
                        Puesto = c.String(maxLength: 50),
                        Activo = c.Boolean(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 50),
                        Telefono = c.String(maxLength: 50),
                        Direccion = c.String(maxLength: 50),
                        Ciudad = c.String(maxLength: 50),
                        Provincia = c.String(maxLength: 20),
                        Pais = c.String(maxLength: 20),
                        Foto = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PlantasElaboracion", t => t.PlantaElaboracionId)
                .ForeignKey("dbo.PuntosVenta", t => t.PuntoVentaId)
                .Index(t => t.PlantaElaboracionId)
                .Index(t => t.PuntoVentaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "PuntoVentaId", "dbo.PuntosVenta");
            DropForeignKey("dbo.Usuarios", "PlantaElaboracionId", "dbo.PlantasElaboracion");
            DropForeignKey("dbo.OrdenReposicionEventos", "OrdenReposicionId", "dbo.OrdenesReposicion");
            DropIndex("dbo.Usuarios", new[] { "PuntoVentaId" });
            DropIndex("dbo.Usuarios", new[] { "PlantaElaboracionId" });
            DropIndex("dbo.OrdenReposicionEventos", new[] { "OrdenReposicionId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.OrdenReposicionEventos");
        }
    }
}
