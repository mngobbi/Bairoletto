namespace Data
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductoStock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productos", "Stock", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Productos", "Stock");
        }
    }
}
