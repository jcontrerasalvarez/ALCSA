using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Datos.Requerimientos
{
    public class Usuario
    {
        public IList<ALCSA.Entidades.Requerimientos.Usuario> Listar()
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Comando = "dbo.SPALC_REQ_USUARIOS_LISTAR";
            return objServicio.Ejecutar<ALCSA.Entidades.Requerimientos.Usuario>();
        }
    }
}
