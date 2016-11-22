using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Juicios
{
    public class Listado
    {
        public System.Data.DataTable ListarPorRiesgo(int idRiesgo)
        {
            return new Datos.Juicios.Listado().ListarPorRiesgo(idRiesgo);
        }
        public System.Data.DataTable ListarPorRiesgo(int idRiesgo, string strTramiteExhorto, string strCliente, string strProcurador, string strTribunal)
        {
            return new Datos.Juicios.Listado().ListarPorRiesgo(idRiesgo, strTramiteExhorto, strCliente,  strProcurador, strTribunal);
        }
    }
}
