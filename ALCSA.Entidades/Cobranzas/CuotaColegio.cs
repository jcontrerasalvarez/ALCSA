using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.Cobranzas
{
    public class CuotaColegio : Base
    {
        public float Abonos { get; set; }

        public int Aniomora { get; set; }

        public string Codigo { get; set; }

        public DateTime Fechaingresocobranza { get; set; }

        public DateTime Fechamora { get; set; }

        public DateTime Fechavencimiento { get; set; }

        public DateTime Fprescripcion { get; set; }

        public DateTime Fproceso { get; set; }

        public int IdBanco { get; set; }

        public int IdCobranza { get; set; }

        public int IdTipoDocu { get; set; }

        public string Mch { get; set; }

        public int Mesmora { get; set; }

        public float Montocapital { get; set; }

        public float Montointeres { get; set; }

        public int Nrocuota { get; set; }

        public string Nrodocumento { get; set; }

        public string Observacion { get; set; }

        public string Pagado { get; set; }

        public string Representante1 { get; set; }

        public string Representante2 { get; set; }

        public float Saldodeuda { get; set; }

        public string Serie { get; set; }

        public string Urldocumento { get; set; }



        public string NombreRepresentanteUno { get; set; }

        public string NombreRepresentanteDos { get; set; }

        public string NombreTipoDocumento { get; set; }

        public string NombreBanco { get; set; }
    }
}
