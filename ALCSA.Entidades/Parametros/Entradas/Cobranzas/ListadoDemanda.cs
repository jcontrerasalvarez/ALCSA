using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.Parametros.Entradas.Cobranzas
{
    public class ListadoDemanda
    {
        public string RutDeudor { get; set; }
        public string NroOperacion { get; set; }
        public string RutCliente { get; set; }
        public int IdRemesa { get; set; }
    }
}