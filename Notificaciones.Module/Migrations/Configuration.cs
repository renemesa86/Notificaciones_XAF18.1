namespace Notificaciones.Module.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Notificaciones.Module.BusinessObjects.NotificacionesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Notificaciones.Module.BusinessObjects.NotificacionesDbContext";
        }

        protected override void Seed(Notificaciones.Module.BusinessObjects.NotificacionesDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
