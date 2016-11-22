using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Documentos.DatosFormatos
{
    public class Juicio : Entidades.Documentos.DatosFormatos.Juicio
    {
        public Juicio(int idJuicio, int idExhorto)
        {
            if (idJuicio < 1) return;
            Entidades.Documentos.DatosFormatos.Juicio objTemporal = new Datos.Documentos.DatosFormatos.Juicio().Buscar(idJuicio, idExhorto);
            FWK.Reflexion.Mapeador.MapearDatos<Entidades.Documentos.DatosFormatos.Juicio, Juicio>(objTemporal, this);
        }
    }
}
