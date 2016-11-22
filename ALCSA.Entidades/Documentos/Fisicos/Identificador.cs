using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.Documentos.Fisicos
{
    public class Identificador : Base
    {
        public int IdDocumento { get; set; }

        public int IdTipoIdentificador { get; set; }

        public string Valor { get; set; }

        public string CodigoTipoIdentificador { get; set; }
    }
}
