using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Gestion.Metricas
{
    public class PlazoCobranzaCliente : Entidades.Gestion.Metricas.PlazoCobranzaCliente
    {
        public PlazoCobranzaCliente() { }

        public PlazoCobranzaCliente(int id)
        {
            if (id < 1) return;
            ALCSA.Entidades.Gestion.Metricas.PlazoCobranzaCliente objTemporal = new ALCSA.Datos.Gestion.Metricas.PlazoCobranzaCliente().Buscar(id);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Gestion.Metricas.PlazoCobranzaCliente, PlazoCobranzaCliente>(objTemporal, this);
        }

        public void Guardar()
        {
            if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
            new ALCSA.Datos.Gestion.Metricas.PlazoCobranzaCliente().Insertar(this);
        }

        public void Actualizar()
        {
            new ALCSA.Datos.Gestion.Metricas.PlazoCobranzaCliente().Actualizar(this);
        }

        public void Eliminar()
        {
            new ALCSA.Datos.Gestion.Metricas.PlazoCobranzaCliente().Eliminar(this.ID);
        }

        public IList<ALCSA.Entidades.Parametros.Salidas.Metricas.EntidadPlazoCliente> Listar()
        {
            return new ALCSA.Datos.Gestion.Metricas.PlazoCobranzaCliente().Listar();
        }
    }
}
