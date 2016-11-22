using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Cobranzas
{
    public class DocumentoEstandard3 : Entidades.Cobranzas.DocumentoEstandard3
    {
        public DocumentoEstandard3() { }

        public DocumentoEstandard3(int id)
        {
            if (id < 1) return;
            ALCSA.Entidades.Cobranzas.DocumentoEstandard3 objTemporal = new ALCSA.Datos.Cobranzas.DocumentoEstandard3().Buscar(id, 0);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Cobranzas.DocumentoEstandard3, DocumentoEstandard3>(objTemporal, this);
        }

        public bool CargarPorCobranza(int idCobranza)
        {
            if (idCobranza < 1) return false;
            ALCSA.Entidades.Cobranzas.DocumentoEstandard3 objTemporal = new ALCSA.Datos.Cobranzas.DocumentoEstandard3().Buscar(0, idCobranza);
            if (objTemporal == null) return false;
            if (objTemporal.ID < 1) return false;
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Cobranzas.DocumentoEstandard3, DocumentoEstandard3>(objTemporal, this);
            return true;
        }

        public void Guardar()
        {
            if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
            new ALCSA.Datos.Cobranzas.DocumentoEstandard3().Insertar(this);
        }

        public void Actualizar()
        {
            new ALCSA.Datos.Cobranzas.DocumentoEstandard3().Actualizar(this);
        }

        public void Eliminar()
        {
            new ALCSA.Datos.Cobranzas.DocumentoEstandard3().Eliminar(this.ID);
        }

        public IList<ALCSA.Entidades.Cobranzas.DocumentoEstandard3> Listar()
        {
            return new ALCSA.Datos.Cobranzas.DocumentoEstandard3().Listar();
        }
    }
}
