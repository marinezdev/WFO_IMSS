﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Administracion
{
    public partial class frmUsuarioOperacion : Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];

            if (!IsPostBack)
            {

            }
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            i.administracion.usuarios.AgregarUsuarioOperacion(txtNombre.Text, txtCorreo.Text, txtClave.Text);
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtClave.Text = "";
            LblMensajes.Text = "Se agregó el usuario.";
        }
    }
}