﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActividadCobranza.aspx.cs" Inherits="CobranzaALC.Cobranza.Procesos.ActividadCobranza" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ALC Asesorìa Legal y Crediticía Ltda</title>
    <link href="../../css/alc2.css" rel="stylesheet" type="text/css" />
    <link href="../../css/alc_estilo.css" rel="stylesheet" />
    <link href="../../css/start/jquery-ui-1.10.3.custom.min.css" rel="stylesheet" />

    <script src="../../js/funciones.js" type="text/javascript"></script>

    <script type="text/javascript" src="../../js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../js/jquery-ui-1.10.3.custom.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('.control-calendario').datepicker({
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true,
                maxDate: 0
            });
            $('.control-solo-lectura').prop('readonly', true);


            $('#txtFechaProximaGestion').datepicker({
                dateFormat: 'dd/mm/yy'
            });

            $('#txtFechaTramite').datepicker({
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true,
                maxDate: 0,
                onSelect: function () {
                    AsignarFechaLimite();
                }
            });

            $('#btnPoderJudicial').click(function () {
                window.open('http://civil.poderjudicial.cl/CIVILPORWEB/', 'ventana', '');
            });

            $('#btnActividades').click(function () {
                var ventana = window.open('MostrarActividades.aspx?Codigo=' + $('#hdfIdJuicio').val() + '&tipo=' + $('#hdfTipoActividad').val(), 'ventana', 'width=900,height=650,scrollbars=1,satus=0,menubar=no,top=10,left=100');
                ventana.focus();
            });
            
            $('#ddlSubTramites').change(function () {
                var _valorSeleccionado = $(this).val();
                var _valorFecha = $('#txtFechaSubTramite').val();

                if (_valorSeleccionado == '') $('#txtFechaSubTramite').val('');
                else if(_valorFecha == '')
                    $('#txtFechaSubTramite').datepicker('setDate', new Date());
            });

            AsignarFechaLimite();

            $("#divMensaje").dialog({
                resizable: false,
                autoOpen: false,
                height: 250,
                width: 500,
                modal: true,
                buttons: {
                    Cerrar: function () {
                        $(this).dialog("close");
                    }
                }
            });

            if (parseInt($('#hdfIdGasto').val()) > 0) {
                var ruta = '../Documentos/Descargar.aspx?id=' + $('#hdfIdGasto').val() + '&nom_id_doc=id&tipo_id_doc=TIGAS&ruta=Formatos/Gastos/ComprobanteIngreso.aspx';
                var ventana = window.open(ruta, 'descarga_archivo', '');
                ventana.focus();
                return;
            }

            if ($('#hdfMostrarMensaje').val() != '1') return;
            $('#pTextoArchivo').hide();

            if (parseInt($('#hdfIdDocumento').val()) > 0) {
                $('#pTextoArchivo').show();
                $('#divMensaje').dialog('option', 'buttons', {
                    'Generar Código Barra': function () {
                        var ruta = '../Documentos/Descargar.aspx?id=' + $('#hdfIdDocumento').val() + '&tipo=DCFIS&ruta=General/GeneradorCodigoBarra.aspx';
                        window.open(ruta, 'descarga_archivo', '');
                        $(this).dialog("close");
                    },
                    'Cerrar': function () {
                        $(this).dialog("close");
                    }
                });
            }

            $("#divMensaje").dialog('open');
        });

        function ValidarGuardar() {
            var _fechaTramite = $("#txtFechatramite").datepicker('getDate');
            var _fechaActual = new Date();
            var _fechaMinima = new Date();
            _fechaMinima.setFullYear(1900, 1, 1);

            if (_fechaTramite <= _fechaMinima) {
                alert('Debe ingresar la fecha de trámite.');
                return false;
            }
            else if (_fechaTramite > _fechaActual) {
                alert('La fecha de trámite no debe ser mayor a la fecha actual.');
                return false;
            }

            var mensaje = 'Esta seguro de guardar la actividad del juicio ?';
            if ($('#ddlTramites').val().split('-', 3)[2] == 'S' || $('#ddlSubTramites').val().split('-', 2)[1] == 'S')
                mensaje = '¿Acaba de seleccionar término de juicio, está seguro?';

            return confirm(mensaje);
        }

        function AsignarFechaLimite() {
            var fecha = $('#txtFechaTramite').datepicker('getDate');
            if (fecha == null) return;
            var fechaFinal = new Date(fecha);
            fechaFinal.setDate(fecha.getDate() + parseInt($('#hdfNumeroDias').val()));
            $('#txtFechaProximaGestion').datepicker('setDate', fechaFinal);
        }

    </script>
