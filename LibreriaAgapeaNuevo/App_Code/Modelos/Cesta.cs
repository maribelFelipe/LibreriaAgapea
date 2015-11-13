using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibreriaAgapeaNuevo.App_Code.Modelos
{
    public class Cesta
    {
        public List<Libro> listaLibrosCesta { get; set; }
        public Usuario usuario { get; set;  }
        public DateTime fecha { get; set;  }

        public Cesta(Usuario usuario)
        {
            listaLibrosCesta = new List<Libro>();
            this.usuario = usuario;
            fecha = DateTime.Now;
        }

    }
}