using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.ServiciosJson
{
    public class ListadorConceptos
    {
        public IList<Entidades.Base> Listar(string concepto)
        {
            return new Datos.ServiciosJson.ListadorConceptos().Listar(concepto);
        }
    }
}
