using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace ALCSA.FWK
{
    /// <summary>
    /// 
    /// </summary>
    /// <creador>Jonathan Contreras</creador>
    /// <fecha_creacion>11-05-2010</fecha_creacion>
    public class Texto
    {
        /// <summary>
        /// Voltea un texto
        /// </summary>
        /// <param name="texto">Texto a voltear</param>
        /// <returns>Texto volteado</returns>
        /// <creador>Jonathan Contreras</creador>
        /// <fecha_creacion>11-05-2010</fecha_creacion>
        public static String Voltear(String texto)
        {
            Char[] arrCaracteres = texto.ToCharArray();
            int intIndiceFinal = arrCaracteres.Length - 1;

            for (int intIndice = 0; intIndice < intIndiceFinal; intIndice++, intIndiceFinal--)
            {
                arrCaracteres[intIndice] ^= arrCaracteres[intIndiceFinal];
                arrCaracteres[intIndiceFinal] ^= arrCaracteres[intIndice];
                arrCaracteres[intIndice] ^= arrCaracteres[intIndiceFinal];
            }
            return new String(arrCaracteres);
        }

        public static String SepararTextoPorMayusculas(String texto)
        {
            StringBuilder strbTextoFinal = new StringBuilder();
            Char[] arrCaracteres = texto.ToCharArray();
            for (int intIndice = 0; intIndice < arrCaracteres.Length; intIndice++)
            {
                if (intIndice == 0) strbTextoFinal.Append(Char.ToUpper(arrCaracteres[intIndice]));
                else if (arrCaracteres[intIndice] == Char.ToLower(arrCaracteres[intIndice]))
                    strbTextoFinal.Append(arrCaracteres[intIndice]);
                else strbTextoFinal.Append(" " + arrCaracteres[intIndice]);
            }
            return strbTextoFinal.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        /// <creador>Jonathan Contreras</creador>
        /// <fecha_creacion>27-09-2010</fecha_creacion>
        public static String ConvertirAMinusculaPrimeraEnMayuscula(String texto)
        {
            if (String.IsNullOrEmpty(texto)) return String.Empty;
            Char[] arrCaracteres = texto.Trim().ToLower().ToCharArray();
            if (arrCaracteres.Length < 1) return String.Empty;
            StringBuilder strbTextoFinal = new StringBuilder();
            Boolean blnMayuscula = false;

            strbTextoFinal.Append(Char.ToUpper(arrCaracteres[0]));
            for (int intIndice = 1; intIndice < arrCaracteres.Length; intIndice++)
            {
                if (Char.IsWhiteSpace(arrCaracteres[intIndice]) || arrCaracteres[intIndice] == '.')
                {
                    if (!blnMayuscula) strbTextoFinal.Append(arrCaracteres[intIndice]);
                    blnMayuscula = true;
                }
                else if (blnMayuscula)
                {
                    strbTextoFinal.Append(Char.ToUpper(arrCaracteres[intIndice]));
                    blnMayuscula = false;
                }
                else strbTextoFinal.Append(arrCaracteres[intIndice]);
            }
            return strbTextoFinal.ToString();
        }

        public static int ConvertirTextoEnEntero(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return 0;
            int intValor = 0;
            int.TryParse(texto, out intValor);
            return intValor;
        }

        public static decimal ConvertirTextoEnDecimal(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return 0;
            decimal decValor = 0;
            decimal.TryParse(texto, out decValor);
            return decValor;
        }

        public static double ConvertirTextoEnDouble(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return 0;
            double decValor = 0;
            double.TryParse(texto, out decValor);
            return decValor;
        }

        public static float ConvertirTextoEnFloat(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return 0;
            float fltValor = 0;
            CultureInfo objCultura = new CultureInfo("es-CL");
            float.TryParse(texto, NumberStyles.Number, objCultura, out fltValor);
            return fltValor;
        }

        public static DateTime ConvertirTextoEnDateTime(string texto, string formato)
        {
            DateTime datValor = new DateTime(1900, 1, 1);
            if (string.IsNullOrEmpty(texto)) return datValor;
            DateTime.TryParseExact(texto, formato, CultureInfo.InvariantCulture, DateTimeStyles.None, out datValor);
            return datValor;
        }
    }
}
