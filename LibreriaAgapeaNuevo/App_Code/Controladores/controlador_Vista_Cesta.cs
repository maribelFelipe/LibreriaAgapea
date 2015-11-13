using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibreriaAgapeaNuevo.App_Code.Modelos;
using LibreriaAgapeaNuevo.App_Code.Controladores;


namespace LibreriaAgapeaNuevo.App_Code.Controladores
{

    public class controlador_Vista_Cesta
    {
        private controlador_Acceso_Ficheros ficheros = new controlador_Acceso_Ficheros();
        private string ficheroLibros = "~/Ficheros/librosStock.txt";

        public List<Libro> buscarLibrosISBN(List<string> listaIsbns)
        {

            List<string> listado = ficheros.leeDatosFichero(ficheroLibros);
            List<string> listadoFiltrado = new List<string>();

            foreach (string linea in listaIsbns)
            {
                if (linea != null)
                {
                    string encontrado = (from unalinea in listado
                                         let isbn = unalinea.Split(new char[] { ':' })[4]
                                         where isbn == linea
                                         select unalinea).SingleOrDefault();

                    listadoFiltrado.Add(encontrado);
                }

            }

        

            List<Libro> listaLibros = new List<Libro>();

            for (int i = 0; i < listadoFiltrado.Count; i++)
            {
                
                string[] campos = listadoFiltrado[i].Split(new char[] { ':' });

                Libro libro = new Libro();

                libro.titulo = campos[0];
                libro.autor = campos[1];
                libro.editorial = campos[2];
                libro.numPaginas = int.Parse(campos[3]);
                libro.ISBN10 = campos[4];
                libro.ISBN13 = campos[5];
                libro.precio = double.Parse(campos[6]);
                libro.categoria = campos[7];
                libro.subcategoria = campos[8];
                libro.resumen = campos[9];

                listaLibros.Add(libro);
            }

            return listaLibros;




        }
    }
}