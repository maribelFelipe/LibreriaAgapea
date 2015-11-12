using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibreriaAgapeaNuevo.App_Code.Modelos
{
    public class Cesta
    {
        private List<Libro> cesta { get; set; }
        private Usuario usuario { get; set;  }
        private DateTime fecha { get; set;  }


    }
}