using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Requerimientos
{
    public class Requerimiento : Entidades.Requerimientos.Requerimiento
    {
        public static string TIPO_DOCUMENTO = "DATOS_REQUERIMIENTO";

        public static string ESTADO_PENDIENTE = "PENDIENTE";
        public static string ESTADO_RECHAZADO = "RECHAZADO";
        public static string ESTADO_EN_DESARROLLO = "EN_DESARROLLO";
        public static string ESTADO_APROBADO = "APROBADO";
        public static string ESTADO_TERMINADO = "TERMINADO";
        public static string ESTADO_ELIMINADA = "ELIMINADA";

        public Requerimiento() { }

        public Requerimiento(int id)
        {
            if (id < 1) return;
            ALCSA.Entidades.Requerimientos.Requerimiento objTemporal = new ALCSA.Datos.Requerimientos.Requerimiento().Buscar(id);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Requerimientos.Requerimiento, Requerimiento>(objTemporal, this);
        }

        public void Guardar()
        {
            if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
            new ALCSA.Datos.Requerimientos.Requerimiento().Insertar(this);
        }

        public void Actualizar()
        {
            new ALCSA.Datos.Requerimientos.Requerimiento().Actualizar(this);
        }

        public void Eliminar()
        {
            new ALCSA.Datos.Requerimientos.Requerimiento().Eliminar(this.ID);
        }

        public IList<ALCSA.Entidades.Requerimientos.Requerimiento> Listar(string usuario)
        {
            return new ALCSA.Datos.Requerimientos.Requerimiento().Listar(usuario);
        }
    }
}
