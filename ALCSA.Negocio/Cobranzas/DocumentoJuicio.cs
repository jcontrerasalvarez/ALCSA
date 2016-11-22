using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Cobranzas
{
    public class DocumentoJuicio : Entidades.Cobranzas.DocumentoJuicio
    {
        public DocumentoJuicio() { }

        public DocumentoJuicio(int id)
        {
            if (id < 1) return;
            ALCSA.Entidades.Cobranzas.DocumentoJuicio objTemporal = new ALCSA.Datos.Cobranzas.DocumentoJuicio().Buscar(id, 0);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Cobranzas.DocumentoJuicio, DocumentoJuicio>(objTemporal, this);
        }

        public bool CargarPorCobranza(int idCobranza)
        {
            if (idCobranza < 1) return false;
            ALCSA.Entidades.Cobranzas.DocumentoJuicio objTemporal = new ALCSA.Datos.Cobranzas.DocumentoJuicio().Buscar(0, idCobranza);
            if (objTemporal == null) return false;
            if (objTemporal.ID < 1) return false;
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Cobranzas.DocumentoJuicio, DocumentoJuicio>(objTemporal, this);
            return true;
        }

        public void Guardar()
        {
            if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
            new ALCSA.Datos.Cobranzas.DocumentoJuicio().Insertar(this);
        }

        public void Actualizar()
        {
            new ALCSA.Datos.Cobranzas.DocumentoJuicio().Actualizar(this);
        }

        public void Eliminar()
        {
            new ALCSA.Datos.Cobranzas.DocumentoJuicio().Eliminar(this.ID);
        }

        public IList<ALCSA.Entidades.Cobranzas.DocumentoJuicio> Listar(int idCobranza)
        {
            return new ALCSA.Datos.Cobranzas.DocumentoJuicio().Listar(idCobranza);
        }
    }
}
