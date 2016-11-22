using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.Parametros.Salidas.Metricas
{
    public class ResumenProcurador
    {
        public string NombreCliente { get; set; }

        public int NumeroTotalCobranzas { get; set; }

        public int NumeroCobranzasVencidas { get; set; }

        public int NumeroCobranzasPorVencer { get; set; }

        public int NumeroCobranzasEnPlazo { get; set; }

        public int NumeroCobranzasTerminadas { get; set; }

        public int NumeroTotalCobranzasMes { get; set; }

        public int NumeroCobranzasVencidasMes { get; set; }

        public int NumeroCobranzasPorVencerMes { get; set; }

        public int NumeroCobranzasEnPlazoMes { get; set; }

        public int NumeroCobranzasTerminadasMes { get; set; }

        public decimal PorcentajeTotalCobranzas { get; set; }

        public decimal PorcentajeCobranzasVencidas { get; set; }

        public decimal PorcentajeCobranzasPorVencer { get; set; }

        public decimal PorcentajeCobranzasEnPlazo { get; set; }

        public decimal PorcentajeCobranzasTerminadas { get; set; }

        public decimal PorcentajeTotalCobranzasMes { get; set; }

        public decimal PorcentajeCobranzasVencidasMes { get; set; }

        public decimal PorcentajeCobranzasPorVencerMes { get; set; }

        public decimal PorcentajeCobranzasEnPlazoMes { get; set; }

        public decimal PorcentajeCobranzasTerminadasMes { get; set; }

        public decimal Efectividad { get; set; }

        public decimal VelocidadPromedioTramitacion { get; set; }

        public decimal VelocidadPromedioTermino { get; set; }
    }
}
