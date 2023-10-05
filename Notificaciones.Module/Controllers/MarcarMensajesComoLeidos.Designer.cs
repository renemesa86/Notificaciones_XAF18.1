namespace Notificaciones.Module.Controllers
{
    partial class MarcarMensajesComoLeidos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MarcarMensajesLeidos = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // MarcarMensajesLeidos
            // 
            this.MarcarMensajesLeidos.Caption = "Marcar como leídos";
            this.MarcarMensajesLeidos.Category = "Edit";
            this.MarcarMensajesLeidos.ConfirmationMessage = "¿Desea marcar como leídos los mensajes?";
            this.MarcarMensajesLeidos.Id = "MarcarMensajesLeidos";
            this.MarcarMensajesLeidos.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireMultipleObjects;
            this.MarcarMensajesLeidos.TargetObjectsCriteriaMode = DevExpress.ExpressApp.Actions.TargetObjectsCriteriaMode.TrueForAll;
            this.MarcarMensajesLeidos.TargetObjectType = typeof(Notificaciones.Module.BusinessObjects.Mensaje);
            this.MarcarMensajesLeidos.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.MarcarMensajesLeidos.ToolTip = null;
            this.MarcarMensajesLeidos.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.MarcarMensajesLeidos.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.MarcarMensajesLeidos_Execute);
            // 
            // MarcarMensajesComoLeidos
            // 
            this.Actions.Add(this.MarcarMensajesLeidos);
            this.TargetObjectType = typeof(Notificaciones.Module.BusinessObjects.Mensaje);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.TypeOfView = typeof(DevExpress.ExpressApp.ListView);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction MarcarMensajesLeidos;
    }
}
