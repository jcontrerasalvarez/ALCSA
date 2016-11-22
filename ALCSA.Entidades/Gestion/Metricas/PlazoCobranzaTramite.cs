using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.Gestion.Metricas
{
    public class PlazoCobranzaTramite : Base
    {
        public int IdPlazoCobranza { get; set; }

        public int IdTramite { get; set; }

        public int PlazoDias { get; set; }
    }
}
