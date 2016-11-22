using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Cobranzas
{
    /// <summary>
    /// 
    /// </summary>
    /// <creador>Generador Código</creador>
    /// <fecha_creacion>20-04-2014</fecha_creacion>
    public class Mutuo : ALCSA.Entidades.Cobranzas.Mutuo
    {
        public Mutuo() { }

        public Mutuo(int id)
        {
            if (id < 1) return;
            ALCSA.Entidades.Cobranzas.Mutuo objTemporal = new ALCSA.Datos.Cobranzas.Mutuo().Buscar(id, 0);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Cobranzas.Mutuo, Mutuo>(objTemporal, this);
        }

        public bool CargarPorCobranza(int idCobranza)
        {
            if (idCobranza < 1) return false;
            ALCSA.Entidades.Cobranzas.Mutuo objTemporal = new ALCSA.Datos.Cobranzas.Mutuo().Buscar(0, idCobranza);
            if (objTemporal == null) return false;
            if (objTemporal.ID < 1) return false;
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Cobranzas.Mutuo, Mutuo>(objTemporal, this);
            return true;
        }

        public void Guardar()
        {
            if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
            new ALCSA.Datos.Cobranzas.Mutuo().Insertar(this);
        }

        public void Actualizar()
        {
            new ALCSA.Datos.Cobranzas.Mutuo().Actualizar(this);
        }

        public void Eliminar()
        {
            new ALCSA.Datos.Cobranzas.Mutuo().Eliminar(this.ID);
        }

        public IList<ALCSA.Entidades.Cobranzas.Mutuo> Listar()
        {
            return new ALCSA.Datos.Cobranzas.Mutuo().Listar();
        }

        public IList<ALCSA.Entidades.Parametros.Salidas.Cobranzas.Mutuo.BienRaiz> ListarBienesRaicesDisponibles(string rutDeudor, int idBienRaizActual)
        {
            return new ALCSA.Datos.Cobranzas.Mutuo().ListarBienesRaicesDisponibles(rutDeudor, idBienRaizActual);
        }
    }
}
