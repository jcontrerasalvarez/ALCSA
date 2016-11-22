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
    public class Mutuo : Base
    {
        public DateTime Fecha1Venc { get; set; }

        public DateTime FechaLiquidacion { get; set; }

        public DateTime FechaMora { get; set; }

        public DateTime FechaPrescripcion { get; set; }

        public DateTime Fproceso { get; set; }

        public int IdBienRaiz { get; set; }

        public int IdCobranza { get; set; }

        public int IdMoneda { get; set; }

        public string Mch { get; set; }

        public int MontoCred1Esc { get; set; }

        public int MontoCred2Esc { get; set; }

        public int MontoDivAdeudadoPs { get; set; }

        public float MontoDivAdeudadoUf { get; set; }

        public int N1DivImpago { get; set; }

        public int NUltDivImpago { get; set; }

        public string Nrodocumento { get; set; }

        public string Pagado { get; set; }

        public int PlazoMutuoMes { get; set; }

        public float SaldoTotalDeudaUf { get; set; }

        public string SerieLetCred { get; set; }

        public int Subproducto { get; set; }

        public float TazaInt1Esc { get; set; }

        public float TazaInt2Esc { get; set; }

        public int TotalAdeudado { get; set; }

        public string Urldocumento { get; set; }

    }
}
