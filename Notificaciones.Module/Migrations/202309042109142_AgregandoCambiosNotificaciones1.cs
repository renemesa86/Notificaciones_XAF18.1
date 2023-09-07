namespace Notificaciones.Module.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregandoCambiosNotificaciones1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mensajes", "RemindIn", c => c.Time(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Mensajes", "RemindIn");
        }
    }
}
