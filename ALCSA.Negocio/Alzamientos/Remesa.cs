using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALCSA.Negocio.Alzamientos
{
    public class Remesa : Entidades.Alzamientos.Remesa
    {
        public Remesa() { }

        public Remesa(int id)
        {
            if (id < 1) return;
            Entidades.Alzamientos.Remesa objTemporal = new Datos.Alzamientos.Remesa().Buscar(id);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<Entidades.Alzamientos.Remesa, Remesa>(objTemporal, this);
        }

        public void Guardar()
        {
            if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
            new Datos.Alzamientos.Remesa().Insertar(this);
        }

        public void Actualizar()
        {
            new Datos.Alzamientos.Remesa().Actualizar(this);
        }

        public void Eliminar()
        {
            new Datos.Alzamientos.Remesa().Eliminar(this.ID);
        }

        public IList<Entidades.Alzamientos.Remesa> Listar()
        {
            return new Datos.Alzamientos.Remesa().Listar();
        }
    }
}
