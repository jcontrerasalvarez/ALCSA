using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Juicios
{
    public class Juicio : Entidades.Juicios.Juicio
    {
        public Juicio() { }

        public Juicio(int id)
        {
            if (id < 1) return;
            ALCSA.Entidades.Juicios.Juicio objTemporal = new ALCSA.Datos.Juicios.Juicio().Buscar(id, 0);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Juicios.Juicio, Juicio>(objTemporal, this);
        }

        public void CargarPorCobranza(int idCobranza)
        {
            ALCSA.Entidades.Juicios.Juicio objTemporal = new ALCSA.Datos.Juicios.Juicio().Buscar(0, idCobranza);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Juicios.Juicio, Juicio>(objTemporal, this);
        }

        public void Guardar()
        {
            if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
            new ALCSA.Datos.Juicios.Juicio().Insertar(this);
        }

        public void Actualizar()
        {
            new ALCSA.Datos.Juicios.Juicio().Actualizar(this);
        }

        public void Actualizar(ALCSA.Entidades.Parametros.Entradas.Juicios.JuicioEstado estado)
        {
            new ALCSA.Datos.Juicios.Juicio().Actualizar(estado);
        }

        public void Eliminar()
        {
            new ALCSA.Datos.Juicios.Juicio().Eliminar(this.ID);
        }

        public IList<ALCSA.Entidades.Juicios.Juicio> Listar()
        {
            return new ALCSA.Datos.Juicios.Juicio().Listar();
        }
    }
}
