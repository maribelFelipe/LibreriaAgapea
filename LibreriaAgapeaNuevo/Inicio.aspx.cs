using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibreriaAgapeaNuevo.App_Code.Modelos;
using LibreriaAgapeaNuevo.App_Code.Controladores;
using LibreriaAgapeaNuevo.controlesUsuario;
using System.Text.RegularExpressions;


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
            TextBox buscador = (TextBox)this.Master.FindControl("TxtBxBuscador");



            if (!this.IsPostBack)
            {
                listaLibros = controladorVistaInicio.devuelveLibros();
                cargarTabla(listaLibros);

            }

            else
            {
               
                    #region ----- Postback del TreeView

                    if (this.Request.Params.GetValues("__EVENTTARGET")[0] == "ctl00$TreeViewCategorias")
                    {
                        string valueNodoTreeview = this.Request.Params.GetValues("__EVENTARGUMENT")[0].ToString();
                        List<Libro> LibrosCat = new List<Libro>();

                        if (valueNodoTreeview.Contains("scategoria"))
                        {

                            if ((valueNodoTreeview.Contains("subcategoria")))
                            {
                                LibrosCat = controladorVistaInicio.BuscarLibrosCategoria("subcategoria", (valueNodoTreeview.Split(new char[] { '\\' })[1]).Split(new char[] { ':' })[1]).ToList();

                            }

                            else
                            {
                                LibrosCat = controladorVistaInicio.BuscarLibrosCategoria("categoria", valueNodoTreeview.Split(new char[] { ':' })[1]).ToList();

                            }

                            cargarTabla(LibrosCat);

                        }
                    }
                    #endregion




                    #region-------Postback de titulo de un libro
                    else if (this.Request.Params["__EVENTTARGET"].Contains("linkbttitulo"))
                    {
                        string isbn_seleccionado = ((string)this.Request.Params["__EVENTTARGET"]).Split('$')[3].Replace("linkbttitulo", "");

                        List<Libro> listaConLibroISBN = new List<Libro>();
                        listaLibros = controladorVistaInicio.devuelveLibros();

                        listaConLibroISBN = (from otrolibro in listaLibros
                                             let isbnFiltrado = otrolibro.ISBN10
                                             where isbnFiltrado.Equals(isbn_seleccionado)
                                             select otrolibro).ToList();

                        cargarTabla(listaConLibroISBN);

         
                    }
                    #endregion

                    #region------- Postback buscador
                    else if (this.Request.Params.Keys.Cast<String>().Contains("ctl00$RadioBtBuscar"))
                    {
                        string filtro = ((RadioButtonList)this.Master.FindControl("RadioBtBuscar")).SelectedItem.Text;
                        string valor = ((TextBox)this.Master.FindControl("TxtBxBuscador")).Text;

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
                                break;

                            case "Autor":
                                listaLibrosFiltrado = (from otrolibro in listaLibros
                                                       let autorFiltrado = otrolibro.autor
                                                       where autorFiltrado.Contains(valor)
                                                       select otrolibro).ToList();
                                break;

                            case "ISBN":
                                listaLibrosFiltrado = (from otrolibro in listaLibros
                                                       let ISBNFiltrado = otrolibro.ISBN10
                                                       where ISBNFiltrado.Contains(valor)
                                                       select otrolibro).ToList();
                                break;

                            case "Editorial":
                                listaLibrosFiltrado = (from otrolibro in listaLibros
                                                       let EditorialFiltrado = otrolibro.editorial
                                                       where EditorialFiltrado.Contains(valor)
                                                       select otrolibro).ToList();
                                break;
                        }
                        cargarTabla(listaLibrosFiltrado);
                        buscador.Text = "";
                    }
                    #endregion

                    #region ------- Postback boton comprar 


                    else
                    {

                    foreach (String clave in this.Request.Params)
                    {
                        if (clave.Contains("btcomprar"))
                        {
                            string isbn_seleccionado = clave.Split('$')[3].Replace("btcomprar", "");
                            
                            HttpCookie cookieCesta;

                            try
                            {
                                cookieCesta = this.Request.Cookies["cesta"];
                                string todosIsbns = clave.Split('=')[2];
                            
                                cookieCesta.Values["isbn"] += "-" + isbn_seleccionado;
                             
                            }
                            catch
                            {
                                cookieCesta = new HttpCookie("cesta");

                                if (this.Request.QueryString["usuario"] != null)
                                {
                                    cookieCesta.Values["usuario"] = (String)this.Request.QueryString["usuario"];
                                    cookieCesta.Values["isbn"] = isbn_seleccionado + ":1" ;
                                }

                                else
                                {
                                    cookieCesta.Values["usuario"] = "Anonimo";
                                    cookieCesta.Values["isbn"] = isbn_seleccionado;
                                }

                               
                            }

                            cookieCesta.Values["lastVisit"] = DateTime.Now.ToString();
                            cookieCesta.Expires = DateTime.Now.AddDays(1);
                            Response.Cookies.Add(cookieCesta);

                            this.Response.Cookies.Add(cookieCesta);
                            this.Response.Redirect("VistaCestaCompra.aspx");
                        }
                    }

                    #endregion




                }

            }
        }



        private void cargarTabla(List<Libro> listaLibros)
        {
            if (listaLibros.Count == 1)
            {
                miniControlLibroSeleccionado unlibro = (miniControlLibroSeleccionado)this.LoadControl("~/controlesUsuario/miniControlLibroSeleccionado.ascx");

                miTablaInicio.Rows.Add(new TableRow());
                TableCell celda = new TableCell();

                miTablaInicio.Rows[0].Cells.Add(celda);

                unlibro.TituloControl = listaLibros[0].titulo;
                unlibro.EditorialControl = listaLibros[0].editorial;
                unlibro.AutorControl = listaLibros[0].autor;
                unlibro.PrecioControl = listaLibros[0].precio.ToString();
                unlibro.ISBN10Control = listaLibros[0].ISBN10;
                unlibro.ISBN13Control = listaLibros[0].ISBN13;
                unlibro.NumPaginasControl = listaLibros[0].numPaginas.ToString();
                unlibro.ResumenControl = listaLibros[0].resumen;

                celda.Controls.Add(unlibro);
            }


            else { 
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

                        ((LinkButton)unlibro.FindControl("linkbttitulo")).ID += listaLibros[contador].ISBN10.ToString();
                        ((Button)unlibro.FindControl("btcomprar")).ID += listaLibros[contador].ISBN10.ToString(); 

                        celda.Controls.Add(unlibro);

                        contador += 1;
                    }

                    
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

    }
}