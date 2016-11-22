using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Gestion.Metricas
{
    public class Procurador
    {
        public IList<Entidades.Parametros.Salidas.Metricas.EstadoProcurador> Listar()
        {
            return Listar(string.Empty);
        }

        public IList<Entidades.Parametros.Salidas.Metricas.EstadoProcurador> Listar(string rutProcurador)
        {
            return new Datos.Gestion.Metricas.Procurador().Listar(rutProcurador);
        }

        public IList<Entidades.Parametros.Salidas.Metricas.EstadoProcuradorCobranza> ListarCobranzas(string rutProcurador)
        {
            if (string.IsNullOrWhiteSpace(rutProcurador))
                return new List<Entidades.Parametros.Salidas.Metricas.EstadoProcuradorCobranza>();
            return new Datos.Gestion.Metricas.Procurador().ListarCobranzas(rutProcurador);
        }

        public IList<Entidades.Parametros.Salidas.Metricas.ResumenProcurador> ListarResumenPorCliente(string rutProcurador, DateTime fechaDesde, DateTime fechaHasta)
        {
            if (string.IsNullOrWhiteSpace(rutProcurador))
                return new List<Entidades.Parametros.Salidas.Metricas.ResumenProcurador>();

            if (fechaDesde.Year < 1900) fechaDesde = new DateTime(1900, 1, 1);
            if (fechaHasta.Year < 1900) fechaHasta = new DateTime(1900, 1, 1);

            fechaDesde = fechaDesde.Date;
            fechaHasta = fechaHasta.Date.AddHours(23).AddMinutes(59);

            return new Datos.Gestion.Metricas.Procurador().ListarResumenPorCliente(rutProcurador, fechaDesde, fechaHasta);
        }

        public IList<Entidades.Parametros.Salidas.Metricas.TramiteCobranzaTerminada> ListarTramitesCobranzasTerminadas(string rutProcurador, DateTime fechaDesde, DateTime fechaHasta)
        {
            if (string.IsNullOrWhiteSpace(rutProcurador))
                return new List<Entidades.Parametros.Salidas.Metricas.TramiteCobranzaTerminada>();

            if (fechaDesde.Year < 1900) fechaDesde = new DateTime(1900, 1, 1);
            if (fechaHasta.Year < 1900) fechaHasta = new DateTime(1900, 1, 1);

            fechaDesde = fechaDesde.Date;
            fechaHasta = fechaHasta.Date.AddHours(23).AddMinutes(59);

            return new Datos.Gestion.Metricas.Procurador().ListarTramitesCobranzasTerminadas(rutProcurador, fechaDesde, fechaHasta);
        }
    }
}
