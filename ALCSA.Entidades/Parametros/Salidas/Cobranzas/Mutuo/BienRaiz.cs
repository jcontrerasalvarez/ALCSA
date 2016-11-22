using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.Parametros.Salidas.Cobranzas.Mutuo
{
    public class BienRaiz
    {
        public int IdBienRaiz { get; set; }

        public string Direccion { get; set; }

        public DateTime FechaEscritura { get; set; }

        public int FojasInscripcion { get; set; }

        public int NumeroInscripcion { get; set; }

        public int AnoInscripcion { get; set; }

        public string Comuna { get; set; }

        public int IdComunaConservador { get; set; }

        public string NombreNotario { get; set; }

        public int FojasHipotecario { get; set; }

        public int NumeroHipotecario { get; set; }

        public int AnoHipotecario { get; set; }

    }
}
