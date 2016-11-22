using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALCSA.Datos.Alzamientos
{
    public class AlzamientoActividad : Entidades.Alzamientos.AlzamientoActividad
    {
        public AlzamientoActividad() { }

        public AlzamientoActividad(int id)
        {
            if (id < 1) return;
            Entidades.Alzamientos.AlzamientoActividad objTemporal = new Datos.Alzamientos.AlzamientoActividad().Buscar(id);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<Entidades.Alzamientos.AlzamientoActividad, AlzamientoActividad>(objTemporal, this);
        }

        public void Guardar()
        {
            if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
            new Datos.Alzamientos.AlzamientoActividad().Insertar(this);
        }

        public void Actualizar()
        {
            new Datos.Alzamientos.AlzamientoActividad().Actualizar(this);
        }

        public void Eliminar()
        {
            new Datos.Alzamientos.AlzamientoActividad().Eliminar(this.ID);
        }

        public IList<Entidades.Alzamientos.AlzamientoActividad> Listar()
        {
            return new Datos.Alzamientos.AlzamientoActividad().Listar();
        }
    }
}
