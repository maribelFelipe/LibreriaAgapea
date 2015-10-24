<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="LibreriaAgapeaNuevo.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #contenedor{
            position:relative;
            width:900px;
            height:1000px;
            margin-left:auto;
            margin-right:auto;
        }

        #formulario {
            position:absolute;
            margin-top:30px;
            margin-left:80px;
            width:700px;
            height:430px;
            -webkit-box-shadow: 0px 5px 23px -8px rgba(0,0,0,0.59);
            -moz-box-shadow: 0px 5px 23px -8px rgba(0,0,0,0.59);
            box-shadow: 0px 5px 23px -8px rgba(0,0,0,0.59);
        }

     
        .titulos{
            font-family: Verdana, Geneva, Tahoma, sans-serif; 
            font-size: 20px; 
            color: #000000; 
            font-weight: lighter;
        }
        .tituloDatos{
            font-family: Verdana, Geneva, Tahoma, sans-serif; 
            font-size: 12px; 
            font-weight: bold; 
            color: #808080
        }
        .boxDatos{
            border-radius: 7px 7px 7px 7px;
            -moz-border-radius: 7px 7px 7px 7px;
            -webkit-border-radius: 7px 7px 7px 7px;
            border: 1px solid #c7c7c7;
            height:25px;
            padding-left: 8px;
        }

        #tabla{
            margin-left:15px;
            margin-top:10px;
            height: 400px; 
            width: 768px
        }

        #tabla1{
            margin-top:20px;
            margin-left:15px;
            height:90px;
            width:880px;

        }
 
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="contenedor" class="auto-style22" >
            <div id="cabecera" >
                <asp:Image ID="Image1" runat="server" Height="237px" ImageUrl="~/img/cabecera.PNG" Width="900px" />
            </div>

             <table id="tabla1">
                <tr>
                    <td class="titulos">Inicia sesión</td>
                    <td class="tituloDatos">Usuario</td>
                    <td>
                        <asp:TextBox ID="usuarioRegistrado" runat="server" Class="boxDatos" Width="193px" ValidationGroup="inicioSesion"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="#990000" ControlToValidate="usuarioRegistrado" ValidationGroup="inicioSesion">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="tituloDatos">Contraseña</td>
                    <td>
                        <asp:TextBox ID="passwRegistrado" runat="server" Class="boxDatos" Width="195px" TextMode="Password" ValidationGroup="inicioSesion" ></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="#990000" ControlToValidate="passwRegistrado" ValidationGroup="inicioSesion">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:ImageButton ID="BtIDentificar" runat="server" ImageUrl="~/img/btIdentificar.PNG" OnClick="BtIDentificar_Click" ValidationGroup="inicioSesion"  />
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="usuarioRegistrado" ErrorMessage="CustomValidator" ForeColor="#990000" OnServerValidate="CustomValidator2_ServerValidate1" ValidationGroup="inicioSesion">Usuario no registrado</asp:CustomValidator>
                    </td>
                </tr>
                
            </table>
           

            <div id="formulario">

                <table id="tabla">

                    <tr>
                        <td class="titulos"><strong>Registrate con Agapea</strong></td>
                    </tr>
                    <tr>
                        <td class="tituloDatos">Usuario</td>
                        <td class="tituloDatos">Correo Electrónico</td>
                    </tr>
                    <tr>
                        <td class="auto-style6">
                            <asp:TextBox ID="TextBoxUsuario" runat="server" Width="270px" Class="boxDatos" ValidationGroup="registroNuevo"></asp:TextBox>
                        </td>
       
                        <td>
                            <asp:TextBox ID="TextBoxMail" runat="server" Width="270px" Class="boxDatos" ValidationGroup="registroNuevo"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxUsuario" ErrorMessage="RequiredFieldValidator" ForeColor="#990000">*</asp:RequiredFieldValidator>

                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxMail" ErrorMessage="RequiredFieldValidator" ForeColor="#990000">*</asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegExEmail" runat="server" ControlToValidate="TextBoxMail" ErrorMessage="RegularExpressionValidator" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="#990000">Formato email incorrecto</asp:RegularExpressionValidator>

                            <asp:CustomValidator ID="CustomMail" runat="server" ControlToValidate="TextBoxMail" ErrorMessage="CustomValidator" ForeColor="#990000" OnServerValidate="CustomValidator2_ServerValidate" Display="Dynamic">Este email ya esta registrado</asp:CustomValidator>

                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Escribe cual será tu contraseña</td>
                        <td class="tituloDatos">Repite la contraseña</td>
                    </tr>
                    <tr>
                        <td class="auto-style6">
                            <asp:TextBox ID="TextBoxPassw1" runat="server" Width="270px" TextMode="Password" Class="boxDatos" ValidationGroup="registroNuevo"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxPassw2" runat="server" Width="270px" Class="boxDatos" TextMode="Password" ValidationGroup="registroNuevo"></asp:TextBox>
                        
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxPassw1" ErrorMessage="RequiredFieldValidator" ForeColor="#990000">*</asp:RequiredFieldValidator>

                            <asp:CustomValidator ID="CValLongitudPassw" runat="server" ControlToValidate="TextBoxPassw1" ErrorMessage="CustomValidator" ForeColor="#990000" OnServerValidate="CValLongitudPassw_ServerValidate">La contraseña debe tener 8 caracteres mínimo</asp:CustomValidator>

                        </td>
                        <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxPassw2" ErrorMessage="RequiredFieldValidator" ForeColor="#990000">*</asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValPasswords" runat="server" ControlToCompare="TextBoxPassw1" ControlToValidate="TextBoxPassw2" ErrorMessage="CompareValidator" ForeColor="#990000">La contraseña no coincide</asp:CompareValidator>
                        </td>
                    </tr>
                     <tr>
                        <td class="auto-style1"><strong>Datos Personales</strong></td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Mi nombre</td>
                        <td class="tituloDatos">Mis apellidos</td>
                    </tr>
                    <tr>
                        <td class="auto-style6">
                            <asp:TextBox ID="TextBoxNombre" runat="server" Width="270px" Class="boxDatos" ValidationGroup="registroNuevo"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxApellidos" runat="server" Width="270px" Class="boxDatos" ValidationGroup="registroNuevo"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxNombre" ErrorMessage="RequiredFieldValidator" ForeColor="#990000">*</asp:RequiredFieldValidator>
                        </td>
                        <td class="auto-style4">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBoxApellidos" ErrorMessage="RequiredFieldValidator" ForeColor="#990000">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="auto-style7" style="font-family: Verdana, Geneva, Tahoma, sans-serif; color: #808080; font-size: x-small">
                            <asp:CheckBox ID="CheckBoxPolitica" runat="server" ValidationGroup="registroNuevo" />
                            Acepto la Condiciones de uso, y nuestras Condiciones de Cookies
                            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator" OnServerValidate="CustomValidator1_ServerValidate" ForeColor="#990000">Debe aceptar las condiciones de uso</asp:CustomValidator>

                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="auto-style3" >
                           <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/img/btRegistrar.PNG" OnClick="BtRegistro_Click" />
                            <asp:Label ID="LabelUsuarioOK" runat="server" Text=""></asp:Label>
                        </td>

                    </tr>
                                        
                </table>
                </div>
        </div>
    </form>
</body>
</html>
