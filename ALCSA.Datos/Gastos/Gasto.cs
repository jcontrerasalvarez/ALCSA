using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Datos.Gastos
{
    public class Gasto
    {
        public ALCSA.Entidades.Gastos.GastoCobranza Buscar(int id)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Comando = "dbo.SPALC_GASTOS_BUSCAR";
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdGasto", Valor = id, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            IList<ALCSA.Entidades.Gastos.GastoCobranza> arrRespuesta = objServicio.Ejecutar<ALCSA.Entidades.Gastos.GastoCobranza>();
            return arrRespuesta.Count > 0 ? arrRespuesta[0] : null;
        }

        public void Insertar(ALCSA.Entidades.Gastos.GastoCobranza gastos)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Comando = "dbo.SPALC_GASTOS_INSERTAR";
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_Desgasto", Valor = gastos.Desgasto, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_Estadogasto", Valor = gastos.Estadogasto, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@DAT_Fechaestadogasto", Valor = gastos.Fechaestadogasto, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@DAT_Fechagasto", Valor = gastos.Fechagasto, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@DAT_Fnomina", Valor = gastos.Fnomina, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@DAT_Fproceso", Valor = gastos.Fproceso, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_Gasto", Valor = gastos.Gasto, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdActPrejudicial", Valor = gastos.IdActPrejudicial, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdCobranza", Valor = gastos.IdCobranza, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdGastoAdmin", Valor = gastos.IdGastoAdmin, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdGastoJudicial", Valor = gastos.IdGastoJudicial, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@FLT_Montogastoadmin", Valor = gastos.Montogastoadmin, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@FLT_Montogastojudi", Valor = gastos.Montogastojudi, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@FLT_Montogastopre", Valor = gastos.Montogastopre, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_NomResponsable", Valor = gastos.NomResponsable, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_Nomina", Valor = gastos.Nomina, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_Nroboleta", Valor = gastos.Nroboleta, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@CHR_Pagado", Valor = gastos.Pagado, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_RutResponsable", Valor = gastos.RutResponsable, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@CHR_TipoResponsable", Valor = gastos.TipoResponsable, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@CHR_Tipogastujudi", Valor = gastos.Tipogastujudi, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_Username", Valor = gastos.Username, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });

            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_Observacion", Valor = gastos.Observacion, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });

            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdGastoSalida", Valor = 0, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Salida });
            objServicio.EjecutarSinRetorno();

            gastos.ID = Convert.ToInt32(objServicio.Parametros[objServicio.Parametros.Count - 1].Valor);
        }

        public void Actualizar(ALCSA.Entidades.Gastos.GastoCobranza gastos)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Comando = "dbo.SPALC_GASTOS_ACTUALIZAR";
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdGasto", Valor = gastos.ID, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_Desgasto", Valor = gastos.Desgasto, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_Estadogasto", Valor = gastos.Estadogasto, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@DAT_Fechaestadogasto", Valor = gastos.Fechaestadogasto, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@DAT_Fechagasto", Valor = gastos.Fechagasto, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@DAT_Fnomina", Valor = gastos.Fnomina, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@DAT_Fproceso", Valor = gastos.Fproceso, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_Gasto", Valor = gastos.Gasto, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdActPrejudicial", Valor = gastos.IdActPrejudicial, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdCobranza", Valor = gastos.IdCobranza, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdGastoAdmin", Valor = gastos.IdGastoAdmin, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdGastoJudicial", Valor = gastos.IdGastoJudicial, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@FLT_Montogastoadmin", Valor = gastos.Montogastoadmin, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@FLT_Montogastojudi", Valor = gastos.Montogastojudi, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@FLT_Montogastopre", Valor = gastos.Montogastopre, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_NomResponsable", Valor = gastos.NomResponsable, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_Nomina", Valor = gastos.Nomina, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_Nroboleta", Valor = gastos.Nroboleta, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@CHR_Pagado", Valor = gastos.Pagado, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_RutResponsable", Valor = gastos.RutResponsable, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@CHR_TipoResponsable", Valor = gastos.TipoResponsable, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@CHR_Tipogastujudi", Valor = gastos.Tipogastujudi, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_Username", Valor = gastos.Username, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_Observacion", Valor = gastos.Observacion, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.EjecutarSinRetorno();
        }

        public void Eliminar(int id)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Comando = "dbo.SPALC_GASTOS_ELIMINAR";
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdGasto", Valor = id, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.EjecutarSinRetorno();
        }

        public IList<ALCSA.Entidades.Gastos.GastoCobranza> Listar(int idCobranza)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Comando = "dbo.SPALC_GASTOS_LISTAR";
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdCobranza", Valor = idCobranza, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            return objServicio.Ejecutar<ALCSA.Entidades.Gastos.GastoCobranza>();
        }
    }
}
