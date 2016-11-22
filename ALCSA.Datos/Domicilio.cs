using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Datos
{
    public class Domicilio
    {
        public IList<Entidades.Parametros.Salidas.Domicilios.Basico> ListarSimilares(string rut)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Comando = "dbo.SPALC_DOMICILIOS_SIMILARES_LISTAR";
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_RutDeudor", Valor = rut, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            return objServicio.Ejecutar<Entidades.Parametros.Salidas.Domicilios.Basico>();
        }
    }
}
