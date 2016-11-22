using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALCSA.Entidades.Alzamientos
{
    public class Remesa : Base
    {
        public DateTime FechaRemesa { get; set; }
        public string RutCliente { get; set; }
        public string UsuarioIngreso { get; set; }
    }
}
