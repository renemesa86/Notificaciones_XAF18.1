namespace Notificaciones.Module.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DefiniendoCamposMensaje : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mensajes", "FechaVencimiento", c => c.DateTime(nullable: false));
            DropColumn("dbo.Mensajes", "Fecha");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Mensajes", "Fecha", c => c.DateTime(nullable: false));
            DropColumn("dbo.Mensajes", "FechaVencimiento");
        }
    }
}
