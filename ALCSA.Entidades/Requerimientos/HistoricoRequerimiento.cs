using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.Requerimientos
{
    public class HistoricoRequerimiento : Base
    {
        public int IdEstado { get; set; }

        public int IdRequerimiento { get; set; }

        public string Usuario { get; set; }
    }
}
