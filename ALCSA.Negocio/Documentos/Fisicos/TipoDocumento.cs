using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Documentos.Fisicos
{
    public class TipoDocumento : Entidades.Documentos.Fisicos.TipoDocumento
    {
        public static string INICIAL_TIPO_DOCUMENTO = "TD";

        public static string TIPO_DOCUMENTO_PAGARE = "TDDPA";
        public static string TIPO_DOCUMENTO_MUTUO = "TDMUT";
        public static string TIPO_DOCUMENTO_JUICIO = "TPDJU";
        public static string TIPO_DOCUMENTO_CUOTA_COLEGIO = "TPCUO";

        public static string TIPO_DOCUMENTO_ESTANDAR_1 = "TDDE1";
        public static string TIPO_DOCUMENTO_ESTANDAR_2 = "TDDE2";
        public static string TIPO_DOCUMENTO_ESTANDAR_3 = "TDDE3";
        public static string TIPO_DOCUMENTO_ESTANDAR_4 = "TDDE4";

        public static string TIPO_DOCUMENTO_EXHORTO = "TDEXH";

        public TipoDocumento() { }

        public TipoDocumento(int id) 
        {
             if(id < 1) return;
             ALCSA.Entidades.Documentos.Fisicos.TipoDocumento objTemporal = new ALCSA.Datos.Documentos.Fisicos.TipoDocumento().Buscar(id, string.Empty);
             ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Documentos.Fisicos.TipoDocumento, TipoDocumento>(objTemporal, this);
        }

        public TipoDocumento(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo)) return;
            ALCSA.Entidades.Documentos.Fisicos.TipoDocumento objTemporal = new ALCSA.Datos.Documentos.Fisicos.TipoDocumento().Buscar(0, codigo);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Documentos.Fisicos.TipoDocumento, TipoDocumento>(objTemporal, this);
        }

        public void Guardar()
        {
             if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
             new ALCSA.Datos.Documentos.Fisicos.TipoDocumento().Insertar(this);
        }

        public void Actualizar()
        {
             new ALCSA.Datos.Documentos.Fisicos.TipoDocumento().Actualizar(this);
        }

        public void Eliminar()
        {
             new ALCSA.Datos.Documentos.Fisicos.TipoDocumento().Eliminar(this.ID);
        }

        public IList<ALCSA.Entidades.Documentos.Fisicos.TipoDocumento> Listar()
        {
             return new ALCSA.Datos.Documentos.Fisicos.TipoDocumento().Listar();
        }

        public string BuscarRutaMantenedorObjeto(int idDocumento)
        {
            if (string.IsNullOrWhiteSpace(RutaMantenedorObjeto)) return string.Empty;

            string strRuta = RutaMantenedorObjeto, strFormato = string.Empty;
            int intIndiceInicial = 0, intIndiceFinal = 0;
            IList<Entidades.Documentos.Fisicos.Identificador> arrIdentificadores = new Identificador().Listar(idDocumento);

            foreach (Entidades.Documentos.Fisicos.Identificador objIdentificador in arrIdentificadores)
                strRuta = ReemplazarValorParametro(strRuta, objIdentificador.Valor, objIdentificador.CodigoTipoIdentificador);

            while ((intIndiceInicial = strRuta.IndexOf("{")) > 0 && (intIndiceFinal = strRuta.IndexOf("}", intIndiceInicial)) > 0)
                strRuta = strRuta.Remove(intIndiceInicial, intIndiceFinal - intIndiceInicial);

            return strRuta.Replace("{", string.Empty).Replace("}", string.Empty);
        }

        public string BuscarRutaMantenedorObjeto(int valorIdentificador, string codigoTipo)
        {
            return BuscarRutaMantenedorObjeto(valorIdentificador.ToString(), codigoTipo);
        }

        public string BuscarRutaMantenedorObjeto(string valorIdentificador, string codigoTipo)
        {
            if (string.IsNullOrWhiteSpace(RutaMantenedorObjeto)) return string.Empty;

            string strRuta = ReemplazarValorParametro(RutaMantenedorObjeto, valorIdentificador, codigoTipo);
            int intIndiceInicial = 0, intIndiceFinal = 0;

            while ((intIndiceInicial = strRuta.IndexOf("{")) > 0 && (intIndiceFinal = strRuta.IndexOf("}", intIndiceInicial)) > 0)
                strRuta = strRuta.Remove(intIndiceInicial, intIndiceFinal - intIndiceInicial);

            return strRuta.Replace("{", string.Empty).Replace("}", string.Empty);
        }

        private string ReemplazarValorParametro(string ruta, string valorIdentificador, string codigoTipo)
        {
            string strFormato = new StringBuilder().Append("{").Append(codigoTipo).Append("}").ToString();
            return ruta.Replace(strFormato, valorIdentificador);
        }
    }
}
