using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Requerimientos
{
    public class Estado : Entidades.Requerimientos.Estado
    {
        public Estado() { }

        public Estado(int id)
        {
            if (id < 1) return;
            ALCSA.Entidades.Requerimientos.Estado objTemporal = new ALCSA.Datos.Requerimientos.Estado().Buscar(id, string.Empty);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Requerimientos.Estado, Estado>(objTemporal, this);
        }

        public Estado(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo)) return;
            ALCSA.Entidades.Requerimientos.Estado objTemporal = new ALCSA.Datos.Requerimientos.Estado().Buscar(0, codigo);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Requerimientos.Estado, Estado>(objTemporal, this);
        }

        public void Guardar()
        {
            if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
            new ALCSA.Datos.Requerimientos.Estado().Insertar(this);
        }

        public void Actualizar()
        {
            new ALCSA.Datos.Requerimientos.Estado().Actualizar(this);
        }

        public void Eliminar()
        {
            new ALCSA.Datos.Requerimientos.Estado().Eliminar(this.ID);
        }

        public IList<ALCSA.Entidades.Requerimientos.Estado> Listar()
        {
            return new ALCSA.Datos.Requerimientos.Estado().Listar();
        }
    }
}
