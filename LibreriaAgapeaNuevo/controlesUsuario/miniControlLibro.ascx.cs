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


    }
}