<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MantenedorAlzamiento.aspx.cs" Inherits="CobranzaALC.Cobranza.Alzamientos.MantenedorAlzamiento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../js/jquery-ui-1.10.3.custom.min.js"></script>
    <script type="text/javascript" src="../../js/bootstrap.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="alert alert-success" role="alert"><span class="glyphicon glyphicon-edit"></span>&nbsp;<strong>ALZAMIENTO</strong></div>

            <div class="panel panel-primary">
                <div class="panel-heading">
                    Información Alzamiento
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-4">
                            <label>Remesa</label>
                            <asp:Label ID="lblIdRemesa" runat="server" Text="" CssClass="form-control" ClientIDMode="Static"></asp:Label>
                        </div>
                        <div class="col-md-4">
                            <label>Estado</label>
                            <asp:Label ID="lblEstado" runat="server" Text="" CssClass="form-control" ClientIDMode="Static"></asp:Label>
                        </div>
                        <div class="col-md-4">

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <label>RUT Cliente</label>
                            <asp:TextBox ID="txtRutDeudor" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-8">
                            <label>Nombre Cliente</label>
                            <asp:TextBox ID="txtNombreDeudor" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-8">
                            <label>Dirección</label>
                            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>Comuna</label>
                            <asp:DropDownList ID="ddlComuna" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <label>Notario</label>
                            <asp:DropDownList ID="ddlNotario" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:DropDownList>
                        </div>
                        <div class="col-md-4">
                            <label>Dirección</label>
                            <asp:TextBox ID="txtNumeroOperacion" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>Conservador</label>
                            <asp:TextBox ID="txtConservador" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <label>Fojas Dominio</label>
                            <asp:TextBox ID="txtFojasDominio" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>N° Dominio</label>
                            <asp:TextBox ID="txtNumeroDominio" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>Año Dominio</label>
                            <asp:TextBox ID="txtAnoDominio" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <label>Fojas Hipoteca</label>
                            <asp:TextBox ID="txtFojasHipoteca" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>N° Hipoteca</label>
                            <asp:TextBox ID="txtNumeroHipoteca" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>Año Hipoteca</label>
                            <asp:TextBox ID="txtAnoHipoteca" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <label>Fojas Prohibición</label>
                            <asp:TextBox ID="txtFojasProhibicion" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>N° Prohibición</label>
                            <asp:TextBox ID="txtNumeroProhibicion" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>Año Prohibición</label>
                            <asp:TextBox ID="txtAnoProhibicion" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <label>Fecha Contabilización</label>
                            <asp:TextBox ID="txtFechaContabilizacion" runat="server" CssClass="form-control control-calendario" ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>Fecha Entrega</label>
                            <asp:TextBox ID="txtFechaEntrega" runat="server" CssClass="form-control control-calendario" ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>Fecha Escritura</label>
                            <asp:TextBox ID="txtFechaEscritura" runat="server" CssClass="form-control control-calendario" ClientIDMode="Static"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <label>Repertorio</label>
                            <asp:TextBox ID="txtRepertorio" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>Protocolo</label>
                            <asp:TextBox ID="txtProtocolo" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>N° Carillas</label>
                            <asp:TextBox ID="txtNumeroCarillas" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <label>Factura</label>
                            <asp:TextBox ID="txtFactura" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>Fecha Factura</label>
                            <asp:TextBox ID="txtFechaFactura" runat="server" CssClass="form-control control-calendario" ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>Centro de Costos</label>
                            <asp:TextBox ID="txtCentroCostos" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <label>Observación</label>
                            <asp:TextBox ID="txtObservacion" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                        </div>
                    </div>


                </div>
                <div class="panel-footer">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-default" Width="150px" OnClick="btnGuardar_Click"/>
                    <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-default" Width="150px" OnClick="btnVolver_Click" />
                </div>
            </div>
            <asp:HiddenField ID="hdfIdRemesa" runat="server" Value="0" ClientIDMode="Static" />
            <asp:HiddenField ID="hdfIdAlzamiento" runat="server" Value="0" ClientIDMode="Static" />
        </div>
    </form>
</body>
</html>
