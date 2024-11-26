using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal
{
    public partial class SiteMaster : MasterPage
    {
        IU.ManejadorSesion manejo_sesion = new IU.ManejadorSesion();
        Utilerias.Comun cm = new Utilerias.Comun();

        protected void Page_Load(object sender, EventArgs e)
        {
           if (Session["Sesion"] == null)
                Response.Redirect("..\\.");
            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];
            LblNombreUsuario.Text = manejo_sesion.Usuarios.Nombre;
            LblTextNombreUsuario.Text = manejo_sesion.Usuarios.Nombre;
            Utilerias.Comun cm = new Utilerias.Comun();
            if (string.IsNullOrEmpty(manejo_sesion.MensajeAdvertencia))
                LblNombreUsuario.Text = manejo_sesion.Usuarios.Nombre;
            else
            {
                LblNombreUsuario.Text = manejo_sesion.MensajeAdvertencia + " " + manejo_sesion.Usuarios.Nombre;
                LblNombreUsuario.ForeColor = System.Drawing.Color.Red;
                LblNombreUsuario.Font.Bold = true;
            }
        }

        protected void BtnSalirSistema_Click(object sender, EventArgs e)
        {
            Negocio.Sistema.Usuarios sisusr = new Negocio.Sistema.Usuarios();
            sisusr.RegistroLog(Session["IdSesion"].ToString(), Session["idusuario"].ToString(), Session["Inicio"].ToString(), 0);
            sisusr.ActualizarDesconectarSesion(manejo_sesion.Usuarios.IdUsuario, 0, manejo_sesion.IdParaCierreSesion);

            ////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////// COMENTAR PARA SALIR LOCALMENTE //////////////////////////////////

            Session.RemoveAll();
            //Eliminar una sola
            Session.Remove("Sesion");
            Session["Sesion"] = null;
            Session.Remove("idusuario");
            Session["idusuario"] = null;
            Session.Remove("IdSesion");
            Session["IdSesion"] = null;
            Session.Remove("Inicio");
            Session["Inicio"] = null;
            //Eliminar todas las variables
            Session.Contents.RemoveAll();
            Session.Clear();
            System.Web.Security.FormsAuthentication.SignOut();

            /* REALIZA LA SALIDA DEL SISTEMA APARTIR DEL PARAMETRO
                1 SALIDA A CAMBIO DE APLIACION, 
                2 SALIDA POR CIERRE DE SESION TOTAL. 

                LA SALIDA SIN PARAMETROS POR URL, NOS REDIRECCIONARA AL CAMBIO DE APLIACION, ENCASO DE NO TENER UN TOKEN, SALDRA AL LOGIN MAESTRO.
                OBTENER LA RUTA ORGIEN PARA REDIRECCIONAR AL LOGEO
             * */
            string host = HttpContext.Current.Request.Url.Host;

            // VALIDA LA VARIABLE DE SESION PARA REGISTRAR SU SALIDA
            if (manejo_sesion != null)
            {
                // CAMBIAR LA RUTA PARA INGRESAR CON WWWW O SIN ELLA. (TOMAR LA RUTA ORIGUEN)
                // VALIDA EL PARAMETRO DE OPERACION.

                string _Token = manejo_sesion.Token;

                //CIERRA SESION A TRAVES DEL WEB SERVICE, PROPORCIONA LLAVE PARA CERRAR SESION EN EL LOGIN PRINCIPAL.
                WFO_IMSSPortal.Negocio.Sistema.CredencialesWS credenciales = new Negocio.Sistema.Autentificar().CierreSesion(_Token);
                //WFO.Negocio.Sistema.CredencialesWS credenciales = new WFO.Negocio.Sistema.Autentificar().CierreSesion(_Token);
                Response.Redirect("https://" + host + "/MetLife/Default.aspx?numlife=" + _Token);
            }
            else
            {
                Response.Redirect("https://" + host + "/MetLife/");
            }

            ////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////
        }

        protected void BtnSalirAplicacion_Click(object sender, EventArgs e)
        {
            Negocio.Sistema.Usuarios sisusr = new Negocio.Sistema.Usuarios();
            sisusr.RegistroLog(Session["IdSesion"].ToString(), Session["idusuario"].ToString(), Session["Inicio"].ToString(), 0);
            sisusr.ActualizarDesconectarSesion(manejo_sesion.Usuarios.IdUsuario, 0, manejo_sesion.IdParaCierreSesion);

            Session.RemoveAll();
            //Eliminar una sola
            Session.Remove("Sesion");
            Session["Sesion"] = null;
            Session.Remove("idusuario");
            Session["idusuario"] = null;
            Session.Remove("IdSesion");
            Session["IdSesion"] = null;
            Session.Remove("Inicio");
            Session["Inicio"] = null;
            //Eliminar todas las variables
            Session.Contents.RemoveAll();
            Session.Clear();
            System.Web.Security.FormsAuthentication.SignOut();


            /* REALIZA LA SALIDA DEL SISTEMA APARTIR DEL PARAMETRO
                1 SALIDA A CAMBIO DE APLIACION, 
                2 SALIDA POR CIERRE DE SESION TOTAL. 

                LA SALIDA SIN PARAMETROS POR URL, NOS REDIRECCIONARA AL CAMBIO DE APLIACION, ENCASO DE NO TENER UN TOKEN, SALDRA AL LOGIN MAESTRO.
                OBTENER LA RUTA ORGIEN PARA REDIRECCIONAR AL LOGEO
             * */

            string host = HttpContext.Current.Request.Url.Host;

            // VALIDA LA VARIABLE DE SESION PARA REGISTRAR SU SALIDA
            if (manejo_sesion != null)
            {
                // CAMBIAR LA RUTA PARA INGRESAR CON WWWW O SIN ELLA. (TOMAR LA RUTA ORIGUEN)
                string _Token = manejo_sesion.Token;

                // ENVIA EL TOKEN REGISTRADO EN SUS SECION, PARA SER AUTENTIFICADO EN EL LOGIN MAESTRO.
                // Response.Redirect("http://localhost:51634/Procesos/Aplicaciones/Default.aspx?numlife=" + _Token);
                Response.Redirect("https://" + host + "/MetLife/Default.aspx?numlife=" + _Token);
            }
            else
            {
                Response.Redirect("https://" + host + "/MetLife/");
            }
        }

        //protected void BtnSalirSistema_Click(object sender, EventArgs e)
        //{
        //    Negocio.Sistema.Usuarios sisusr = new Negocio.Sistema.Usuarios();
        //    sisusr.RegistroLog(Session["IdSesion"].ToString(), Session["idusuario"].ToString(), Session["Inicio"].ToString(), 0);
        //    sisusr.ActualizarDesconectarSesion(manejo_sesion.Usuarios.IdUsuario, 0, manejo_sesion.IdParaCierreSesion);
        //    //Session.Abandon();
        //    //Session.Clear();
        //    Response.Redirect("~/Default.aspx");
        //}
    }
}