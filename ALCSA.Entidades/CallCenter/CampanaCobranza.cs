using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.CallCenter
{
    public class CampanaCobranza : Base
    {
        public DateTime FechaIngreso { get; set; }

        public int IdCampana { get; set; }

        public int IdCobranza { get; set; }

        public string NumeroOperacion { get; set; }

        public string RutDeudor { get; set; }

        public string NombreDeudor { get; set; }

        public string RutCliente { get; set; }

        public string NombreCliente { get; set; }

        public int NumeroComentarios { get; set; }

        public string DisposicionDeudor { get; set; }
    }
}
