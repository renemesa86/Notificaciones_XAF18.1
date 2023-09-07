namespace Notificaciones.Module.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregandoClaseTasks : DbMigration
    {
        public override void Up()
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tasks");
        }
    }
}
