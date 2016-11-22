using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Generador.Negocio.BD
{
    public class Nomenclatura
    {
        private static string[] COLUMNAS_COMUNES = { "ES_VIGENTE", "FECHA_INGRESO", "FECHA_ELIMINACION", "ID", "NOMBRE", "CODIGO", "DESCRIPCION" };
        private static string[] COLUMNAS_DESCARTABLES_COMO_PARAMETROS = { "ES_VIGENTE", "FECHA_INGRESO", "FECHA_ELIMINACION" };

        public static string SP = "SPALC_";

        public static string[] TIPOS_DATOS = { "NUMERIC", "INT", "FLOAT", "CHAR", "VARCHAR", "NVARCHAR", "DATETIME", "SMALLDATETIME", "BIGINT", "BIT", "DECIMAL", "IMAGE", "VARBINARY" };

        public static string[] FORMATOS_TIPOS_DATOS = { "NUMERIC({1}, {0})", "VARCHAR({0})", "NVARCHAR({0})", "DECIMAL({0}, {1})" };

        public static string[] ABR_TIPOS_DATOS_PARAMETROS = { "@NUM_{0}", "@INT_{0}", "@FLT_{0}", "@CHR_{0}", "@VC_{0}", "@NVC_{0}", "@DAT_{0}", "@DAT_{0}", "@INT_{0}", "@BIT_{0}", "@DEC_{0}", "@BIN_{0}", "@BIN_{0}" };

        public static string ConcatenarParametroSP(ALCSA.Generador.Entidades.BD.Columna columna)
        {
            string strTipoDato = columna.TipoDato.ToUpper();
            string strNombre = columna.Nombre.Replace("_", " ").Replace(" ", String.Empty);    
            // ALCSA.FWK.Texto.ConvertirAMinusculaPrimeraEnMayuscula(columna.Nombre.Replace("_", " ")).Replace(" ", String.Empty);

            for(int intIndice = 0; intIndice < TIPOS_DATOS.Length; intIndice++)
                if(TIPOS_DATOS[intIndice].Equals(strTipoDato))
                {
                    strNombre = String.Format(ABR_TIPOS_DATOS_PARAMETROS[intIndice], strNombre);
                    break;
                }

            return strNombre;
        }

        public static string ConcatenarTipoDato(ALCSA.Generador.Entidades.BD.Columna columna)
        {
            string strTipoDato = columna.TipoDato.ToUpper();
            for(int intIndice = 0; intIndice < FORMATOS_TIPOS_DATOS.Length; intIndice++)
                if(strTipoDato.Equals(FORMATOS_TIPOS_DATOS[intIndice].Substring(0, FORMATOS_TIPOS_DATOS[intIndice].IndexOf("("))))
                {
                    strTipoDato = string.Format(FORMATOS_TIPOS_DATOS[intIndice], columna.Largo, columna.Presicion);
                    break;
                }
            return strTipoDato;
        }

        public static bool DescartarColumna(string nombre)
        {
            for (int intIndice = 0; intIndice < BD.Nomenclatura.COLUMNAS_COMUNES.Length; intIndice++)
                if (BD.Nomenclatura.COLUMNAS_COMUNES[intIndice].Equals(nombre)) return true;
            return false;
        }

        public static bool DescartarColumnaComoParametro(string nombre)
        {
            for (int intIndice = 0; intIndice < BD.Nomenclatura.COLUMNAS_DESCARTABLES_COMO_PARAMETROS.Length; intIndice++)
                if (BD.Nomenclatura.COLUMNAS_COMUNES[intIndice].Equals(nombre)) return true;
            return false;
        }
    }
}
