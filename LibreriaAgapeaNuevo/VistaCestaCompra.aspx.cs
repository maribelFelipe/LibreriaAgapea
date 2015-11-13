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
                recuperarCookie();
                cargarCesta(listaLibrosCesta);
            }

            else
            {
                recuperarCookie();

                cargarCesta(listaLibrosCesta);

                miniControlListaCompra unlibro = (miniControlListaCompra)this.LoadControl("~/controlesUsuario/miniControlListaCompra.ascx");


                foreach (String clave in this.Request.Params)
                {
                    if (clave.Contains("BtSeguirComprando"))
                    {

                    }

                    if (clave.Contains("BtFinCompra"))
                    {

                    }
                    if (clave.Contains("ButtonDelUnit"))
                    {
                        String titulo = clave.Split(':')[2];
                        borrar(listaLibrosCesta, titulo);

                    }
                    if (clave.Contains("ButtonAddUnit"))
                    {
                        unlibro.UnidadesControl += 1;
                    }

                    if (clave.Contains("btBorrar"))
                    {
                        String titulo = clave.Split(':')[1];
                        borrarCesta();
                        borrar(listaLibrosCesta, titulo);
                        cargarCesta(listaLibrosCesta);
                    }
                }
            }
        }


        private void borrar(List<Libro> listaLibrosCesta, String titulo)
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

        private void addUnidad(String titulo, List<Libro> listaLibrosCesta)
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

        private void cargarCesta (List<Libro> listaLibrosCesta)
        {

            for (int i =0; i<listaLibrosCesta.Count;i++)
            { 
          
                miniControlListaCompra unlibro = (miniControlListaCompra)this.LoadControl("~/controlesUsuario/miniControlListaCompra.ascx");

                TableListaCesta.Rows.Add(new TableRow());

                TableCell celda = new TableCell();

                TableListaCesta.Rows[i].Cells.Add(celda);
                unlibro.TituloControl = listaLibrosCesta[i].titulo;
                unlibro.AutorControl = listaLibrosCesta[i].autor;
                unlibro.PrecioControl = listaLibrosCesta[i].precio.ToString();
                

                ((Button)unlibro.FindControl("ButtonDelUnit")).ID += ":" + listaLibrosCesta[i].titulo;
                ((Button)unlibro.FindControl("ButtonAddUnit")).ID += ":" + listaLibrosCesta[i].titulo;
                ((Button)unlibro.FindControl("btBorrar")).ID += ":" + listaLibrosCesta[i].titulo;

                celda.Controls.Add(unlibro);

            }
        }


        public void recuperarCookie()
        {
            HttpCookie cookieCesta = this.Request.Cookies["cesta"];
            String isbnLibrosCesta = cookieCesta.Values.ToString().Split('&')[1].Replace("isbn=", "");
            List<String> isbnsFiltrados = isbnLibrosCesta.Split(new char[] { '-' }).ToList();

            listaLibrosCesta = controladorVistaCesta.buscarLibrosISBN(isbnsFiltrados);
        }

        private void borrarCesta()
        {
            TableListaCesta.Controls.RemoveAt(0);
        }




        protected void recuperarSesion()
        {


            String usuario = (String)this.Request.QueryString["usuario"];
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
            String mensaje = "";


            foreach (String clave in this.Request.Params.Keys)
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