using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.Parametros.Salidas.Metricas
{
    public class EstadoBaseCobranza
    {
        public string NumeroOperacion { get; set; }

        public string RutDeudor { get; set; }

        public string NombreDeudor { get; set; }

        public string RutCliente { get; set; }

        public string NombreCliente { get; set; }

        public string Rol { get; set; }

        public int PlazoDias { get; set; }

        public int DiasDesdeIngresoCobranza { get; set; }

        public int DiasRestantes { get; set; }

        public int DiasAtraso { get; set; }

        public DateTime FechaIngreso { get; set; }

        public DateTime FechaLimite { get; set; }

        public DateTime FechaTermino { get; set; }

        public string Estado { get; set; }

        public string EstadoAvance { get; set; }

        public string Etapa { get; set; }

        public string Tramite { get; set; }

        public string SubTramite { get; set; }

        public string FechaIngresoComoTexto
        {
            get { return FormatearFecha(FechaIngreso); }
        }

        public string FechaLimiteComoTexto
        {
            get { return FormatearFecha(FechaLimite); }
        }

        public string FechaTerminoComoTexto
        {
            get { return FormatearFecha(FechaTermino); }
        }

        private string FormatearFecha(DateTime fecha)
        {
            if (fecha.Year <= 1900) return "N/A";
            return fecha.ToString("dd-MM-yyyy");
        }
    }
}
