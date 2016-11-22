using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CobranzaALC.Cobranza.Alzamientos
{
    public partial class MantenedorAlzamiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;

            // CARGAR LISTADOS

            // CARGAR ALZAMIENTO
            int intIdAlzamiento = ALCSA.FWK.Web.Sitio.ExtraerValorQueryStringComoEntero(Request, "id_alz");
            ALCSA.Negocio.Alzamientos.Alzamiento objEntidad = new ALCSA.Negocio.Alzamientos.Alzamiento(intIdAlzamiento);

            ALCSA.FWK.Web.Control.AsignarValor(lblIdRemesa, objEntidad.ID);

            ALCSA.FWK.Web.Control.AsignarValor(lblEstado, objEntidad.IdEstado);
            ALCSA.FWK.Web.Control.AsignarValor(txtRutDeudor, objEntidad.RutDeudor);
            ALCSA.FWK.Web.Control.AsignarValor(txtNombreDeudor, objEntidad.Nombre);

            ALCSA.FWK.Web.Control.AsignarValor(txtDireccion, objEntidad.Direccion);
            ALCSA.FWK.Web.Control.SeleccionarValor(ddlComuna, objEntidad.IdComuna);

            ALCSA.FWK.Web.Control.SeleccionarValor(ddlNotario, objEntidad.IdNotaria);
            ALCSA.FWK.Web.Control.AsignarValor(txtNumeroOperacion, objEntidad.NumeroOperacion);
            ALCSA.FWK.Web.Control.AsignarValor(txtConservador, objEntidad.Conservador);

            ALCSA.FWK.Web.Control.AsignarValor(txtFojasDominio, objEntidad.FojasDominio);
            ALCSA.FWK.Web.Control.AsignarValor(txtNumeroDominio, objEntidad.NumeroDominio);
            ALCSA.FWK.Web.Control.AsignarValor(txtAnoDominio, objEntidad.AnoDominio);

            ALCSA.FWK.Web.Control.AsignarValor(txtFojasHipoteca, objEntidad.FojasHipoteca);
            ALCSA.FWK.Web.Control.AsignarValor(txtNumeroHipoteca, objEntidad.NumeroHipoteca);
            ALCSA.FWK.Web.Control.AsignarValor(txtAnoHipoteca, objEntidad.AnoHipoteca);

            ALCSA.FWK.Web.Control.AsignarValor(txtFojasProhibicion, objEntidad.FojasProhibicion);
            ALCSA.FWK.Web.Control.AsignarValor(txtNumeroProhibicion, objEntidad.NumeroProhibicion);
            ALCSA.FWK.Web.Control.AsignarValor(txtAnoProhibicion, objEntidad.AnoProhibicion);

            ALCSA.FWK.Web.Control.AsignarValor(txtFechaContabilizacion, objEntidad.FechaContabilizacion);
            ALCSA.FWK.Web.Control.AsignarValor(txtFechaEntrega, objEntidad.FechaEntrega);
            ALCSA.FWK.Web.Control.AsignarValor(txtFechaEscritura, objEntidad.FechaEscritura);

            ALCSA.FWK.Web.Control.AsignarValor(txtRepertorio, objEntidad.Reportorio);
            ALCSA.FWK.Web.Control.AsignarValor(txtProtocolo, objEntidad.Protocolo);
            ALCSA.FWK.Web.Control.AsignarValor(txtNumeroCarillas, objEntidad.NumeroCarillas);

            ALCSA.FWK.Web.Control.AsignarValor(txtFactura, objEntidad.Fectura);
            ALCSA.FWK.Web.Control.AsignarValor(txtFechaFactura, objEntidad.FechaFactura);
            ALCSA.FWK.Web.Control.AsignarValor(txtCentroCostos, objEntidad.CentroCostos);

            ALCSA.FWK.Web.Control.AsignarValor(txtObservacion, objEntidad.Observacion);
            ALCSA.FWK.Web.Control.AsignarValor(hdfIdRemesa, objEntidad.IdRemesa);
            ALCSA.FWK.Web.Control.AsignarValor(hdfIdAlzamiento, objEntidad.ID);
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            int intIdRemesa = ALCSA.FWK.Web.Control.ExtraerValorComoEntero(hdfIdRemesa);
            Response.Redirect(string.Format("ListadoAlzamientos.aspx?id_rem={0}", intIdRemesa), true);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ALCSA.Negocio.Alzamientos.Alzamiento objEntidad = new ALCSA.Negocio.Alzamientos.Alzamiento(ALCSA.FWK.Web.Control.ExtraerValorComoEntero(hdfIdAlzamiento));


            objEntidad.IdEstado = ALCSA.FWK.Web.Control.ExtraerValorComoEntero(lblEstado);
            objEntidad.RutDeudor = ALCSA.FWK.Web.Control.ExtraerValor(txtRutDeudor);
            objEntidad.Nombre = ALCSA.FWK.Web.Control.ExtraerValor(txtNombreDeudor);

            objEntidad.Direccion = ALCSA.FWK.Web.Control.ExtraerValor(txtDireccion);
            objEntidad.IdComuna = ALCSA.FWK.Web.Control.ExtraerValorComoEntero(ddlComuna);

            objEntidad.IdNotaria = ALCSA.FWK.Web.Control.ExtraerValorComoEntero(ddlNotario);
            objEntidad.NumeroOperacion = ALCSA.FWK.Web.Control.ExtraerValor(txtNumeroOperacion);
            objEntidad.Conservador = ALCSA.FWK.Web.Control.ExtraerValor(txtConservador);

            objEntidad.FojasDominio = ALCSA.FWK.Web.Control.ExtraerValor(txtFojasDominio);
            objEntidad.NumeroDominio = ALCSA.FWK.Web.Control.ExtraerValor(txtNumeroDominio, );
            objEntidad.AnoDominio = ALCSA.FWK.Web.Control.ExtraerValorComoEntero(txtAnoDominio);

            objEntidad.FojasHipoteca = ALCSA.FWK.Web.Control.ExtraerValor(txtFojasHipoteca);
            objEntidad.NumeroHipoteca = ALCSA.FWK.Web.Control.ExtraerValor(txtNumeroHipoteca);
            objEntidad.AnoHipoteca = ALCSA.FWK.Web.Control.ExtraerValorComoEntero(txtAnoHipoteca);

            objEntidad.FojasProhibicion = ALCSA.FWK.Web.Control.ExtraerValor(txtFojasProhibicion);
            objEntidad.NumeroProhibicion = ALCSA.FWK.Web.Control.ExtraerValor(txtNumeroProhibicion);
            objEntidad.AnoProhibicion = ALCSA.FWK.Web.Control.ExtraerValorComoEntero(txtAnoProhibicion);

            objEntidad.FechaContabilizacion = ALCSA.FWK.Web.Control.ExtraerValorComoDateTime(txtFechaContabilizacion);
            objEntidad.FechaEntrega = ALCSA.FWK.Web.Control.ExtraerValorComoDateTime(txtFechaEntrega);
            objEntidad.FechaEscritura = ALCSA.FWK.Web.Control.ExtraerValorComoDateTime(txtFechaEscritura);

            objEntidad.Reportorio = ALCSA.FWK.Web.Control.ExtraerValor(txtRepertorio);
            objEntidad.Protocolo = ALCSA.FWK.Web.Control.ExtraerValor(txtProtocolo);
            objEntidad.NumeroCarillas = ALCSA.FWK.Web.Control.ExtraerValorComoEntero(txtNumeroCarillas);

            objEntidad.Fectura = ALCSA.FWK.Web.Control.ExtraerValor(txtFactura);
            objEntidad.FechaFactura = ALCSA.FWK.Web.Control.ExtraerValorComoDateTime(txtFechaFactura);
            objEntidad.CentroCostos = ALCSA.FWK.Web.Control.ExtraerValor(txtCentroCostos);

            objEntidad.Observacion = ALCSA.FWK.Web.Control.ExtraerValor(txtObservacion);
            objEntidad.IdRemesa = ALCSA.FWK.Web.Control.ExtraerValorComoEntero(hdfIdRemesa);

            objEntidad.Guardar();

            // MENSAJE

            // REDIRECCIONAR

        }
    }
}