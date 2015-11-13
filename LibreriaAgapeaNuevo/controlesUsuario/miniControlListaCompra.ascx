<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="miniControlListaCompra.ascx.cs" Inherits="LibreriaAgapeaNuevo.controlesUsuario.miniControlListaCompra" %>
<html>
    <head>
        <style type="text/css">
    #tablaLibroCompra {

            width:680px;
            height:20px;
            margin-bottom:10px;
    }
    .tituloTabla {
        height:20px;
        background-color:darkgray;
        color:white;
    }

         
          

            .auto-style1 {
                width: 349px;
            }
            .auto-style2 {
                width: 144px;
            }

         
          

            .auto-style3 {
                width: 174px;
            }
            .auto-style4 {
                width: 229px;
            }

         
          

            </style>
    </head>
    <body>
        <table id="tablaLibroCompra">

    
     <tr>
        <td class="auto-style1" colspan="2">
            <asp:LinkButton ID="LinkBtTitulo" runat="server" Text="Titulo"></asp:LinkButton>
        </td>

    </tr>
    <tr>
                <td class="auto-style3">
            <asp:Label ID="LblAutor" runat="server" Text="Autor"></asp:Label>
        </td>

        
                <td class="auto-style4">
                    <asp:Label ID="LblIsbn" runat="server" Text="ISBN10"></asp:Label>
                  </td>

        
        <td class="auto-style2" style="align-items:center">
             <asp:Button ID="ButtonAddUnit" runat="server" Text="+" BackColor="#999966" />
            <asp:Label ID="LblUnidades" runat="server" Text="Unidades"></asp:Label>
            <asp:Button ID="ButtonDelUnit" runat="server" Text="-" CssClass="auto-style8" Width="22px" BackColor="#999966"  />

        </td>

        <td >
             <asp:Label ID="LblPrecio" runat="server" Text="Precio" Style="align-content:center"></asp:Label>
            </td>
        <td>
            <asp:Button ID="btBorrar" runat="server" Text="X" BackColor="#FF9933" ForeColor="Maroon" />
        </td>
       
        

    </tr>

</table>

    </body>
</html>


    