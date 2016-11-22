using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.Juicios
{
    public class Juicio : Base
    {
        public DateTime FechaMotivoRiesgo { get; set; }

        public DateTime Fingresocorte { get; set; }

        public DateTime Fproceso { get; set; }

        public int IdCobranza { get; set; }

        public int IdJurisdiccion { get; set; }

        public int IdRiesgo { get; set; }

        public int IdTribunal { get; set; }

        public string NombreTribunal { get; set; }

        public string Rol { get; set; }

        public string RutAbogado { get; set; }

        public string RutProcurador { get; set; }

        public string Urldocumento { get; set; }
    }
}
