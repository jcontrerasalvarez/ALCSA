using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Requerimientos
{
    public class Usuario
    {
        public IList<ALCSA.Entidades.Requerimientos.Usuario> Listar()
        {
            return new Datos.Requerimientos.Usuario().Listar();
        }
    }
}
