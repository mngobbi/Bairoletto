namespace Data
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductosPv : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PuntosVentaProductos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PuntoVentaId = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                        Stock = c.Int(),
                        Precio = c.Single(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Productos", t => t.ProductoId, cascadeDelete: true)
                .ForeignKey("dbo.PuntosVenta", t => t.PuntoVentaId, cascadeDelete: true)
                .Index(t => t.PuntoVentaId)
                .Index(t => t.ProductoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PuntosVentaProductos", "PuntoVentaId", "dbo.PuntosVenta");
            DropForeignKey("dbo.PuntosVentaProductos", "ProductoId", "dbo.Productos");
            DropIndex("dbo.PuntosVentaProductos", new[] { "ProductoId" });
            DropIndex("dbo.PuntosVentaProductos", new[] { "PuntoVentaId" });
            DropTable("dbo.PuntosVentaProductos");
        }
    }
}
