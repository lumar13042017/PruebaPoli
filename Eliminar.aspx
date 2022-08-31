<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Eliminar.aspx.cs" Inherits="libreriaOnline.Eliminar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="formContainer" runat="server" style="margin: 0 auto; width: 90%; z-index: 2; padding-bottom: 5px; border-radius: 8px 8px 8px 8px; -webkit-border-radius: 8px 8px 8px 8px; background-color: white; box-shadow: 0px 0px 15px rgba(0,0,0,0.15),0px 0px 1px 1px rgba(0,0,0,0.1); font-family: 'Helvetica Neue',sans-serif; padding: 10px; margin-top: 15px;">
            <center>
                <table style="width: 100%; padding: 10px;">
                    <tr>
                        <td style="width: 50%; padding-right: 5px; padding-left: 5px; padding: 20px; border: 1px solid black" valign="top">
                            <div style="margin-top: 5px; line-height: 1.5; margin-bottom: 8px; word-break: break-word; font-size: 16px; font-weight: 600; text-align: center;">
                                Eliminar Escritor
                            </div>
                            <br />
                            <br />
                            <div style="margin-top: 5px; line-height: 1.5; margin-bottom: 8px; word-break: break-word; font-size: 16px; font-weight: 600; text-align: left;">
                                Listado Escritores
                            </div>
                            <div style="width: 100%;">
                                <asp:DropDownList ID="ddlEscritores" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEscritores_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div style="margin-top: 5px; line-height: 1.5; margin-bottom: 8px; word-break: break-word; font-size: 16px; font-weight: 600; text-align: left;">
                                Nuevo Nombre
                            </div>
                            <div style="width: 100%; font-size: 14px; font-weight: 600; text-align: left;">
                                <asp:Label ID="lblEscritor" runat="server" CssClass="textCustomerField" Width="90%"></asp:Label>
                            </div>
                            <br />
                            <br />
                            <div style="width: 100%;">
                                <asp:Label ID="lblMensjeEscritor" runat="server" Width="90%" Style="color: red; text-align: center;"></asp:Label>
                            </div>
                            <div style="background-color: #2492fc; width: 200px; margin: 0 auto; padding: 10px; color: white; border-radius: 8px 8px 8px 8px; -webkit-border-radius: 8px 8px 8px 8px; margin-top: 20px; cursor: pointer; height: 50px; text-align: center;">
                                <asp:LinkButton ID="lnkEliminatEscritor" runat="server" OnClick="lnkEliminatEscritor_Click">
                                        <div style="padding-top: 4px;color: white;text-decoration: none;">
                                           Eliminar
                                        </div>
                                </asp:LinkButton>
                            </div>
                        </td>
                        <td style="width: 50%; padding-right: 5px; padding-left: 5px; padding: 20px; border: 1px solid black" valign="top">
                            <div style="margin-top: 5px; line-height: 1.5; margin-bottom: 8px; word-break: break-word; font-size: 16px; font-weight: 600; text-align: center;">
                                Eliminar Libro
                            </div>
                            <br />
                            <br />
                            <div style="margin-top: 5px; line-height: 1.5; margin-bottom: 8px; word-break: break-word; font-size: 16px; font-weight: 600; text-align: left;">
                                Listado de Libros
                            </div>
                            <div style="width: 100%;">
                                <asp:DropDownList ID="ddllibros" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLibros_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div style="margin-top: 5px; line-height: 1.5; margin-bottom: 8px; word-break: break-word; font-size: 16px; font-weight: 600; text-align: left;">
                                Nombre Actual
                            </div>
                            <div style="width: 100%; font-size: 14px; font-weight: 600; text-align: left;">
                                <asp:Label ID="lblNombreLibro" runat="server" Width="90%"></asp:Label>
                            </div>
                            <br />
                            <div style="line-height: 1.5; margin-bottom: 8px; word-break: break-word; font-size: 16px; font-weight: 600; text-align: left;">
                                Editorial Actual
                            </div>
                            <div style="width: 100%; font-size: 14px; font-weight: 600; text-align: left;">
                                <asp:Label ID="lblEditorial" runat="server" Width="90%"></asp:Label>
                            </div>
                            <br />
                            <div style="line-height: 1.5; margin-bottom: 8px; word-break: break-word; font-size: 16px; font-weight: 600; text-align: left;">
                                Año Publicacion Actual
                            </div>
                            <div style="width: 100%; font-size: 14px; font-weight: 600; text-align: left;">
                                <asp:Label ID="lblPublicacion" runat="server" Width="90%"></asp:Label>
                            </div>
                            <br />
                            <div style="line-height: 1.5; margin-bottom: 8px; word-break: break-word; font-size: 16px; font-weight: 600; text-align: left;">
                                Autor Actual
                            </div>
                            <div style="width: 100%; font-size: 14px; font-weight: 600; text-align: left;">
                                <asp:Label ID="lblAutor" runat="server" Width="90%"></asp:Label>
                            </div>
                            <div style="width: 100%;">
                                <asp:Label ID="lblmensajeLibro" runat="server" Width="90%" Style="color: red; text-align: center;"></asp:Label>
                            </div>
                            <div style="background-color: #2492fc; width: 200px; margin: 0 auto; padding: 10px; color: white; border-radius: 8px 8px 8px 8px; -webkit-border-radius: 8px 8px 8px 8px; margin-top: 20px; cursor: pointer; height: 50px; text-align: center;">
                                <asp:LinkButton ID="lnkModificarLibro" runat="server" OnClick="lnkModificarLibro_Click">
                                        <div style="padding-top: 4px;color: white;text-decoration: none;">
                                           Eliminar
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
