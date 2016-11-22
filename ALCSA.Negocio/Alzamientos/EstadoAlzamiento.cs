using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALCSA.Negocio.Alzamientos
{
    public class EstadoAlzamiento : Entidades.Alzamientos.EstadoAlzamiento
    {
        public EstadoAlzamiento() { }

        public EstadoAlzamiento(int id)
        {
            if (id < 1) return;
            Entidades.Alzamientos.EstadoAlzamiento objTemporal = new Datos.Alzamientos.EstadoAlzamiento().Buscar(id);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<Entidades.Alzamientos.EstadoAlzamiento, EstadoAlzamiento>(objTemporal, this);
        }

        public void Guardar()
        {
            if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
            new Datos.Alzamientos.EstadoAlzamiento().Insertar(this);
        }

        public void Actualizar()
        {
            new Datos.Alzamientos.EstadoAlzamiento().Actualizar(this);
        }

        public void Eliminar()
        {
            new Datos.Alzamientos.EstadoAlzamiento().Eliminar(this.ID);
        }

        public IList<Entidades.Alzamientos.EstadoAlzamiento> Listar()
        {
            return new Datos.Alzamientos.EstadoAlzamiento().Listar();
        }
    }
}
