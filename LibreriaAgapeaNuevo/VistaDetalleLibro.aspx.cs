﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibreriaAgapeaNuevo.App_Code.Modelos;
using LibreriaAgapeaNuevo.App_Code.Controladores;
using LibreriaAgapeaNuevo.controlesUsuario;

namespace LibreriaAgapeaNuevo
{
    public partial class VistaDetalleLibro : System.Web.UI.Page
    {

        private controlador_Vista_Inicio controladorVistaInicio = new controlador_Vista_Inicio();

        protected void Page_Load(object sender, EventArgs e)
        {

            string isbnlibro = (String)this.Request.QueryString["ISBNlibro"];

            miniControlLibroSeleccionado unlibro = (miniControlLibroSeleccionado)this.LoadControl("~/controlesUsuario/miniControlLibroSelecionado.ascx");

            List<Libro> listaLibros = new List<Libro>();
            listaLibros = controladorVistaInicio.devuelveLibros();

            Libro libro = new Libro();

            libro = (from otrolibro in listaLibros
                     let isbn = otrolibro.ISBN10
                     where isbn == isbnlibro
                     select otrolibro).SingleOrDefault();


            unlibro.TituloControl = libro.titulo;
            unlibro.EditorialControl = libro.editorial;
            unlibro.AutorControl = libro.autor;
            unlibro.PrecioControl = libro.precio.ToString();
            unlibro.ISBN10Control = libro.ISBN10;
            unlibro.ISBN13Control = libro.ISBN13;
            unlibro.NumPaginasControl = libro.numPaginas.ToString();
            unlibro.ResumenControl = libro.resumen;



        
    }
    }
}