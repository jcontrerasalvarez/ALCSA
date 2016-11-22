using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Datos.Documentos.Fisicos
{
    public class Documento
    {
        public ALCSA.Entidades.Documentos.Fisicos.Documento Buscar(int id)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.DOCUMENTOS;
            objServicio.Comando = "dbo.SPALC_ALCSA_DOCUMENTOS_BUSCAR";
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdDocumento", Valor = id, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            IList<ALCSA.Entidades.Documentos.Fisicos.Documento> arrRespuesta = objServicio.Ejecutar<ALCSA.Entidades.Documentos.Fisicos.Documento>();
            return arrRespuesta.Count > 0 ? arrRespuesta[0] : null;
        }

        public void Insertar(ALCSA.Entidades.Documentos.Fisicos.Documento documento)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.DOCUMENTOS;
            objServicio.Comando = "dbo.SPALC_ALCSA_DOCUMENTOS_INSERTAR";
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@BIN_Archivo", Valor = documento.Archivo, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_CodigoTipoDocumento", Valor = documento.CodigoTipoDocumento, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_Descripcion", Valor = documento.Descripcion, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdTipoDocumento", Valor = documento.IdTipoDocumento, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_Nombre", Valor = documento.Nombre, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@NUM_Peso", Valor = documento.Peso, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdDocumentoSalida", Valor = 0, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Salida });
            objServicio.EjecutarSinRetorno();

            documento.ID = Convert.ToInt32(objServicio.Parametros[objServicio.Parametros.Count - 1].Valor);
        }

        public void Eliminar(int id)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.DOCUMENTOS;
            objServicio.Comando = "dbo.SPALC_ALCSA_DOCUMENTOS_ELIMINAR";
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdDocumento", Valor = id, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.EjecutarSinRetorno();
        }

        public IList<ALCSA.Entidades.Documentos.Fisicos.Documento> Listar(string identificador, string codigoTipoIDentificador)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.DOCUMENTOS;
            objServicio.Comando = "dbo.SPALC_ALCSA_DOCUMENTOS_LISTAR";

            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_Identificador", Valor = identificador, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_CodigoTipoIdentificador", Valor = codigoTipoIDentificador, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });

            return objServicio.Ejecutar<ALCSA.Entidades.Documentos.Fisicos.Documento>();
        }
    }
}
