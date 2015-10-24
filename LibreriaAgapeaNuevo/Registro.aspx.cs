using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibreriaAgapeaNuevo.App_Code.Controladores;


namespace LibreriaAgapeaNuevo
{
    public partial class Registro : System.Web.UI.Page
    {
        
        private controlador_Vista_Registro controladorVistaRegistro = new controlador_Vista_Registro();


        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!this.CheckBoxPolitica.Checked) args.IsValid = false;
        }



        protected void BtRegistro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Validate("registroNuevo");

            if (IsValid)
            {

                String nombreUsuario = TextBoxUsuario.Text;
                String email = TextBoxMail.Text;
                String passw = TextBoxPassw1.Text;
                String nombre = TextBoxNombre.Text;
                String apellidos = TextBoxApellidos.Text;

                controladorVistaRegistro.GrabarDatosUsuario(nombreUsuario, email, passw, nombre, apellidos);

                limpiar();

                this.Response.Redirect("inicio.aspx?usuario=" + nombreUsuario);

            }

        }


        protected void limpiar()
        {
            TextBoxUsuario.Text = "";
            TextBoxMail.Text = "";
            TextBoxNombre.Text = "";
            TextBoxApellidos.Text = "";
            CheckBoxPolitica.Checked = false;

        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {

            String email = TextBoxMail.Text;
            if (controladorVistaRegistro.compruebaExisteEmailFichero(email))
            {
                args.IsValid = false;
            }

        }

        protected void CValLongitudPassw_ServerValidate(object source, ServerValidateEventArgs args)
        {

            String passw = TextBoxPassw1.Text;

            if (passw.Length < 8)
            {
                args.IsValid = false;
            }
        }


        protected void BtIDentificar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Validate("inicioSesion");

            if (IsValid)
            {
                this.Response.Redirect("inicio.aspx?usuario=" + usuarioRegistrado.Text);
            }
        }

        protected void CustomValidator2_ServerValidate1(object source, ServerValidateEventArgs args)
        {

            if (controladorVistaRegistro.compruebaExisteUsuario(usuarioRegistrado.Text, passwRegistrado.Text))
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }


        }

    }
    
}