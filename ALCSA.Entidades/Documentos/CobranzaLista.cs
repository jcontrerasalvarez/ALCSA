using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.Documentos
{
    public class CobranzaLista
    {
        public string NumeroOperacion { get; set; }

        public string Cliente { get; set; }

        public string Deudor { get; set; }

        public string Rol { get; set; }

        public string RolExhorto { get; set; }

        public int IdCobranza { get; set; }

        public int IdJuicio { get; set; }

        public int IdExhorto { get; set; }

        public string NombreTribunal { get; set; }

    }
}
