namespace Notificaciones.Module.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EliminandoCampoHoraProgramada : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Eventoes", "HoraProgramada");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Eventoes", "HoraProgramada", c => c.Time(nullable: false, precision: 7));
        }
    }
}
