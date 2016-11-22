using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.Parametros.Salidas.Metricas
{
    public class EstadoCliente
    {
        public string RutCliente { get; set; }

        public string NombreCliente { get; set; }

        public int NumeroCobranzasVencidas { get; set; }

        public int NumeroCobranzasPorVencer { get; set; }

        public int NumeroCobranzasEnPlazo { get; set; }

        public int NumeroCobranzasTerminadas { get; set; }

        public int NumeroTotalCobranzas { get; set; }
    }
}
