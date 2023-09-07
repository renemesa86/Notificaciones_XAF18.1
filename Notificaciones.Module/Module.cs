using System;
using System.Text;
using System.Linq;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using System.Collections.Generic;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.DomainLogics;
using DevExpress.ExpressApp.Model.NodeGenerators;
using System.Data.Entity;
using Notificaciones.Module.BusinessObjects;
using DevExpress.ExpressApp.Notifications;
using DevExpress.Persistent.Base.General;
using DevExpress.Data.Filtering;

namespace Notificaciones.Module {
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppModuleBasetopic.aspx.
    public sealed partial class NotificacionesModule : ModuleBase {
        static NotificacionesModule() {
            DevExpress.Data.Linq.CriteriaToEFExpressionConverter.SqlFunctionsType = typeof(System.Data.Entity.SqlServer.SqlFunctions);
			DevExpress.Data.Linq.CriteriaToEFExpressionConverter.EntityFunctionsType = typeof(System.Data.Entity.DbFunctions);
			DevExpress.ExpressApp.SystemModule.ResetViewSettingsController.DefaultAllowRecreateView = false;
            // Uncomment this code to delete and recreate the database each time the data model has changed.
            // Do not use this code in a production environment to avoid data loss.
            // #if DEBUG
            // Database.SetInitializer(new DropCreateDatabaseIfModelChanges<NotificacionesDbContext>());
            // #endif 
        }
        public NotificacionesModule() {
            InitializeComponent();
			DevExpress.ExpressApp.Security.SecurityModule.UsedExportedTypes = DevExpress.Persistent.Base.UsedExportedTypes.Custom;
        }
        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB) {
            ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
            return new ModuleUpdater[] { updater };
        }       
        public override void Setup(XafApplication application)
        {
            base.Setup(application);
            application.LoggedOn += new EventHandler<LogonEventArgs>(application_LoggedOn);
        }
        void application_LoggedOn(object sender, LogonEventArgs e)
        {
            NotificationsModule notificationsModule = Application.Modules.FindModule<NotificationsModule>();
            DefaultNotificationsProvider notificationsProvider = notificationsModule.DefaultNotificationsProvider;
            notificationsProvider.CustomizeNotificationCollectionCriteria += notificationsProvider_CustomizeNotificationCollectionCriteria;
        }
        void notificationsProvider_CustomizeNotificationCollectionCriteria(
            object sender, CustomizeCollectionCriteriaEventArgs e)
        {
            if (e.Type == typeof(Mensaje))
            {
                int currentUser = int.Parse(SecuritySystem.CurrentUserId.ToString());
                e.Criteria = CriteriaOperator.Parse("Receptor is null || Receptor.Id == CurrentUserId()");
            }
        }

    }
}
