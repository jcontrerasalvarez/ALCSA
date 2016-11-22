using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Juicios
{
    public class Riesgo : Entidades.Juicios.Riesgo
    {
        public Riesgo() { }

        public Riesgo(int id)
        {
            if (id < 1) return;
            Entidades.Juicios.Riesgo objRiesgoTemporal = new Datos.Juicios.Riesgo().Buscar(id);
            FWK.Reflexion.Mapeador.MapearDatos<Entidades.Juicios.Riesgo, Riesgo>(objRiesgoTemporal, this);
        }

        public void Guardar()
        {
            if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
            new Datos.Juicios.Riesgo().Insertar(this);
        }

        public void Actualizar()
        {
            new Datos.Juicios.Riesgo().Actualizar(this);
        }

        public void Eliminar()
        {
            new Datos.Juicios.Riesgo().Eliminar(this.ID);
        }

        public IList<Entidades.Juicios.Riesgo> Listar()
        {
            return new Datos.Juicios.Riesgo().Listar();
        }
    }
}
