using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.FWK
{
    public class NumeroRomano
    {
        private string[] arrRomanos = new string[50];

        public NumeroRomano()
        {
            InicializarMatriz();
        }

        public string Convertir(int numero)
        {
            string strLetra = String.Empty;

            switch (numero.ToString().Length)
            {
                case 1:
                    strLetra += ConvierteUno(numero.ToString());
                    break;
                case 2:
                    strLetra += ConvierteDos(numero.ToString());
                    break;
                case 3:
                    strLetra += ConvierteTres(numero.ToString());
                    break;
                case 4:
                    strLetra += ConvierteCuatro(numero.ToString());
                    break;
                case 5:
                    strLetra += ConvierteCinco(numero.ToString());
                    break;
            }

            return strLetra;
        }

        private string ConvierteUno(string numero)
        {
            return arrRomanos[int.Parse(numero)];
        }

        private string ConvierteDos(string numero)
        {
            //Obtiene el primer número
            string strLetra = String.Empty;
            string strNumero = numero.ToString().Substring(0, 1);
            string strTemporal = String.Empty;

            if (int.Parse(strNumero) > 0)
                strLetra = arrRomanos[int.Parse(strNumero) + 9];
            strTemporal = ConvierteUno(numero.ToString().Substring(1, 1));

            return strLetra + strTemporal;
        }

        private string ConvierteTres(string numero)
        {
            string strLetra = String.Empty;
            string strTemporal = String.Empty;

            if (int.Parse(numero.ToString().Substring(0, 1)) > 0)
                strLetra += arrRomanos[int.Parse(numero.ToString().Substring(0, 1)) + 18];
            strTemporal = ConvierteDos(numero.ToString().Substring(1, 2));

            return strLetra + strTemporal;
        }

        private string ConvierteCuatro(string numero)
        {
            string strLetra = String.Empty;
            string strTemporal = String.Empty;

            if (int.Parse(numero.ToString().Substring(0, 1)) > 0)
                strLetra += arrRomanos[int.Parse(numero.ToString().Substring(0, 1)) + 27];
            strTemporal += ConvierteTres(numero.Substring(1, 3));

            return strLetra + strTemporal;
        }

        private string ConvierteCinco(string numero)
        {
            string strLetra = String.Empty;
            string strTemporal = String.Empty;

            strLetra += arrRomanos[int.Parse(numero.ToString().Substring(0, 1)) + 36];
            strTemporal += ConvierteCuatro(numero.Substring(1, 4));

            return strLetra + strTemporal;
        }

        private void InicializarMatriz()
        {
            arrRomanos[0] = String.Empty;
            arrRomanos[1] = "I";
            arrRomanos[2] = "II";
            arrRomanos[3] = "III";
            arrRomanos[4] = "IV";
            arrRomanos[5] = "V";
            arrRomanos[6] = "VI";
            arrRomanos[7] = "VII";
            arrRomanos[8] = "VIII";
            arrRomanos[9] = "IX";
            arrRomanos[10] = "X";
            arrRomanos[11] = "XX";
            arrRomanos[12] = "XXX";
            arrRomanos[13] = "XL";
            arrRomanos[14] = "L";
            arrRomanos[15] = "LX";
            arrRomanos[16] = "LXX";
            arrRomanos[17] = "LXXX";
            arrRomanos[18] = "XC";
            arrRomanos[19] = "C";
            arrRomanos[20] = "CC";
            arrRomanos[21] = "CCC";
            arrRomanos[22] = "CD";
            arrRomanos[23] = "D";
            arrRomanos[24] = "DC";
            arrRomanos[25] = "DCC";
            arrRomanos[26] = "DCCC";
            arrRomanos[27] = "CM";
            arrRomanos[28] = "M";
            arrRomanos[29] = "MM";
            arrRomanos[30] = "MMM";
            arrRomanos[31] = "M(V)";
            arrRomanos[32] = "(V)";
            arrRomanos[33] = "(V)M";
            arrRomanos[34] = "(V)MM";
            arrRomanos[35] = "(V)MMM";
            arrRomanos[36] = "M(X)";
            arrRomanos[37] = "(X)";
            arrRomanos[38] = "(XX)";
            arrRomanos[39] = "(XXX)";
            arrRomanos[40] = "(XL)";
            arrRomanos[41] = "(L)";
            arrRomanos[42] = "(LX)";
            arrRomanos[43] = "(LXX)";
            arrRomanos[44] = "(LXXX)";
            arrRomanos[45] = "(XC)";
        }
    }
}
