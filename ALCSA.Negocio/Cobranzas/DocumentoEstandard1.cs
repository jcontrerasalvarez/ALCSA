using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Cobranzas
{
    public class DocumentoEstandard1 : Entidades.Cobranzas.DocumentoEstandard1
    {
        public DocumentoEstandard1() { }

        public DocumentoEstandard1(int id)
        {
            if (id < 1) return;
            ALCSA.Entidades.Cobranzas.DocumentoEstandard1 objTemporal = new ALCSA.Datos.Cobranzas.DocumentoEstandard1().Buscar(id, 0);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Cobranzas.DocumentoEstandard1, DocumentoEstandard1>(objTemporal, this);
        }

        public bool CargarPorCobranza(int idCobranza)
        {
            if (idCobranza < 1) return false;
            ALCSA.Entidades.Cobranzas.DocumentoEstandard1 objTemporal = new ALCSA.Datos.Cobranzas.DocumentoEstandard1().Buscar(0, idCobranza);
            if (objTemporal == null) return false;
            if (objTemporal.ID < 1) return false;
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Cobranzas.DocumentoEstandard1, DocumentoEstandard1>(objTemporal, this);
            return true;
        }

        public void Guardar()
        {
            if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
            new ALCSA.Datos.Cobranzas.DocumentoEstandard1().Insertar(this);
        }

        public void Actualizar()
        {
            new ALCSA.Datos.Cobranzas.DocumentoEstandard1().Actualizar(this);
        }

        public void Eliminar()
        {
            new ALCSA.Datos.Cobranzas.DocumentoEstandard1().Eliminar(this.ID);
        }

        public IList<ALCSA.Entidades.Cobranzas.DocumentoEstandard1> Listar()
        {
            return new ALCSA.Datos.Cobranzas.DocumentoEstandard1().Listar();
        }
    }
}
