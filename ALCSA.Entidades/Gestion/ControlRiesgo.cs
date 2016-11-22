using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.Gestion
{
    public class ControlRiesgo
    {
        public string NumeroOperacion { get; set; }

        public string RutCliente { get; set; }

        public string NombreCliente { get; set; }

        public string RutDeudor { get; set; }

        public string NombreDeudor { get; set; }

        public string Rol { get; set; }

        public string RolExhorto { get; set; }

        public string EstadoJuicio { get; set; }

        public string NombreTribunal { get; set; }

        public string NombreProcurador { get; set; }

        public string NombreTramite { get; set; }

        public DateTime FechaTramite { get; set; }

        public string NombreSubTramite { get; set; }

        public DateTime FechaSubTramite { get; set; }

        public int DiasSinMovimientos { get; set; }

        public string EstadoExhorto { get; set; }

        public string TramiteExhorto { get; set; }
    }
}
