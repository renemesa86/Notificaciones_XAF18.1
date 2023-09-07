namespace Notificaciones.Module.Controllers
{
    partial class EnviarMensajeController
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
            this.EnviarMensaje = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // EnviarMensaje
            // 
            this.EnviarMensaje.Caption = "Enviar mensaje";
            this.EnviarMensaje.ConfirmationMessage = null;
            this.EnviarMensaje.Id = "mensaje";
            this.EnviarMensaje.TargetObjectType = typeof(Notificaciones.Module.BusinessObjects.Mensaje);
            this.EnviarMensaje.ToolTip = null;
            // 
            // EnviarMensajeController
            // 
            this.Actions.Add(this.EnviarMensaje);
            this.TargetObjectType = typeof(Notificaciones.Module.BusinessObjects.Mensaje);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction EnviarMensaje;
    }
}
