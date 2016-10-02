namespace Data
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjustarEventos : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrdenReposicionEventos", "UsuarioId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrdenReposicionEventos", "UsuarioId", c => c.Int(nullable: false));
        }
    }
}
