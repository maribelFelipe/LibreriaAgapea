using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibreriaAgapeaNuevo.App_Code.Modelos
{
    public class Libro
    {
        public string titulo { get; set; }
        public string autor { get; set; }
        public string editorial { get; set; }
        public int numPaginas { get; set; }
        public string ISBN10 { get; set; }
        public string ISBN13 { get; set; }
        public Double precio { get; set; }
        public string categoria { get; set; }
        public string subcategoria { get; set; }
        public string resumen { get; set; }
    }
}