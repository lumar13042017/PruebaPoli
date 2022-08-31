<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consultar.aspx.cs" Inherits="libreriaOnline.Consultar" %>

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
                <div style="height: 80px; width: 100%; background: #E8E8E8; background: -webkit-gradient(linear, 0% 0%, 0% 100%, from(white), to(#F2F2F2)); background: -moz-linear-gradient(top, white, #F2F2F2);">
                    <div style="border-left: 1px solid #DADADA; -webkit-box-shadow: inset 1px 0 #fff; -moz-box-shadow: inset 1px 0 #fff; box-shadow: inset 1px 0 #fff; padding: 12px 17px 14px; text-align: center; border-bottom: 0px; text-transform: capitalize; text-shadow: rgba(255, 255, 255, 0.75) 0 1px 0; font-family: Arial, Helvetica, sans-serif;">
                        <div style="-webkit-padding-end: 24px; -webkit-user-select: none; color: #53637D; font-size: 200%; font-weight: normal; margin: 0; padding-bottom: 14px; padding-top: 5px; text-align: left; text-shadow: white 0 1px 2px;">
                            <table cellspacing="0" style="table-layout: auto; width: 100%; color: #6F6F6F; font-size: 12px; font-family: helvetica;">
                                <thead>
                                    <tr style="text-align: center;">
                                        <th></th>
                                        <th>Año Publicacion
                                        </th>
                                        <th>Autor</th>
                                        <th></th>
                                        <th>&nbsp;
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr style="text-align: center;">
                                        <td style="color: #53637D; font-size: 200%; text-align: left;">Reporte Escritores
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAño" Width="50%" runat="server">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlEscritores" runat="server"></asp:DropDownList>
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:LinkButton ID="lnkLoadReport" runat="server" OnClick="lnkLoadReport_Click">Cargar Reporte</asp:LinkButton>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <table border="1px" cellpadding="4px" style="border-collapse: collapse; font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; font-size: 11px; width: 100%; border: 1px solid #C4C4C4; width: 100%; border-collapse: collapse;">
                    <tr style="line-height: 25px; text-align: center; font-weight: bold; background-color: #EBEBEB; padding: 100px 0 0; box-shadow: inset 1px 1px 0 rgba(0, 0, 0, .1),inset 0 -1px 0 rgba(0, 0, 0, .07);">
                        <td style="border-bottom: 1px solid #C4C4C4; text-align: center;">Nombre
                                                                    </td>
                        <td style="border-bottom: 1px solid #C4C4C4; text-align: center;">Editorial
                                                                    </td>
                        <td style="border-bottom: 1px solid #C4C4C4; text-align: center;">Año Publicado
                                                                    </td>
                        <td style="border-bottom: 1px solid #C4C4C4; text-align: center;">Autor
                                                                    </td>
                    </tr>
                    <asp:Repeater ID="rptLibros" runat="server" EnableViewState="false">
                        <ItemTemplate>
                            <tr>
                                <td style="text-align: center; border-bottom: 1px solid #C4C4C4;">
                                    <%# Eval("Name")%>
                                                                            </td>
                                <td style="text-align: center; border-bottom: 1px solid #C4C4C4;">
                                    <%# Eval("Editorial")%>
                                                                            </td>
                                <td style="text-align: center; border-bottom: 1px solid #C4C4C4;">
                                    <%# Eval("publicacion")%>
                                                                            </td>
                                <td style="text-align: center; border-bottom: 1px solid #C4C4C4;">
                                    <%# Eval("Autor") %>
                                                                            </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                       
                        </FooterTemplate>
                    </asp:Repeater>
                </table>
            </center>
        </div>
    </form>
</body>
</html>
