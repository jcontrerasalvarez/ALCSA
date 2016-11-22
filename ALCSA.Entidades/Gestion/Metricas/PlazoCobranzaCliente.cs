using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.Gestion.Metricas
{
    public class PlazoCobranzaCliente : Base
    {
        public int IdProducto { get; set; }

        public int IdMateria { get; set; }

        public int IdProcedimiento { get; set; }

        public string RutCliente { get; set; }
    }
}
