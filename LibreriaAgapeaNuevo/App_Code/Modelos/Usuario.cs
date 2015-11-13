using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibreriaAgapeaNuevo.App_Code.Modelos
{
    public class Usuario
    {
        public string nombreUsuario { get; set; }
        public string email { get; set; }
        public string passw { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public List<Cesta> listaDeCestas { get; set; }
        
        public Usuario(string nombre, string email, string passw, string apellidos)
        {
            nombreUsuario = nombre;
            this.email = email;
            this.passw = passw;
            this.apellidos = apellidos;
            listaDeCestas = new List<Cesta>();
        }

        public Usuario() { }
    }
}