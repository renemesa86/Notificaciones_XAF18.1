using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notificaciones.Module.BusinessObjects
{
    class Util
    {

        public void InsertaMultiplesMensajesUsuarios(Mensaje MensajeAEnviar, IObjectSpace objectSpace)
        {

            //Obtengo un listado de todos los usuarios que no son Administradores
            var usuariosNoAdmin = objectSpace.GetObjects<PermissionPolicyUser>().Where(u => !u.Roles.Any(r => r.Name == "Administrators"));

            //Ciclo para recorrer los usuarios NoAdmin e insertar el mensaje para cada uno.
            //Esta implementación es necesaria ya que, de guardar un sólo mensaje, puede salirle a todos los usuarios,
            //pero si uno de los usuario que recibiera el mensaje decidiera marcarlo como leído 
            //se marcaría Leído para todos.         

            foreach (var usuario in usuariosNoAdmin)
            {

                Mensaje nuevomensaje = objectSpace.CreateObject<Mensaje>();

                nuevomensaje.Contenido = MensajeAEnviar.Contenido;
                nuevomensaje.Emisor = MensajeAEnviar.Emisor;
                nuevomensaje.Receptor = usuario;
                nuevomensaje.Evento = MensajeAEnviar.Evento;

                nuevomensaje.FechaProgramada = MensajeAEnviar.Evento.FechaProgramada;

                //Hora Programada
                int horas = nuevomensaje.FechaProgramada.Hour;
                int minutos = nuevomensaje.FechaProgramada.Minute;
                int segundos = nuevomensaje.FechaProgramada.Second;
                TimeSpan horaProgramada = new TimeSpan(horas, minutos, segundos);

                //El campo RemindIn define cada que tiempo se recordará al usuario el mensaje 
                nuevomensaje.RemindIn = horaProgramada;

                nuevomensaje.AlarmTime = MensajeAEnviar.Evento.FechaProgramada;// - horaProgramada; //MensajeAEnviar.AlarmTime;         
                nuevomensaje.IsPostponed = MensajeAEnviar.IsPostponed;

            }

            //Elimino el objeto que inserta el ADMIN con el receptor NULL, para que no se inserte en el sistema
            var objetosAEliminar = objectSpace.ModifiedObjects.OfType<Mensaje>().ToList();
            foreach (var objetoAEliminar in objetosAEliminar)
            {
                if (objetoAEliminar.Receptor == null)
                {
                    objectSpace.Delete(objetoAEliminar);
                }
            }

        }

        public void InsertaMensajeSimpleUsuario(Mensaje MensajeAEnviar, IObjectSpace objectSpace)
        {

            Mensaje nuevomensaje = objectSpace.CreateObject<Mensaje>();

            nuevomensaje.Contenido = MensajeAEnviar.Contenido;
            nuevomensaje.Emisor = MensajeAEnviar.Emisor;
            nuevomensaje.Receptor = MensajeAEnviar.Receptor;
            nuevomensaje.Evento = MensajeAEnviar.Evento;

            nuevomensaje.FechaProgramada = MensajeAEnviar.Evento.FechaProgramada;

            //Hora Programada
            int horas = nuevomensaje.FechaProgramada.Hour;
            int minutos = nuevomensaje.FechaProgramada.Minute;
            int segundos = nuevomensaje.FechaProgramada.Second;
            TimeSpan horaProgramada = new TimeSpan(horas, minutos, segundos);

            //El campo RemindIn define cada que tiempo se recordará al usuario el mensaje 
            nuevomensaje.RemindIn = horaProgramada;
      
            nuevomensaje.AlarmTime = MensajeAEnviar.Evento.FechaProgramada;// - horaProgramada; //MensajeAEnviar.AlarmTime;         
            nuevomensaje.IsPostponed = MensajeAEnviar.IsPostponed;


            //objectSpace.CommitChanges(); 
        

        }


    }
}
