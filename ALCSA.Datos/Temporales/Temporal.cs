using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Datos.Temporales
{
    public class Temporal
    {
        public Entidades.Temporales.Temporal Buscar(int id, string codigo)
        {
            FWK.BD.Servicio objServicio = new FWK.BD.Servicio() { Conexion = Conexion.ALCSA, Comando = "dbo.SPALC_DatosTemporalesBuscar" };

            objServicio.Parametros = new List<FWK.BD.Parametro>();
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@INT_IdTemporal", Valor = id, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_Codigo", Valor = codigo, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });

            return objServicio.EjecutarPrimerRegistro<Entidades.Temporales.Temporal>();
        }

        public void Insertar(Entidades.Temporales.Temporal temporal)
        {
            FWK.BD.Servicio objServicio = new FWK.BD.Servicio() { Conexion = Conexion.ALCSA, Comando = "dbo.SPALC_DatosTemporalesInsertar" };
            
            objServicio.Parametros = new List<FWK.BD.Parametro>();

            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_Codigo", Valor = temporal.Codigo, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_CodigoProceso", Valor = temporal.CodigoProceso, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_UsuarioDueno", Valor = temporal.UsuarioDueno, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_Estado", Valor = temporal.Estado, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_TextoTemporal", Valor = temporal.TextoTemporal, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });

            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@INT_IdTemporalSalida", Valor = 0, Direccion = FWK.BD.Enumeradores.Direcciones.Salida });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_CodigoSalida", Valor = string.Empty, Direccion = FWK.BD.Enumeradores.Direcciones.Salida });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_FechaIngresoSalida", Valor = new DateTime(1900, 1, 1), Direccion = FWK.BD.Enumeradores.Direcciones.Salida });

            objServicio.EjecutarSinRetorno();

            temporal.ID = Convert.ToInt32(objServicio.Parametros[objServicio.Parametros.Count - 3].Valor);
            temporal.Codigo = Convert.ToString(objServicio.Parametros[objServicio.Parametros.Count - 2].Valor);
            temporal.FechaIngreso = Convert.ToDateTime(objServicio.Parametros[objServicio.Parametros.Count - 1].Valor);
        }

        public void Actualizar(Entidades.Temporales.Temporal temporal)
        {
            FWK.BD.Servicio objServicio = new FWK.BD.Servicio() { Conexion = Conexion.ALCSA, Comando = "dbo.SPALC_DatosTemporalesActualizar" };

            objServicio.Parametros = new List<FWK.BD.Parametro>();

            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@INT_IdTemporal", Valor = temporal.ID, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_Codigo", Valor = temporal.Codigo, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_Estado", Valor = temporal.Estado, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_TextoTemporal", Valor = temporal.TextoTemporal, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });

            objServicio.EjecutarSinRetorno();
        }

        public void Eliminar(Entidades.Temporales.Temporal temporal)
        {
            FWK.BD.Servicio objServicio = new FWK.BD.Servicio() { Conexion = Conexion.ALCSA, Comando = "dbo.SPALC_DatosTemporalesEliminar" };

            objServicio.Parametros = new List<FWK.BD.Parametro>();
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_Codigo", Valor = temporal.Codigo, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_CodigoProceso", Valor = temporal.CodigoProceso, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_UsuarioDueno", Valor = temporal.UsuarioDueno, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });

            objServicio.EjecutarSinRetorno();
        }

        public IList<Entidades.Temporales.Temporal> Listar(string codigoProceso, string usuario)
        {
            FWK.BD.Servicio objServicio = new FWK.BD.Servicio() { Conexion = Conexion.ALCSA, Comando = "dbo.SPALC_DatosTemporalesListar" };

            objServicio.Parametros = new List<FWK.BD.Parametro>();
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_CodigoProceso", Valor = codigoProceso, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_UsuarioDueno", Valor = usuario, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });

            return objServicio.Ejecutar<Entidades.Temporales.Temporal>();
        }
    }
}
