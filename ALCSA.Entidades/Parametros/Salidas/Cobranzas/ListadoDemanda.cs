using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.Parametros.Salidas.Cobranzas
{
    public class ListadoDemanda
    {
        public int IdCobranza { get; set; }

        public string NumeroOperacion { get; set; }

        public string NombreDeudor { get; set; }

        public string NombreCliente { get; set; }

        public string NombreRemesa { get; set; }

        public string TipoActividad { get; set; }

        public string NombreProcedimiento { get; set; }

        public string NombreMateria { get; set; }

        public string NombreProducto { get; set; }

        public DateTime FechaProceso { get; set; }

        public string RutCliente { get; set; }

        public string EstadoCobranza { get; set; }

        public string TipoCobranza { get; set; }

        public string Codigo { get; set; }
    }
}
