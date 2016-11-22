using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CobranzaALC.Cobranza.Alzamientos
{
    public partial class ListadoAlzamientos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int intIdRemesa = ALCSA.FWK.Web.Sitio.ExtraerValorQueryStringComoEntero(Request, "id_rem");
            if (intIdRemesa < 1) Response.Redirect("ListadoRemesas.aspx", true); ;

            ALCSA.FWK.Web.Control.AsignarValor(hdfIdRemesa, intIdRemesa);

            CargarGrilla(0);
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoRemesas.aspx", true);
        }

        protected void btnNuevoAlzamiento_Click(object sender, EventArgs e)
        {
            int intIdRemesa = ALCSA.FWK.Web.Control.ExtraerValorComoEntero(hdfIdRemesa);
            Response.Redirect(string.Format("MantenedorAlzamiento.aspx?id_rem", intIdRemesa), true);
        }

        protected void gvAlzamientos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CargarGrilla(e.NewPageIndex);
        }

        private void CargarGrilla(int indice)
        {
            int intIdRemesa = ALCSA.FWK.Web.Control.ExtraerValorComoEntero(hdfIdRemesa);

            gvAlzamientos.PageIndex = indice;
            gvAlzamientos.DataSource = new ALCSA.Negocio.Alzamientos.Alzamiento().Listar(intIdRemesa);
            gvAlzamientos.DataBind();
        }
    }
}