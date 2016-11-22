using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Gestion.Metricas
{
    public class ParametroGeneral : Entidades.Gestion.Metricas.ParametroGeneral
    {
        public ParametroGeneral() { }

        public ParametroGeneral(int id) 
        {
             if(id < 1) return;
             ALCSA.Entidades.Gestion.Metricas.ParametroGeneral objTemporal = new ALCSA.Datos.Gestion.Metricas.ParametroGeneral().Buscar(id, string.Empty);
             ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Gestion.Metricas.ParametroGeneral, ParametroGeneral>(objTemporal, this);
        }

        public ParametroGeneral(string codigo) 
        {
             if(string.IsNullOrEmpty(codigo)) return;
             ALCSA.Entidades.Gestion.Metricas.ParametroGeneral objTemporal = new ALCSA.Datos.Gestion.Metricas.ParametroGeneral().Buscar(0, codigo);
             ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Gestion.Metricas.ParametroGeneral, ParametroGeneral>(objTemporal, this);
        }

        public void Guardar()
        {
             if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
             new ALCSA.Datos.Gestion.Metricas.ParametroGeneral().Insertar(this);
        }

        public void Actualizar()
        {
             new ALCSA.Datos.Gestion.Metricas.ParametroGeneral().Actualizar(this);
        }

        public void Eliminar()
        {
             new ALCSA.Datos.Gestion.Metricas.ParametroGeneral().Eliminar(this.ID);
        }

        public IList<ALCSA.Entidades.Gestion.Metricas.ParametroGeneral> Listar()
        {
             return new ALCSA.Datos.Gestion.Metricas.ParametroGeneral().Listar();
        }
    }
}
