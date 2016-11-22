using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Abonos
{
    public class AbonoCheque : ALCSA.Entidades.Abonos.AbonoCheque
    {
        public AbonoCheque() { }

        public AbonoCheque(int id)
        {
            if (id < 1) return;
            ALCSA.Entidades.Abonos.AbonoCheque objTemporal = new ALCSA.Datos.Abonos.AbonoCheque().Buscar(id);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Abonos.AbonoCheque, AbonoCheque>(objTemporal, this);
        }

        public void Guardar()
        {
            if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
            new ALCSA.Datos.Abonos.AbonoCheque().Insertar(this);
        }

        public void Actualizar()
        {
            new ALCSA.Datos.Abonos.AbonoCheque().Actualizar(this);
        }

        public void Eliminar()
        {
            new ALCSA.Datos.Abonos.AbonoCheque().Eliminar(this.ID);
        }

        public IList<ALCSA.Entidades.Abonos.AbonoCheque> Listar(int idAbonoComprobante)
        {
            return new ALCSA.Datos.Abonos.AbonoCheque().Listar(idAbonoComprobante);
        }
    }
}
