using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Requerimientos
{
    public class HistoricoRequerimiento : Entidades.Requerimientos.HistoricoRequerimiento
    {
        public HistoricoRequerimiento() { }

        public HistoricoRequerimiento(int id)
        {
            if (id < 1) return;
            ALCSA.Entidades.Requerimientos.HistoricoRequerimiento objTemporal = new ALCSA.Datos.Requerimientos.HistoricoRequerimiento().Buscar(id);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Requerimientos.HistoricoRequerimiento, HistoricoRequerimiento>(objTemporal, this);
        }

        public void Guardar()
        {
            if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
            new ALCSA.Datos.Requerimientos.HistoricoRequerimiento().Insertar(this);
        }

        public void Actualizar()
        {
            new ALCSA.Datos.Requerimientos.HistoricoRequerimiento().Actualizar(this);
        }

        public void Eliminar()
        {
            new ALCSA.Datos.Requerimientos.HistoricoRequerimiento().Eliminar(this.ID);
        }

        public IList<ALCSA.Entidades.Requerimientos.HistoricoRequerimiento> Listar()
        {
            return new ALCSA.Datos.Requerimientos.HistoricoRequerimiento().Listar();
        }
    }
}
