namespace Data
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Camiones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                        Estado = c.Int(nullable: false),
                        Patente = c.String(),
                        Capacidad = c.Double(nullable: false),
                        Descripcion = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrdenesReposicion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PuntoVentaId = c.Int(nullable: false),
                        PlantaElaboracionId = c.Int(nullable: false),
                        CamionId = c.Int(),
                        Numero = c.Int(nullable: false),
                        Estado = c.Int(nullable: false),
                        FechaSolicitud = c.DateTime(nullable: false),
                        FechaEntrega = c.DateTime(nullable: false),
                        FechaEntregaDeseada = c.DateTime(),
                        FechaEntegaEstimada = c.DateTime(),
                        Comentario = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Camiones", t => t.CamionId)
                .ForeignKey("dbo.PlantasElaboracion", t => t.PlantaElaboracionId, cascadeDelete: true)
                .ForeignKey("dbo.PuntosVenta", t => t.PuntoVentaId, cascadeDelete: true)
                .Index(t => t.PuntoVentaId)
                .Index(t => t.PlantaElaboracionId)
                .Index(t => t.CamionId)
                .Index(t => t.Numero);
            
            CreateTable(
                "dbo.PlantasElaboracion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 15),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        FechaAlta = c.DateTime(),
                        Direccion = c.String(maxLength: 100),
                        Telefono = c.String(maxLength: 50),
                        WebMail = c.String(maxLength: 50),
                        Ciudad = c.String(maxLength: 50),
                        Provincia = c.String(maxLength: 20),
                        Pais = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PuntosVenta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlantaElaboracionId = c.Int(),
                        Codigo = c.String(nullable: false, maxLength: 15),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Tipo = c.Int(nullable: false),
                        Descripcion = c.String(maxLength: 255),
                        FechaAlta = c.DateTime(),
                        Direccion = c.String(maxLength: 100),
                        Telefono = c.String(maxLength: 50),
                        WebMail = c.String(maxLength: 50),
                        Ciudad = c.String(maxLength: 50),
                        Provincia = c.String(maxLength: 20),
                        Pais = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PlantasElaboracion", t => t.PlantaElaboracionId)
                .Index(t => t.PlantaElaboracionId);
            
            CreateTable(
                "dbo.OrdenesReposicionDetalle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrdenReposicionId = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                        CantidadSolicitada = c.Int(nullable: false),
                        PrecioUnitario = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrdenesReposicion", t => t.OrdenReposicionId, cascadeDelete: true)
                .ForeignKey("dbo.Productos", t => t.ProductoId, cascadeDelete: true)
                .Index(t => t.OrdenReposicionId)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TipoProducto = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Codigo = c.String(nullable: false, maxLength: 30),
                        Descripcion = c.String(maxLength: 255),
                        PrecioCosto = c.Single(nullable: false),
                        Foto = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrdenesReposicionDetalle", "ProductoId", "dbo.Productos");
            DropForeignKey("dbo.OrdenesReposicionDetalle", "OrdenReposicionId", "dbo.OrdenesReposicion");
            DropForeignKey("dbo.PuntosVenta", "PlantaElaboracionId", "dbo.PlantasElaboracion");
            DropForeignKey("dbo.OrdenesReposicion", "PuntoVentaId", "dbo.PuntosVenta");
            DropForeignKey("dbo.OrdenesReposicion", "PlantaElaboracionId", "dbo.PlantasElaboracion");
            DropForeignKey("dbo.OrdenesReposicion", "CamionId", "dbo.Camiones");
            DropIndex("dbo.OrdenesReposicionDetalle", new[] { "ProductoId" });
            DropIndex("dbo.OrdenesReposicionDetalle", new[] { "OrdenReposicionId" });
            DropIndex("dbo.PuntosVenta", new[] { "PlantaElaboracionId" });
            DropIndex("dbo.OrdenesReposicion", new[] { "Numero" });
            DropIndex("dbo.OrdenesReposicion", new[] { "CamionId" });
            DropIndex("dbo.OrdenesReposicion", new[] { "PlantaElaboracionId" });
            DropIndex("dbo.OrdenesReposicion", new[] { "PuntoVentaId" });
            DropTable("dbo.Productos");
            DropTable("dbo.OrdenesReposicionDetalle");
            DropTable("dbo.PuntosVenta");
            DropTable("dbo.PlantasElaboracion");
            DropTable("dbo.OrdenesReposicion");
            DropTable("dbo.Camiones");
        }
    }
}
