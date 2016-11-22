using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Cobranzas
{
    public class Bitacora : Entidades.Cobranzas.Bitacora
    {
        public Bitacora() { }

        public Bitacora(int id)
        {
            if (id < 1) return;
            ALCSA.Entidades.Cobranzas.Bitacora objTemporal = new ALCSA.Datos.Cobranzas.Bitacora().Buscar(id);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Cobranzas.Bitacora, Bitacora>(objTemporal, this);
        }

        public void Insertar()
        {
            new ALCSA.Datos.Cobranzas.Bitacora().Insertar(this);
        }

        public void Eliminar()
        {
            new ALCSA.Datos.Cobranzas.Bitacora().Eliminar(this.ID);
        }

        public IList<ALCSA.Entidades.Cobranzas.Bitacora> Listar(int idCobranza)
        {
            return new ALCSA.Datos.Cobranzas.Bitacora().Listar(idCobranza);
        }
    }
}
