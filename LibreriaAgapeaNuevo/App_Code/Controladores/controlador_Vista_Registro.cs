using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibreriaAgapeaNuevo.App_Code.Modelos;

namespace LibreriaAgapeaNuevo.App_Code.Controladores
{
    public class controlador_Vista_Registro
    {
        private controlador_Acceso_Ficheros ficheros = new controlador_Acceso_Ficheros();
        private Usuario usuario = new Usuario();
        private string ficheroUsuarios = "~/Ficheros/usuarios.txt";


        public void GrabarDatosUsuario(string nombreUsuario, string email, string passw, string nombre, string apellidos)
        {
            Usuario nuevoUsuario = new Usuario();
            nuevoUsuario.nombreUsuario = nombreUsuario;
            nuevoUsuario.email = email;
            nuevoUsuario.passw = passw;
            nuevoUsuario.nombre = nombre;
            nuevoUsuario.apellidos = apellidos;

            string nuevaLinea = nuevoUsuario.nombreUsuario + ":" + nuevoUsuario.email + ":" + nuevoUsuario.passw +
               ":" + nuevoUsuario.nombre + ":" + nuevoUsuario.apellidos;

            ficheros.AddDatosFichero(ficheroUsuarios, nuevaLinea);

        }


        public Boolean compruebaExisteEmailFichero(string email)

        {
            if (ficheros.compruebaExisteDato(ficheroUsuarios, email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean compruebaExisteUsuario(string usuario, string passw)
        {
            if (ficheros.compruebaExisteDato(ficheroUsuarios, usuario, passw, 0, 2))
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}