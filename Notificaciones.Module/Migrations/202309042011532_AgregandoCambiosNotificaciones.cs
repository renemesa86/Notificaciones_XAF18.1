namespace Notificaciones.Module.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregandoCambiosNotificaciones : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mensajes", "AlarmTime", c => c.DateTime());
            AddColumn("dbo.Mensajes", "IsPostponed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Mensajes", "IsPostponed");
            DropColumn("dbo.Mensajes", "AlarmTime");
        }
    }
}
