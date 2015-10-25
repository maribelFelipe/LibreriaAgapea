<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="miniControlLibroSeleccionado.ascx.cs" Inherits="LibreriaAgapeaNuevo.controlesUsuario.miniControlLibroSeleccionado" %>
<html>
<head>
    <style type="text/css">
        .auto-style8 {
            border-style: none;
            border-color: inherit;
            border-width: 2px;
            width: 500px;
            height: 302px;
            margin: 20px 20px 20px 20px;
            vertical-align:top;
            
      
        }
        .auto-style9 {
            width: 11px;
            vertical-align:top;
        }
        .auto-style12 {
            height: 36px;
        }
        .auto-style13 {
            height: 36px;
            width: 11px;
        }
        .auto-style14 {
            height: 36px;
            width: 71px;
        }
        .auto-style15 {
            width: 179px;
            vertical-align: top;
            height: 48px;
        }
        .auto-style17 {
            width: 179px;
            vertical-align: top;
            height: 84px;
        }
        .auto-style19 {
            width: 179px;
            vertical-align: top;
            height: 39px;
        }
        .auto-style20 {
            width: 179px;
            vertical-align: top;
            height: 37px;
        }
        .auto-style21 {
            height: 69px;
        }
    </style>
</head>

    <body>
        
        <table class="auto-style8">
            <tr>
                <td class="auto-style9" rowspan="4" >
                   
                    <asp:Image ID="Image1" runat="server" Height="206px" Width="166px" BackColor="#00ccff"/>
                   
                </td>
                <td  class="auto-style17" colspan="2">

                    <asp:Label ID="lbltitulo" runat="server">Titulo</asp:Label>

                </td>

            </tr>
            <tr>
                <td  class="auto-style19" colspan="2">

                    <asp:Label ID="lblautor" runat="server" Text="Autor"></asp:Label>

                </td>

            </tr>
            <tr>
                <td class="auto-style15" colspan="2">

                    <asp:Label ID="lbleditorial" runat="server" Text="Editorial"></asp:Label>

                </td>
               
            </tr>
            <tr>
                <td class="auto-style20" colspan="2">

                    
                    <asp:Label ID="lblNumPaginas" runat="server" Text="NumPaginas"></asp:Label>

                    
                </td>
               
            </tr>
            <tr>
                <td class="auto-style13">

                    <asp:Label ID="lblprecio" runat="server" Text="Precio"></asp:Label>

                </td>
                <td class="auto-style14">

                    <asp:Label ID="lblisbn10" runat="server" Text="Isbn10"></asp:Label>
                </td>
                <td class="auto-style12">
                    <asp:Label ID="lblisbn13" runat="server" Text="Isbn13"></asp:Label>
                 </td>
            </tr>
            <tr>
                <td colspan="3" class="auto-style21">
                    <asp:Label ID="lblResumen" runat="server" Text="Resumen"></asp:Label>
                </td>
            </tr>
            
  
            <tr>
                <td colspan="3">

                    <asp:Button ID="btcomprar" runat="server" Text="Comprar" />

                </td>
            </tr>
            
  
        </table>

    </body>




</html>