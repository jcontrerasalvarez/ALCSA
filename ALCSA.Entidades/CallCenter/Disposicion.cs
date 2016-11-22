using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.CallCenter
{
    public class Disposicion : Base
    {
        public int IdTipoDisposicion { get; set; }

        public DateTime FechaEliminacion { get; set; }
    }
}
