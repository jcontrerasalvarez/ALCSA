using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALCSA.Entidades.Procuradores
{
    public class Procurador : Base
    {
        public string Rut { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public string NombreCompleto
        {
            get
            {
                if (Nombre == null) Nombre = string.Empty;
                if (ApellidoPaterno == null) ApellidoPaterno = string.Empty;
                if (ApellidoMaterno == null) ApellidoMaterno = string.Empty;

                return string.Format("{0} {1} {2}", Nombre.Trim(), ApellidoPaterno.Trim(), ApellidoMaterno.Trim());
            }
        }
    }
}
