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
    public partial class Inicio : System.Web.UI.Page
    {
        private controlador_Vista_Inicio controladorVistaInicio = new controlador_Vista_Inicio();
        private List<Libro> listaLibros = new List<Libro>();
        



        protected void Page_Load(object sender, EventArgs e)
        {
            recuperarSesion();
            mostrar();
            


            if (!this.IsPostBack)
            {
                listaLibros = controladorVistaInicio.devuelveLibros();
                cargarTabla(listaLibros);
         
            }

            else
            { //hay postback, no es la 1º vez que se carga la pagina pq ha habido algun evento sobre algun componente de la pagina...detectamos si es del treeview

                //TreeView arbolMaster = (TreeView)this.Master.FindControl("TreeViewCategorias");

                //string valueNodoTreeview = this.Request.Params.GetValues("__EVENTARGUMENT")[0].ToString();

                String eventarget = this.Request.Params.GetValues("__EVENTTARGET")[0];

                List<Libro> librosInformatica = controladorVistaInicio.BuscarLibrosCategoria("categoria", "Informatica");

                switch (this.Request.Params.GetValues("__EVENTTARGET")[0])
                {
                    case "ctl00$TreeViewCategorias": //lo ha provocado un nodo del treeview, viendo el __EVENTARGUMENTS se si es una categoria o una subcategoria:
                        string valueNodoTreeview = this.Request.Params.GetValues("__EVENTARGUMENT")[0].ToString();
                        List<Libro> LibrosCat = valueNodoTreeview.Contains("scategoria") ? controladorVistaInicio.BuscarLibrosCategoria("categoria", valueNodoTreeview.Split(new char[] { ':' })[1]) :
                                                controladorVistaInicio.BuscarLibrosCategoria("categoria", valueNodoTreeview.Split(new char[] { ':' })[2]);
                        cargarTabla(LibrosCat);
                        break;

                   
                }

            };



        }



        private void cargarTabla(List<Libro> listaLibros)
        {
            int contador = 0;

            for (int i = 0; i < 6; i++)
            {
                miTablaInicio.Rows.Add(new TableRow());


                for (int j = 0; j < 2; j++)
                {

                    if (contador < listaLibros.Count)
                    {

                        miniControlLibro unlibro = (miniControlLibro)this.LoadControl("~/controlesUsuario/miniControlLibro.ascx");
                        TableCell celda = new TableCell();

                        miTablaInicio.Rows[i].Cells.Add(celda);
                        unlibro.TituloControl = listaLibros[contador].titulo;
                        unlibro.AutorControl = listaLibros[contador].autor;
                        unlibro.EditorialControl = listaLibros[contador].editorial;
                        unlibro.ISBNControl = listaLibros[contador].ISBN10;
                        unlibro.PrecioControl = listaLibros[contador].precio.ToString();

                        celda.Controls.Add(unlibro);


                        contador += 1;
                    }

                    
                }


            }
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





        protected void BtBuscador_Click(object sender, EventArgs e)
        {
            if (RadioBtBuscar.SelectedItem != null)
            {
                // --- Cogemos nombre del radiobutton y valor introducido en el en textoboxbuscar ------
                string filtro = RadioBtBuscar.SelectedValue; // valores: autor, titulo, editorial, isbn
                string valor = TxtBxBuscador.Text; // valor introducido por el usuario


                // ---- cargo lista de todos los libros disponibles ----------
                listaLibros = controladorVistaInicio.devuelveLibros();


                //--- lista que contendrá los libros filtrados --------
                List<Libro> listaLibrosFiltrado = new List<Libro>();

                switch (filtro)
                {
                    case "Titulo":

                        listaLibrosFiltrado = (from otrolibro in listaLibros
                                               let tituloFiltrado = otrolibro.titulo
                                               where tituloFiltrado.Contains(valor)
                                               select otrolibro).ToList();

                        cargarTabla(listaLibrosFiltrado);
                        TxtBxBuscador.Text = "";
                                             
                    break;

                    case "Autor":
                        listaLibrosFiltrado = (from otrolibro in listaLibros
                                               let autorFiltrado = otrolibro.autor
                                               where autorFiltrado.Contains(valor)
                                               select otrolibro).ToList();

                        cargarTabla(listaLibrosFiltrado);
                        TxtBxBuscador.Text = "";
                        break;

                    case "ISBN":
                        listaLibrosFiltrado = (from otrolibro in listaLibros
                                               let ISBNFiltrado = otrolibro.ISBN10
                                               where ISBNFiltrado.Contains(valor)
                                               select otrolibro).ToList();

                        cargarTabla(listaLibrosFiltrado);
                        TxtBxBuscador.Text = "";
                        break;

                    case "Editorial":
                        listaLibrosFiltrado = (from otrolibro in listaLibros
                                               let EditorialFiltrado = otrolibro.editorial
                                               where EditorialFiltrado.Contains(valor)
                                               select otrolibro).ToList();

                        cargarTabla(listaLibrosFiltrado);
                        TxtBxBuscador.Text = "";
                        break;
                }
            }
        }

    }
}