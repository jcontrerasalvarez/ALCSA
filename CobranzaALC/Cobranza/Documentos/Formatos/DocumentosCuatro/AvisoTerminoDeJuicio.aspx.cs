﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CobranzaALC.Cobranza.Documentos.Formatos.DocumentosCuatro
{
    public partial class AvisoTerminoDeJuicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.EnableViewState = false;
            int intIdJuicio = 0, intIdExhorto = 0;
            int.TryParse(Request.QueryString["id_jui"], out intIdJuicio);
            int.TryParse(Request.QueryString["id_exh"], out intIdExhorto);

            lblFecha.Text = string.Format("{0:dd} de {1} de {0:yyyy}", DateTime.Now, ALCSA.FWK.Tiempo.MESES[DateTime.Now.Month - 1]);

            ALCSA.Negocio.Documentos.DatosFormatos.Juicio objJuicio = new ALCSA.Negocio.Documentos.DatosFormatos.Juicio(intIdJuicio, intIdExhorto);
            lblTribunal.Text = objJuicio.Tribunal;
            lblCliente.Text = objJuicio.Cliente;
            lblDeudor.Text = objJuicio.Deudor;
            lblDeudorUno.Text = objJuicio.Deudor;
            lblRol.Text = objJuicio.Rol;
        }
    }
}