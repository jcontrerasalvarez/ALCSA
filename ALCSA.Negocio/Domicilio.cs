using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio
{
    public class Domicilio
    {
        public IList<Entidades.Parametros.Salidas.Domicilios.Basico> ListarSimilares(string rut)
        {
            if (string.IsNullOrEmpty(rut)) return null;
            rut = rut.Replace(".", string.Empty);
            return new Datos.Domicilio().ListarSimilares(rut);
        }
    }
}
