using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CobranzaALC.Cobranza.Alzamientos
{
    public partial class ListadoRemesas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;

            gvRemesas.DataSource = new ALCSA.Negocio.Alzamientos.Remesa().Listar();
            gvRemesas.DataBind();
        }
    }
}