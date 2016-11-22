using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.Tramites
{
    public class SubTramite : Base
    {
        public string Termino { get; set; }

        public string Tipo { get; set; }

        public bool Vigente { get; set; }
    }
}
