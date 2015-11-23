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
        //private string ficheroUsuarios = "~/Ficheros/usuarios.txt";
        //private string ficheroLibros = "~/Ficheros/librosStock.txt";


        public void AddDatosFichero(string fichero, string datos)
        {
            this.escritorFichero = new StreamWriter(HttpContext.Current.Request.MapPath(fichero), true);
            escritorFichero.WriteLine(datos);
            escritorFichero.Close();

        }


        public List<string> leeDatosFichero(string fichero)
        {
            this.lectorFichero = new StreamReader(HttpContext.Current.Request.MapPath(fichero));

            List<string> listaContenidoFichero = new List<string>();

            listaContenidoFichero = (from unalinea in this.lectorFichero.ReadToEnd().Split(new char[] { '\r', '\n' }).Where(unalinea => unalinea.Length != 0) //.Where(unalinea => !System.Text.RegularExpression.Regex("^$").Math(unalinea).Success)
                                     select unalinea).ToList();

            return listaContenidoFichero;
        }



        public Boolean compruebaExisteDato(string fichero, string dato)
        {
            this.lectorFichero = new StreamReader(HttpContext.Current.Request.MapPath(fichero));

            List<string> listaDatos = new List<string>();
            string linea;

            while ((linea = lectorFichero.ReadLine()) != null)
            {
                char[] separator = { ':' };
                string[] campos = linea.Split(separator);
                listaDatos.Add(campos[1]);

            }

            Boolean encontrado = false;

            foreach (string datoEnLista in listaDatos)
            {
                if (dato.Equals(datoEnLista))
                {
                    encontrado = true;
                }
            }

            lectorFichero.Close();
            return encontrado;
        }

        public bool compruebaExisteDato(string fichero, string dato1, string dato2, int campo1, int campo2)
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