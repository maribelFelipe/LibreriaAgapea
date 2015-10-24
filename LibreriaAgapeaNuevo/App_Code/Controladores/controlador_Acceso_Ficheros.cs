using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using LibreriaAgapeaNuevo.App_Code.Modelos;


namespace LibreriaAgapeaNuevo.App_Code.Controladores
{
    public class controlador_Acceso_Ficheros
    {
        private StreamReader lectorFichero;
        private StreamWriter escritorFichero;
        //private String ficheroUsuarios = "~/Ficheros/usuarios.txt";
        //private String ficheroLibros = "~/Ficheros/librosStock.txt";


        public void AddDatosFichero(String fichero, String datos)
        {
            this.escritorFichero = new StreamWriter(HttpContext.Current.Request.MapPath(fichero), true);
            escritorFichero.WriteLine(datos);
            escritorFichero.Close();

        }


        public string[] LeerDatos(String fichero, string filtro, int numcampo)
        {

            this.lectorFichero = new StreamReader(HttpContext.Current.Request.MapPath(fichero));

            string[] lineas = new string[] { };

            switch (filtro)
            {



                case "categoria":

                    //-----con LINQ con QUERY-----

                    lineas = (from unalinea in this.lectorFichero.ReadToEnd().Split(new char[] { '\n' })
                              let categoriaLinea = unalinea.Split(new char[] { ':' })[numcampo]
                              where categoriaLinea == filtro
                              select unalinea).ToArray();

                    /*-------con LINQ extendido, filtro lineas por una categoria----
                    lineas = this.lectorFichero.ReadToEnd().Split(new char[] { '\n' }).Where(linea => linea.Split(new char[] { ':' })[numcampo] == filtro).ToArray();
                    return lineas;*/
                    break;





            }
            return lineas;

        }



        public List<String> leeDatosFichero(String fichero)
        {
            this.lectorFichero = new StreamReader(HttpContext.Current.Request.MapPath(fichero));

            List<String> listaContenidoFichero = new List<String>();

            listaContenidoFichero = (from unalinea in this.lectorFichero.ReadToEnd().Split(new char[] { '\r', '\n' }).Where(unalinea => unalinea.Length != 0) //.Where(unalinea => !System.Text.RegularExpression.Regex("^$").Math(unalinea).Success)
                                     select unalinea).ToList();

            return listaContenidoFichero;
        }



        public Boolean compruebaExisteDato(String fichero, String dato)
        {
            this.lectorFichero = new StreamReader(HttpContext.Current.Request.MapPath(fichero));

            List<String> listaDatos = new List<string>();
            String linea;

            while ((linea = lectorFichero.ReadLine()) != null)
            {
                char[] separator = { ':' };
                String[] campos = linea.Split(separator);
                listaDatos.Add(campos[1]);

            }

            Boolean encontrado = false;

            foreach (String datoEnLista in listaDatos)
            {
                if (dato.Equals(datoEnLista))
                {
                    encontrado = true;
                }
            }

            lectorFichero.Close();
            return encontrado;
        }

        public bool compruebaExisteDato(String fichero, String dato1, String dato2, int campo1, int campo2)
        {
            this.lectorFichero = new StreamReader(HttpContext.Current.Request.MapPath(fichero));


            bool resultadoBusqueda = (from unalinea in lectorFichero.ReadToEnd().Split(new char[] { '\r', '\n' }).Where(unalinea => unalinea.Length != 0) //.Where(unalinea => !System.Text.RegularExpression.Regex("^$").Math(unalinea).Success)
                                      let campo1Buscado = unalinea.Split(new char[] { ':' })[campo1]
                                      let campo2Buscado = unalinea.Split(new char[] { ':' })[campo2]
                                      where campo1Buscado == dato1 && campo2Buscado == dato2
                                      select true).Single();

            return resultadoBusqueda;

        }

    }
}