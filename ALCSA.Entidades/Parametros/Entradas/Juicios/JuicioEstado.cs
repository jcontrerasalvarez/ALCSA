using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.Parametros.Entradas.Juicios
{
    public class JuicioEstado
    {
        public int IdJuicios { get; set; }

        public int IdRiesgo { get; set; }
        public DateTime FechaMotivoRiesgo { get; set; }
        public int IdTribunal { get; set; }
        public string Rol { get; set; }
        public int IdCobranza { get; set; }
        public string Observacion { get; set; }

        public string EstadoCobranza { get; set; }
        public string Usuario { get; set; }
    }
}
