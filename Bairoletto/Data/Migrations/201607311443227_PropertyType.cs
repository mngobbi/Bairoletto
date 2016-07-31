namespace Data
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropertyType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PuntosVentaProductos", "Precio", c => c.Double());
            AlterColumn("dbo.Productos", "PrecioCosto", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Productos", "PrecioCosto", c => c.Single(nullable: false));
            AlterColumn("dbo.PuntosVentaProductos", "Precio", c => c.Single());
        }
    }
}
