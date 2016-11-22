using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Documentos.Fisicos
{
    public class Identificador : Entidades.Documentos.Fisicos.Identificador
    {
        public Identificador() { }

        public Identificador(int id) 
        {
             if(id < 1) return;
             ALCSA.Entidades.Documentos.Fisicos.Identificador objTemporal = new ALCSA.Datos.Documentos.Fisicos.Identificador().Buscar(id);
             ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Documentos.Fisicos.Identificador, Identificador>(objTemporal, this);
        }

        public void Insertar()
        {
             new ALCSA.Datos.Documentos.Fisicos.Identificador().Insertar(this);
        }

        public void Eliminar()
        {
             new ALCSA.Datos.Documentos.Fisicos.Identificador().Eliminar(this.ID);
        }

        public IList<ALCSA.Entidades.Documentos.Fisicos.Identificador> Listar(int idDocumento)
        {
             return new ALCSA.Datos.Documentos.Fisicos.Identificador().Listar(idDocumento);
        }
    }
}
