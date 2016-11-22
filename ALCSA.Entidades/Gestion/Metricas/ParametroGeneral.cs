using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.Gestion.Metricas
{
    public class ParametroGeneral : Base
    {
        public string Codigo { get; set; }

        public DateTime Fechaingreso { get; set; }

        public string Nombre { get; set; }

        public decimal Valornumerico { get; set; }

        public string Valortexto { get; set; }
    }
}
