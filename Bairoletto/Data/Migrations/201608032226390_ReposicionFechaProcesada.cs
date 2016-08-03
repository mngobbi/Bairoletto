namespace Data
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReposicionFechaProcesada : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrdenesReposicion", "FechaProcesada", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrdenesReposicion", "FechaProcesada");
        }
    }
}
