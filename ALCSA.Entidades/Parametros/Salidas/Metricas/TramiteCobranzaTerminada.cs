using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.Parametros.Salidas.Metricas
{
    public class TramiteCobranzaTerminada
    {
        public string NombreCliente { get; set; }

        public int IdCobranza { get; set; }

        public string Tramite { get; set; }

        public bool EsTramiteTermino { get; set; }

        public DateTime FechaTermino { get; set; }
    }
}
