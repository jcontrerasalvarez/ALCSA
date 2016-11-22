using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.Parametros.Salidas.Metricas
{
    public class EstadoProcurador
    {
        public string RutProcurador { get; set; }

        public string NombreProcurador { get; set; }

        public int NumeroCobranzasVencidas { get; set; }

        public int NumeroCobranzasPorVencer { get; set; }

        public int NumeroCobranzasEnPlazo { get; set; }

        public int NumeroCobranzasTerminadas { get; set; }

        public int NumeroTotalCobranzas { get; set; }

        public decimal PorcentajeAsignado { get; set; }

        public decimal PorcentajeVencidas { get; set; }

        public decimal PorcentajePorVencer { get; set; }

        public decimal PorcentajeEnPlazo { get; set; }

        public decimal PorcentajeTerminado { get; set; }
    }
}
