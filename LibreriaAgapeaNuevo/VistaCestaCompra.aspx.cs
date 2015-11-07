using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibreriaAgapeaNuevo
{
    public partial class VistaCestaCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            recuperarSesion();
            mostrar();



        }

        
        protected void recuperarSesion()
        {

            Label usuarioRegistrado = (Label)this.Master.FindControl("LabelUsuarioRegistrado");

            String usuario = (String)this.Request.QueryString["usuario"];
            if (usuario != null)
            {
                usuarioRegistrado.Text = "Usuario: " + usuario;

            }
            else
            {
                usuarioRegistrado.Text = "";
            }

        }
       

        private void mostrar()
        {
            String mensaje = "";

            TextBox TxtBoxVariables = (TextBox)this.Master.FindControl("TxtBoxVariables");

            foreach (String clave in this.Request.Params.Keys)
            {
                mensaje += "clave:_" + clave + "--------------valor:_" + this.Request.Params[clave].ToString() + "\n";
            }

            TxtBoxVariables.Text = mensaje;
        }
    }
}