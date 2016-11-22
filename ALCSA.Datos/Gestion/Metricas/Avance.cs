using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Datos.Gestion.Metricas
{
    public class Avance
    {
        public IList<ALCSA.Entidades.Parametros.Salidas.Metricas.AvanceEtapa> ListarAvancePorEtapa(string rutCliente, string rutProcurador, DateTime fechaDesde, DateTime fechaHasta)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_RutCliente", Valor = rutCliente, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_RutProcurador", Valor = rutProcurador, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@DAT_FechaDesde", Valor = fechaDesde, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@DAT_FechaHasta", Valor = fechaHasta, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });

            objServicio.Comando = "dbo.SPALC_MetricasListarAvancePorEtapa";
            return objServicio.Ejecutar<ALCSA.Entidades.Parametros.Salidas.Metricas.AvanceEtapa>();
        }

        public IList<ALCSA.Entidades.Parametros.Salidas.Metricas.AvanceTramite> ListarAvancePorTramite(string rutCliente, string rutProcurador, DateTime fechaDesde, DateTime fechaHasta)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_RutCliente", Valor = rutCliente, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_RutProcurador", Valor = rutProcurador, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@DAT_FechaDesde", Valor = fechaDesde, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@DAT_FechaHasta", Valor = fechaHasta, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Comando = "dbo.SPALC_MetricasListarAvancePorTramite";
            return objServicio.Ejecutar<ALCSA.Entidades.Parametros.Salidas.Metricas.AvanceTramite>();
        }

        public IList<ALCSA.Entidades.Parametros.Salidas.Metricas.Cumplimiento> ListarCumplimientoPorEtapa(string rutCliente, string rutProcurador, DateTime fechaDesde, DateTime fechaHasta)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_RutCliente", Valor = rutCliente, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_RutProcurador", Valor = rutProcurador, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@DAT_FechaDesde", Valor = fechaDesde, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@DAT_FechaHasta", Valor = fechaHasta, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Comando = "dbo.SPALC_MetricasListarCumplimiento";
            return objServicio.Ejecutar<ALCSA.Entidades.Parametros.Salidas.Metricas.Cumplimiento>();
        }

        public IList<ALCSA.Entidades.Parametros.Salidas.Metricas.Cumplimiento> ListarCumplimientoPorTramite(string rutCliente, string rutProcurador, DateTime fechaDesde, DateTime fechaHasta)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_RutCliente", Valor = rutCliente, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_RutProcurador", Valor = rutProcurador, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@DAT_FechaDesde", Valor = fechaDesde, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@DAT_FechaHasta", Valor = fechaHasta, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Comando = "dbo.SPALC_MetricasListarCumplimientoTramite";
            return objServicio.Ejecutar<ALCSA.Entidades.Parametros.Salidas.Metricas.Cumplimiento>();
        }
    }
}
