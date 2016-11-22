using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.Cobranzas
{
    public class DocumentoPagare : Base
    {
        public DateTime Fautorizacionfirma { get; set; }

        public DateTime Fliquidacion { get; set; }

        public DateTime Fmora { get; set; }

        public DateTime Fprescripcion { get; set; }

        public DateTime Fproceso { get; set; }

        public DateTime Fsuscripcion { get; set; }

        public int IdCobranza { get; set; }

        public int IdComunaExhorto { get; set; }

        public int IdComunaNotaria { get; set; }

        public int IdDomiRepre1 { get; set; }

        public int IdDomiRepre2 { get; set; }

        public int IdDomicilio { get; set; }

        public int IdMoneda { get; set; }

        public int IdNotaria { get; set; }

        public string Mch { get; set; }

        public float Monto1cuotas { get; set; }

        public float Montodemanda { get; set; }

        public float Montotaldeuda { get; set; }

        public float Montoultimacuota { get; set; }

        public int Nrocuotas { get; set; }

        public string Nropagare { get; set; }

        public string Observacion { get; set; }

        public string Pagado { get; set; }

        public string RutRepresentante1 { get; set; }

        public string RutRepresentante2 { get; set; }

        public float Sumainisuscripcion { get; set; }

        public float Tasainteres { get; set; }

        public string Urldocumento { get; set; }

        public DateTime Vcto1cuota { get; set; }

        public int Vctosiguientescuotas { get; set; }


        public string NombreComunaNotario { get; set; }

        public string NombreNotario { get; set; }

        public string DireccionPagare { get; set; }

        public string NombreRepresentanteUno { get; set; }

        public string NombreRepresentanteDos { get; set; }

        public string DireccionRepresentanteUno { get; set; }

        public string DireccionRepresentanteDos { get; set; }

        public string NombreTipoMoneda { get; set; }

        public string NombreComunaExhorto { get; set; }
    }
}
