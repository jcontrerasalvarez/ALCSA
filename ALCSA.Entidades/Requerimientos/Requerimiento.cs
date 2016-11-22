using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.Requerimientos
{
    public class Requerimiento : Base
    {
        public string Descripcion { get; set; }

        public DateTime FechaIngreso { get; set; }

        public int IdEstado { get; set; }

        public int IdDocumento { get; set; }

        public string UsuarioAprobador { get; set; }

        public string UsuarioResponsable { get; set; }

        public string UsuarioSolicitante { get; set; }

        public string NombreEstado { get; set; }

        public string CodigoEstado { get; set; }
    }
}
