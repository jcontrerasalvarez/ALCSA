using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Generador.Negocio.Capas
{
    public class Nomenclatura
    {
        public static string[] TIPOS_DATOS = { "decimal", "int", "float", "string", "string", "string", "DateTime", "DateTime", "float", "bool", "decimal", "byte[]", "byte[]" };
        public static string[] ABR_TIPOS_DATOS = { "dec{0}", "int{0}", "flt{0}", "str{0}", "str{0}", "str{0}", "dat{0}", "dat{0}", "flt{0}", "bln{0}", "dec{0}", "arr{0}", "arr{0}" };

        public static string BuscarTipoDatoNetDesdeBD(ALCSA.Generador.Entidades.BD.Columna columna)
        {
            string strTipoDato = columna.TipoDato.ToUpper();
            for (int intIndice = 0; intIndice < BD.Nomenclatura.TIPOS_DATOS.Length; intIndice++)
                if (strTipoDato.Equals(BD.Nomenclatura.TIPOS_DATOS[intIndice]))
                {
                    strTipoDato = TIPOS_DATOS[intIndice];
                    break;
                }
            return strTipoDato;
        }

        public static string CrearNombreCampo(ALCSA.Generador.Entidades.BD.Columna columna)
        {
            string strNombre = ALCSA.FWK.Texto.ConvertirAMinusculaPrimeraEnMayuscula(columna.Nombre.Replace("_", " ")).Replace(" ", String.Empty);
            string strTipoDato = columna.TipoDato.ToUpper();

            for (int intIndice = 0; intIndice < BD.Nomenclatura.TIPOS_DATOS.Length; intIndice++)
                if (strTipoDato.Equals(BD.Nomenclatura.TIPOS_DATOS[intIndice]))
                {
                    strNombre = string.Format(ABR_TIPOS_DATOS[intIndice], strNombre);
                    break;
                }
            return strNombre;
        }

        public static string CrearNombrePropiedad(ALCSA.Generador.Entidades.BD.Columna columna)
        {
            return columna.Nombre;
            // return ALCSA.FWK.Texto.ConvertirAMinusculaPrimeraEnMayuscula(columna.Nombre.Replace("_", " ")).Replace(" ", String.Empty);
        }

        public static string CrearNombreParametroMetodo(ALCSA.Generador.Entidades.BD.Columna columna)
        {
            string strParametro = ALCSA.FWK.Texto.ConvertirAMinusculaPrimeraEnMayuscula(columna.Nombre.Replace("_", " ")).Replace(" ", string.Empty);
            strParametro = strParametro.Substring(0, 1).ToLower() + strParametro.Substring(1);
            return strParametro;
        }
    }
}
