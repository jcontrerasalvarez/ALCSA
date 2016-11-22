using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.Parametros.Salidas.Metricas
{
    public class Cumplimiento
    {
        public string Etapa { get; set; }

        public string Tramite { get; set; }

        public int NumeroCasos { get; set; }

        public double PorcentajeCasos { get; set; }

        public int CasosVencido { get; set; }

        public int CasosPorVencer { get; set; }

        public int CasosEnPlazo { get; set; }
    }
}
