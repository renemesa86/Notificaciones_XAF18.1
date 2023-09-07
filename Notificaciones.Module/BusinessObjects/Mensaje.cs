using System;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.Generic;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using DevExpress.Persistent.Base.General;
using System.ComponentModel.DataAnnotations.Schema;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;

namespace Notificaciones.Module.BusinessObjects
{
    // Register this entity in the DbContext using the "public DbSet<Mensaje> Mensajes { get; set; }" syntax.
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("Name")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Mensaje : IXafEntityObject, IObjectSpaceLink, INotifyPropertyChanged, ISupportNotifications
    {
        public Mensaje()
        {
            // In the constructor, initialize collection properties, e.g.: 
            // this.AssociatedEntities = new List<AssociatedEntityObject>();
        }
        [Browsable(false)]  // Hide the entity identifier from UI.
        public Int32 ID { get; protected set; }
        //[VisibleInListView]
        //[VisibleInDetailView]
        public String Contenido { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public virtual PermissionPolicyUser Emisor { get; set; }

        public virtual PermissionPolicyUser Receptor { get; set; }

        //public String Contenido { get; set; }

        // You can use the regular Code First syntax:
        //public string Name { get; set; }

        // Alternatively, specify more UI options: 
        //private string _PersistentProperty;
        //[XafDisplayName("My display name"), ToolTip("My hint message")]
        //[ModelDefault("EditMask", "(000)-00"), VisibleInListView(false)]
        //[RuleRequiredField(DefaultContexts.Save)]
        //public string PersistentProperty {
        //    get { return _PersistentProperty; }
        //    set {
        //        if (_PersistentProperty != value) {
        //            _PersistentProperty = value;
        //            OnPropertyChanged("PersistentProperty");
        //        }
        //    }
        //}

        // Collection property:
        //public virtual IList<AssociatedEntityObject> AssociatedEntities { get; set; }

        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}

        #region IXafEntityObject members (see https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppIXafEntityObjecttopic.aspx)
        void IXafEntityObject.OnCreated()
        {
            // Place the entity initialization code here.
            // You can initialize reference properties using Object Space methods; e.g.:
            // this.Address = objectSpace.CreateObject<Address>();
        }
        void IXafEntityObject.OnLoaded()
        {
            // Place the code that is executed each time the entity is loaded here.
        }
        void IXafEntityObject.OnSaving()
        {
            if (RemindIn.HasValue) //Si campo recordar tiene valor
            {
                //Si hora de alarma es null ó hora de alarma es menor 
                //que FECHAVENCIMIENTO - RECORDAREN
                if ((AlarmTime == null) || (AlarmTime < FechaVencimiento - RemindIn.Value))
                {
                    AlarmTime = FechaVencimiento - RemindIn.Value;
                }
            }
            else
            {
                AlarmTime = null;
            }
            if (AlarmTime == null)
            {
                RemindIn = null;
                IsPostponed = false;
            }
        }
        #endregion

        #region IObjectSpaceLink members (see https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppIObjectSpaceLinktopic.aspx)
        // Use the Object Space to access other entities from IXafEntityObject methods (see https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113707.aspx).
        private IObjectSpace objectSpace;
        IObjectSpace IObjectSpaceLink.ObjectSpace
        {
            get { return objectSpace; }
            set { objectSpace = value; }
        }
        #endregion

        #region ISupportNotifications members
        private DateTime? alarmTime;
        [Browsable(false)]
        public DateTime? AlarmTime
        {
            get { return alarmTime; }
            set
            {
                alarmTime = value;
                if (value == null)
                {
                    RemindIn = null;
                    IsPostponed = false;
                }
            }
        }
        [Browsable(false)]
        public bool IsPostponed { get; set; }
        [Browsable(false), NotMapped]
        public string NotificationMessage
        {
            get { return Contenido; }
        }
        public TimeSpan? RemindIn { get; set; }
        [Browsable(false), NotMapped]
        public object UniqueId
        {
            get { return ID; }
        }
        #endregion

        #region INotifyPropertyChanged members (see http://msdn.microsoft.com/en-us/library/system.componentmodel.inotifypropertychanged(v=vs.110).aspx)
        private void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
