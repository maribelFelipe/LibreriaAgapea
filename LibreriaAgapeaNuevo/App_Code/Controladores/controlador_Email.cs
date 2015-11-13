using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibreriaAgapeaNuevo.App_Code.Controladores;
using System.Net.Mail;
using LibreriaAgapeaNuevo.App_Code.Modelos;

namespace LibreriaAgapeaNuevo.App_Code.Controladores
{
    public class controlador_Email
    {

        public bool MandarEmail(Usuario user)
        {
            //MailMessage mensajeEnviado = this.CrearEmail(user);
            SmtpClient server = new SmtpClient("smtp.gmail.com", 587);

            try
            {
                //server.Send(mensajeEnviado);
                return true;
            }
            catch
            {
                return false;
            }
            
        }

       /* private MailMessage CrearEmail(Usuario user)
        {
            //Dictionary<string, Libro> librosCarrito = user.obtenerCarrito();
            controlador_generar_PDF generadorFactura = new controlador_generar_PDF();

            MailMessage mail = new MailMessage();
            mail.To.Add(new MailAddress(user.email));
            mail.From = new MailAddress("agapea@agapea.com");
            mail.Subject = "Factura con fecha:";
            //mail.Attachments.Add(new Attachment(generadorFactura.CrearDocPDF(librosCarrito));

        }*/
    }
}