using System;
using System.Collections;
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
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using DevExpress.Persistent.Validation;
using Notificaciones.Module.BusinessObjects;


namespace Notificaciones.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class GuardarMensajeCustomController : DevExpress.ExpressApp.Web.SystemModule.WebModificationsController
    {
        public GuardarMensajeCustomController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }

        protected override void Save(SimpleActionExecuteEventArgs args)
        {
            View view = View;
            IObjectSpace objectSpace = View.ObjectSpace;

            var util = new Util();

            var mensaje = args.CurrentObject as Mensaje;

            if ((view != null) && (view.ObjectTypeInfo.Type == typeof(Mensaje)))
            {
                if (mensaje.Receptor == null)
                {
                    util.InsertaMultiplesMensajesUsuarios(mensaje, objectSpace);

                    IList modifiedObjects = new ArrayList(ObjectSpace.ModifiedObjects);
                    ObjectSpace.CommitChanges();
                    DetailView rootDetailView = (DetailView)Application.MainWindow.View;
                    foreach (object obj in modifiedObjects)
                    {
                        rootDetailView.ObjectSpace.ReloadObject(obj);
                    }

                    objectSpace.Refresh();
                }
                else
                {

                    mensaje.FechaProgramada = mensaje.Evento.FechaProgramada;

                    //Hora Programada
                    int horas = mensaje.FechaProgramada.Hour;
                    int minutos = mensaje.FechaProgramada.Minute;
                    int segundos = mensaje.FechaProgramada.Second;
                    TimeSpan horaProgramada = new TimeSpan(horas, minutos, segundos);

                    //El campo RemindIn define cada que tiempo se recordará al usuario el mensaje 
                    mensaje.RemindIn = horaProgramada;

                    mensaje.AlarmTime = mensaje.Evento.FechaProgramada;// - horaProgramada; //MensajeAEnviar.AlarmTime;         
                    mensaje.IsPostponed = mensaje.IsPostponed;

                    base.Save(args);

                }              


            }
            else {

                base.Save(args);

            }

        }

        protected override void SaveAndClose(SimpleActionExecuteEventArgs args)
        {
            View view = View;
            IObjectSpace objectSpace = View.ObjectSpace;

            var util = new Util();

            var mensaje = args.CurrentObject as Mensaje;

            if ((view != null) && (view.ObjectTypeInfo.Type == typeof(Mensaje)))
            {
                if (mensaje.Receptor == null)
                {
                    util.InsertaMultiplesMensajesUsuarios(mensaje, objectSpace);

                    IList modifiedObjects = new ArrayList(ObjectSpace.ModifiedObjects);
                    ObjectSpace.CommitChanges();
                    DetailView rootDetailView = (DetailView)Application.MainWindow.View;
                    foreach (object obj in modifiedObjects)
                    {
                        rootDetailView.ObjectSpace.ReloadObject(obj);
                    }

                    objectSpace.Refresh();
                }
                else
                {

                    mensaje.FechaProgramada = mensaje.Evento.FechaProgramada;

                    //Hora Programada
                    int horas = mensaje.FechaProgramada.Hour;
                    int minutos = mensaje.FechaProgramada.Minute;
                    int segundos = mensaje.FechaProgramada.Second;
                    TimeSpan horaProgramada = new TimeSpan(horas, minutos, segundos);

                    //El campo RemindIn define cada que tiempo se recordará al usuario el mensaje 
                    mensaje.RemindIn = horaProgramada;

                    mensaje.AlarmTime = mensaje.Evento.FechaProgramada;// - horaProgramada; //MensajeAEnviar.AlarmTime;         
                    mensaje.IsPostponed = mensaje.IsPostponed;

                    base.SaveAndClose(args);

                }


            }
            else
            {

                base.SaveAndClose(args);

            }
        }

        //protected override void SaveAnd
        protected override void SaveAndNew(SingleChoiceActionExecuteEventArgs args)
        {
            View view = View;
            IObjectSpace objectSpace = View.ObjectSpace;

            var util = new Util();

            var mensaje = args.CurrentObject as Mensaje;

            if ((view != null) && (view.ObjectTypeInfo.Type == typeof(Mensaje)))
            {
                if (mensaje.Receptor == null)
                {
                    util.InsertaMultiplesMensajesUsuarios(mensaje, objectSpace);

                    IList modifiedObjects = new ArrayList(ObjectSpace.ModifiedObjects);
                    ObjectSpace.CommitChanges();
                    DetailView rootDetailView = (DetailView)Application.MainWindow.View;
                    foreach (object obj in modifiedObjects)
                    {
                        rootDetailView.ObjectSpace.ReloadObject(obj);
                    }

                    objectSpace.Refresh();
                }
                else
                {

                    mensaje.FechaProgramada = mensaje.Evento.FechaProgramada;

                    //Hora Programada
                    int horas = mensaje.FechaProgramada.Hour;
                    int minutos = mensaje.FechaProgramada.Minute;
                    int segundos = mensaje.FechaProgramada.Second;
                    TimeSpan horaProgramada = new TimeSpan(horas, minutos, segundos);

                    //El campo RemindIn define cada que tiempo se recordará al usuario el mensaje 
                    mensaje.RemindIn = horaProgramada;

                    mensaje.AlarmTime = mensaje.Evento.FechaProgramada;// - horaProgramada; //MensajeAEnviar.AlarmTime;         
                    mensaje.IsPostponed = mensaje.IsPostponed;

                    base.SaveAndNew(args);

                }


            }
            else
            {

                base.SaveAndNew(args);

            }
        }

    }
}
