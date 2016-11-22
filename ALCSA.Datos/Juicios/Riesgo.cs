using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Datos.Juicios
{
    public class Riesgo
    {
        public Entidades.Juicios.Riesgo Buscar(int id)
        {
            FWK.BD.Servicio objServicio = new FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Comando = "dbo.SPALC_RIESGO_BUSCAR";
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@INT_IdRiesgo", Valor = id, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            IList<Entidades.Juicios.Riesgo> arrRespuesta = objServicio.Ejecutar<Entidades.Juicios.Riesgo>();
            return arrRespuesta.Count > 0 ? arrRespuesta[0] : null;
        }

        public void Insertar(Entidades.Juicios.Riesgo riesgo)
        {
            FWK.BD.Servicio objServicio = new FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Comando = "dbo.SPALC_RIESGO_INSERTAR";
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_Nombre", Valor = riesgo.Nombre, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@INT_IdRiesgoSalida", Valor = 0, Direccion = FWK.BD.Enumeradores.Direcciones.Salida });
            objServicio.EjecutarSinRetorno();

            riesgo.ID = Convert.ToInt32(objServicio.Parametros[objServicio.Parametros.Count - 1].Valor);
        }

        public void Actualizar(Entidades.Juicios.Riesgo riesgo)
        {
            FWK.BD.Servicio objServicio = new FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Comando = "dbo.SPALC_RIESGO_ACTUALIZAR";
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@INT_IdRiesgo", Valor = riesgo.ID, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_Nombre", Valor = riesgo.Nombre, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.EjecutarSinRetorno();
        }

        public void Eliminar(int id)
        {
            FWK.BD.Servicio objServicio = new FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Comando = "dbo.SPALC_RIESGO_ELIMINAR";
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@INT_IdRiesgo", Valor = id, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.EjecutarSinRetorno();
        }

        public IList<Entidades.Juicios.Riesgo> Listar()
        {
            FWK.BD.Servicio objServicio = new FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Comando = "dbo.SPALC_RIESGO_LISTAR";
            return objServicio.Ejecutar<Entidades.Juicios.Riesgo>();
        }
    }
}
