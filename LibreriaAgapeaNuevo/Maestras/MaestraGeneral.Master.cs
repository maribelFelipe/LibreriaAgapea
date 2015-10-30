using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibreriaAgapeaNuevo.App_Code.Modelos;
using LibreriaAgapeaNuevo.App_Code.Controladores;


namespace LibreriaAgapeaNuevo.Maestras
{
    public partial class MaestraGeneral : System.Web.UI.MasterPage
    {
        private Dictionary<String, Libro> coleccionLibros;

        protected void Page_Load(object sender, EventArgs e)
        {
            //-------- carga del TreeView ---------
            controlador_Vista_Inicio controlVistaInicio = new controlador_Vista_Inicio();
            coleccionLibros = controlVistaInicio.RecuperarLibrosMasVendidos();

            if (!this.IsPostBack)
            {
                CargaTreeView(controlVistaInicio.RecuperarCatySub());
                
            }

 
        }

        private void CargaTreeView(Dictionary<String, List<String>> datos)
        {
            datos.Keys.ToList().ForEach(valor => TreeViewCategorias.Nodes.Add(new TreeNode() { Text = valor, Value = "categoria:" + valor })); //...asi creamos los nodos principales
            datos.Keys.ToList().ForEach(delegate (String cat)
            {
                datos[cat].ForEach(subcategoria => TreeViewCategorias.FindNode("categoria:" + cat).ChildNodes.Add(new TreeNode() { Text = subcategoria, Value = "subcategoria:" + subcategoria }));
            }); //...asi añadimos las subcategorias a cada nodo del treeview que representa una categoria...

        }

       
    }
}