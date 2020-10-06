<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<%@ Register Assembly="FastReport.Web" Namespace="FastReport.Web" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>FastReport .NET Demo</title>
</head>
<body style="background-repeat: no-repeat; background-color: lightgrey;">
    <form id="form2" runat="server">
    <div>
        <table>
            <tr>
                <td style="height: 44px; text-align: center; width: 106px;">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/demo_logo.png" EnableViewState="False" /></td>
                <td style="height: 44px; width: 768px;">
                    <span style="font-size: 16pt; font-family: Tahoma"><strong>FastReport .NET Demo<br />
                        <asp:Label ID="Version" runat="server" Font-Size="Small" Text="ver. 1.0.0" Width="188px" EnableViewState="False"></asp:Label></strong></span></td>
            </tr>
        </table>        
        <hr />
    </div>
                <strong><span style="font-size: 10pt; font-family: Tahoma"></span></strong>
                <table>
                    <tr>
                        <td style="width: 300px; height: 884px;" valign="top">
                            
        <asp:Menu ID="LeftMenu" runat="server" BackColor="#EEEEEE" DynamicHorizontalOffset="5"
            Font-Names="Arial" Font-Bold="False" Font-Size="10pt" ForeColor="Black" StaticSubMenuIndent="20px" MaximumDynamicDisplayLevels="2" StaticDisplayLevels="2" Width="240px" OnInit="LeftMenu_Init" OnMenuItemClick="LeftMenu_MenuItemClick">
            <StaticSelectedStyle BackColor="LightSteelBlue" ForeColor="DarkBlue" />
            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
            <DynamicMenuStyle BackColor="#FFFBD6" />
            <DynamicItemTemplate>
                <%# Eval("Text") %>
            </DynamicItemTemplate>
            <DynamicSelectedStyle BackColor="Chocolate" />
            <DynamicMenuItemStyle HorizontalPadding="15px" VerticalPadding="2px" />
            <StaticHoverStyle BackColor="Lavender" ForeColor="DarkBlue" />
            <Items>
                <asp:MenuItem Text="Simple reports" Value="Simple reports" Selectable="False">
                    <asp:MenuItem Selected="True" Text="Report1" Value="Report1"></asp:MenuItem>
                    <asp:MenuItem Text="Report2" Value="Report2"></asp:MenuItem>
                    <asp:MenuItem Text="Report3" Value="Report3"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Selectable="False" Text="Matrix" Value="Matrix">
                    <asp:MenuItem Text="Matrix1" Value="Matrix1"></asp:MenuItem>
                    <asp:MenuItem Text="Matrix2" Value="Matrix2"></asp:MenuItem>
                    <asp:MenuItem Text="Matrix3" Value="Matrix3"></asp:MenuItem>
                </asp:MenuItem>
            </Items>
            <LevelMenuItemStyles>
                <asp:MenuItemStyle Font-Bold="False" Font-Underline="False" ForeColor="Black" />
                <asp:MenuItemStyle Font-Size="8pt" Font-Underline="False" />
            </LevelMenuItemStyles>
        </asp:Menu>
                        </td>
                        <td style="WIDTH: 100%; HEIGHT: 884px" valign="top">                            


                                <cc1:WebReport ID="WebReport1" runat="server" BackColor="White" Font-Bold="False"
				    Width="100%" Height="100%"
				    OnStartReport="WebReport1_StartReport" ToolbarColor="Lavender"
                                    PrintInPdf="True"
                                    PdfEmbeddingFonts="True"
                                    Layers="true" Zoom="1"
                                    EmbedPictures ="false"
                                    SinglePage ="false"
                                    ToolbarStyle= "Large"
                                    ToolbarBackgroundStyle="Light"
                                    ToolbarIconsStyle="Black" DesignReport="False" PdfA="True"
                                    DesignScriptCode ="true" ReportResourceString="77u/PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0idXRmLTgiPz4NCjxSZXBvcnQgU2NyaXB0TGFuZ3VhZ2U9IkNTaGFycCIgUmVwb3J0SW5mby5DcmVhdGVkPSIwOS8yOS8yMDE1IDEyOjI2OjI0IiBSZXBvcnRJbmZvLk1vZGlmaWVkPSIwOS8yOS8yMDE1IDEyOjI2OjI5IiBSZXBvcnRJbmZvLkNyZWF0b3JWZXJzaW9uPSIxLjAuMC4wIj4NCiAgPERpY3Rpb25hcnkvPg0KICA8UmVwb3J0UGFnZSBOYW1lPSJQYWdlMSI+DQogICAgPFJlcG9ydFRpdGxlQmFuZCBOYW1lPSJSZXBvcnRUaXRsZTEiIFdpZHRoPSI3MTguMiIgSGVpZ2h0PSIzNy44Ii8+DQogICAgPFBhZ2VIZWFkZXJCYW5kIE5hbWU9IlBhZ2VIZWFkZXIxIiBUb3A9IjQxLjgiIFdpZHRoPSI3MTguMiIgSGVpZ2h0PSIyOC4zNSIvPg0KICAgIDxEYXRhQmFuZCBOYW1lPSJEYXRhMSIgVG9wPSI3NC4xNSIgV2lkdGg9IjcxOC4yIiBIZWlnaHQ9Ijc1LjYiLz4NCiAgICA8UGFnZUZvb3RlckJhbmQgTmFtZT0iUGFnZUZvb3RlcjEiIFRvcD0iMTUzLjc1IiBXaWR0aD0iNzE4LjIiIEhlaWdodD0iMTguOSIvPg0KICA8L1JlcG9ydFBhZ2U+DQo8L1JlcG9ydD4NCg==" DesignerLocale="fr" LocalizationFile="~/Localization/French.frl"
                                    />


                                </td>
                    </tr>
                </table>
                <br />
    </form>
</body>
</html>

