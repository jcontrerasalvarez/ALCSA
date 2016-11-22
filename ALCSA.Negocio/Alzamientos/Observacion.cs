using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALCSA.Negocio.Alzamientos
{
    public class Observacion : Entidades.Alzamientos.Observacion
    {
        public Observacion() { }

        public Observacion(int id)
        {
            if (id < 1) return;
            Entidades.Alzamientos.Observacion objTemporal = new Datos.Alzamientos.Observacion().Buscar(id);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<Entidades.Alzamientos.Observacion, Observacion>(objTemporal, this);
        }

        public void Guardar()
        {
            if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
            new Datos.Alzamientos.Observacion().Insertar(this);
        }

        public void Actualizar()
        {
            new Datos.Alzamientos.Observacion().Actualizar(this);
        }

        public void Eliminar()
        {
            new Datos.Alzamientos.Observacion().Eliminar(this.ID);
        }

        public IList<Entidades.Alzamientos.Observacion> Listar()
        {
            return new Datos.Alzamientos.Observacion().Listar();
        }
    }
}
