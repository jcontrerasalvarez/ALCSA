using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Datos.Juicios
{
    public class Listado
    {
        public System.Data.DataTable ListarPorRiesgo(int idRiesgo)
        {
            FWK.BD.Servicio objServicio = new FWK.BD.Servicio() { Conexion = Conexion.ALCSA, Comando = "dbo.SPALC_JUICIOS_LISTAR_POR_RIESGO " };

            objServicio.Parametros = new List<FWK.BD.Parametro>();
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@INT_IdRiesgo", Valor = idRiesgo, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });

            return objServicio.EjecutarDataTable();
        }
        public System.Data.DataTable ListarPorRiesgo(int idRiesgo, string strTramiteExhorto,string strCliente, string strProcurador, string strTribunal)
        {
            FWK.BD.Servicio objServicio = new FWK.BD.Servicio() { Conexion = Conexion.ALCSA, Comando = "dbo.SPALC_JUICIOS_LISTAR_POR_RIESGO " };

            objServicio.Parametros = new List<FWK.BD.Parametro>();
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@INT_IdRiesgo", Valor = idRiesgo, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada});
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@INT_IDTRAMITEEXHORTO", Valor = idRiesgo, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@ACTIVIDADEXHORTO", Valor = strTramiteExhorto, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@CLIENTE", Valor = strCliente, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@PROCURADOR", Valor = strProcurador, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@TRIBUNAL", Valor = strTribunal, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            return objServicio.EjecutarDataTable();
        }
    }
}
