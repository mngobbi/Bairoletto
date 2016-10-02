namespace Data
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjustarEventos1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrdenReposicionEventos", "UsuarioNombre", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrdenReposicionEventos", "UsuarioNombre");
        }
    }
}
