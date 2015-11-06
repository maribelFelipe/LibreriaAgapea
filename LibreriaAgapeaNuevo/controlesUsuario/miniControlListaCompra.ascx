<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="miniControlListaCompra.ascx.cs" Inherits="LibreriaAgapeaNuevo.controlesUsuario.miniControlListaCompra" %>
<style type="text/css">
    #tablaLibroCompra {
        position:absolute;
            width:880px;
            height:80px;
            margin-left:10px;
            margin-top:40px;
    }
    .auto-style3 {
        width: 65px;
        background-color:aqua;
    }
    .auto-style4 {
        width: 202px;
        height: 10px;
    }
    .auto-style5 {
        height: 10px;
    }
    .auto-style6 {
        width: 37px;
    }
    .auto-style7 {
        width: 268435264px;
    }
    .auto-style8 {
        margin-left: 0px;
    }
    </style>
<table id="tablaLibroCompra">
    <tr>
        <td rowspan="2" class="auto-style3">
            <asp:Image ID="Image1" runat="server" Height="68px" Width="58px" />
        </td>
        <td class="auto-style4">
            <asp:LinkButton ID="LinkBtTitulo" runat="server" Text="Titulo"></asp:LinkButton>
        </td>

        <td class="auto-style5" colspan="7">
            <asp:Label ID="LblAutor" runat="server" Text="Autor"></asp:Label>
        </td>

        <td class="auto-style5" colspan="2">
            <asp:Label ID="LblEditorial" runat="server" Text="Editorial"></asp:Label>
        </td>

    </tr>
    <tr>
        <td colspan="2">
            <asp:Label ID="LblPrecio" runat="server" Text="Precio"></asp:Label>
        </td>

        <td class="auto-style6">
            <asp:Button ID="ButtonAddUnit" runat="server" Text="+" />
        </td>

        <td>
            <asp:Label ID="LblUnidades" runat="server" Text="Unidades"></asp:Label>
            <asp:Button ID="ButtonDelUnit" runat="server" Text="-" CssClass="auto-style8" Width="16px" />
        </td>

        <td>
            &nbsp;</td>

        <td>
            &nbsp;</td>

        <td>
            &nbsp;</td>

        <td>
            &nbsp;</td>

        <td class="auto-style7">
            &nbsp;</td>

        <td>
            &nbsp;</td>

    </tr>

</table>
