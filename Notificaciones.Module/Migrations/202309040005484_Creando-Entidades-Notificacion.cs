namespace Notificaciones.Module.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreandoEntidadesNotificacion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mensajes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Emisor = c.String(),
                        Receptor = c.String(),
                        Contenido = c.String(),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Notificacions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Mensaje = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Notificacions");
            DropTable("dbo.Mensajes");
        }
    }
}
