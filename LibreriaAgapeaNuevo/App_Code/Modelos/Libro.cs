using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibreriaAgapeaNuevo.App_Code.Modelos
{
    public class Libro
    {
        public String titulo { get; set; }
        public String autor { get; set; }
        public String editorial { get; set; }
        public int numPaginas { get; set; }
        public String ISBN10 { get; set; }
        public String ISBN13 { get; set; }
        public Double precio { get; set; }
        public String categoria { get; set; }
        public String subcategoria { get; set; }
        public String resumen { get; set; }
    }
}