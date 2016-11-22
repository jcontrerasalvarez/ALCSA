using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Datos.ServiciosJson
{
    public class ListadorConceptos
    {
        public IList<Entidades.Base> Listar(string concepto)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Comando = "dbo.SPALC_CONCEPTOS_LISTAR";
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_Concepto", Valor = concepto, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            return objServicio.Ejecutar<Entidades.Base>();
        }
    }
}
