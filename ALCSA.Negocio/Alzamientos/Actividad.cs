using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALCSA.Negocio.Alzamientos
{
    public class Actividad : Entidades.Alzamientos.Actividad
    {
        public Actividad() { }

        public Actividad(int id)
        {
            if (id < 1) return;
            Entidades.Alzamientos.Actividad objTemporal = new Datos.Alzamientos.Actividad().Buscar(id);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<Entidades.Alzamientos.Actividad, Actividad>(objTemporal, this);
        }

        public void Guardar()
        {
            if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
            new Datos.Alzamientos.Actividad().Insertar(this);
        }

        public void Actualizar()
        {
            new Datos.Alzamientos.Actividad().Actualizar(this);
        }

        public void Eliminar()
        {
            new Datos.Alzamientos.Actividad().Eliminar(this.ID);
        }

        public IList<Entidades.Alzamientos.Actividad> Listar()
        {
            return new Datos.Alzamientos.Actividad().Listar();
        }
    }
}
