namespace Notificaciones.Module.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregandoCampoLeido : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Eventoes", "Leido", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Eventoes", "Leido");
        }
    }
}
