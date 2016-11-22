using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.Cobranzas
{
    public class Bitacora : Base
    {
        public string Descripcion { get; set; }

        public string Estado { get; set; }

        public DateTime Fproceso { get; set; }

        public int IdCobranza { get; set; }

        public string Usuario { get; set; }
    }
}
