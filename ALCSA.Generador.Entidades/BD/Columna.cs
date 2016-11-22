using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Generador.Entidades.BD
{
    public class Columna
    {
        public string Nombre { get; set; }

        public string TipoDato { get; set; }

        public int Largo { get; set; }

        public int Presicion { get; set; }

        public bool EsLlavePrimaria { get; set; }
    }
}
