using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.CallCenter
{
    public class Campana : Entidades.CallCenter.Campana
    {
        public Campana() { }

        public Campana(int id)
        {
            if (id < 1) return;
            ALCSA.Entidades.CallCenter.Campana objTemporal = new ALCSA.Datos.CallCenter.Campana().Buscar(id);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.CallCenter.Campana, Campana>(objTemporal, this);
        }

        public void Guardar()
        {
            if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
            new ALCSA.Datos.CallCenter.Campana().Insertar(this);
        }

        public void Actualizar()
        {
            new ALCSA.Datos.CallCenter.Campana().Actualizar(this);
        }

        public void Eliminar()
        {
            new ALCSA.Datos.CallCenter.Campana().Eliminar(this.ID);
        }

        public IList<ALCSA.Entidades.CallCenter.Campana> Listar()
        {
            return new ALCSA.Datos.CallCenter.Campana().Listar();
        }
    }
}
