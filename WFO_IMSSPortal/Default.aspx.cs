using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal
{
    public partial class Default : Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (!SM1.IsInAsyncPostBack)
            //    Session["timeout"] = DateTime.Now.AddMinutes(double.Parse(manejo_sesion.EsperaBloqueo)).ToString();

///////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////
// COMENTAR TODAS LAS LINEAS PARA DEJAR ENTRAR POR LOGION

#if DEBUG
#else

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

            //PARAMETROS DE AUTENTITFIACION POR WEB SERVICE EN EL CASO DE NO EXISTIR REDIRIGIR AL LISTADO DE APLIACIONES.
            if (Request.Params["numlife"] != null && Request.Params["us"] != null && Request.Params["ap"] != null)
            {
                // VALIDACION POR WEB SERVICE. - RETORNARA EL TOKEN Y EL NOMBRE DEL USUARIO.
                string token = Request.Params["numlife"].ToString();
                int IdUsuario = Convert.ToInt32(Request.Params["us"]);
                int IdAplicacion = Convert.ToInt32(Request.Params["ap"]);

                // COLOCA AUTENTITIFACION POR WS
                WFO_IMSSPortal.Negocio.Sistema.CredencialesWS credenciales = i.administracion.autentificar.Autentificarws(IdUsuario, IdAplicacion, token);

                if (credenciales.Token != "0")
                {
                    manejo_sesion.Inicializar();

                    
                    Propiedades.Sesion psesion = new Propiedades.Sesion();
                    //psesion.IdUsuario = manejo_sesion.Usuarios.IdUsuario;
                    manejo_sesion.Usuarios = i.administracion.usuarios.SeleccionarPorId(credenciales.Id);
                    //manejo_sesion.IdParaCierreSesion = i.administracion.sesion.Agregar(psesion);
                    manejo_sesion.Token = credenciales.Token;
                    manejo_sesion.Menu = i.administracion.menu.Seleccionar(manejo_sesion.Usuarios.IdRol); //nueva carga del menú, como es modo texto, ya no hay que cargarlo de nuevo
                    Session["Sesion"] = manejo_sesion;                        //Asignación de la sesión principal del sistema
                    Session["idusuario"] = manejo_sesion.Usuarios.IdUsuario;  //desbloqueo del usuario si termina la sesión
                    Session["IdSesion"] = HttpContext.Current.Session.SessionID;
                    Session["Inicio"] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                    Response.Redirect(manejo_sesion.Usuarios.RolAcceso, true);

                }
                else
                {
                    string host = HttpContext.Current.Request.Url.Host;
                    Response.Redirect("https://" + host + "/MetLife/");
                    //Response.Redirect("http://localhost:51634/Default.aspx");
                }
            }
            else
            {
                string host = HttpContext.Current.Request.Url.Host;
                Response.Redirect("https://" + host + "/MetLife/");
                //Response.Redirect("http://localhost:51634/Default.aspx");
            }
#endif

            ///////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////*/
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                string mensaje = string.Empty;
                string ruta = string.Empty;
                int validaUsuario = i.administracion.usuarios.SeleccionarValidarAcceso(txUsuario.Text, txClave.Text, manejo_sesion, ref mensaje);

                Propiedades.Sesion psesion = new Propiedades.Sesion();
                psesion.IdUsuario = manejo_sesion.Usuarios.IdUsuario;

                //manejo_sesion.Usuarios.IdRol = 3;
                manejo_sesion.IdParaCierreSesion = i.administracion.sesion.Agregar(psesion);
                manejo_sesion.MensajeAdvertencia = mensaje;
                manejo_sesion.Menu = i.administracion.menu.Seleccionar(manejo_sesion.Usuarios.IdRol); //nueva carga del menú, como es modo texto, ya no hay que cargarlo de nuevo
                Session["Sesion"] = manejo_sesion;                        //Asignación de la sesión principal del sistema
                Session["idusuario"] = manejo_sesion.Usuarios.IdUsuario;  //desbloqueo del usuario si termina la sesión
                Session["IdSesion"] = HttpContext.Current.Session.SessionID;
                Session["Inicio"] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                
                //manejo_sesion.Usuarios.RolAcceso = "Procesos/Promotoria/Default.aspx";
                Response.Redirect(manejo_sesion.Usuarios.RolAcceso, true);
                /*
                if (validaUsuario == 1 || validaUsuario == 3)
                {
                    Propiedades.Sesion psesion = new Propiedades.Sesion();
                    psesion.IdUsuario = manejo_sesion.Usuarios.IdUsuario;
                    manejo_sesion.IdParaCierreSesion = i.administracion.sesion.Agregar(psesion);
                    manejo_sesion.MensajeAdvertencia = mensaje;
                    manejo_sesion.Menu = i.administracion.menu.Seleccionar(manejo_sesion.Usuarios.IdRol); //nueva carga del menú, como es modo texto, ya no hay que cargarlo de nuevo
                    Session["Sesion"] = manejo_sesion;                        //Asignación de la sesión principal del sistema
                    Session["idusuario"] = manejo_sesion.Usuarios.IdUsuario;  //desbloqueo del usuario si termina la sesión
                    Session["IdSesion"] = HttpContext.Current.Session.SessionID;
                    Session["Inicio"] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                    Response.Redirect(manejo_sesion.Usuarios.RolAcceso, true);
                }
                else if (validaUsuario == 2)
                {
                    log.Agregar(txUsuario.Text + " ha intentado ingresar al sistema, ha equivocado su clave o intenta accesar sin autorización.");
                    mensajes.MostrarMensaje(this, mensaje);
                }
                else if (validaUsuario == 4)
                {
                    log.Agregar(txUsuario.Text + " intenta ingresar al sistema pero está bloqueado.");
                    //LblMensajes.Text = "Acceso del usuario se encuentra bloqueado o contraseña vencida. Contacte al administrador. Intentar de nuevo después de " + manejo_sesion.EsperaBloqueo + " minutos.";
                    LoginButton.Enabled = false;
                    LoginButton.CssClass = "btn-block";
                    //Label1.Visible = true;
                    Session["idusuario"] = manejo_sesion.Usuarios.IdUsuario;
                }
                else if (validaUsuario == 5)
                {
                    //LblMensajes.Text = "Acceso bloqueado o contraseña vencida. Contacte al administrador.";
                    LoginButton.Enabled = false;
                    LoginButton.CssClass = "btn-block";
                }
                else if (validaUsuario == 0)
                {
                    //LblMensajes.Text = "El usuario ya se encuentra conectado en el sistema.";
                }
                */
            }
            catch (Exception ex)
            {
                log.Agregar(ex);
            }
        }

        //private void UpdateTimer()
        //{
        //    Label1.Text = DateTime.Now.ToLongTimeString();
        //}

        //protected void Timer1_Tick(object sender, EventArgs e)
        //{
        //    if (0 > DateTime.Compare(DateTime.Now, Funciones.Fechas.ConvertirTextoAFecha(Session["timeout"].ToString())))
        //        Label1.Text = "Quedan " + ((Int32)Funciones.Fechas.ConvertirTextoAFecha(Session["timeout"].ToString()).Subtract(DateTime.Now).TotalMinutes).ToString() + " minutos para desbloquear. <br /> No cierre el navegador.";
        //    else
        //    {
        //        try
        //        {
        //            i.administracion.usuarios.ActualizarDesconectarSesion(Funciones.Nums.TextoAEntero(Session["idusuario"].ToString()), 0, manejo_sesion.IdParaCierreSesion);
        //            Session["idusuario"] = null;
        //            LblMensajes.Text = "";
        //            Label1.Text = "";
        //            Response.Redirect("Default.aspx", true);
        //        }
        //        catch
        //        {
        //        }
        //    }
        //}
    }
}