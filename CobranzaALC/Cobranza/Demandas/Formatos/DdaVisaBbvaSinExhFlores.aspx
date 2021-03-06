﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DdaVisaBbvaSinExhFlores.aspx.cs" Inherits="CobranzaALC.Cobranza.Demandas.Formatos.DdaVisaBbvaSinExhFlores" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                <tr>
                    <td style="width: 30%">PROCEDIMIENTO</td>
                    <td style="width: 70%">:&nbsp;EJECUTIVO</td>
                </tr>
                <tr>
                    <td style="width: 30%">MATERIA</td>
                    <td style="width: 70%">:&nbsp;COBRO DE PAGARÉ</td>
                </tr>
                <tr>
                    <td style="width: 30%">DEMANDANTE</td>
                    <td style="width: 70%">:&nbsp;<asp:Label ID="lblNombreCliente" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%">RUT</td>
                    <td style="width: 70%">:&nbsp;<asp:Label ID="lblRutCliente" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%">ABOGADO PATROCINANTE</td>
                    <td style="width: 70%">:&nbsp;JOSE SANTANDER ROBLES</td>
                </tr>
                <tr>
                    <td style="width: 30%">RUT</td>
                    <td style="width: 70%">:&nbsp;10.050.813-3</td>
                </tr>
                <tr>
                    <td style="width: 30%">APODERADO</td>
                    <td style="width: 70%">:&nbsp;CLAUDIO VILLARROEL MELENDEZ</td>
                </tr>
                <tr>
                    <td style="width: 30%">RUT</td>
                    <td style="width: 70%">:&nbsp;10.650.279-K</td>
                </tr>
                <tr>
                    <td style="width: 30%">DEMANDADO</td>
                    <td style="width: 70%">:&nbsp;<asp:Label ID="lblNombreDeudor" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%">RUT</td>
                    <td style="width: 70%">:
                        <asp:Label ID="lblRutDeudor" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>

            <p style="text-align: justify; font-family: Verdana;">
                <br />
                <strong>EN LO PRINCIPAL:</strong> Demanda ejecutiva y mandamiento de ejecución y embargo. <strong>PRIMER OTROSI:</strong> Bienes para el embargo. <strong>SEGUNDO OTROSI:</strong> Acompaña documentos en la forma legal y custodia. <strong>TERCERO OTROSI:</strong> Cuantía. <strong>CUARTO OTROSI:</strong> Personería. <strong>QUINTO OTROSI:</strong> Exhorto; <strong>SEXTO OTROSI:</strong> Patrocinio y Poder
            </p>
            <p style="text-align: center; font-family: Verdana;">
                <br />
                <strong>S. 		J.		 L.</strong>
                <br />
            </p>
            <p style="text-align: justify; font-family: Verdana;">
                <strong>JOSE SANTANDER ROBLES, abogado, domiciliado en calle Estado Nº 359, Piso 13, Santiago,</strong> mandatario judicial y en representacion convencional del BANCO BILBAO VIZCAYA ARGENTARIA, CHILE, Sociedad Anónima Bancaria, según consta en escritura pública que se acompaña en un otrosí de esta presentación, representada Iegalmente por don Manuel Antonio Olivares Rossetti, Ingeniero Comercial, cédula de identidad número 8.496.988-, todos domiciliados para estos efectos en calle Barros Errázuriz Nº 1953, Piso 8º, comuna de Providencia, Región Metropolitana, a US. respetuosamente digo:
            </p>
            <p style="text-align: justify; font-family: Verdana;">
                Mi representado es dueño del siguiente pagaré suscrito por don (ña) <asp:Label ID="lblNombreDeudor0" runat="server" Font-Bold="True"></asp:Label>
                    ,  ignoro profesión u oficio, con domicilio en   
                <asp:Label ID="lblDomicilio" runat="server" Font-Bold="True"></asp:Label>
                , comuna de &lt;&lt;COMUNA&gt;&gt;, en calidad de deudor u obligado principal,  y  cuyos términos son los siguientes:
            </p>
            <p style="text-align: justify; font-family: Verdana;">
                - Pagaré B.B.V.A. número <asp:Label ID="lblNumeroPagare" runat="server" Font-Bold="True"></asp:Label>
                &nbsp;suscrito con fecha 15 de Septiembre de 2011, por la suma única y total de $ 1.656.706.-, pagadero al día   
                <asp:Label ID="lblFechaPrimerVencimiento" runat="server" Font-Bold="True"></asp:Label>
                . 
            </p>
            <p style="text-align: justify; font-family: Verdana;">
                En caso que el suscriptor no pagare íntegra y oportunamente la obligación, esta devengará desde el día de la mora y hasta el de su completo y efectivo pago, el interés máximo convencional que corresponda según el monto y plazo del pagaré.
            </p>
            <p style="text-align: justify; font-family: Verdana;">
                Se deja expresamente establecido, que en caso de cobro judicial corresponderá al suscriptor acreditar el pago del documento.     
            </p>
            <p style="text-align: justify; font-family: Verdana;">
                Todas las obligaciones que emanen de este pagaré serán solidarias para los suscriptores, avalistas y demás obligados al pago, y serán indivisibles para dichos obligados, sus herederos y/o sucesores, conforme a lo dispuesto en los artículos 1526 N° 4 y 1528 del Código Civil. 
            </p>
            <p style="text-align: justify; font-family: Verdana;">
                Para todos los efectos legales las partes constituyeron domicilio en la comuna de Santiago y se somete a la competencia de los tribunales de la misma.
            </p>
            <p style="text-align: justify; font-family: Verdana;">
                Se estipula la clausula sin obligación de protesto, pero si el tenedor optare por la realización de dicha diligencia, podrá hacerla. En todo caso, se estipuló que en el evento de protesto el suscriptor se obliga a pagar los gastos e impuestos que devenguen.
            </p>
            <p style="text-align: justify; font-family: Verdana;">
                La firma del suscriptor se encuentra autorizadas por notario público, por lo que el pagaré constituye titulo ejecutivo perfecto en su contra, siendo además, la obligación liquida, actualmente exigible y la acción ejecutiva no está prescrita.
            </p>
            <p style="text-align: justify; font-family: Verdana;">
                Se hace presente, que el deudor se encuentra en mora de la obligación desde el día del vencimiento, es decir, desde 30 de Diciembre de 2013 en adelante, incumplimiento que faculta al banco para exigir de inmediato la totalidad de la deuda, por lo que vengo en exigir el pago total de la obligación del pagaré, mediante la notificación de la presente demanda.
            </p>
            <p style="text-align: justify; font-family: Verdana;">
                Dicha deuda, de conformidad a lo establecido en el propio pagaré,  asciende a la cantidad $1.656.706.-, correspondiente a capital adeudado vencido, más los intereses convencionales y penales que se generen a contar desde la mora, hasta la fecha del pago efectivo de la deuda mas las costas del juicio.
            </p>
            <p style="text-align: center; font-family: Verdana;">
                <br />
                <strong>POR TANTO,
                <br />
            </strong>
            </p>
            <p style="text-align: justify; font-family: Verdana;">
                de acuerdo a lo dispuesto y de conformidad a las normas de las leyes números 18.010, Ley 18.092 y Ley 19.951 y a los artículos 434 y siguientes del Código de Procedimiento Civil,
            </p>
            <p style="text-align: justify; font-family: Verdana;">
                <strong>RUEGO A US.</strong>, tener por entablada demanda ejecutiva y despachar mandamiento de ejecución y embargo en contra de don <asp:Label ID="lblNombreDeudor1" runat="server" Font-Bold="True"></asp:Label>
                    &nbsp;debidamente individualizado, en su calidad de suscriptor y deudor principal del pagare singularizado, por la suma de $1.656.706.-, correspondiente a capital adeudado vencido, ello más los intereses correspondientes, que se generan a contar desde la mora y hasta la fecha del pago efectivo de la deuda, mas las costas del juicio y disponer que se continúe la ejecución, acogiendo la demanda en todas sus partes, hasta que se haga a mi representado entero pago de sus acreencias, con costas. 
            </p>
            <p style="text-align: justify; font-family: Verdana;">
                <strong>PRIMER OTROSI:</strong> Ruego a US., tener presente que señalo como bienes para la traba del embargo todos aquellos muebles e inmuebles que actualmente sean o, aparezcan posteriormente como de dominio del ejecutado. 
            </p>
            <p style="text-align: justify; font-family: Verdana;">
                <strong>SEGUNDO OTROSI:</strong> Ruego a S.S. tener por acompañados en la forma legal y ordenar la <strong>custodia</strong> de los siguientes documentos:
            </p>
            <p style="text-align: justify; font-family: Verdana;">
                <strong>1.-</strong> Con citación, Pagaré B.B.V.A. número<strong> </strong> <asp:Label ID="lblNumeroPagare0" runat="server" Font-Bold="True"></asp:Label>
                .
            </p>
            <p style="text-align: justify; font-family: Verdana;">
                <strong>2.-</strong> Con citación, copia autorizada de mi personería para representar a Banco Bilbao Vizcaya Argentaria, Chile que consta de la escritura de fecha 22 de Enero de 2014, otorgada en la Notaria de Santiago, de don Eduardo Avello Concha.
            </p>
            <p style="text-align: justify; font-family: Verdana;">
                <strong>TERCER OTROSI:</strong> Ruego a S.S. tener presente para el solo efecto de determinar la cuantía del juicio, el valor de lo demandado asciende a la suma de $1.656.706.-, correspondiente a capital adeudado vencido, todo ello más los intereses correspondientes que se generan a contar desde la fecha de la mora, hasta la fecha del pago efectivo de la deuda, mas costas.
            </p>
            <p style="text-align: justify; font-family: Verdana;">
                <strong>CUARTO OTROSI:</strong> Ruego a US. tener presente, que mi personería para actuar en representación del BANCO BILBAO VIZCAYA ARGENTARIA, CHILE consta de la escritura de fecha 22 de Enero de 2014, otorgada en la Notaria de Santiago, de don Eduardo Avello Concha, copia autorizada de la cual acompaño en el segundo otrosí de esta demanda.
            </p>
            <p style="text-align: justify; font-family: Verdana;">
                <strong>QUINTO OTROSI:</strong> Ruego a SS., tener presente que en mi calidad de abogado habilitado, asumo personalmente el patrocinio y poder en esta causa, y a la vez confiero poder al abogado don <strong>CLAUDIO VILLARROEL MELENDEZ</strong>, de mi mismo domicilio, pudiendo actuar de manera conjunta o separada indistintamente con el suscrito.
            </p>
        </div>
    </form>
</body>
</html>
