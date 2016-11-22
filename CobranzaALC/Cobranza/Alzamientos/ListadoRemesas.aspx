<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoRemesas.aspx.cs" Inherits="CobranzaALC.Cobranza.Alzamientos.ListadoRemesas" %>

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
            $('.detalle-remesa').click(function () {
                window.location = 'CargaMasivaRemesa.aspx';
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="alert alert-success" role="alert"><span class="glyphicon glyphicon-edit"></span>&nbsp;<strong>REMESAS</strong></div>

            <div class="panel panel-primary">
                <div class="panel-heading">
                    <div class="btn btn-default detalle-remesa" role="alert"><span class="glyphicon glyphicon-plus"></span>&nbsp;<strong>Ingresar Nueva Remesa</strong></div>
                </div>
                <div class="panel-body">

                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="gvRemesas" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" EmptyDataText="NO SE ENCONTRARON REMESAS">
                                <Columns>
                                    <asp:BoundField DataField="ID" DataFormatString="{0:00000}" HeaderText="ID" HtmlEncode="False">
                                        <ItemStyle HorizontalAlign="Right" Width="10%" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="UsuarioIngreso" HeaderText="Usuario Ingreso">
                                        <ItemStyle HorizontalAlign="Right" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FechaIngreso" DataFormatString="{0:dd-MM-yyyy}" HeaderText="Fecha Ingreso">
                                        <ItemStyle HorizontalAlign="Right" Width="15%" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="NumeroAlzamientosCargados" HeaderText="N° Alzamientos Cargados">
                                        <ItemStyle HorizontalAlign="Right" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NumeroAlzamientosEnCurso" HeaderText="N° Alzamientos en Curso">
                                        <ItemStyle HorizontalAlign="Right" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NumeroAlzamientosTerminados" HeaderText="N° Alzamientos Terminados">
                                        <ItemStyle HorizontalAlign="Right" Width="15%" />
                                    </asp:BoundField>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HyperLink ID="btnDetalle" runat="server" CssClass="glyphicon glyphicon-search" NavigateUrl='<%# Eval("ID","ListadoAlzamientos.aspx?id_rem={0}") %>'></asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle Width="5%" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
