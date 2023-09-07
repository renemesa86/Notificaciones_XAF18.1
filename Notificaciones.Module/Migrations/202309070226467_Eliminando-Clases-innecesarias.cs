namespace Notificaciones.Module.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EliminandoClasesinnecesarias : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Notificacions");
            DropTable("dbo.Tasks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        DueDate = c.DateTime(nullable: false),
                        AlarmTime = c.DateTime(),
                        IsPostponed = c.Boolean(nullable: false),
                        RemindIn = c.Time(precision: 7),
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
    }
}
