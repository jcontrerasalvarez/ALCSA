﻿using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace CobranzaALC.Cobranza.mantenedores.RelacionBienes
{
    public partial class ReporteBienesRaicesDelCliente : System.Web.UI.Page
    {
        private void Excel()
        {
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            HtmlTextWriter writer2 = new HtmlTextWriter(writer);
            Page page = new Page();
            HtmlForm child = new HtmlForm();
            this.gvBienes.EnableViewState = false;
            page.EnableEventValidation = false;
            page.DesignerInitialize();
            page.Controls.Add(child);
            child.Controls.Add(this.gvBienes);
            page.RenderControl(writer2);
            base.Response.Clear();
            base.Response.Buffer = true;
            base.Response.ContentType = "application/vnd.ms-excel";
            base.Response.AddHeader("Content-Disposition", "attachment;filename=ReporteBienesRaicesDeudor_" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".xls");
            base.Response.Charset = "UTF-8";
            base.Response.ContentEncoding = Encoding.Default;
            base.Response.Write(sb.ToString());
        }

        public void ExportarPdf()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.Page.IsPostBack)
                {
                    DataTable table = null;
                    table = (DataTable)this.Session["ReporteExcelBienesRaices"];
                    int count = table.Rows.Count;
                    if ((table != null) && (table.Rows.Count >= 1))
                    {
                        this.gvBienes.DataSource = table;
                        this.gvBienes.DataBind();
                        this.Excel();
                        base.Response.End();
                    }
                }
            }
            catch {
                Response.Write("<script language=javascript>alert('Vuelva a Realiza la Busqueda');</script>");
            
            }       

        }
    }
}