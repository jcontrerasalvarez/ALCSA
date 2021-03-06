﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DiaHoraSubasta.aspx.cs" Inherits="CobranzaALC.Cobranza.Documentos.Formatos.DocumentosDos.DiaHoraSubasta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p style="text-align: left; font-family: Verdana;"><strong>SE FIJE DIA Y HORA PARA LA SUBASTA.-</strong>
        </p>
        <p style="text-align: center; font-family: Verdana;">
            <strong>S. J. L. (<asp:Label ID="lblTribunal" runat="server" EnableViewState="False"></asp:Label>).-</strong>
        </p>
        <br />
        <p style="text-align: justify; font-family: Verdana;">
            <strong>JOSÉ SANTANDER ROBLES,</strong> por la parte demandante en los autos caratulados <strong>&quot;<asp:Label ID="lblCliente" runat="server" EnableViewState="False"></asp:Label>&nbsp;</strong>con <strong>
                <asp:Label ID="lblDeudor" runat="server" EnableViewState="False"></asp:Label>&quot;</strong>, Rol Nº <strong>C-
                        <asp:Label ID="lblRol" runat="server" EnableViewState="False"></asp:Label></strong>, cuaderno apremio a US. respetuosamente digo:
        </p>
        <br />
        <p style="text-align: justify; font-family: Verdana;">
            Que vengo en solicitar a SS. se sirva resolver y fijar  día y hora para la subasta, para lo cual propongo el día ___  de _____ de ______, a las _____.- horas.
        </p>
        <br />
        <p style="text-align: center; font-family: Verdana;">
            <strong>POR TANTO,
            </strong>
        </p>
        <br />
        <p style="text-align: justify; font-family: Verdana;">
            <strong>RUEGO A US</strong>. Acceder a lo solicitado.-
        </p>
    </form>
</body>
</html>
