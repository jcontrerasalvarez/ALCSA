<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoAlzamientos.aspx.cs" Inherits="CobranzaALC.Cobranza.Alzamientos.ListadoAlzamientos" %>

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
            <div class="alert alert-success" role="alert"><span class="glyphicon glyphicon-edit"></span>&nbsp;<strong>ALZAMIENTOS REMESA</strong></div>

            <div class="panel panel-primary">
                <div class="panel-heading">
                    <asp:Button ID="btnNuevoAlzamiento" runat="server" Text="Nuevo Alzamiento" CssClass="btn btn-default" Width="150px" OnClick="btnNuevoAlzamiento_Click" />
                    <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-default" Width="150px" OnClick="btnVolver_Click" />
                </div>
                <div class="panel-body">

                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="gvAlzamientos" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" EmptyDataText="NO SE ENCONTRARON ALZAMIENTOS" AllowPaging="True" OnPageIndexChanging="gvAlzamientos_PageIndexChanging" PageSize="50">
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
                                            <asp:HyperLink ID="btnDetalle" runat="server" CssClass="glyphicon glyphicon-search" NavigateUrl='<%# Eval("ID","MantenedorAlzamiento.aspx?id_alz={0}") %>'></asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle Width="5%" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <asp:HiddenField ID="hdfIdRemesa" runat="server" Value="0" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>