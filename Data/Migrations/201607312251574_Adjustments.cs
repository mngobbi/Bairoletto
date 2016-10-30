namespace Data
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adjustments : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrdenesReposicion", "FechaEntrega", c => c.DateTime());
            AlterColumn("dbo.OrdenesReposicionDetalle", "PrecioUnitario", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrdenesReposicionDetalle", "PrecioUnitario", c => c.Single(nullable: false));
            AlterColumn("dbo.OrdenesReposicion", "FechaEntrega", c => c.DateTime(nullable: false));
        }
    }
}
