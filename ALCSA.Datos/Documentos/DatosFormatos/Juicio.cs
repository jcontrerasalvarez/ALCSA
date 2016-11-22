using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Datos.Documentos.DatosFormatos
{
    public class Juicio
    {
        public Entidades.Documentos.DatosFormatos.Juicio Buscar(int idJuicio, int idExhorto)
        {
            FWK.BD.Servicio objServicio = new FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Comando = "dbo.SPALCDOC_JUICIO_BUSCAR";
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@INT_IdJuicio", Valor = idJuicio, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@INT_IdExhorto", Valor = idExhorto, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            IList<Entidades.Documentos.DatosFormatos.Juicio> arrRespuesta = objServicio.Ejecutar<Entidades.Documentos.DatosFormatos.Juicio>();
            return arrRespuesta.Count > 0 ? arrRespuesta[0] : null;
        }
    }
}
