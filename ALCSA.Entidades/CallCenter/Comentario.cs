using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.CallCenter
{
    public class Comentario : Base
    {
        public DateTime FechaIngreso { get; set; }

        public int IdCobranza { get; set; }

        public int IdCampana { get; set; }

        public int IdDisposicion { get; set; }

        public string UsuarioIngreso { get; set; }

        public string CodigoDisposicion { get; set; }

        public string NombreDisposicion { get; set; }

        public string NombreTipoDisposicion { get; set; }

        public int IdAdicionalTipoVivienda { get; set; }

        public int IdAdicionalAntiguedadVivienda { get; set; }

        public string AdicionalTipoVivienda { get; set; }

        public string AdicionalAntiguedadVivienda { get; set; }
    }
}
