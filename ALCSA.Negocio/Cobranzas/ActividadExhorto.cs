using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Cobranzas
{
    public class ActividadExhorto 
    {
        public ActividadExhorto() { }

        public IList<Entidades.Cobranzas.ActividadExhorto> Listar()
        {
            return new ALCSA.Datos.Cobranzas.ActividadExhorto().Listar();
        }
    }
}
