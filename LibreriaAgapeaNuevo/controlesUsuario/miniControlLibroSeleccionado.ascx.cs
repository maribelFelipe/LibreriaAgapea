using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibreriaAgapeaNuevo.App_Code.Modelos;

namespace LibreriaAgapeaNuevo.controlesUsuario
{
    public partial class miniControlLibroSeleccionado : System.Web.UI.UserControl
    {

        #region ------ propiedades de mis controles ---------------

        private string _titulo;
        private string _editorial;
        private string _autor;
        private string _numPaginas;
        private string _isbn10;
        private string _isbn13;
        private string _precio;
        private string _resumen;

        public string TituloControl
        {
            get { return this._titulo; }
            set
            {
                this._titulo = value;
                this.lbltitulo.Text = this._titulo;
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

        public string ISBN10Control
        {
            get { return this._isbn10; }
            set
            {
                this._isbn10 = value;
                this.lblisbn10.Text = this._isbn10;
            }
        }

        public string ISBN13Control
        {
            get { return this._isbn13; }
            set
            {
                this._isbn13 = value;
                this.lblisbn13.Text = this._isbn13;
            }
        }

        public string ResumenControl
        {
            get { return this._resumen; }
            set
            {
                this._resumen = value;
                this.lblResumen.Text = this._resumen;
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

        public string NumPaginasControl
        {
            get { return this._numPaginas; }
            set
            {
                this._numPaginas = value;
                this.lblNumPaginas.Text = this._numPaginas;
            }
        }
        #endregion

        #region -------constructrores---------

        public miniControlLibroSeleccionado() { }

        public miniControlLibroSeleccionado(Libro unLibro)
        {
            this.TituloControl = unLibro.titulo;
            this.AutorControl = unLibro.autor;
            this.EditorialControl = unLibro.editorial;
            this.PrecioControl = unLibro.precio.ToString();
            this.ISBN10Control = unLibro.ISBN10;
            this.ISBN13Control = unLibro.ISBN13;
            this.ResumenControl = unLibro.resumen;
            this.NumPaginasControl = unLibro.numPaginas.ToString();

        }


        #endregion




        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}