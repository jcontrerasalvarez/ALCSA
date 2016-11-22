using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALCSA.Datos.Procuradores
{
    public class Procurador
    {
        public IList<ALCSA.Entidades.Procuradores.Procurador> Listar()
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Comando = "SPALC_PROCURADORES_LISTAR";
            return objServicio.Ejecutar<ALCSA.Entidades.Procuradores.Procurador>();
        }
    }
}
