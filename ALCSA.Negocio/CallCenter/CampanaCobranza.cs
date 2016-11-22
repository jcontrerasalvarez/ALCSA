using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.CallCenter
{
    public class CampanaCobranza : Entidades.CallCenter.CampanaCobranza
    {
        public CampanaCobranza() { }

        public CampanaCobranza(int id)
        {
            if (id < 1) return;
            ALCSA.Entidades.CallCenter.CampanaCobranza objTemporal = new ALCSA.Datos.CallCenter.CampanaCobranza().Buscar(id);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.CallCenter.CampanaCobranza, CampanaCobranza>(objTemporal, this);
        }

        public void Guardar()
        {
            if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
            new ALCSA.Datos.CallCenter.CampanaCobranza().Insertar(this);
        }

        public void Actualizar()
        {
            new ALCSA.Datos.CallCenter.CampanaCobranza().Actualizar(this);
        }

        public void Eliminar()
        {
            new ALCSA.Datos.CallCenter.CampanaCobranza().Eliminar(this.ID);
        }

        public IList<ALCSA.Entidades.CallCenter.CampanaCobranza> Listar(int idCampana)
        {
            return new ALCSA.Datos.CallCenter.CampanaCobranza().Listar(idCampana, 0);
        }

        public IList<ALCSA.Entidades.CallCenter.CampanaCobranza> ListarPorCobranza(int idCobranza)
        {
            return new ALCSA.Datos.CallCenter.CampanaCobranza().Listar(0, idCobranza);
        }

        public IList<ALCSA.Entidades.CallCenter.CampanaCobranza> ListarNoSeleccionadas(int idCampana)
        {
            return ListarNoSeleccionadas(idCampana, string.Empty, string.Empty, string.Empty);
        }

        public IList<ALCSA.Entidades.CallCenter.CampanaCobranza> ListarNoSeleccionadas(int idCampana, string rutCliente, string rutDeudor, string numeroOperacion)
        {
            return new ALCSA.Datos.CallCenter.CampanaCobranza().ListarNoSeleccionadas(idCampana, rutCliente, rutDeudor, numeroOperacion);
        }

        public DataTable ListarFormatoVicidial(int idCampana)
        {
            return new ALCSA.Datos.CallCenter.CampanaCobranza().ListarFormatoVicidial(idCampana);
        }
    }
}
