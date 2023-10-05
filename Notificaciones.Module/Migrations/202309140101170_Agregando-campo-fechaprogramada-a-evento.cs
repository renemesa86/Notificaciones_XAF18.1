namespace Notificaciones.Module.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Agregandocampofechaprogramadaaevento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Eventoes", "FechaProgramada", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Eventoes", "FechaProgramada");
        }
    }
}
