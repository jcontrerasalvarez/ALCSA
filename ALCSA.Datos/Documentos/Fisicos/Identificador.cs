using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Datos.Documentos.Fisicos
{
    public class Identificador
    {
        public ALCSA.Entidades.Documentos.Fisicos.Identificador Buscar(int id)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.DOCUMENTOS;
            objServicio.Comando = "dbo.SPALC_ALCSA_DOCUMENTOS_IDENTIFICADORES_BUSCAR";
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdIdentificador", Valor = id, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            IList<ALCSA.Entidades.Documentos.Fisicos.Identificador> arrRespuesta = objServicio.Ejecutar<ALCSA.Entidades.Documentos.Fisicos.Identificador>();
            return arrRespuesta.Count > 0 ? arrRespuesta[0] : null;
        }

        public void Insertar(ALCSA.Entidades.Documentos.Fisicos.Identificador identificador)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.DOCUMENTOS;
            objServicio.Comando = "dbo.SPALC_ALCSA_DOCUMENTOS_IDENTIFICADORES_INSERTAR";
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdDocumento", Valor = identificador.IdDocumento, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdTipoIdentificador", Valor = identificador.IdTipoIdentificador, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_CodigoTipoIdentificador", Valor = identificador.CodigoTipoIdentificador, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_Valor", Valor = identificador.Valor, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdIdentificadorSalida", Valor = 0, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Salida });
            objServicio.EjecutarSinRetorno();

            identificador.ID = Convert.ToInt32(objServicio.Parametros[objServicio.Parametros.Count - 1].Valor);
        }

        public void Eliminar(int id)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.DOCUMENTOS;
            objServicio.Comando = "dbo.SPALC_ALCSA_DOCUMENTOS_IDENTIFICADORES_ELIMINAR";
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdIdentificador", Valor = id, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.EjecutarSinRetorno();
        }

        public IList<ALCSA.Entidades.Documentos.Fisicos.Identificador> Listar(int idDocumento)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.DOCUMENTOS;
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdDocumento", Valor = idDocumento, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Comando = "dbo.SPALC_ALCSA_DOCUMENTOS_IDENTIFICADORES_LISTAR";
            return objServicio.Ejecutar<ALCSA.Entidades.Documentos.Fisicos.Identificador>();
        }
    }
}
