using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace ALCSA.Negocio.Documentos.Demandas
{
    public class ParseadorPagina
    {
        private Page Pagina { get; set; }

        public ParseadorPagina(Page pagina)
        {
            Pagina = pagina;
        }

        public void CargarDatosCobranza(int idCobranza)
        {
            if (idCobranza < 1) return;
            ALCSA.Negocio.Cobranzas.Cobranza objCobranza = new ALCSA.Negocio.Cobranzas.Cobranza(idCobranza);
            if (objCobranza == null) return;
            if (objCobranza.ID < 1) return;

            AsignarValor("lblNombreCliente", objCobranza.NombreCliente);
            AsignarValor("lblNombreDeudor", objCobranza.NombreDeudor);

            AsignarValor("lblProcedimiento", "");
            AsignarValor("lblMateria", "");
            AsignarValor("lblRol", "");

            if (objCobranza.TipoActividad == ALCSA.Negocio.Cobranzas.Cobranza.TIPO_COBRANZA_DOCUMENTO_ESTANDAR_UNO)
                CargarDatosDocumentoEstandarUno(objCobranza.ID);
            else if (objCobranza.TipoActividad == ALCSA.Negocio.Cobranzas.Cobranza.TIPO_COBRANZA_DOCUMENTO_ESTANDAR_DOS)
                CargarDatosDocumentoEstandarDos(objCobranza.ID);
            else if (objCobranza.TipoActividad == ALCSA.Negocio.Cobranzas.Cobranza.TIPO_COBRANZA_DOCUMENTO_ESTANDAR_TRES)
                CargarDatosDocumentoEstandarTres(objCobranza.ID);
            else if (objCobranza.TipoActividad == ALCSA.Negocio.Cobranzas.Cobranza.TIPO_COBRANZA_DOCUMENTO_ESTANDAR_CUATRO)
                CargarDatosDocumentoEstandarCuatro(objCobranza.ID);
            else if (objCobranza.TipoActividad == ALCSA.Negocio.Cobranzas.Cobranza.TIPO_COBRANZA_DOCUMENTO_JUICIO)
                CargarDatosDocumentoJuicio(objCobranza.ID);
            else if (objCobranza.TipoActividad == ALCSA.Negocio.Cobranzas.Cobranza.TIPO_COBRANZA_DOCUMENTO_PAGARE)
                CargarDatosDocumentoPagare(objCobranza.ID);
            else if (objCobranza.TipoActividad == ALCSA.Negocio.Cobranzas.Cobranza.TIPO_COBRANZA_MUTUO)
                CargarDatosMutuo(objCobranza.ID);
            else if (objCobranza.TipoActividad == ALCSA.Negocio.Cobranzas.Cobranza.TIPO_COBRANZA_CUOTA_COLEGIO)
                CargarDatosCuotaColegio(objCobranza.ID);
        }

        #region Asignación Datos Por Tipo

        private void CargarDatosDocumentoEstandarUno(int idCobranza)
        {
            ALCSA.Negocio.Cobranzas.DocumentoEstandard1 objDocumento = new ALCSA.Negocio.Cobranzas.DocumentoEstandard1();
            if (!objDocumento.CargarPorCobranza(idCobranza)) return;

            AsignarValor("lblDomicilio", objDocumento.DireccionDemandado);
            AsignarValor("lblNombreRepresentante", objDocumento.NomRepresLegal);
            AsignarValor("lblMontoTotal", objDocumento.Cuantia);
            AsignarValor("lblMontoTotalPalabras", ALCSA.FWK.Numero.ConvertirNumeroEnPalabras(objDocumento.Cuantia, 2));
        }

        private void CargarDatosDocumentoEstandarDos(int idCobranza)
        {
            ALCSA.Negocio.Cobranzas.DocumentoEstandard2 objDocumento = new ALCSA.Negocio.Cobranzas.DocumentoEstandard2();
            if (!objDocumento.CargarPorCobranza(idCobranza)) return;

            AsignarValor("lblDomicilio", objDocumento.Txtdomicilio);
            AsignarValor("lblNombreRepresentante", objDocumento.Txtdemandado);
            AsignarValor("lblMontoTotal", objDocumento.Txtmontodemandado);
            AsignarValor("lblMontoTotalPalabras", ALCSA.FWK.Numero.ConvertirNumeroEnPalabras(objDocumento.Txtmontodemandado, 2));
        }

        private void CargarDatosDocumentoEstandarTres(int idCobranza)
        {
            ALCSA.Negocio.Cobranzas.DocumentoEstandard3 objDocumento = new ALCSA.Negocio.Cobranzas.DocumentoEstandard3();
            if (!objDocumento.CargarPorCobranza(idCobranza)) return;

            AsignarValor("lblDomicilio", objDocumento.DireccionDemandado);
            AsignarValor("lblNombreRepresentante", objDocumento.NomRepresLegal);
            AsignarValor("lblMontoTotal", objDocumento.Cuantia);
            AsignarValor("lblMontoTotalPalabras", ALCSA.FWK.Numero.ConvertirNumeroEnPalabras(objDocumento.Cuantia, 2));
        }

        private void CargarDatosDocumentoEstandarCuatro(int idCobranza)
        {
            ALCSA.Negocio.Cobranzas.DocumentoEstandard4 objDocumento = new ALCSA.Negocio.Cobranzas.DocumentoEstandard4();
            if (!objDocumento.CargarPorCobranza(idCobranza)) return;

            AsignarValor("lblDomicilio", objDocumento.DireccionDemandado);
            AsignarValor("lblNombreRepresentante", objDocumento.NomRepresLegal);
            AsignarValor("lblMontoTotal", objDocumento.Cuantia);
            AsignarValor("lblMontoTotalPalabras", ALCSA.FWK.Numero.ConvertirNumeroEnPalabras(objDocumento.Cuantia, 2));
        }

        private void CargarDatosDocumentoPagare(int idCobranza)
        {
            ALCSA.Negocio.Cobranzas.DocumentoPagare objDocumento = new ALCSA.Negocio.Cobranzas.DocumentoPagare();
            if (!objDocumento.CargarPorCobranza(idCobranza)) return;

            AsignarValor("lblDomicilio", objDocumento.DireccionPagare);
            AsignarValor("lblNombreRepresentante", objDocumento.NombreRepresentanteUno);
            AsignarValor("lblMontoTotal", objDocumento.Sumainisuscripcion);
            AsignarValor("lblMontoTotalPalabras", ALCSA.FWK.Numero.ConvertirNumeroEnPalabras(objDocumento.Sumainisuscripcion, 2));
        }

        private void CargarDatosDocumentoJuicio(int idCobranza)
        {
            ALCSA.Negocio.Cobranzas.DocumentoJuicio objDocumento = new ALCSA.Negocio.Cobranzas.DocumentoJuicio();
            if (!objDocumento.CargarPorCobranza(idCobranza)) return;

            AsignarValor("lblDomicilio", objDocumento.DireccionDeudor);
            AsignarValor("lblNombreRepresentante", objDocumento.NombreRepresentanteUno);
            AsignarValor("lblMontoTotal", objDocumento.Monto);
            AsignarValor("lblMontoTotalPalabras", ALCSA.FWK.Numero.ConvertirNumeroEnPalabras(objDocumento.Monto, 2));
        }

        private void CargarDatosMutuo(int idCobranza)
        {
            ALCSA.Negocio.Cobranzas.Mutuo objDocumento = new ALCSA.Negocio.Cobranzas.Mutuo();
            if (!objDocumento.CargarPorCobranza(idCobranza)) return;

            // AsignarValor("lblDomicilio", objDocumento.Dire);
            // AsignarValor("lblNombreRepresentante", objDocumento.n);
            AsignarValor("lblMontoTotal", objDocumento.SaldoTotalDeudaUf, 2);
            AsignarValor("lblMontoTotalPalabras", ALCSA.FWK.Numero.ConvertirNumeroEnPalabras(objDocumento.SaldoTotalDeudaUf, 2));
        }

        private void CargarDatosCuotaColegio(int idCobranza)
        {
            ALCSA.Negocio.Cobranzas.CuotaColegio objDocumento = new ALCSA.Negocio.Cobranzas.CuotaColegio();
            if (!objDocumento.CargarPorCobranza(idCobranza)) return;

            // AsignarValor("lblDomicilio", objDocumento.Dir);
            AsignarValor("lblNombreRepresentante", objDocumento.NombreRepresentanteUno);
            AsignarValor("lblMontoTotal", objDocumento.Saldodeuda);
            AsignarValor("lblMontoTotalPalabras", ALCSA.FWK.Numero.ConvertirNumeroEnPalabras(objDocumento.Saldodeuda, 2));
        }

        #endregion

        #region Asignacion Datos

        private void AsignarValor(string nombreEtiqueta, decimal valor)
        {
            AsignarValor(nombreEtiqueta, valor, 0);
        }

        private void AsignarValor(string nombreEtiqueta, decimal valor, int numeroDecimales)
        {
            AsignarValor(nombreEtiqueta, valor.ToString(string.Format("N{0}", numeroDecimales)));
        }

        private void AsignarValor(string nombreEtiqueta, float valor)
        {
            AsignarValor(nombreEtiqueta, valor, 0);
        }

        private void AsignarValor(string nombreEtiqueta, float valor, int numeroDecimales)
        {
            AsignarValor(nombreEtiqueta, valor.ToString(string.Format("N{0}", numeroDecimales)));
        }

        private void AsignarValor(string nombreEtiqueta, DateTime valor)
        {
            AsignarValor(nombreEtiqueta, valor.Year < 1900 ? string.Empty : string.Format("{0:dd} de {1} de {0:yyyy}", valor, ALCSA.FWK.Tiempo.MESES[valor.Month - 1]));
        }

        private void AsignarValor(string nombreEtiqueta, string valor)
        {
            if (string.IsNullOrEmpty(valor)) valor = new string(' ', 15);
            else valor = valor.Trim();
            List<Label> arrEtiquetas = BuscarControles(nombreEtiqueta, Pagina.Controls);
            foreach (Label lblEtiqueta in arrEtiquetas)
                lblEtiqueta.Text = valor;
        }

        private List<Label> BuscarControles(string nombreEtiqueta, ControlCollection controles)
        {
            List<Label> arrLista = new List<Label>();
            BuscarControles<Label>(controles, arrLista);
            int intIndice = 0;
            while (intIndice < arrLista.Count)
                if (TieneEtiquetaNombreIndicado(arrLista[intIndice], nombreEtiqueta))
                    intIndice++;
                else arrLista.RemoveAt(intIndice);
            return arrLista;
        }

        private void BuscarControles<T>(ControlCollection controles, List<T> listadoFinal) where T : Control
        {
            foreach (Control objControl in controles)
            {
                if (objControl is T)
                    listadoFinal.Add(objControl as T);
                if (objControl.HasControls())
                    BuscarControles<T>(objControl.Controls, listadoFinal);
            }
        }

        private bool TieneEtiquetaNombreIndicado(Label etiqueta, string nombre)
        {
            if (!etiqueta.ID.StartsWith(nombre)) return false;
            if (etiqueta.ID == nombre) return true;
            for (int intIndice = 0; intIndice < 25; intIndice++)
                if (string.Format("{0}{1}", etiqueta.ID, intIndice) == nombre)
                    return true;
            return false;
        }

        #endregion
    }
}
