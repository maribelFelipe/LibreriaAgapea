<%@ Page Title="" Language="C#" MasterPageFile="~/Maestras/MaestraGeneral.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="LibreriaAgapeaNuevo.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="tablaLibrosASP" style="position:absolute;width:680px;height:790px; margin-left:210px; margin-top:20px">
        <asp:Table ID="miTablaInicio" runat="server">
        </asp:Table>
    </div>
    <div id="buscador">
                <asp:TextBox ID="TxtBxBuscador" runat="server"></asp:TextBox>
                <asp:RadioButtonList ID="RadioBtBuscar" runat="server" Width="260px" RepeatDirection="Horizontal" RepeatLayout="Flow" BorderStyle="None" CellPadding="5" CellSpacing="5" Height="23px" >
                    <asp:ListItem Text="Titulo" Value="Titulo"></asp:ListItem>
                    <asp:ListItem Text="Autor" Value="Autor"></asp:ListItem>
                    <asp:ListItem Text="ISBN" Value="ISBN"></asp:ListItem>
                    <asp:ListItem Text="Editorial" Value="Editorial"></asp:ListItem>
                </asp:RadioButtonList>
                <asp:Button ID="BtBuscador" runat="server" Text="Buscar" OnClick="BtBuscador_Click"/>
            </div>
</asp:Content>
