using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.Juicios
{
    public class ActividadJudicial : Base
    {
        public DateTime Fproceso { get; set; }

        public DateTime Fproxgestion { get; set; }

        public DateTime Fsubtramite { get; set; }

        public DateTime Ftramite { get; set; }

        public int IdJuicios { get; set; }

        public int IdProxGestion { get; set; }

        public int IdSubTramite { get; set; }

        public int IdTramite { get; set; }

        public int Indice { get; set; }

        public string Observacion { get; set; }

    }
}
