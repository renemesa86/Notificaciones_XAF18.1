namespace Notificaciones.Module.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregandoentidadEvento : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Eventoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Mensajes", "Evento_ID", c => c.Int());
            CreateIndex("dbo.Mensajes", "Evento_ID");
            AddForeignKey("dbo.Mensajes", "Evento_ID", "dbo.Eventoes", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mensajes", "Evento_ID", "dbo.Eventoes");
            DropIndex("dbo.Mensajes", new[] { "Evento_ID" });
            DropColumn("dbo.Mensajes", "Evento_ID");
            DropTable("dbo.Eventoes");
        }
    }
}
