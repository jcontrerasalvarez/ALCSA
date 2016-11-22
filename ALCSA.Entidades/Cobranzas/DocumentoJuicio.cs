using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.Cobranzas
{
    /// <summary>
    /// 
    /// </summary>
    /// <creador>Generador Código</creador>
    /// <fecha_creacion>20-04-2014</fecha_creacion>
    public class DocumentoJuicio : Base
    {
        public string Actaprotesto { get; set; }

        public string Ctacte { get; set; }

        public string Direccionacta { get; set; }

        public DateTime Faceptacion { get; set; }

        public DateTime Fautorizacionnotarial { get; set; }

        public DateTime Fdeuda { get; set; }

        public DateTime Fgiroemision { get; set; }

        public DateTime Fprescripcion { get; set; }

        public DateTime Fproceso { get; set; }

        public DateTime Fvencimiento { get; set; }

        public int IdBanco { get; set; }

        public int IdCobranza { get; set; }

        public int IdComunaNotario { get; set; }

        public int IdTipoDocumento { get; set; }

        public int IdDomicilio { get; set; }

        public int IdDomicilioEndosante { get; set; }

        public int IdNotario { get; set; }

        public string Mch { get; set; }

        public float Monto { get; set; }

        public string Nrodocumento { get; set; }

        public string Numcheque { get; set; }

        public string Numserie { get; set; }

        public string Observacion { get; set; }

        public string Pagado { get; set; }

        public string Representante1 { get; set; }

        public string Representante2 { get; set; }

        public string RutDeudorEndosante { get; set; }

        public string Tituloconstadeuda { get; set; }

        public string Urldocumento { get; set; }

        public string NombreComunaNotario { get; set; }

        public string NombreBanco { get; set; }

        public string NombreNotario { get; set; }

        public string DireccionDeudor { get; set; }

        public string NombreRepresentanteUno { get; set; }

        public string NombreRepresentanteDos { get; set; }

        public string NombreEndosante { get; set; }

        public string DireccionEndosante { get; set; }
    }
}
