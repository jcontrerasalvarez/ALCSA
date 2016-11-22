using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Datos.Gestion
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
            FWK.BD.Servicio objServicio = new FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@BIT_BuscarPorExhorto", Valor = buscarPorExhorto, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_RutDeudor", Valor = rutDeudor, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_NumeroOperacion", Valor = numeroOperacion, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_RutCliente", Valor = rutCliente, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@INT_IdTribunal", Valor = idTribunal, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_CodigoEstado", Valor = codigoEstado, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_RutProcurador", Valor = rutProcurador, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@INT_DiasSinMovimiento", Valor = diasSinMovimiento, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Comando = "dbo.SPALC_GESTION_CONTROL_PLAZOS";
            return objServicio.Ejecutar<Entidades.Gestion.ControlRiesgo>();
        }
    }
}
