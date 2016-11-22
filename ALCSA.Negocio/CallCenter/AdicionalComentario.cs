using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALCSA.Negocio.CallCenter
{
    public class AdicionalComentario : ALCSA.Entidades.CallCenter.AdicionalComentario
    {
        public AdicionalComentario() { }

        public AdicionalComentario(int id)
        {
            if (id < 1) return;
            ALCSA.Entidades.CallCenter.AdicionalComentario objTemporal = new ALCSA.Datos.CallCenter.AdicionalComentario().Buscar(id);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.CallCenter.AdicionalComentario, AdicionalComentario>(objTemporal, this);
        }

        public void Guardar()
        {
            if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
            new ALCSA.Datos.CallCenter.AdicionalComentario().Insertar(this);
        }

        public void Actualizar()
        {
            new ALCSA.Datos.CallCenter.AdicionalComentario().Actualizar(this);
        }

        public void Eliminar()
        {
            new ALCSA.Datos.CallCenter.AdicionalComentario().Eliminar(this.ID);
        }

        public IList<ALCSA.Entidades.CallCenter.AdicionalComentario> Listar(string codigoGrupo)
        {
            return new ALCSA.Datos.CallCenter.AdicionalComentario().Listar(codigoGrupo);
        }
    }
}
