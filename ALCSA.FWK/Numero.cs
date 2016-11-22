using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.FWK
{
    public class Numero
    {
        public static string ConvertirNumeroEnPalabras(int valor)
        {
            return ConvertirValorEnPalabra(Convert.ToDecimal(valor), 0);
        }

        public static string ConvertirNumeroEnPalabras(float valor)
        {
            return ConvertirValorEnPalabra(Convert.ToDecimal(valor), 0);
        }

        public static string ConvertirNumeroEnPalabras(float valor, int numeroDecimales)
        {
            return ConvertirValorEnPalabra(Convert.ToDecimal(valor), numeroDecimales);
        }

        public static string ConvertirNumeroEnPalabras(decimal valor)
        {
            return ConvertirValorEnPalabra(valor, 0);
        }

        public static string ConvertirNumeroEnPalabras(decimal valor, int numeroDecimales)
        {
            return ConvertirValorEnPalabra(valor, numeroDecimales);
        }

        private static string ConvertirValorEnPalabra(decimal valor, int numeroDecimales)
        {
            return string.Empty;
        }
    }
}
