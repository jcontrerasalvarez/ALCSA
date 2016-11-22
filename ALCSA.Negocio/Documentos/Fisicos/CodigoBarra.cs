using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Documentos.Fisicos
{
    public class CodigoBarra : Entidades.Documentos.Fisicos.CodigoBarra
    {
        public static string INICIAL_CODIGO_DOCUMENTO_FISICO = "DCFIS";

        public static string FORMATO_CODIGO_DOCUMENTO = "{0}{1:0000000}";

        public static string FORMATO_RUTA_DESCARGA_CODIGO_EN_DOCUMENTO = "~/Cobranza/Documentos/Descargar.aspx?id={0}&tipo={1}&ruta=General/GeneradorCodigoBarra.aspx";

        public CodigoBarra(int id, string tipo)
        {
            CargarDatos(id, tipo);
        }

        public CodigoBarra(string codigo)
        {
            if (codigo == null) return;
            if (codigo.Length <= INICIAL_CODIGO_DOCUMENTO_FISICO.Length) return;

            int intId = ALCSA.FWK.Texto.ConvertirTextoEnEntero(codigo.Remove(0, INICIAL_CODIGO_DOCUMENTO_FISICO.Length));
            string strTipo = codigo.Substring(0, INICIAL_CODIGO_DOCUMENTO_FISICO.Length);

            CargarDatos(intId, strTipo);
        }

        private void CargarDatos(int id, string tipo)
        {
            if (tipo == INICIAL_CODIGO_DOCUMENTO_FISICO)
                CargarDatosDocumentoFisico(id);
            else if (tipo.StartsWith(TipoIdentificador.INICIAL_TIPO_IDENTIFICADOR))
                CargarDatosPorTipoIdentificador(id, tipo);
        }

        private void CargarDatosDocumentoFisico(int id)
        {
            Codigo = string.Format(FORMATO_CODIGO_DOCUMENTO, INICIAL_CODIGO_DOCUMENTO_FISICO, id);

            Documento objDocumento = new Documento(id);
            ID = objDocumento.ID;
            Nombre = objDocumento.Nombre;
            RutaMantenedor = new TipoDocumento(objDocumento.IdTipoDocumento).BuscarRutaMantenedorObjeto(id);
        }

        private void CargarDatosPorTipoIdentificador(int id, string tipo)
        {
            IList<Entidades.Documentos.Fisicos.Documento> arrDocumentos = new Documento().Listar(id.ToString(), tipo);
            if (!arrDocumentos.Count.Equals(0))
            {
                CargarDatosDocumentoFisico(arrDocumentos[0].ID);
                return;
            }

            Codigo = string.Format(FORMATO_CODIGO_DOCUMENTO, tipo, id);
            ID = id;
            Nombre = tipo;

            TipoDocumento objTipo = new TipoDocumento(tipo);
            if (objTipo.ID < 1)
            {
                TipoIdentificador objTipoIdentificador = new TipoIdentificador(tipo);
                if (objTipoIdentificador.ID > 0) objTipo = new TipoDocumento(objTipoIdentificador.CodigoTipoDocumento);
            }

            RutaMantenedor = objTipo.BuscarRutaMantenedorObjeto(id, tipo);
        }
    }
}
