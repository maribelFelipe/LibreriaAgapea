using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibreriaAgapeaNuevo.App_Code.Modelos;

namespace LibreriaAgapeaNuevo.App_Code.Controladores
{
    public class controlador_Vista_Inicio
    {
        private String ficheroLibros = "~/Ficheros/librosStock.txt";
        private controlador_Acceso_Ficheros ficheros = new controlador_Acceso_Ficheros();


        public List<Libro> devuelveLibros()
        {

            List<String> listado = new List<String>();
            listado = ficheros.leeDatosFichero(ficheroLibros);

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


        public Dictionary<String, List<string>> RecuperarCatySub()
        {
            Dictionary<string, List<string>> CategoriasySubcategorias = new Dictionary<string, List<string>>();
            List<string> filas = ficheros.leeDatosFichero(ficheroLibros);


            List<string> catysubcat = filas.Select(f => f.Split(new char[] { ':' })[7] + ":" + f.Split(new char[] { ':' })[8]).Distinct().ToList();


            foreach (string tupla in catysubcat)
            {
                string categoria = tupla.Split(new char[] { ':' })[0];

                if (!CategoriasySubcategorias.Keys.Contains(categoria))
                {
                    List<string> subcategorias = (from elemento in catysubcat
                                                  where categoria == elemento.Split(new char[] { ':' })[0].ToString()
                                                  select elemento.Split(new char[] { ':' })[1]).ToList();


                    CategoriasySubcategorias.Add(categoria, subcategorias);
                }

            }
            return CategoriasySubcategorias; //<---devuelvo algo asi: [ "Informatica", ["Programacion","Bases de Datos",...],    "Derecho",["Derecho Penal","Derecho Civil",.... ] .... ]
        }



        public Dictionary<String, Libro> RecuperarLibrosMasVendidos()
        {
            Dictionary<String, Libro> coleccionLibros = new Dictionary<String, Libro>();

            foreach (String libro in ficheros.leeDatosFichero(ficheroLibros))
            {
                string[] campos = libro.Split(new char[] { ':' });
                coleccionLibros.Add(campos[5], new Modelos.Libro()
                {
                    titulo = campos[0],
                    autor = campos[1],
                    editorial = campos[2],
                    numPaginas = Convert.ToInt16(campos[3]),
                    ISBN10 = campos[4],
                    ISBN13 = campos[5],
                    precio = Convert.ToDouble(campos[6]),
                    categoria = campos[7],
                    subcategoria = campos[8],
                    resumen = campos[9]
            });
            }
            return coleccionLibros;
        }




        public List<Libro> BuscarLibrosCategoria(string criterio, string valor)
        {
            Func<string, bool> Filtro;

            if (criterio == "categoria") {
                Filtro = delegate (string fila) { return fila.Split(new char[] { ':' })[7] == valor; };
            }

            else {
                Filtro = delegate (string fila) { return fila.Split(new char[] { ':' })[8] == valor; };
            };
    

            return ficheros.leeDatosFichero(ficheroLibros).Where(Filtro).Select(delegate (string linea)
            {
                string[] campos = linea.Split(new char[] { ':' });
                return new Libro()
                {
                    titulo = campos[0],
                    autor = campos[1],
                    editorial = campos[2],
                    numPaginas = Convert.ToInt16(campos[3]),
                    ISBN10 = campos[4],
                    ISBN13 = campos[5],
                    precio = Convert.ToDouble(campos[6]),
                    categoria = campos[7],
                    subcategoria = campos[8],
                    resumen = campos[9]
                };
            }).ToList();
        }



        public void crearLibros()
        {
            List<String> listaLibros = new List<String>();
            listaLibros = ficheros.leeDatosFichero(ficheroLibros);

            Libro libro = new Libro();

            for (int i = 0; i < listaLibros.Count; i++)
            {
                char[] separator = { ':' };
                String[] campos = listaLibros[i].Split(separator);

                libro.titulo = campos[0];
                libro.autor = campos[1];
                libro.editorial = campos[2];
                libro.numPaginas = int.Parse(campos[3]);
                libro.ISBN10 = campos[4];
                libro.ISBN13 = campos[5];
                libro.precio = long.Parse(campos[6]);
                libro.categoria = campos[7];
                libro.subcategoria = campos[8];

            }
        }
    }
}