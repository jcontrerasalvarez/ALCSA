using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Gestion
{
    public class ControlRiesgo
    {
        public IList<Entidades.Gestion.ControlRiesgo> Listar(
            bool buscarPorExhorto,
            string rutDeudor,
            string numeroOperacion,
            string rutCliente,
            int idTribunal,
            string codigoEstado,
            string rutProcurador,
            int diasSinMovimiento)
        {
            return new Datos.Gestion.ControlRiesgo().Listar(buscarPorExhorto, rutDeudor, numeroOperacion, rutCliente, idTribunal, codigoEstado, rutProcurador, diasSinMovimiento);
        }
    }
}
