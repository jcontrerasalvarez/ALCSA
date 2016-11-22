using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Requerimientos
{
    public class Observacion : Entidades.Requerimientos.Observacion
    {
        public Observacion() { }

        public Observacion(int id)
        {
            if (id < 1) return;
            ALCSA.Entidades.Requerimientos.Observacion objTemporal = new ALCSA.Datos.Requerimientos.Observacion().Buscar(id);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Requerimientos.Observacion, Observacion>(objTemporal, this);
        }

        public void Guardar()
        {
            if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
            new ALCSA.Datos.Requerimientos.Observacion().Insertar(this);
        }

        public void Actualizar()
        {
            new ALCSA.Datos.Requerimientos.Observacion().Actualizar(this);
        }

        public void Eliminar()
        {
            new ALCSA.Datos.Requerimientos.Observacion().Eliminar(this.ID);
        }

        public IList<ALCSA.Entidades.Requerimientos.Observacion> Listar(int idRequerimiento)
        {
            return new ALCSA.Datos.Requerimientos.Observacion().Listar(idRequerimiento);
        }
    }
}
