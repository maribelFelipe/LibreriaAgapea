using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibreriaAgapeaNuevo.controlesUsuario
{
    public partial class miniControlListaCompra : System.Web.UI.UserControl
    {

        private string titulo;
        private string autor;
        private string precio;
        private int unidades;

        public string TituloControl
        {
            get { return this.titulo; }
            set
            {
                this.titulo = value;
                this.LinkBtTitulo.Text = this.titulo;
            }

        }

        public string AutorControl
        {
            get { return this.autor;  }
            set
            {
                this.autor = value;
                this.LblAutor.Text = this.autor;
            }
        }

 

        public string PrecioControl
        {
            get { return this.precio; }
            set
            {
                this.precio = value;
                this.LblPrecio.Text = this.precio;
            }
        }

        public int UnidadesControl
        {
            get { return this.unidades; }

            set
            {
                this.unidades = value;
                this.LblUnidades.Text = "";
            }
        }





        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}