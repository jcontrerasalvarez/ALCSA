using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.FWK.BD
{
    public class Enumeradores
    {
        public enum Direcciones
        {
            Entrada = 0,
            Salida = 1,
            Retorno = 2
        };

        public enum TiposComandos
        {
            SP = 0,
            Query = 1
        };
    }
}
