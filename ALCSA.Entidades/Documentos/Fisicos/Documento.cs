using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.Documentos.Fisicos
{
    public class Documento : Base
    {
        public byte[] Archivo { get; set; }

        public int IdTipoDocumento { get; set; }

        public int Peso { get; set; }

        public string CodigoTipoDocumento { get; set; }
    }
}