</head>
<body>
    <form runat="server" id="Formulario">
        <table border="0" style="width: 800px">
            <tr>
                <td class="barra-titulo" colspan="4">SISTEMA DE COBRANZA</td>
                </tr>

            <tr>
                <td class="barra-sub-titulo" colspan="4">INGRESO ACTIVIDAD JUDICIAL</td>
            </tr>

            <tr>
                <td align="left" style="width: 20%" >N° Operación</td>
                <td align="left" style="width: 30%"  >
                    <asp:TextBox ID="txtNroOperacion" runat="server"
                         ReadOnly="True" Width="95%"></asp:TextBox>
                </td>
                <td align="left" style="width: 20%" >Cliente</td>
                <td align="left"style="width: 30%" >
                    <asp:TextBox ID="txtCliente" runat="server"
                         ReadOnly="True" Width="95%"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td align="left" style="width: 20%" >Rut Deudor</td>
                <td align="left" style="width: 30%"  >
                    <asp:TextBox ID="txtRutDeudor" runat="server"
                         ReadOnly="True" Width="95%"></asp:TextBox>
                </td>
                <td align="left" style="width: 20%" >Deudor</td>
                <td align="left"style="width: 30%" >
                    <asp:TextBox ID="txtNomDeudor" runat="server"
                         ReadOnly="True" Width="95%"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td align="left" style="width: 20%" >Procedimiento</td>
                <td align="left" style="width: 30%"  >
                    <asp:TextBox ID="txtProcedimiento" runat="server"
                         ReadOnly="True" Width="95%"></asp:TextBox>
                </td>
                <td align="left" style="width: 20%" >Materia</td>
                <td align="left"style="width: 30%" >
                    <asp:TextBox ID="txtMateria" runat="server"
                         ReadOnly="True" Width="95%"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td align="left" style="width: 20%" >Producto</td>
                <td align="left" style="width: 30%"  >
                    <asp:TextBox ID="txtProducto" runat="server"
                         ReadOnly="True" Width="95%"></asp:TextBox>
                </td>
                <td align="left" style="width: 20%" >Número Sucursal</td>
                <td align="left"style="width: 30%" >
                    <asp:TextBox ID="txtNumeroSucursal" runat="server"
                         ReadOnly="True" Width="95%">SIN NÚMERO</asp:TextBox>
                </td>
            </tr>


            <tr>
                <td align="right" class="barra-sub-titulo" colspan="4" >
                    <asp:Button ID="btnGastos" runat="server" CssClass="boton" OnClick="btnGastos_Click" Text="Agregar Gasto" />
                    &nbsp;<input id="btnPoderJudicial" type="button" value="Poder Judicial" class="boton" />
                    <input id="btnActividades" type="button" value="Ver Actividades" class="boton" /></td>
            </tr>


            <tr>
                <td align="left" style="width: 20%" >Rol-Rit</td>
                <td align="left" style="width: 30%"  >
                    <asp:TextBox ID="txtRol" runat="server"
                         ReadOnly="True" Width="95%"></asp:TextBox>
                </td>
                <td align="left" style="width: 20%" >Tribunal</td>
                <td align="left"style="width: 30%" >
                    <asp:TextBox ID="txtTribunal" runat="server"
                         ReadOnly="True" Width="95%"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td align="left" style="width: 20%" >Fecha Ing. Corte</td>
                <td align="left" style="width: 30%"  >
                    <asp:TextBox ID="txtFechaIngCorte" runat="server" Enabled="false" Width="95%"></asp:TextBox>
                </td>
                <td align="left" style="width: 20%" >&nbsp;</td>
                <td align="left"style="width: 30%" ></td>
            </tr>

            <tr>
                <td align="left" class="barra-sub-titulo" colspan="4" >Trámite</td>
            </tr>

            <tr>
                <td align="left" style="width: 20%" >Trámite</td>
                <td align="left" style="width: 30%"  >
                    <asp:DropDownList ID="ddlTramites" runat="server" Width="95%" AutoPostBack="True" DataTextField="descripcion" DataValueField="id_tramite" OnSelectedIndexChanged="ddlTramites_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td align="left" style="width: 20%" >Fecha Trámite</td>
                <td align="left"style="width: 30%" >
                    <asp:TextBox ID="txtFechaTramite" runat="server" MaxLength="10" Width="95%"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td align="left" style="width: 20%" >&nbsp;</td>
                <td align="left" style="width: 30%"  >
                    <asp:HiddenField ID="hdfNumeroDias" runat="server" Value="1" />
                </td>
                <td align="left" style="width: 20%" >Fecha Límite</td>
                <td align="left"style="width: 30%" >
                    <asp:TextBox ID="txtFechaProximaGestion" runat="server" Width="95%" Enabled="False" CssClass="control-solo-lectura"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td align="left" style="width: 20%" >&nbsp;</td>
                <td align="left" style="width: 30%"  >
                    &nbsp;</td>
                <td align="left" style="width: 20%" >Proxima Gestión</td>
                <td align="left"style="width: 30%" >
                    <asp:TextBox ID="txtProximoTramite" runat="server" Width="95%" Enabled="False"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td align="left" class="barra-sub-titulo" colspan="4" >sub-trámite</td>
            </tr>

            <tr>
                <td align="left" style="width: 20%" >Sub Trámite</td>
                <td align="left" style="width: 30%"  >
                    <asp:DropDownList ID="ddlSubTramites" runat="server" Width="95%" DataTextField="descripcion" DataValueField="id_sub_tramite">
                    </asp:DropDownList>
                </td>
                <td align="left" style="width: 20%" >Fecha Sub Trámite</td>
                <td align="left"style="width: 30%" >
                    <asp:TextBox ID="txtFechaSubTramite" runat="server" MaxLength="10" Width="95%" CssClass="control-calendario control-solo-lectura"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td align="left" class="barra-sub-titulo" colspan="4" >observación</td>
            </tr>

            <tr>
                <td align="left" style="width: 20%" >Observación</td>
                <td align="left"  colspan="3" >
                    <asp:TextBox ID="observacion" runat="server"
                        TextMode="MultiLine" MaxLength="10" Width="98%" Height="50px"></asp:TextBox>
                </td>

            </tr>
            <!--<asp:Panel ID="pnlCorreo" runat="server" Visible="false">-->
            <tr>
                <td align="left" class="barra-sub-titulo" colspan="4" >&nbsp;Correo aviso suspención de acciones</td>
                
            </tr>

            <tr>
                <td align="left" style="width: 20%" >Destinatarios</td>
                <td align="left"  colspan="3" >
                    <asp:TextBox ID="txtDestinatarios" runat="server" Width="97%" TextMode="MultiLine"></asp:TextBox>
                    <br />
                    <span style="font: normal 10px Verdana">
                    Para agregar varios destinatarios, separelos por &quot;,&quot;:<br />
                    Ejemplo: usuario@alcsa.cl, usuario_uno@alcsa.cl, usuario_dos@alcsa.cl</span>
                </td>

            </tr>
            <!--</asp:Panel>-->
            <tr>
                <td class="barra-sub-titulo" colspan="4" align="right">
                    <asp:Button ID="btnGuardar" runat="server" CssClass="boton" OnClick="btnGuardar_Click" OnClientClick="return ValidarGuardar();" Text="Guardar" />
                    &nbsp;<asp:Button ID="btnCancelar" runat="server" CssClass="boton" OnClick="btnCancelar_Click" Text="Cancelar" />
                </td>
            </tr>
        </table>

        <asp:HiddenField ID="hdfIdJuicio" runat="server" Value="0" />
        <asp:HiddenField ID="hdfIdCobranza" runat="server" Value="0" />
        <asp:HiddenField ID="hdfTipoActividad" runat="server" Value="" />

        <asp:HiddenField ID="hdfMostrarMensaje" runat="server" Value="" EnableViewState="false" ClientIDMode="Static" />
        <asp:HiddenField ID="hdfIdDocumento" runat="server" Value="" EnableViewState="false" ClientIDMode="Static" />

        <asp:HiddenField ID="hdfIdGasto" runat="server" Value="0" EnableViewState="false" ClientIDMode="Static" />
        
        <div id="divMensaje" title="Cobranza">
            <p>No hay ningún tramite registrado, debe guardar..</p>
            <p id="pTextoArchivo">¿Desea generar el código de barra del archivo que subió al guardar el juicio?</p>
        </div>
    </form>
</body>
</html>