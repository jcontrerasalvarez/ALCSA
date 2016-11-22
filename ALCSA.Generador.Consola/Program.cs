using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Generador.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            string strModulo = string.Empty;
            while (string.IsNullOrEmpty(strModulo))
            {
                Console.WriteLine("Ingrese el nombre del modulo para considerarlo en el Namespace...\n");
                strModulo = Console.ReadLine();
            }
            GenerarCodigo(strModulo);

            Console.WriteLine("Presione cualquier tecla para finalizar.");
            Console.Read();
        }

        private static void GenerarCodigo(string modulo)
        {
            IList<ALCSA.Generador.Entidades.BD.Tabla> arrTablas = ALCSA.Generador.Negocio.BD.Tabla.Listar();
            ALCSA.Generador.Negocio.GeneradorPieza objGenerador = null;
            string strRuta = "D:\\00. Generador";
            string strEspacioNombre = ALCSA.FWK.Texto.ConvertirAMinusculaPrimeraEnMayuscula(modulo);
            if (!System.IO.Directory.Exists(strRuta)) System.IO.Directory.CreateDirectory(strRuta);

            DateTime datFechaActual = DateTime.Now;

            for (int intIndice = 0; intIndice < arrTablas.Count; intIndice++)
            {
                Console.WriteLine(arrTablas[intIndice].Nombre);
                objGenerador = new ALCSA.Generador.Negocio.GeneradorPieza(arrTablas[intIndice].Nombre, strRuta);
                objGenerador.GenerarPiezas(strEspacioNombre);
            }

            TimeSpan objTiempo = DateTime.Now - datFechaActual;
            Console.WriteLine(string.Format("Tiempo: {0}:{1}:{2}", objTiempo.Hours, objTiempo.Minutes, objTiempo.Seconds));
            Console.WriteLine("END");
        }
    }
}
