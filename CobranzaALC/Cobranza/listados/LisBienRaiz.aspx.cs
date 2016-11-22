﻿namespace CobranzaALC.Cobranza.listados
{
    using ALCLOCAL;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public partial class LisBienRaiz : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.Grilla.DataSource = Consulta.BienRaiz();
                this.Grilla.DataBind();
            }
        }
    }
}

