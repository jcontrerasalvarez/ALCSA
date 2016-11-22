using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Documentos
{
    public class Listado
    {
        public IList<Entidades.Documentos.CobranzaLista> Listar(
            string tipo,
            string rutCliente, 
            string rutDeudor, 
            int idTribunal,
            string rol,
            string rolExhorto)
        {
            return new Datos.Documentos.CobranzaLista().Listar(tipo, rutCliente, rutDeudor, idTribunal, rol, rolExhorto);
        }
    }
}
