using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Datos.CallCenter
{
    public class Disposicion
    {
        public ALCSA.Entidades.CallCenter.Disposicion Buscar(int id, string codigo)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Comando = "SPALC_DISPOSICIONESVICIDIAL_BUSCAR";
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdDisposicion", Valor = id, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_Codigo", Valor = codigo, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            IList<ALCSA.Entidades.CallCenter.Disposicion> arrRespuesta = objServicio.Ejecutar<ALCSA.Entidades.CallCenter.Disposicion>();
            return arrRespuesta.Count > 0 ? arrRespuesta[0] : null;
        }

        public void Insertar(ALCSA.Entidades.CallCenter.Disposicion disposicion)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Comando = "";
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_Codigo", Valor = disposicion.Codigo, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@DAT_FechaEliminacion", Valor = disposicion.FechaEliminacion, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@DAT_Fechaingreso", Valor = disposicion.FechaIngreso, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_Nombre", Valor = disposicion.Nombre, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdTipoDisposicion", Valor = disposicion.IdTipoDisposicion, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdDisposicionSalida", Valor = 0, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Salida });
            objServicio.EjecutarSinRetorno();

            disposicion.ID = Convert.ToInt32(objServicio.Parametros[objServicio.Parametros.Count - 1].Valor);
        }

        public void Actualizar(ALCSA.Entidades.CallCenter.Disposicion disposicion)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Comando = "";
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdDisposicion", Valor = disposicion.ID, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_Codigo", Valor = disposicion.Codigo, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@DAT_FechaEliminacion", Valor = disposicion.FechaEliminacion, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@DAT_FechaIngreso", Valor = disposicion.FechaIngreso, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdTipoDisposicion", Valor = disposicion.IdTipoDisposicion, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_Nombre", Valor = disposicion.Nombre, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.EjecutarSinRetorno();
        }

        public void Eliminar(int id)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Comando = "";
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_Iddisposicion", Valor = id, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.EjecutarSinRetorno();
        }

        public IList<ALCSA.Entidades.CallCenter.Disposicion> Listar(int idTipoDisposicion)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdTipoDisposicion", Valor = idTipoDisposicion, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Comando = "dbo.SPALC_DISPOSICIONESVICIDIAL_LISTAR";
            return objServicio.Ejecutar<ALCSA.Entidades.CallCenter.Disposicion>();
        }
    }
}
