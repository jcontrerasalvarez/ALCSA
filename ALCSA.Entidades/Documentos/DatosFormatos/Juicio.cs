using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.Documentos.DatosFormatos
{
    public class Juicio
    {
        public string Tribunal { get; set; }

        public string Cliente { get; set; }

        public string RutDeudor { get; set; }

        public string Deudor { get; set; }

        public string Rol { get; set; }

        public int IdExhorto { get; set; }

        public string DomicilioDeudor { get; set; }

        public string ComunaDomicilioDeudor { get; set; }
    }
}
