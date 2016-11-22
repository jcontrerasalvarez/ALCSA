using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.Gastos
{
    public class GastoCobranza : Base
    {
        public string Desgasto { get; set; }

        public int Estadogasto { get; set; }

        public DateTime Fechaestadogasto { get; set; }

        public DateTime Fechagasto { get; set; }

        public DateTime Fnomina { get; set; }

        public DateTime Fproceso { get; set; }

        public string Gasto { get; set; }

        public int IdActPrejudicial { get; set; }

        public int IdCobranza { get; set; }

        public int IdGastoAdmin { get; set; }

        public int IdGastoJudicial { get; set; }

        public float Montogastoadmin { get; set; }

        public float Montogastojudi { get; set; }

        public float Montogastopre { get; set; }

        public string NomResponsable { get; set; }

        public string Nomina { get; set; }

        public string Nroboleta { get; set; }

        public string Pagado { get; set; }

        public string RutResponsable { get; set; }

        public string TipoResponsable { get; set; }

        public string Tipogastujudi { get; set; }

        public string Username { get; set; }

        public string Observacion { get; set; }
    }
}
