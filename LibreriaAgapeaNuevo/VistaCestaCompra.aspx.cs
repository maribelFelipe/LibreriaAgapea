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
    public partial class VistaCestaCompra : System.Web.UI.Page
    {
        private controlador_Vista_Cesta controladorVistaCesta = new controlador_Vista_Cesta();

        protected void Page_Load(object sender, EventArgs e)
        {
            recuperarSesion();
            mostrar();

            try
            {
                HttpCookie cookieCesta = this.Request.Cookies["cesta"];

                String isbnLibrosCesta = cookieCesta.Values.ToString().Split('&')[1].Replace("isbn=","");
                List<String> isbnsFiltrados = isbnLibrosCesta.Split(new char[] { '-' }).ToList();

                List<Libro> listaLibrosCesta = controladorVistaCesta.buscarLibrosISBN(isbnsFiltrados);

                cargarCesta(listaLibrosCesta);
            }
            catch
            {
                this.Response.Redirect("Inicio.aspx");
            }

        }

        private void cargarCesta (List<Libro> listaLibrosCesta)
        {

            for (int i =0; i<listaLibrosCesta.Count;i++)
            { 
          
                miniControlListaCompra unlibro = (miniControlListaCompra)this.LoadControl("~/controlesUsuario/miniControlListaCompra.ascx");

                TableListaCesta.Rows.Add(new TableRow());

                TableCell celda = new TableCell();

                TableListaCesta.Rows[i].Cells.Add(celda);
                unlibro.TituloControl = listaLibrosCesta[i].titulo;
                unlibro.AutorControl = listaLibrosCesta[i].autor;
                unlibro.EditorialControl = listaLibrosCesta[i].editorial;
                unlibro.PrecioControl = listaLibrosCesta[i].precio.ToString();
               

                //((LinkButton)unlibro.FindControl("linkbttitulo")).ID += libro.ISBN10.ToString();

                celda.Controls.Add(unlibro);

                
            }

           

        }


        protected void recuperarSesion()
        {

            Label usuarioRegistrado = (Label)this.Master.FindControl("LabelUsuarioRegistrado");

            String usuario = (String)this.Request.QueryString["usuario"];
            if (usuario != null)
            {
                usuarioRegistrado.Text = "Usuario: " + usuario;

            }
            else
            {
                usuarioRegistrado.Text = "";
            }

        }
       

        private void mostrar()
        {
            String mensaje = "";

            TextBox TxtBoxVariables = (TextBox)this.Master.FindControl("TxtBoxVariables");

            foreach (String clave in this.Request.Params.Keys)
            {
                mensaje += "clave:_" + clave + "--------------valor:_" + this.Request.Params[clave].ToString() + "\n";
            }

            TxtBoxVariables.Text = mensaje;
        }
    }
}