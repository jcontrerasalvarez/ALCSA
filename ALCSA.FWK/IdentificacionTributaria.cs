using System;
using System.Collections.Generic;
using System.Text;

namespace ALCSA.FWK
{
    /// <summary>
    /// Clase con funciones de validacion de identificaciones tributarias chilenas
    /// </summary>
    /// <creador>Jonathan Contreras</creador>
    /// <fecha_creacion>09-06-2011</fecha_creacion>
    public class IdentificacionTributaria
    {
        /// <summary>
        /// Verifica si un rut es valido
        /// </summary>
        /// <param name="rut">rut con digito verificador</param>
        /// <returns>True cuando el rut es valido y false para caso contrario</returns>
        /// <creador>Jonathan Contreras</creador>
        /// <fecha_creacion>09-06-2011</fecha_creacion>
        public static Boolean RutValido(string rut)
        {
            return ConseguirRutSinDigitoVerificador(rut) > 0 ? true : false;
        }

        /// <summary>
        /// Calcula el digito verificador de un Rut
        /// </summary>
        /// <param name="rut">Rut</param>
        /// <returns>Digito verificador</returns>
        /// <creador>Jonathan Contreras</creador>
        /// <fecha_creacion>09-06-2011</fecha_creacion>
        public static String CalcularDigitoVerificadorRut(int rut)
        {
            int intContador = 2, intDato = 0;
            while (rut != 0)
            {
                intDato += (rut % 10) * intContador;
                rut /= 10;
                intContador++;
                if (intContador == 8) intContador = 2;
            }
            intDato = 11 - (intDato % 11);

            if (intDato == 10) return "K";
            if (intDato == 11) return "0";
            return intDato.ToString();
        }

        /// <summary>
        /// Formatea un RUT. Ejemplo 1.111.111-1
        /// </summary>
        /// <param name="rut">Rut sin formato</param>
        /// <returns>Rut con formato</returns>
        /// <creador>Jonathan Contreras</creador>
        /// <fecha_creacion>09-06-2011</fecha_creacion>
        public static String FormatearRut(string rut)
        {
            String strRut = rut.Replace(".", "").Replace("-", "").ToUpper().Trim();
            if (strRut.Length > 1)
            {
                String strVerificador = strRut.Substring(strRut.Length - 1);
                int intRutSinVerificador;
                if (Int32.TryParse(strRut.Substring(0, strRut.Length - 1), out intRutSinVerificador) && CalcularDigitoVerificadorRut(intRutSinVerificador) == strVerificador)
                    return String.Format("{0}-{1}", intRutSinVerificador.ToString("N0").Replace(",", "."), strVerificador.ToUpper());
            }
            return string.Empty;
        }

        /// <summary>
        /// Formatea un RUT. Ejemplo 1.111.111-1
        /// </summary>
        /// <param name="rut">Rut sin formato</param>
        /// <returns>Rut con formato</returns>
        /// <creador>Jonathan Contreras</creador>
        /// <fecha_creacion>09-06-2011</fecha_creacion>
        public static String QuitarFormatoRut(string rut)
        {
            String strRut = FormatearRut(rut);
            return strRut.Replace(".", "").Replace("-", "").ToUpper().Trim();
        }

        public static int ConseguirRutSinDigitoVerificador(string rut)
        {
            String strRut = rut.Replace(".", "").Replace("-", "").ToUpper().Trim();
            if (strRut.Length > 1)
            {
                String strVerificador = strRut.Substring(strRut.Length - 1);
                int intRutSinVerificador;
                if (Int32.TryParse(strRut.Substring(0, strRut.Length - 1), out intRutSinVerificador) && CalcularDigitoVerificadorRut(intRutSinVerificador) == strVerificador)
                    return intRutSinVerificador;
            }
            return 0;
        }
    }
}
