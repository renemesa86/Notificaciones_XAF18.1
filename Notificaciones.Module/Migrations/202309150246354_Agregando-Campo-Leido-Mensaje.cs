namespace Notificaciones.Module.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregandoCampoLeidoMensaje : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mensajes", "Leido", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Mensajes", "Leido");
        }
    }
}
