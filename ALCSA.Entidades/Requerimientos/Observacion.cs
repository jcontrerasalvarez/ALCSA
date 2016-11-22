using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.Requerimientos
{
    public class Observacion : Base
    {
        public int IdDocumento { get; set; }

        public int IdRequerimientos { get; set; }

        public string Usuario { get; set; }
    }
}
