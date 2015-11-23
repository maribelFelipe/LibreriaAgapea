using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibreriaAgapeaNuevo.App_Code.Modelos;
using LibreriaAgapeaNuevo.App_Code.Controladores;
using LibreriaAgapeaNuevo.controlesUsuario;

namespace LibreriaAgapeaNuevo
{
    public partial class VistaCestaCompra : System.Web.UI.Page
    {
        private controlador_Vista_Cesta controladorVistaCesta = new controlador_Vista_Cesta();
        private List<Libro> listaLibrosCesta = new List<Libro>();


        protected void Page_Load(object sender, EventArgs e)
        {
            recuperarSesion();
            mostrar();

            if (!this.IsPostBack)
            {
                cargarCesta();
            }

            else
            {
                cargarCesta();

                miniControlListaCompra unlibro = (miniControlListaCompra)this.LoadControl("~/controlesUsuario/miniControlListaCompra.ascx");


                foreach (string clave in this.Request.Params)
                {
                    if (clave.Contains("BtSeguirComprando"))
                    {

                    }

                    if (clave.Contains("BtFinCompra"))
                    {

                    }
                    if (clave.Contains("ButtonDelUnit"))
                    {
                        string titulo = clave.Split(':')[2];
                        borrar(listaLibrosCesta, titulo);

                    }
                    if (clave.Contains("ButtonAddUnit"))
                    {
                        unlibro.UnidadesControl += 1;
                    }

                    if (clave.Contains("btBorrar"))
                    {
                        string titulo = clave.Split(':')[1];
                        borrarCesta();
                        borrar(listaLibrosCesta, titulo);
                        cargarCesta();
                    }
                }
            }
        }


        private void borrar(List<Libro> listaLibrosCesta, string titulo)
        {
            Libro libro = new Libro();

            foreach(Libro unlibro in listaLibrosCesta)
            {
                libro = (from linea in listaLibrosCesta
                         let tituloFiltro = linea.titulo
                         where tituloFiltro == titulo
                         select linea).SingleOrDefault();
            }

            listaLibrosCesta.Remove(libro);
        }

        private void addUnidad(string titulo, List<Libro> listaLibrosCesta)
        {
            Libro libro = new Libro();

            foreach (Libro unlibro in listaLibrosCesta)
            {
                libro = (from linea in listaLibrosCesta
                         let tituloFiltro = linea.titulo
                         where tituloFiltro == titulo
                         select linea).SingleOrDefault();        
            }

           

        }

        private void cargarCesta ()
        {
            HttpCookie cookieCesta = this.Request.Cookies["cesta"];

            // isbn:cant-isbn:cant-isbn:cant
            string isbnLibrosCesta = cookieCesta.Value.ToString().Split('&')[1].Replace("isbn=", "");

            // Lista en la que cada elemento es isbn:cant
            List<string> isbnsFiltrados = isbnLibrosCesta.Split(new char[] { '-' }).ToList();


            double importeLibros = 0;
            double importeGastosEnvio = 3.50;
            double total = 0; 

            for (int i = 0 ; i < isbnsFiltrados.Count ; i++)
            {

                Libro libroCesta = controladorVistaCesta.buscarUnLibro(isbnsFiltrados[i].Substring(0, 10));
                int cantidad = int.Parse(isbnsFiltrados[i].Substring(11));

                miniControlListaCompra unlibro = (miniControlListaCompra)this.LoadControl("~/controlesUsuario/miniControlListaCompra.ascx");

                TableListaCesta.Rows.Add(new TableRow());
                TableCell celda = new TableCell();
                TableListaCesta.Rows[i].Cells.Add(celda);

                unlibro.TituloControl = libroCesta.titulo;
                unlibro.AutorControl = libroCesta.autor;
                unlibro.PrecioControl = (libroCesta.precio * cantidad).ToString();
                unlibro.UnidadesControl = cantidad;

                importeLibros += double.Parse(unlibro.PrecioControl);

                ((Button)unlibro.FindControl("ButtonDelUnit")).ID += ":" + libroCesta.ISBN10 + ":" + cantidad;
                ((Button)unlibro.FindControl("ButtonAddUnit")).ID += ":" + libroCesta.ISBN10 + ":" + cantidad;
                ((Button)unlibro.FindControl("btBorrar")).ID += ":" + libroCesta.ISBN10;

                celda.Controls.Add(unlibro);

            }

            lblImporteLibros.Text = importeLibros.ToString();
            LblGastosEnvio.Text = importeGastosEnvio.ToString();
            LblTotal.Text = (importeLibros + importeGastosEnvio).ToString();

        }


        private void borrarCesta()
        {
            TableListaCesta.Controls.RemoveAt(0);
        }




        protected void recuperarSesion()
        {


            string usuario = (string)this.Request.QueryString["usuario"];
            if (usuario != null)
            {
                LabelUsuarioRegistrado.Text = "Usuario: " + usuario;

            }
            else
            {
                LabelUsuarioRegistrado.Text = "";
            }

        }
       

        private void mostrar()
        {
            string mensaje = "";


            foreach (string clave in this.Request.Params.Keys)
            {
                mensaje += "clave:_" + clave + "--------------valor:_" + this.Request.Params[clave].ToString() + "\n";
            }

            TxtBoxVariables.Text = mensaje;
        }

        protected void BtFinCompra_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void BtSeguirComprando_Click(object sender, ImageClickEventArgs e)
        {
           
        }
    }
}