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
        private String ficheroLibros = "~/Ficheros/librosStock.txt";

        public List<Libro> buscarLibrosISBN(List<String> listaIsbns)
        {

            List<String> listado = new List<String>();
            listado = ficheros.buscarDatoEnFichero(ficheroLibros, listaIsbns, 4);

            List<Libro> listaLibros = new List<Libro>();

            for (int i = 0; i < listado.Count; i++)
            {
                char[] separator = { ':' };
                String[] campos = listado[i].Split(separator);

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