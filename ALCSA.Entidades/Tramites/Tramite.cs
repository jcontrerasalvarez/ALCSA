using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.Tramites
{
    public class Tramite : Base
    {
        public string Etapa { get; set; }

        public int Indice { get; set; }

        public string Termino { get; set; }

        public string Tipo { get; set; }

        public bool Vigente { get; set; }
    }
}
