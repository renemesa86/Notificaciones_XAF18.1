namespace Notificaciones.Module.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModificandoCamposRelacionadosUsuario : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PermissionPolicyUserPermissionPolicyRoles", newName: "PermissionPolicyRolePermissionPolicyUsers");
            DropPrimaryKey("dbo.PermissionPolicyRolePermissionPolicyUsers");
            AddColumn("dbo.Mensajes", "Emisor_ID", c => c.Int());
            AddColumn("dbo.Mensajes", "Receptor_ID", c => c.Int());
            AddPrimaryKey("dbo.PermissionPolicyRolePermissionPolicyUsers", new[] { "PermissionPolicyRole_ID", "PermissionPolicyUser_ID" });
            CreateIndex("dbo.Mensajes", "Emisor_ID");
            CreateIndex("dbo.Mensajes", "Receptor_ID");
            AddForeignKey("dbo.Mensajes", "Emisor_ID", "dbo.PermissionPolicyUsers", "ID");
            AddForeignKey("dbo.Mensajes", "Receptor_ID", "dbo.PermissionPolicyUsers", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mensajes", "Receptor_ID", "dbo.PermissionPolicyUsers");
            DropForeignKey("dbo.Mensajes", "Emisor_ID", "dbo.PermissionPolicyUsers");
            DropIndex("dbo.Mensajes", new[] { "Receptor_ID" });
            DropIndex("dbo.Mensajes", new[] { "Emisor_ID" });
            DropPrimaryKey("dbo.PermissionPolicyRolePermissionPolicyUsers");
            DropColumn("dbo.Mensajes", "Receptor_ID");
            DropColumn("dbo.Mensajes", "Emisor_ID");
            AddPrimaryKey("dbo.PermissionPolicyRolePermissionPolicyUsers", new[] { "PermissionPolicyUser_ID", "PermissionPolicyRole_ID" });
            RenameTable(name: "dbo.PermissionPolicyRolePermissionPolicyUsers", newName: "PermissionPolicyUserPermissionPolicyRoles");
        }
    }
}
