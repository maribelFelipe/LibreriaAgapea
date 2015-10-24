<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="miniControlLibro.ascx.cs" Inherits="LibreriaAgapeaNuevo.controlesUsuario.miniControlLibro" %>
<html>
<head>
    <style type="text/css">
        .auto-style8 {
            width: 300px;
            height: 150px;
            border: 2px;
            margin: 20px 20px 20px 20px;
            
      
        }
        .auto-style9 {
            width: 68px;
        }
    </style>
</head>

    <body>
        
        <table class="auto-style8">
            <tr>
                <td class="auto-style9" rowspan="4" >
                   
                    <asp:Image ID="Image1" runat="server" Height="134px" Width="96px" BackColor="#00ccff"/>
                   
                </td>
                <td colspan="2">

                    <asp:LinkButton ID="linkbttitulo" runat="server">Titulo</asp:LinkButton>

                </td>

            </tr>
            <tr>
                <td>

                    <asp:Label ID="lblautor" runat="server" Text="Autor"></asp:Label>

                </td>
                <td>

                    <asp:Label ID="lbleditorial" runat="server" Text="Editorial"></asp:Label>

                </td>
            </tr>
            <tr>
                <td>

                    <asp:Label ID="lblprecio" runat="server" Text="Precio"></asp:Label>

                </td>
                <td>

                    <asp:Label ID="lblisbn" runat="server" Text="Isbn"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">

                    <asp:Button ID="btcomprar" runat="server" Text="Comprar" />

                </td>
            </tr>
  
        </table>

    </body>




</html>
