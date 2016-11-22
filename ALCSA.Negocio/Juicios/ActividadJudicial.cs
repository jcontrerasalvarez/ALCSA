using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Juicios
{
    public class ActividadJudicial : Entidades.Juicios.ActividadJudicial
    {
        public ActividadJudicial() { }

        public ActividadJudicial(int idActividad) : this(idActividad, 0) { }

        public ActividadJudicial(int idActividad, int idJuicio)
        {
            if (idActividad < 1 && idJuicio < 1) return;
            ALCSA.Entidades.Juicios.ActividadJudicial objTemporal = new ALCSA.Datos.Juicios.ActividadJudicial().Buscar(idActividad, idJuicio);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Juicios.ActividadJudicial, ActividadJudicial>(objTemporal, this);
        }

        public void Guardar()
        {
            if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
            new ALCSA.Datos.Juicios.ActividadJudicial().Insertar(this);
        }

        public void Actualizar()
        {
            new ALCSA.Datos.Juicios.ActividadJudicial().Actualizar(this);
        }

        public void Eliminar()
        {
            new ALCSA.Datos.Juicios.ActividadJudicial().Eliminar(this.ID);
        }

        public IList<ALCSA.Entidades.Juicios.ActividadJudicial> Listar()
        {
            return new ALCSA.Datos.Juicios.ActividadJudicial().Listar();
        }
    }
}
