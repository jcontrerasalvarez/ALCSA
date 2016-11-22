using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Datos.CallCenter
{
    public class Campana
    {
        public ALCSA.Entidades.CallCenter.Campana Buscar(int id)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Comando = "dbo.SPALC_CAMPANAS_BUSCAR";
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdCampana", Valor = id, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            IList<ALCSA.Entidades.CallCenter.Campana> arrRespuesta = objServicio.Ejecutar<ALCSA.Entidades.CallCenter.Campana>();
            return arrRespuesta.Count > 0 ? arrRespuesta[0] : null;
        }

        public void Insertar(ALCSA.Entidades.CallCenter.Campana campana)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Comando = "dbo.SPALC_CAMPANAS_INSERTAR";
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@BIT_EsTemporal", Valor = campana.EsTemporal, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_UsuarioIngreso", Valor = campana.UsuarioIngreso, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdCampanaSalida", Valor = 0, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Salida });
            objServicio.EjecutarSinRetorno();

            campana.ID = Convert.ToInt32(objServicio.Parametros[objServicio.Parametros.Count - 1].Valor);
        }

        public void Actualizar(ALCSA.Entidades.CallCenter.Campana campana)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Comando = "dbo.SPALC_CAMPANAS_ACTUALIZAR";
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdCampana", Valor = campana.ID, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@BIT_EsTemporal", Valor = campana.EsTemporal, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_UsuarioIngreso", Valor = campana.UsuarioIngreso, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.EjecutarSinRetorno();
        }

        public void Eliminar(int id)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Comando = "dbo.SPALC_CAMPANAS_ELIMINAR";
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdCampana", Valor = id, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.EjecutarSinRetorno();
        }

        public IList<ALCSA.Entidades.CallCenter.Campana> Listar()
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Comando = "dbo.SPALC_CAMPANAS_LISTAR";
            return objServicio.Ejecutar<ALCSA.Entidades.CallCenter.Campana>();
        }
    }
}
