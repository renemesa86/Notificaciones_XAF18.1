namespace Notificaciones.Module.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregandoCampoLeidoj : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Eventoes", "Leido");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Eventoes", "Leido", c => c.Boolean(nullable: false));
        }
    }
}
