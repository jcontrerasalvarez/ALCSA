using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Gestion.Metricas
{
    public class PlazoCobranzaTramite : Entidades.Gestion.Metricas.PlazoCobranzaTramite
    {
        public PlazoCobranzaTramite() { }

        public PlazoCobranzaTramite(int id)
        {
            if (id < 1) return;
            ALCSA.Entidades.Gestion.Metricas.PlazoCobranzaTramite objTemporal = new ALCSA.Datos.Gestion.Metricas.PlazoCobranzaTramite().Buscar(id);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Gestion.Metricas.PlazoCobranzaTramite, PlazoCobranzaTramite>(objTemporal, this);
        }

        public void Guardar()
        {
            if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
            new ALCSA.Datos.Gestion.Metricas.PlazoCobranzaTramite().Insertar(this);
        }

        public void Actualizar()
        {
            new ALCSA.Datos.Gestion.Metricas.PlazoCobranzaTramite().Actualizar(this);
        }

        public void Eliminar()
        {
            new ALCSA.Datos.Gestion.Metricas.PlazoCobranzaTramite().Eliminar(this.ID);
        }

        public IList<ALCSA.Entidades.Gestion.Metricas.PlazoCobranzaTramite> Listar()
        {
            return new ALCSA.Datos.Gestion.Metricas.PlazoCobranzaTramite().Listar();
        }

        public IList<ALCSA.Entidades.Parametros.Salidas.Metricas.Tramite> Listar(ALCSA.Entidades.Parametros.Entradas.Metricas.ListadoTramite entrada)
        {
            return new ALCSA.Datos.Gestion.Metricas.PlazoCobranzaTramite().Listar(entrada);
        }
    }
}
