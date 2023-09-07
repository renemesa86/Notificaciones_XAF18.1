using System;
using System.Data;
using System.Linq;
using System.Data.Entity;
using System.Data.Common;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.ComponentModel;
using DevExpress.ExpressApp.EF.Updating;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;

namespace Notificaciones.Module.BusinessObjects {
	public class NotificacionesDbContext : DbContext {
		public NotificacionesDbContext(String connectionString)
			: base(connectionString) {
		}
		public NotificacionesDbContext(DbConnection connection)
			: base(connection, false) {
		}
		public NotificacionesDbContext()
			: base("name=ConnectionString") {
		}
		public DbSet<ModuleInfo> ModulesInfo { get; set; }
	    public DbSet<PermissionPolicyRole> Roles { get; set; }
		public DbSet<PermissionPolicyTypePermissionObject> TypePermissionObjects { get; set; }
		public DbSet<PermissionPolicyUser> Users { get; set; }
		public DbSet<ModelDifference> ModelDifferences { get; set; }
		public DbSet<ModelDifferenceAspect> ModelDifferenceAspects { get; set; }
        public DbSet<Mensaje> Mensaje { get; set; }
        //public DbSet<Notificacion> Notificacion { get; set; }
        //public DbSet<Task> Tasks { get; set; }
    }
}