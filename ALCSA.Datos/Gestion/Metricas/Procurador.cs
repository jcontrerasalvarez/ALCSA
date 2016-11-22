using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Datos.Gestion.Metricas
{
    public class Procurador
    {
        public IList<Entidades.Parametros.Salidas.Metricas.EstadoProcurador> Listar(string rutProcurador)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_RutProcurador", Valor = rutProcurador, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Comando = "dbo.SPALC_MetricasContadorCobranzasProcuradorListar";
            return objServicio.Ejecutar<Entidades.Parametros.Salidas.Metricas.EstadoProcurador>();
        }

        public IList<Entidades.Parametros.Salidas.Metricas.EstadoProcuradorCobranza> ListarCobranzas(string rutProcurador)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_RutProcurador", Valor = rutProcurador, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Comando = "dbo.SPALC_MetricasEstadoCobranzasProcuradorListar";
            return objServicio.Ejecutar<Entidades.Parametros.Salidas.Metricas.EstadoProcuradorCobranza>();
        }

        public IList<Entidades.Parametros.Salidas.Metricas.ResumenProcurador> ListarResumenPorCliente(string rutProcurador, DateTime fechaDesde, DateTime fechaHasta)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_RutProcurador", Valor = rutProcurador, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@DAT_FechaDesde", Valor = fechaDesde, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@DAT_FechaHasta", Valor = fechaHasta, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Comando = "dbo.SPALC_MetricasContadorResumenProcuradorListar";
            return objServicio.Ejecutar<Entidades.Parametros.Salidas.Metricas.ResumenProcurador>();
        }

        public IList<Entidades.Parametros.Salidas.Metricas.TramiteCobranzaTerminada> ListarTramitesCobranzasTerminadas(string rutProcurador, DateTime fechaDesde, DateTime fechaHasta)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_RutProcurador", Valor = rutProcurador, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@DAT_FechaDesde", Valor = fechaDesde, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@DAT_FechaHasta", Valor = fechaHasta, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Comando = "dbo.SPALC_MetricasCobranzasTerminadasProcuradorListar";
            return objServicio.Ejecutar<Entidades.Parametros.Salidas.Metricas.TramiteCobranzaTerminada>();
        }
    }
}
