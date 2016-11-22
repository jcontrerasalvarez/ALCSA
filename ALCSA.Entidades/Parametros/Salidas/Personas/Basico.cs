using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.Parametros.Salidas.Personas
{
    public class Basico : Base
    {
        public string Rut { get; set; }

        public int IdDomicilio { get; set; }

        public string Direccion { get; set; }
    }
}
