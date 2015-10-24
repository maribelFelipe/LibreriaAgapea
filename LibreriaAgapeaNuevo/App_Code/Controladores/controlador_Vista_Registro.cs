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
        private String ficheroUsuarios = "~/Ficheros/usuarios.txt";


        public void GrabarDatosUsuario(String nombreUsuario, String email, String passw, String nombre, String apellidos)
        {
            Usuario nuevoUsuario = new Usuario();
            nuevoUsuario.nombreUsuario = nombreUsuario;
            nuevoUsuario.email = email;
            nuevoUsuario.passw = passw;
            nuevoUsuario.nombre = nombre;
            nuevoUsuario.apellidos = apellidos;

            String nuevaLinea = nuevoUsuario.nombreUsuario + ":" + nuevoUsuario.email + ":" + nuevoUsuario.passw +
               ":" + nuevoUsuario.nombre + ":" + nuevoUsuario.apellidos;

            ficheros.AddDatosFichero(ficheroUsuarios, nuevaLinea);

        }


        public Boolean compruebaExisteEmailFichero(String email)

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

        public Boolean compruebaExisteUsuario(String usuario, String passw)
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