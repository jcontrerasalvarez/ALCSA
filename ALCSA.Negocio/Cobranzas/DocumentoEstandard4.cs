using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Cobranzas
{
    public class DocumentoEstandard4 : Entidades.Cobranzas.DocumentoEstandard4
    {
        public DocumentoEstandard4() { }

        public DocumentoEstandard4(int id)
        {
            if (id < 1) return;
            ALCSA.Entidades.Cobranzas.DocumentoEstandard4 objTemporal = new ALCSA.Datos.Cobranzas.DocumentoEstandard4().Buscar(id, 0);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Cobranzas.DocumentoEstandard4, DocumentoEstandard4>(objTemporal, this);
        }

        public bool CargarPorCobranza(int idCobranza)
        {
            if (idCobranza < 1) return false;
            ALCSA.Entidades.Cobranzas.DocumentoEstandard4 objTemporal = new ALCSA.Datos.Cobranzas.DocumentoEstandard4().Buscar(0, idCobranza);
            if (objTemporal == null) return false;
            if (objTemporal.ID < 1) return false;
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Cobranzas.DocumentoEstandard4, DocumentoEstandard4>(objTemporal, this);
            return true;
        }

        public void Guardar()
        {
            if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
            new ALCSA.Datos.Cobranzas.DocumentoEstandard4().Insertar(this);
        }

        public void Actualizar()
        {
            new ALCSA.Datos.Cobranzas.DocumentoEstandard4().Actualizar(this);
        }

        public void Eliminar()
        {
            new ALCSA.Datos.Cobranzas.DocumentoEstandard4().Eliminar(this.ID);
        }

        public IList<ALCSA.Entidades.Cobranzas.DocumentoEstandard4> Listar()
        {
            return new ALCSA.Datos.Cobranzas.DocumentoEstandard4().Listar();
        }
    }
}
