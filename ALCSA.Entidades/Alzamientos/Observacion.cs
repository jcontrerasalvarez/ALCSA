using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALCSA.Entidades.Alzamientos
{
    public class Observacion : Base
    {
        public int IdAlzamientoActividad { get; set; }

        public string Observacion { get; set; }

        public string UsuarioIngreso { get; set; }
    }
}
