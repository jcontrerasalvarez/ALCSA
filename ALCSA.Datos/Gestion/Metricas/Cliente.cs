using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Datos.Gestion.Metricas
{
    public class Cliente
    {
        public IList<Entidades.Parametros.Salidas.Metricas.EstadoCliente> Listar(string rutCliente)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_RutCliente", Valor = rutCliente, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Comando = "dbo.SPALC_MetricasContadorCobranzasClienteListar";
            return objServicio.Ejecutar<Entidades.Parametros.Salidas.Metricas.EstadoCliente>();   
        }

        public IList<Entidades.Parametros.Salidas.Metricas.EstadoClienteCobranza> ListarCobranzas(string rutCliente)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_RutCliente", Valor = rutCliente, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Comando = "dbo.SPALC_MetricasEstadoCobranzasClientesListar";
            return objServicio.Ejecutar<Entidades.Parametros.Salidas.Metricas.EstadoClienteCobranza>();
        }
    }
}
