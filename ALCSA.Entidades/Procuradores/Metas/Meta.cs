using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALCSA.Entidades.Procuradores.Metas
{
    public class Meta : Base
    {
        public string Etapa { get; set; }

        public DateTime FechaIngreso { get; set; }

        public DateTime FechaDesde { get; set; }

        public DateTime FechaHasta { get; set; }

        public int Numero { get; set; }

        public string UsuarioIngreso { get; set; }
    }
}
