using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Gastos
{
    public class Gasto : Entidades.Gastos.GastoCobranza
    {
        public Gasto() { }

        public Gasto(int id)
        {
            if (id < 1) return;
            ALCSA.Entidades.Gastos.GastoCobranza objTemporal = new ALCSA.Datos.Gastos.Gasto().Buscar(id);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Gastos.GastoCobranza, Gasto>(objTemporal, this);
        }

        public void Guardar()
        {
            if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
            new ALCSA.Datos.Gastos.Gasto().Insertar(this);
        }

        public void Actualizar()
        {
            new ALCSA.Datos.Gastos.Gasto().Actualizar(this);
        }

        public void Eliminar()
        {
            new ALCSA.Datos.Gastos.Gasto().Eliminar(this.ID);
        }

        public IList<ALCSA.Entidades.Gastos.GastoCobranza> Listar(int idCobranza)
        {
            return new ALCSA.Datos.Gastos.Gasto().Listar(idCobranza);
        }
    }
}
