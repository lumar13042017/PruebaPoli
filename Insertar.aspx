<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Insertar.aspx.cs" Inherits="libreriaOnline.Insertar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <div id="formContainer" runat="server" style="margin: 0 auto; width: 90%; z-index: 2; padding-bottom: 5px; border-radius: 8px 8px 8px 8px; -webkit-border-radius: 8px 8px 8px 8px; background-color: white; box-shadow: 0px 0px 15px rgba(0,0,0,0.15),0px 0px 1px 1px rgba(0,0,0,0.1); font-family: 'Helvetica Neue',sans-serif; padding: 10px; margin-top: 15px;">
                <center>
                    <table style="width: 100%; padding: 10px;">
                        <tr>
                            <td style="width: 50%; padding-right: 5px; padding-left: 5px; padding: 20px; border:1px solid black" valign="top">
                                <div style="margin-top: 5px; line-height: 1.5; margin-bottom: 8px; word-break: break-word; font-size: 16px; font-weight: 600; text-align: center;">
                                    Ingresar Escritor
                                </div>
                                <br />
                                <br />
                                <div style="margin-top: 5px; line-height: 1.5; margin-bottom: 8px; word-break: break-word; font-size: 16px; font-weight: 600; text-align: left;">
                                    Nombre
                                </div>
                                <div style="width: 100%;">
                                    <asp:TextBox ID="txtNameEscritor" runat="server" CssClass="textCustomerField" Width="90%"></asp:TextBox>
                                </div>
                                 <br />
                                <br />
                                <div style="width: 100%;">
                                    <asp:label ID="lblMensjeEscritor" runat="server" Width="90%" style="color:red;text-align: center;"></asp:label>
                                </div>
                                <div style="background-color: #2492fc; width: 200px; margin: 0 auto; padding: 10px; color: white; border-radius: 8px 8px 8px 8px; -webkit-border-radius: 8px 8px 8px 8px; margin-top: 20px; cursor: pointer; height: 50px; text-align: center;">
                                    <asp:LinkButton ID="lnkAddEscritor" runat="server" OnClick="lnkAddEscritor_Click">
                                        <div style="padding-top: 4px;color: white;text-decoration: none;">
                                           Ingresar
                                        </div>
                                    </asp:LinkButton>
                                </div>
                            </td>
                            <td style="width: 50%; padding-right: 5px; padding-left: 5px; padding: 20px;border:1px solid black" valign="top">
                                <div style="margin-top: 5px; line-height: 1.5; margin-bottom: 8px; word-break: break-word; font-size: 16px; font-weight: 600; text-align: center;">
                                    Ingresar Libro
                                </div>
                                <br />
                                <br />
                                 <div style="margin-top: 5px; line-height: 1.5; margin-bottom: 8px; word-break: break-word; font-size: 16px; font-weight: 600; text-align: left;">
                                    Nombre
                                </div>
                                <div style="width: 100%;">
                                    <asp:TextBox ID="txtNameLibro" runat="server" CssClass="textCustomerField" Width="90%"></asp:TextBox>
                                </div>
                                <br />
                                <div style="line-height: 1.5; margin-bottom: 8px; word-break: break-word; font-size: 16px; font-weight: 600; text-align: left;">
                                    Editorial
                                </div>
                                <div style="width: 100%;">
                                    <asp:TextBox ID="txtEditorial" runat="server" CssClass="textCustomerField" Width="90%"></asp:TextBox>
                                </div>
                                <br />
                                <div style="line-height: 1.5; margin-bottom: 8px; word-break: break-word; font-size: 16px; font-weight: 600; text-align: left;">
                                    Año Publicacion
                                </div>
                                <div style="width: 100%;">
                                    <asp:TextBox ID="txtAñoPublicacion" runat="server" CssClass="textCustomerField" Width="90%"></asp:TextBox>
                                </div>
                                 <div style="line-height: 1.5; margin-bottom: 8px; word-break: break-word; font-size: 16px; font-weight: 600; text-align: left;">
                                    Autor
                                </div>
                                <div style="width: 100%;">
                                    <asp:DropDownList ID="ddlEscritores" runat="server" ></asp:DropDownList>
                                </div>
                                 <br />
                                <br />
                                <div style="width: 100%;">
                                    <asp:label ID="lblmensajeLibro" runat="server" Width="90%" style="color:red;text-align: center;"></asp:label>
                                </div>
                                <div style="background-color: #2492fc; width: 200px; margin: 0 auto; padding: 10px; color: white; border-radius: 8px 8px 8px 8px; -webkit-border-radius: 8px 8px 8px 8px; margin-top: 20px; cursor: pointer; height: 50px; text-align: center;">
                                    <asp:LinkButton ID="lnkAddLibro" runat="server" OnClick="lnkAddLibro_Click">
                                        <div style="padding-top: 4px;color: white;text-decoration: none;">
                                           Ingresar
                                        </div>
                                    </asp:LinkButton>
                                </div>
                            </td>
                        </tr>
                    </table>
                </center>
            </div>
    </form>
</body>
</html>
