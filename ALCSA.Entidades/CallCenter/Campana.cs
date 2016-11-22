using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.CallCenter
{
    public class Campana : Base
    {
        public bool EsTemporal { get; set; }

        public DateTime FechaIngreso { get; set; }

        public DateTime FechaRegistroVicidial { get; set; }

        public string UsuarioIngreso { get; set; }

        public int NumeroCobranzasAsignadas { get; set; }

        public int NumeroCobranzasConComentario { get; set; }
    }
}
