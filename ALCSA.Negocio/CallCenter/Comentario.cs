using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.CallCenter
{
    public class Comentario : Entidades.CallCenter.Comentario
    {
        public Comentario() { }

        public Comentario(int id)
        {
            if (id < 1) return;
            ALCSA.Entidades.CallCenter.Comentario objTemporal = new ALCSA.Datos.CallCenter.Comentario().Buscar(id);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.CallCenter.Comentario, Comentario>(objTemporal, this);
        }

        public void Guardar()
        {
            if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
            new ALCSA.Datos.CallCenter.Comentario().Insertar(this);
        }

        public void Actualizar()
        {
            new ALCSA.Datos.CallCenter.Comentario().Actualizar(this);
        }

        public void Eliminar()
        {
            new ALCSA.Datos.CallCenter.Comentario().Eliminar(this.ID);
        }

        public IList<ALCSA.Entidades.CallCenter.Comentario> Listar(int idCobranza, int idCampana)
        {
            return new ALCSA.Datos.CallCenter.Comentario().Listar(idCobranza, idCampana);
        }
    }
}
