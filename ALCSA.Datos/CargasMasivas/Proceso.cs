using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Datos.CargasMasivas
{
    public class Proceso
    {
        public void Insertar(Entidades.CargasMasivas.Registro registro, string codigoProceso, string usuarioCreador)
        {
            FWK.BD.Servicio objServicio = new FWK.BD.Servicio() { Conexion = Conexion.ALCSA, Comando = "dbo.SPALC_CargasMasivasCobranzaInsertar" };

            objServicio.Parametros = new List<FWK.BD.Parametro>();
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_RutCliente", Valor = registro.RutCliente, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_Rut", Valor = registro.Rut, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_DigitoVerificador", Valor = registro.DigitoVerificador, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_Nombre", Valor = registro.Nombre, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_ApellidoPaterno", Valor = registro.ApellidoPaterno, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_ApellidoMaterno", Valor = registro.ApellidoMaterno, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });

            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_Calle", Valor = registro.Calle, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_Numero", Valor = registro.Numero, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_NumeroDpto", Valor = registro.NumeroDpto, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_Villa", Valor = registro.Villa, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_Block", Valor = registro.Block, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_Comuna", Valor = registro.Comuna, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });

            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_CodigoProceso", Valor = codigoProceso, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_UsuarioCreador", Valor = usuarioCreador, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });

            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_Monto", Valor = registro.Monto, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_IdTipoCobranza", Valor = registro.IdTipoCobranza, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_IdProcedimiento", Valor = registro.IdProcedimiento, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_IdMateria", Valor = registro.IdMateria, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_IdProducto", Valor = registro.IdProducto, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_FechaVencimiento", Valor = registro.FechaVencimiento, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });

            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@INT_IdRemesa", Valor = registro.IdRemesa, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });

            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_EstadoSalida", Valor = string.Empty, Tamano = 100, Direccion = FWK.BD.Enumeradores.Direcciones.Salida });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_MensajeSalida", Valor = string.Empty, Tamano = 500, Direccion = FWK.BD.Enumeradores.Direcciones.Salida });

            objServicio.EjecutarSinRetorno();

            registro.Estado = Convert.ToString(objServicio.Parametros[objServicio.Parametros.Count - 2].Valor);
            registro.Mensaje = Convert.ToString(objServicio.Parametros[objServicio.Parametros.Count - 1].Valor);

        }
    }
}
