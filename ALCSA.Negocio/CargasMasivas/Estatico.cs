using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.CargasMasivas
{
    public class Estatico
    {
        public static int POSICION_RUT = 0;
        public static int POSICION_DIGITO_VERIFICADOR = 1;

        public static int POSICION_NOMBRE = 2;
        public static int POSICION_APELLIDO_PATERNO = 3;
        public static int POSICION_APELLIDO_MATERNO = 4;

        public static int POSICION_CALLE = 5;
        public static int POSICION_NUMERO = 6;
        public static int POSICION_NUMERODPTO = 7;
        public static int POSICION_BLOCK = 8;
        public static int POSICION_VILLA = 9;
        public static int POSICION_COMUNA = 10;
        public static int POSICION_MONTO = 11;

        public static string ESTADO_OK = "OK";
        public static string ESTADO_ERROR = "ERROR";
        public static string ESTADO_PENDIENTE = "PENDIENTE";

    }
}
