using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Web.Templates.ActionContainers.Menu;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using Notificaciones.Module.BusinessObjects;

namespace Notificaciones.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class CustomNotificationsNotificationsDialogViewControllerViewController : DevExpress.ExpressApp.Notifications.Web.WebNotificationsDialogViewController
    {
        public CustomNotificationsNotificationsDialogViewControllerViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }

       
        protected override void UpdateActionActivity(ActionBase action)
        {
            base.UpdateActionActivity(action);
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            Frame.GetController<CustomNotificationsNotificationsDialogViewControllerViewController>().Dismiss.Execute += CustomizeActionControlControllerWeb_Execute;
        }

        private void CustomizeActionControlControllerWeb_Execute(object sender, SimpleActionExecuteEventArgs e)
        {            
           
                foreach (var mensaje in e.SelectedObjects)
                {
                    var id=(mensaje as DevExpress.ExpressApp.Notifications.Notification).NotificationSource.UniqueId;
                    using (var db = new NotificacionesDbContext())
                    {
                        Mensaje m = db.Mensaje.FirstOrDefault(x => x.ID == (int)id);
                        m.Leido = true;
                        db.SaveChanges();
                    }
                    
                }
                
             
        }

        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            Frame.GetController<CustomNotificationsNotificationsDialogViewControllerViewController>().Dismiss.Execute -=
CustomizeActionControlControllerWeb_Execute;
            base.OnDeactivated();
        }
    }
}
