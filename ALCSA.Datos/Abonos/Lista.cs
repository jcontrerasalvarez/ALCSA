using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ALCSA.Datos.Abonos
{
    public class Lista
    {
        public DataTable ListarDesglose(int idAbono, int idCobranza)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdAbono", Valor = idAbono, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdCobranza", Valor = idCobranza, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Comando = "dbo.SPALC_DesgloseListar";
            return objServicio.EjecutarDataTable();
        }
    }
}
