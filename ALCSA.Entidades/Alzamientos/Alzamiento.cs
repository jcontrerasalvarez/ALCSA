using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALCSA.Entidades.Alzamientos
{
    public class Alzamiento : Base
    {
        public int AnoDominio { get; set; }

        public int AnoHipoteca { get; set; }

        public int AnoProhibicion { get; set; }

        public string CentroCostos { get; set; }

        public string Conservador { get; set; }

        public string Direccion { get; set; }

        public DateTime FechaContabilizacion { get; set; }

        public DateTime FechaEntrega { get; set; }

        public DateTime FechaEscritura { get; set; }

        public DateTime FechaEstado { get; set; }

        public DateTime FechaFactura { get; set; }

        public string Fectura { get; set; }

        public string FojasDominio { get; set; }

        public string FojasHipoteca { get; set; }

        public string FojasProhibicion { get; set; }

        public int IdComuna { get; set; }

        public int IdEstado { get; set; }

        public int IdNotaria { get; set; }

        public int IdRemesa { get; set; }

        public int NumeroCarillas { get; set; }

        public string NumeroDominio { get; set; }

        public string NumeroHipoteca { get; set; }

        public string NumeroOperacion { get; set; }

        public string NumeroProhibicion { get; set; }

        public string Observacion { get; set; }

        public string Protocolo { get; set; }

        public string Reportorio { get; set; }

        public string RutDeudor { get; set; }

        public string UsuarioCarga { get; set; }

        public string UsuarioResponsable { get; set; }

        public int NumeroAlzamientos { get; set; }
    }
}
