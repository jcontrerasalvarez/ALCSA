using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Cobranzas
{
    public class CuotaColegio : Entidades.Cobranzas.CuotaColegio
    {
        public CuotaColegio() { }

        public CuotaColegio(int id)
        {
            if (id < 1) return;
            ALCSA.Entidades.Cobranzas.CuotaColegio objTemporal = new ALCSA.Datos.Cobranzas.CuotaColegio().Buscar(id, 0);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Cobranzas.CuotaColegio, CuotaColegio>(objTemporal, this);
        }

        public bool CargarPorCobranza(int idCobranza)
        {
            if (idCobranza < 1) return false;
            ALCSA.Entidades.Cobranzas.CuotaColegio objTemporal = new ALCSA.Datos.Cobranzas.CuotaColegio().Buscar(0, idCobranza);
            if (objTemporal == null) return false;
            if (objTemporal.ID < 1) return false;
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Cobranzas.CuotaColegio, CuotaColegio>(objTemporal, this);
            return true;
        }

        public void Guardar()
        {
            if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
            new ALCSA.Datos.Cobranzas.CuotaColegio().Insertar(this);
        }

        public void Actualizar()
        {
            new ALCSA.Datos.Cobranzas.CuotaColegio().Actualizar(this);
        }

        public void Eliminar()
        {
            new ALCSA.Datos.Cobranzas.CuotaColegio().Eliminar(this.ID);
        }

        public IList<ALCSA.Entidades.Cobranzas.CuotaColegio> Listar()
        {
            return new ALCSA.Datos.Cobranzas.CuotaColegio().Listar();
        }
    }
}
