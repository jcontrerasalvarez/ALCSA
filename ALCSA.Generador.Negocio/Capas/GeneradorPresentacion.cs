using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Generador.Negocio.Capas
{
    public class GeneradorPresentacion : BaseGenerador
    {
        public GeneradorPresentacion(BD.Tabla tabla, string ruta, string espacioNombre) : base(tabla, ruta, espacioNombre) { }

        public void GenerarPaginas()
        {
            List<String> arrLineas = new List<string>();
            string strNombreEntidad = ALCSA.FWK.Texto.ConvertirAMinusculaPrimeraEnMayuscula(InfoTabla.Nombre.Replace("_", " ")).Replace(" ", String.Empty);
            RutaCarpeta += strNombreEntidad;

            GenerarPaginaListar(arrLineas, strNombreEntidad);
            GuardarArchivo(arrLineas, "Listar", ".aspx");

            arrLineas = new List<string>();
            GenerarCodeBehindListar(arrLineas, strNombreEntidad);
            GuardarArchivo(arrLineas, "Listar", ".aspx.cs");

            arrLineas = new List<string>();
            GenerarDesignerListar(arrLineas, strNombreEntidad);
            GuardarArchivo(arrLineas, "Listar", ".aspx.designer.cs");

            arrLineas = new List<string>();
            GenerarPaginaMantenedor(arrLineas, strNombreEntidad);
            GuardarArchivo(arrLineas, "Mantenedor", ".aspx");

            arrLineas = new List<string>();
            GenerarCodeBehindMantenedor(arrLineas, strNombreEntidad);
            GuardarArchivo(arrLineas, "Mantenedor", ".aspx.cs");

            arrLineas = new List<string>();
            GenerarDesignerMantenedor(arrLineas, strNombreEntidad);
            GuardarArchivo(arrLineas, "Mantenedor", ".aspx.designer.cs");
        }

        #region Listar.aspx"

        private void GenerarPaginaListar(List<String> lineas, string nombreEntidad)
        {
            lineas.Add(String.Format("<%@ Page Title=\"\" Language=\"C#\" MasterPageFile=\"~/MasterPages/Principal.Master\" AutoEventWireup=\"true\" CodeBehind=\"Listar.aspx.cs\" Inherits=\"SIMEF_II.Modulos.Licitaciones.{0}.Listar\" %>",
                nombreEntidad));

            lineas.Add(string.Empty);

            lineas.Add("<asp:Content ID=\"Content1\" ContentPlaceHolderID=\"cphContenedorPrincipal\" runat=\"server\">");


            lineas.Add("<table width=\"100%\" align=\"left\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" class=\"caja\">");
            lineas.Add("<tr>");
            lineas.Add("    <td align=\"left\" class=\"caja_th\">");
            lineas.Add(string.Format("        {0}", nombreEntidad));
            lineas.Add("    </td>");
            lineas.Add("</tr>");
            lineas.Add("<tr>");
            lineas.Add("    <td align=\"left\">");
            lineas.Add("        <a href=\"Mantenedor.aspx?id=0\">");
            lineas.Add("            <img src=\"../../../assets/iconos/icono_agregar.png\" width=\"10px\" height=\"10px\" alt=\"*\" />");
            lineas.Add("            Agregar Nueva {0}");
            lineas.Add("        </a>");
            lineas.Add("    </td>");
            lineas.Add("</tr>");
            lineas.Add("<tr>");
            lineas.Add("    <td align=\"left\">");
            GenerarGrilla(lineas, nombreEntidad);
            lineas.Add("     </td>");
            lineas.Add("</tr>");
            lineas.Add("</table>");
            lineas.Add("</asp:Content>");
        }

        private void GenerarGrilla(List<String> lineas, string nombreEntidad)
        {

            lineas.Add(string.Format("    <asp:GridView ID=\"gv{0}\" runat=\"server\" AutoGenerateColumns=\"False\" Width=\"50%\" EnableViewState=\"False\">", nombreEntidad));
            lineas.Add("        <Columns>");

            for (int intIndice = 0; intIndice < InfoTabla.Columnas.Count; intIndice++)
            {
                lineas.Add(string.Format("            <asp:BoundField HeaderText=\"{0}\" DataField=\"{1}\">",
                    ALCSA.FWK.Texto.ConvertirAMinusculaPrimeraEnMayuscula(InfoTabla.Columnas[intIndice].Nombre.Replace("_", " ")), InfoTabla.Columnas[intIndice].Nombre));
                lineas.Add("            <ItemStyle Width=\"20%\" />");
                lineas.Add("            </asp:BoundField>");
            }

            lineas.Add("            <asp:TemplateField>");
            lineas.Add("                <ItemTemplate>");
            lineas.Add("                    <asp:HyperLink ID=\"hlkModificar\" runat=\"server\" EnableViewState=\"false\" ImageUrl=\"~/assets/iconos/icono_actualizar.png\"");
            lineas.Add("                        NavigateUrl='<%# Eval(\"ID\", \"Mantenedor.aspx?id={0}\") %>'>Modificar</asp:HyperLink>");
            lineas.Add("                </ItemTemplate>");
            lineas.Add("                <ItemStyle HorizontalAlign=\"Center\" Width=\"25px\" />");
            lineas.Add("            </asp:TemplateField>");
            lineas.Add("        </Columns>");
            lineas.Add("    </asp:GridView>");
        }

        private void GenerarCodeBehindListar(List<String> lineas, string nombreEntidad)
        {
            GenerarNamespaces(lineas);

            lineas.Add(string.Format("namespace SIMEF_II.Modulos.{0}.{1}", "", nombreEntidad));
            lineas.Add("{");
            lineas.Add("    public partial class Listar : System.Web.UI.Page");
            lineas.Add("    {");
            lineas.Add("        protected void Page_Load(object sender, EventArgs e)");
            lineas.Add("        {");
            lineas.Add("            if (Page.IsPostBack) return;");
            lineas.Add(string.Format("            gv{0}.DataSource = null;", nombreEntidad));
            lineas.Add(string.Format("            gv{0}.DataBind();", nombreEntidad));
            lineas.Add("        }");
            lineas.Add("    }");
            lineas.Add("}");
        }

        private void GenerarDesignerListar(List<String> lineas, string nombreEntidad)
        {
            lineas.Add("//------------------------------------------------------------------------------");
            lineas.Add("// <auto-generated>");
            lineas.Add("//     This code was generated by a tool.");
            lineas.Add("//");
            lineas.Add("//     Changes to this file may cause incorrect behavior and will be lost if");
            lineas.Add("//     the code is regenerated. ");
            lineas.Add("// </auto-generated>");
            lineas.Add("//------------------------------------------------------------------------------");
            lineas.Add("");
            lineas.Add(String.Format("namespace SIMEF_II.Modulos.Licitaciones.{0} ", nombreEntidad));
            lineas.Add("{");
            lineas.Add("public partial class Listar {");
            lineas.Add(String.Format("        protected global::System.Web.UI.WebControls.GridView gv{0};", nombreEntidad));
            lineas.Add("    }");
            lineas.Add("}");
        }

        #endregion

        #region Mantenedor

        private void GenerarPaginaMantenedor(List<String> lineas, string nombreEntidad)
        {
            lineas.Add(String.Format("<%@ Page Title=\"\" Language=\"C#\" MasterPageFile=\"~/MasterPages/Principal.Master\" AutoEventWireup=\"true\" CodeBehind=\"Mantenedor.aspx.cs\" Inherits=\"SIMEF_II.Modulos.Licitaciones.{0}.Mantenedor\" %>",
                nombreEntidad));

            lineas.Add("<asp:Content ID=\"Content1\" ContentPlaceHolderID=\"cphContenedorPrincipal\" runat=\"server\">");


            lineas.Add("<table width=\"100%\" align=\"left\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" class=\"caja\">");
            lineas.Add("<tr>");
            lineas.Add("    <td colspan=\"2\" align=\"left\" class=\"caja_th\">");
            lineas.Add(string.Format("        {0}", nombreEntidad));
            lineas.Add("    </td>");
            lineas.Add("</tr>");

            for (int intIndice = 0; intIndice < InfoTabla.ColumnasSinLlavesPrimarias.Count; intIndice++)
                GenerarFilaTabla(lineas, InfoTabla.ColumnasSinLlavesPrimarias[intIndice]);

            GenerarFilaBoton(lineas);
            lineas.Add("</table>");
            lineas.Add("<script type=\"text/javascript\">");
            lineas.Add("    function ConfirmarEliminacion() {");
            lineas.Add(string.Format("        event.returnValue = confirm('¿ Esta seguro que desea eliminar la {0} ?');", nombreEntidad));
            lineas.Add("    }");
            lineas.Add(string.Empty);
            lineas.Add("    function Volver() {");
            lineas.Add("        window.location = 'Listar.aspx';");
            lineas.Add("    }");
            lineas.Add("</script>");
            lineas.Add("</asp:Content>");
        }

        private void GenerarFilaTabla(List<String> lineas, ALCSA.Generador.Entidades.BD.Columna columna)
        {
            string strNombre = ALCSA.FWK.Texto.ConvertirAMinusculaPrimeraEnMayuscula(columna.Nombre).Replace("_", " ").Replace(" ", string.Empty);

            lineas.Add("    <tr>");
            lineas.Add("        <td align=\"left\" style=\"width: 15%\">");
            lineas.Add(string.Format("        {0}</td>",
                 ALCSA.FWK.Texto.ConvertirAMinusculaPrimeraEnMayuscula(columna.Nombre).Replace("_", " ")));
            lineas.Add("        <td align=\"left\" style=\"width: 85%\">");

            if (!strNombre.StartsWith("Id"))
                lineas.Add(string.Format("            <asp:TextBox ID=\"txt{0}\" runat=\"server\" Width=\"90%\"></asp:TextBox>", strNombre));
            else lineas.Add(string.Format("            <asp:DropDownList ID=\"ddl{0}\" DataTextField=\"Nombre\" DataValueField=\"ID\" runat=\"server\" Width=\"90%\"></asp:DropDownList>", strNombre));

            lineas.Add("        </td>");
            lineas.Add("    </tr>");
        }

        private void GenerarFilaBoton(List<String> lineas)
        {
            lineas.Add("    <tr>");
            lineas.Add("        <td align=\"left\" style=\"width: 20%\">");
            lineas.Add("            <asp:HiddenField ID=\"hdfId\" runat=\"server\" Value=\"0\" />");
            lineas.Add("        </td>");
            lineas.Add("        <td align=\"left\" style=\"width: 80%\">");
            lineas.Add("            <asp:Button ID=\"btnGuardar\" runat=\"server\" Text=\"Guardar\" OnClick=\"btnGuardar_Click\" CssClass=\"boton_interior\" Width=\"80px\" />");
            lineas.Add("            <asp:Button ID=\"btnEliminar\" runat=\"server\" CssClass=\"boton_interior\" OnClick=\"btnEliminar_Click\" Text=\"Eliminar\" Width=\"80px\" />");
            lineas.Add("            <input id=\"btnVolver\" type=\"button\" class=\"boton_interior\" value=\"Volver\" onclick=\"Volver();\" style=\"width: 80px;\" />");
            lineas.Add("        </td>");
            lineas.Add("    </tr>");
        }

        private void GenerarCodeBehindMantenedor(List<String> lineas, string nombreEntidad)
        {
            GenerarNamespaces(lineas);
            lineas.Add(string.Format("namespace SIMEF_II.Modulos.{0}.{1}", "", nombreEntidad));
            lineas.Add("{");
            lineas.Add("    public partial class Mantenedor : System.Web.UI.Page");
            lineas.Add("    {");
            lineas.Add("        protected void Page_Load(object sender, EventArgs e)");
            lineas.Add("        {");
            lineas.Add("            if (Page.IsPostBack) return;");
            lineas.Add("            int intId = 0;");
            lineas.Add("            if (Int32.TryParse(Request.QueryString[\"id\"], out intId) && intId > 0)");
            lineas.Add("            {");
            lineas.Add("            }");
            lineas.Add("            btnEliminar.Attributes.Add(\"onClick\", \"ConfirmarEliminacion()\");");
            lineas.Add("        }");
            lineas.Add(string.Empty);
            lineas.Add("        protected void btnGuardar_Click(object sender, EventArgs e)");
            lineas.Add("        {");
            lineas.Add(string.Format("          {0}Negocio.{1} obj{1} = new {0}Negocio.{1}();", EspacioNombre, nombreEntidad));
            lineas.Add(string.Format("          obj{0}.ID = Convert.ToInt32(hdfId.Value);", nombreEntidad));
            lineas.Add(string.Format("           obj{0}.Guardar();", nombreEntidad));
            lineas.Add(string.Format("           hdfId.Value = obj{0}.ID.ToString();", nombreEntidad));
            lineas.Add("        }");
            lineas.Add(string.Empty);
            lineas.Add("        protected void btnEliminar_Click(object sender, EventArgs e)");
            lineas.Add("        {");
            lineas.Add("            int intId = Convert.ToInt32(hdfId.Value);");
            lineas.Add(string.Format("          {0}Negocio.{1} obj{1} = new {0}Negocio.{1}(intId);", EspacioNombre, nombreEntidad));
            lineas.Add(string.Format("          obj{0}.Eliminar();", nombreEntidad));
            lineas.Add("            Response.Redirect(\"Listar.aspx\", true);");
            lineas.Add("        }");
            lineas.Add("    }");
            lineas.Add("}");

        }

        private void GenerarDesignerMantenedor(List<String> lineas, string nombreEntidad)
        {
            lineas.Add("//------------------------------------------------------------------------------");
            lineas.Add("// <auto-generated>");
            lineas.Add("//     This code was generated by a tool.");
            lineas.Add("//");
            lineas.Add("//     Changes to this file may cause incorrect behavior and will be lost if");
            lineas.Add("//     the code is regenerated. ");
            lineas.Add("// </auto-generated>");
            lineas.Add("//------------------------------------------------------------------------------");
            lineas.Add("");
            lineas.Add(String.Format("namespace SIMEF_II.Modulos.Licitaciones.{0} ", nombreEntidad));
            lineas.Add("{");
            lineas.Add("public partial class Mantenedor {");

            string strNombre;
            for (int intIndice = 0; intIndice < InfoTabla.ColumnasSinLlavesPrimarias.Count; intIndice++)
            {
                strNombre = ALCSA.FWK.Texto.ConvertirAMinusculaPrimeraEnMayuscula(InfoTabla.ColumnasSinLlavesPrimarias[intIndice].Nombre).Replace("_", " ").Replace(" ", string.Empty);
                lineas.Add(String.Format("        protected global::System.Web.UI.WebControls.TextBox txt{0};", strNombre));
                lineas.Add(String.Format("        protected global::System.Web.UI.WebControls.DropDownList ddl{0};", strNombre));
            }

            lineas.Add("        protected global::System.Web.UI.WebControls.HiddenField hdfId;");
            lineas.Add("        protected global::System.Web.UI.WebControls.Button btnGuardar;");
            lineas.Add("        protected global::System.Web.UI.WebControls.Button btnEliminar;");

            lineas.Add("    }");
            lineas.Add("}");
        }

        #endregion

        private void GenerarNamespaces(List<string> lineas)
        {
            lineas.Add("using System;");
            lineas.Add("using System.Text;");
            lineas.Add("using System.Collections.Generic;");
            lineas.Add("using System.Web;");
            lineas.Add("using System.Web.UI;");
            lineas.Add("using System.Web.UI.WebControls;");
        }
    }
}
