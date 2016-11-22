using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.Abonos
{
    public class AbonoCheque : Base
    {
        public string Cuentadeposito { get; set; }

        public string Estado { get; set; }

        public DateTime Fechadeposito { get; set; }

        public DateTime Fechaliberacion { get; set; }

        public DateTime Fpago { get; set; }

        public DateTime Fproceso { get; set; }

        public int IdAbonoComprobante { get; set; }

        public int IdBanco { get; set; }

        public int IdCobranza { get; set; }

        public float Montoabono { get; set; }

        public string Nrocheque { get; set; }

        public string Nrocomprobantedeposito { get; set; }

        public string RutDeudor { get; set; }

        public string Serie { get; set; }

        public string Userdeposito { get; set; }

        public string Username { get; set; }

        public int NumeroCorrelativo { get; set; }
    }
}
