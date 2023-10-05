namespace Notificaciones.Module.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Agregandocampotimeaevento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Eventoes", "HoraProgramada", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Eventoes", "HoraProgramada");
        }
    }
}
