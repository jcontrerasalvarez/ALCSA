using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.Temporales
{
    public class Temporal : Base
    {
        public string TextoTemporal { get; set; }

        public string CodigoProceso { get; set; }

        public string UsuarioDueno { get; set; }

        public string Estado { get; set; }
    }
}
