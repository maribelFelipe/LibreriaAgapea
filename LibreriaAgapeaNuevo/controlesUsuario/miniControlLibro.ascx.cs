using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibreriaAgapeaNuevo.App_Code.Modelos;
using LibreriaAgapeaNuevo.App_Code.Controladores;

namespace LibreriaAgapeaNuevo.controlesUsuario
{
    public partial class miniControlLibro : System.Web.UI.UserControl
    {

        private controlador_Vista_Inicio controladorVistaInicio = new controlador_Vista_Inicio();

        #region ------ propiedades de mis controles ---------------

        private string _titulo;
        private string _editorial;
        private string _autor;
        private string _isbn;
        private string _precio;

        public string TituloControl
        {
            get { return this._titulo; }
            set
            {
                this._titulo = value;
                this.linkbttitulo.Text = this._titulo;
            }

        }

        public string AutorControl
        {
            get { return this._autor; }
            set
            {
                this._autor = value;
                this.lblautor.Text = this._autor;
            }
        }

        public string EditorialControl
        {
            get { return this._editorial; }
            set
            {
                this._editorial = value;
                this.lbleditorial.Text = this._editorial;
            }
        }

        public string ISBNControl
        {
            get { return this._isbn; }
            set
            {
                this._isbn = value;
                this.lblisbn.Text = this._editorial;
            }
        }

        public string PrecioControl
        {
            get { return this._precio; }
            set
            {
                this._precio = value;
                this.lblprecio.Text = this._precio;
            }
        }
        #endregion

        #region -------constructrores---------

        public miniControlLibro() { }

        public miniControlLibro(Libro unLibro)
        {
            this.TituloControl = unLibro.titulo;
            this.AutorControl = unLibro.autor;
            this.EditorialControl = unLibro.editorial;
            this.PrecioControl = unLibro.precio.ToString();
            this.ISBNControl = unLibro.ISBN10;

        }

  
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void linkbttitulo_Click(object sender, EventArgs e)
        {


            miniControlLibroSeleccionado unlibro = (miniControlLibroSeleccionado)this.LoadControl("~/controlesUsuario/miniControlLibroSelecionado.ascx");

            List<Libro> listaLibros = new List<Libro>();
            listaLibros = controladorVistaInicio.devuelveLibros();

            Libro libro = new Libro();

            libro = (from otrolibro in listaLibros
                     let tituloFiltrado = otrolibro.titulo
                     where tituloFiltrado == linkbttitulo.Text
                     select otrolibro).Single();


            unlibro.TituloControl = libro.titulo;
            unlibro.EditorialControl = libro.editorial;
            unlibro.AutorControl = libro.autor;
            unlibro.PrecioControl = libro.precio.ToString();
            unlibro.ISBN10Control = libro.ISBN10;
            unlibro.ISBN13Control = libro.ISBN13;
            unlibro.NumPaginasControl = libro.numPaginas.ToString();
            unlibro.ResumenControl = libro.resumen;



        }
    }
}