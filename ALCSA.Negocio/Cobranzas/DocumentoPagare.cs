using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Cobranzas
{
    public class DocumentoPagare : Entidades.Cobranzas.DocumentoPagare
    {
        public DocumentoPagare() { }

        public DocumentoPagare(int id)
        {
            if (id < 1) return;
            ALCSA.Entidades.Cobranzas.DocumentoPagare objTemporal = new ALCSA.Datos.Cobranzas.DocumentoPagare().Buscar(id, 0);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Cobranzas.DocumentoPagare, DocumentoPagare>(objTemporal, this);
        }

        public bool CargarPorCobranza(int idCobranza)
        {
            if (idCobranza < 1) return false;
            ALCSA.Entidades.Cobranzas.DocumentoPagare objTemporal = new ALCSA.Datos.Cobranzas.DocumentoPagare().Buscar(0, idCobranza);
            if (objTemporal == null) return false;
            if (objTemporal.ID < 1) return false;
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Cobranzas.DocumentoPagare, DocumentoPagare>(objTemporal, this);
            return true;
        }

        public void Guardar()
        {
            if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
            new ALCSA.Datos.Cobranzas.DocumentoPagare().Insertar(this);
        }

        public void Actualizar()
        {
            new ALCSA.Datos.Cobranzas.DocumentoPagare().Actualizar(this);
        }

        public void Eliminar()
        {
            new ALCSA.Datos.Cobranzas.DocumentoPagare().Eliminar(this.ID);
        }

        public IList<ALCSA.Entidades.Cobranzas.DocumentoPagare> Listar()
        {
            return new ALCSA.Datos.Cobranzas.DocumentoPagare().Listar();
        }
    }
}
