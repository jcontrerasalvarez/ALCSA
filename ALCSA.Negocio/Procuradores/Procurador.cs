using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALCSA.Negocio.Procuradores
{
    public class Procurador //: ALCSA.Entidades.Procuradores.Procurador
    {
        public Procurador() { }

        public IList<ALCSA.Entidades.Procuradores.Procurador> Listar()
        {
            return new ALCSA.Datos.Procuradores.Procurador().Listar();
        }
    }
}
