using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spire.Pdf;
using System.Threading.Tasks;
using LibreriaAgapeaNuevo.App_Code.Modelos;
using System.Text;





namespace LibreriaAgapeaNuevo.App_Code.Controladores
{
    public class controlador_generar_PDF
    {

        public PdfDocument CrearDocPDF(Dictionary<String, Libro> coleccionLibrosCesta)
        {
            String factura = GenerarFacturaEnHtml(coleccionLibrosCesta);
            PdfDocument mifactura = new PdfDocument();
            Task generarPDF = new Task(() => mifactura.LoadFromHTML(factura, false, true, true));
            generarPDF.Start();

            // Hay que guardar el fichero en el servidor
            // llamar a mifactura.SaveToFile("nombre_fichero.pdf")
            // pasar la ruta en el controlador_Email

            generarPDF.Wait(); // Aseguramos que el hilo acabe antes de retornarlo
      
            return mifactura;
        }


        private String GenerarFacturaEnHtml (Dictionary<String,Libro> coleccionLibrosCesta)
        {
            //Documento html
            StringBuilder miDocHtml = new StringBuilder();
            miDocHtml.Append("<html><head><tittle>Factura</tittle></head><body>");
            miDocHtml.Append("<img src=' " + HttpContext.Current + "' />");
        }
    }
}