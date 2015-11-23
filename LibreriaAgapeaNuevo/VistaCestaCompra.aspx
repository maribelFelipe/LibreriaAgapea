<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="VistaCestaCompra.aspx.cs" Inherits="LibreriaAgapeaNuevo.VistaCestaCompra" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
    <style type="text/css">
        #contenedor{
            position:relative;
            width:900px;
            margin-left:auto;
            margin-right:auto;
        }

        #contenido{
            position:absolute;
            width:880px;
            height:800px;
            margin-left:10px;
            margin-top:10px;
        }
        #contDinamico{
            position:relative;
            margin-bottom:10px;
            display:block;
        }

        #usuario{
            text-align:right;
        }

        #variables{
            position:absolute;
            width:680px;
            margin-top:810px;
            height:150px;
        }
         #tablaLibroCompra {

            width:680px;
            height:10px;
            margin-bottom:10px;
    }
        
        
    .tituloTabla {
        
        background-color:darkgray;
        color:white;
    }
   
        .auto-style1 {
            height: 14px;
        }
           
        .auto-style3 {
            height: 9px;
            width: 1032px;
        }
        .auto-style5 {
            height: 9px;
            width: 140px;
        }
   
        .auto-style6 {
            height: 9px;
            width: 160px;
        }
        .auto-style7 {
            height: 9px;
            width: 280px;
        }
   
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="contenedor">
            <div id="usuario">
                <asp:Label ID="LabelUsuarioRegistrado" runat="server" Text=""></asp:Label>
            </div>
            
            <div id="cabecera" >
                <asp:Image ID="Image1" runat="server" ImageUrl="~/img/cabecera01.png" Width="900px" />   
            </div>
            
            <div id="contenido">
            <div id="texto">
                <h2 style="text-align:center">Contenido de su cesta</h2>
            </div>
            <div id="tabla">
            <div id="contDinamico">
                
                <asp:Table ID="TableListaCesta" runat="server"></asp:Table>
            </div>
            
            <table id="tablaImportes">
                <tr>
                    <td class="auto-style1"><p>Importe libros</p></td>
                    <td class="auto-style1"><asp:Label ID="lblImporteLibros" runat="server" Text="--"></asp:Label></td>
                </tr>
                <tr>
                    <td class="auto-style1"><p>Gastos de envío</p></td>
                    <td class="auto-style1"><asp:Label ID="LblGastosEnvio" runat="server" Text="--"></asp:Label></td>
                </tr>
                <tr>
                    <td class="auto-style1"><p>Total pedido</p></td>
                    <td class="auto-style1"><asp:Label ID="LblTotal" runat="server" Text="--"></asp:Label></td>
                </tr>

            </table>

                 <div id="botones" style="text-align:center; margin-top:20px">
                    <asp:ImageButton ID="BtSeguirComprando" runat="server" BorderColor="White" BorderWidth="10px" ImageUrl="~/img/BtSeguirCompra.JPG" OnClick="BtSeguirComprando_Click" />
                    <asp:ImageButton ID="BtFinCompra" runat="server" BorderColor="White" BorderWidth="10px" ImageUrl="~/img/BtFinCompra.JPG" OnClick="BtFinCompra_Click" />
                </div>
                </div>
               
               

            <div id="variables">
            <asp:TextBox ID="TxtBoxVariables" runat="server" Height="140px" TextMode="MultiLine" Width="660px"></asp:TextBox>

            </div>
    </div>

    </form>
</body>
</html>

