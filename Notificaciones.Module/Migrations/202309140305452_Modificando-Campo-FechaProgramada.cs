namespace Notificaciones.Module.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModificandoCampoFechaProgramada : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mensajes", "FechaProgramada", c => c.DateTime(nullable: false));
            DropColumn("dbo.Mensajes", "FechaVencimiento");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Mensajes", "FechaVencimiento", c => c.DateTime(nullable: false));
            DropColumn("dbo.Mensajes", "FechaProgramada");
        }
    }
}
