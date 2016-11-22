using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Gestion.Metricas
{
    public class Avance
    {
        public IList<ALCSA.Entidades.Parametros.Salidas.Metricas.AvanceEtapa> ListarAvancePorEtapa(string rutCliente, string rutProcurador, DateTime fechaDesde, DateTime fechaHasta)
        {
            ValidarFechas(ref fechaDesde, ref fechaHasta);
            return new Datos.Gestion.Metricas.Avance().ListarAvancePorEtapa(rutCliente, rutProcurador, fechaDesde, fechaHasta);
        }

        public IList<ALCSA.Entidades.Parametros.Salidas.Metricas.AvanceTramite> ListarAvancePorTramite(string rutCliente, string rutProcurador, DateTime fechaDesde, DateTime fechaHasta)
        {
            ValidarFechas(ref fechaDesde, ref fechaHasta);
            return new Datos.Gestion.Metricas.Avance().ListarAvancePorTramite(rutCliente, rutProcurador, fechaDesde, fechaHasta);
        }

        public IList<ALCSA.Entidades.Parametros.Salidas.Metricas.Cumplimiento> ListarCumplimientoPorEtapa(string rutCliente, string rutProcurador, DateTime fechaDesde, DateTime fechaHasta)
        {
            ValidarFechas(ref fechaDesde, ref fechaHasta);
            IList<ALCSA.Entidades.Parametros.Salidas.Metricas.Cumplimiento> arrDatos = new Datos.Gestion.Metricas.Avance().ListarCumplimientoPorEtapa(rutCliente, rutProcurador, fechaDesde, fechaHasta);
            double dblNumeroTotal = 0;
            foreach (ALCSA.Entidades.Parametros.Salidas.Metricas.Cumplimiento objDato in arrDatos)
                dblNumeroTotal += objDato.NumeroCasos;

            foreach (ALCSA.Entidades.Parametros.Salidas.Metricas.Cumplimiento objDato in arrDatos)
                objDato.PorcentajeCasos = objDato.NumeroCasos > 0 ? Convert.ToDouble(objDato.NumeroCasos * 100f / dblNumeroTotal) : 0;

            return arrDatos;
        }

        public IList<ALCSA.Entidades.Parametros.Salidas.Metricas.Cumplimiento> ListarCumplimientoPorTramite(string rutCliente, string rutProcurador, DateTime fechaDesde, DateTime fechaHasta)
        {
            ValidarFechas(ref fechaDesde, ref fechaHasta);
            IList<ALCSA.Entidades.Parametros.Salidas.Metricas.Cumplimiento> arrDatos = new Datos.Gestion.Metricas.Avance().ListarCumplimientoPorTramite(rutCliente, rutProcurador, fechaDesde, fechaHasta);
            double dblNumeroTotal = 0;
            foreach (ALCSA.Entidades.Parametros.Salidas.Metricas.Cumplimiento objDato in arrDatos)
                dblNumeroTotal += objDato.NumeroCasos;

            foreach (ALCSA.Entidades.Parametros.Salidas.Metricas.Cumplimiento objDato in arrDatos)
                objDato.PorcentajeCasos = objDato.NumeroCasos > 0 ? Convert.ToDouble(objDato.NumeroCasos * 100f / dblNumeroTotal) : 0;

            return arrDatos;
        }

        private void ValidarFechas(ref DateTime fechaDesde, ref DateTime fechaHasta)
        {
            fechaDesde = fechaDesde.Date;
            fechaHasta = fechaHasta.Date;
            if (fechaDesde.Year < 1900) fechaDesde = new DateTime(1900, 1, 1);
            if (fechaHasta < fechaDesde || fechaHasta.Year <= 1900)
                fechaHasta = new DateTime(2020, 1, 1);
            fechaHasta = fechaHasta.AddHours(11).AddMinutes(59);
        }
    }
}
