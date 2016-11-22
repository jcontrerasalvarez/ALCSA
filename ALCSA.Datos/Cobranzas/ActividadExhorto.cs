using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Datos.Cobranzas
{
    public class ActividadExhorto
    {
        public IList<ALCSA.Entidades.Cobranzas.ActividadExhorto> Listar()
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Comando = "dbo.SPALC_ACTIVIDAD_EXHORTO";            
            return objServicio.Ejecutar<ALCSA.Entidades.Cobranzas.ActividadExhorto>();
        }
    }
}
