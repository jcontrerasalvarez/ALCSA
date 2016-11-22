using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALCSA.Negocio.Alzamientos
{
    public class Alzamiento : Entidades.Alzamientos.Alzamiento
    {
        public Alzamiento() { }

        public Alzamiento(int id)
        {
            if (id < 1) return;
            Entidades.Alzamientos.Alzamiento objTemporal = new Datos.Alzamientos.Alzamiento().Buscar(id);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<Entidades.Alzamientos.Alzamiento, Alzamiento>(objTemporal, this);
        }

        public void Guardar()
        {
            if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
            new Datos.Alzamientos.Alzamiento().Insertar(this);
        }

        public void Actualizar()
        {
            new Datos.Alzamientos.Alzamiento().Actualizar(this);
        }

        public void Eliminar()
        {
            new Datos.Alzamientos.Alzamiento().Eliminar(this.ID);
        }

        public IList<Entidades.Alzamientos.Alzamiento> Listar(int idRemesa)
        {
            return new Datos.Alzamientos.Alzamiento().Listar(idRemesa);
        }
    }
}
