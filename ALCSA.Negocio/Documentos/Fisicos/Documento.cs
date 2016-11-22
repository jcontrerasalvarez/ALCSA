using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Documentos.Fisicos
{
    public class Documento : Entidades.Documentos.Fisicos.Documento
    {
        public Documento() { }

        public Documento(int id)
        {
            if (id < 1) return;
            ALCSA.Entidades.Documentos.Fisicos.Documento objTemporal = new ALCSA.Datos.Documentos.Fisicos.Documento().Buscar(id);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Documentos.Fisicos.Documento, Documento>(objTemporal, this);
        }

        public void Insertar()
        {
            LimpiarNombreArchivo();
            new ALCSA.Datos.Documentos.Fisicos.Documento().Insertar(this);
        }

        public void Insertar(List<ALCSA.Entidades.Documentos.Fisicos.Identificador> identificadores)
        {
            LimpiarNombreArchivo();

            new Datos.Documentos.Fisicos.Documento().Insertar(this);

            if (identificadores == null) return;

            Identificador objIdentificador = null;
            foreach (Entidades.Documentos.Fisicos.Identificador objEntidad in identificadores)
            {
                objIdentificador = new Identificador();
                FWK.Reflexion.Mapeador.MapearDatos<Entidades.Documentos.Fisicos.Identificador, Identificador>(objEntidad, objIdentificador);
                objIdentificador.IdDocumento = this.ID;
                objIdentificador.Insertar();
            }
        }

        private void LimpiarNombreArchivo()
        {
            if (!string.IsNullOrWhiteSpace(Nombre) && Nombre.Contains("\\"))
                Nombre = Nombre.Substring(Nombre.LastIndexOf("\\") + 1);

            if (!string.IsNullOrWhiteSpace(Nombre) && Nombre.Contains("/"))
                Nombre = Nombre.Substring(Nombre.LastIndexOf("/") + 1);
        }

        public void Eliminar()
        {
            new ALCSA.Datos.Documentos.Fisicos.Documento().Eliminar(this.ID);
        }

        public IList<ALCSA.Entidades.Documentos.Fisicos.Documento> Listar()
        {
            return Listar(string.Empty, string.Empty);
        }

        public IList<ALCSA.Entidades.Documentos.Fisicos.Documento> Listar(string identificador, string codigoTipoIDentificador)
        {
            return new ALCSA.Datos.Documentos.Fisicos.Documento().Listar(identificador, codigoTipoIDentificador);
        }
    }
}
