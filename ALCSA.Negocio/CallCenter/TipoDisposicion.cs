using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALCSA.Negocio.CallCenter
{
    public class TipoDisposicion : ALCSA.Entidades.CallCenter.TipoDisposicion
    {
        public TipoDisposicion() { }

        public TipoDisposicion(int id)
        {
            if (id < 1) return;
            ALCSA.Entidades.CallCenter.TipoDisposicion objTemporal = new ALCSA.Datos.CallCenter.TipoDisposicion().Buscar(id, string.Empty);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.CallCenter.TipoDisposicion, TipoDisposicion>(objTemporal, this);
        }

        public TipoDisposicion(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo)) return;
            ALCSA.Entidades.CallCenter.TipoDisposicion objTemporal = new ALCSA.Datos.CallCenter.TipoDisposicion().Buscar(0, codigo);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.CallCenter.TipoDisposicion, TipoDisposicion>(objTemporal, this);
        }

        public void Guardar()
        {
            if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
            new ALCSA.Datos.CallCenter.TipoDisposicion().Insertar(this);
        }

        public void Actualizar()
        {
            new ALCSA.Datos.CallCenter.TipoDisposicion().Actualizar(this);
        }

        public void Eliminar()
        {
            new ALCSA.Datos.CallCenter.TipoDisposicion().Eliminar(this.ID);
        }

        public IList<ALCSA.Entidades.CallCenter.TipoDisposicion> Listar()
        {
            return new ALCSA.Datos.CallCenter.TipoDisposicion().Listar();
        }
    }
}
