namespace Notificaciones.Module.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModificandoCampos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Mensajes", "Evento_ID", "dbo.Eventoes");
            DropIndex("dbo.Mensajes", new[] { "Evento_ID" });
            AlterColumn("dbo.Mensajes", "Evento_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Mensajes", "Evento_ID");
            AddForeignKey("dbo.Mensajes", "Evento_ID", "dbo.Eventoes", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mensajes", "Evento_ID", "dbo.Eventoes");
            DropIndex("dbo.Mensajes", new[] { "Evento_ID" });
            AlterColumn("dbo.Mensajes", "Evento_ID", c => c.Int());
            CreateIndex("dbo.Mensajes", "Evento_ID");
            AddForeignKey("dbo.Mensajes", "Evento_ID", "dbo.Eventoes", "ID");
        }
    }
}
