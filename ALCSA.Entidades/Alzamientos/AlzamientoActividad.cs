using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALCSA.Entidades.Alzamientos
{
    public class AlzamientoActividad : Base
    {
        public int IdActividad { get; set; }

        public int IdAlzamiento { get; set; }

        public string UsuarioIngreso { get; set; }
    }
}
