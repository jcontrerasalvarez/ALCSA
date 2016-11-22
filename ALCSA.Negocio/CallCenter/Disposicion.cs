using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.CallCenter
{
    public class Disposicion : ALCSA.Entidades.CallCenter.Disposicion
    {
        public Disposicion() { }

        public Disposicion(int id)
        {
            if (id < 1) return;
            ALCSA.Entidades.CallCenter.Disposicion objTemporal = new ALCSA.Datos.CallCenter.Disposicion().Buscar(id, string.Empty);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.CallCenter.Disposicion, Disposicion>(objTemporal, this);
        }

        public Disposicion(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo)) return;
            ALCSA.Entidades.CallCenter.Disposicion objTemporal = new ALCSA.Datos.CallCenter.Disposicion().Buscar(0, codigo);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.CallCenter.Disposicion, Disposicion>(objTemporal, this);
        }

        public void Guardar()
        {
            if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
            new ALCSA.Datos.CallCenter.Disposicion().Insertar(this);
        }

        public void Actualizar()
        {
            new ALCSA.Datos.CallCenter.Disposicion().Actualizar(this);
        }

        public void Eliminar()
        {
            new ALCSA.Datos.CallCenter.Disposicion().Eliminar(this.ID);
        }

        public IList<ALCSA.Entidades.CallCenter.Disposicion> Listar(int idTipoDisposicion)
        {
            return new ALCSA.Datos.CallCenter.Disposicion().Listar(idTipoDisposicion);
        }
    }
}
