using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Cobranzas
{
    public class Remesa : Entidades.Cobranzas.Remesa
    {
        public Remesa() { }

        public Remesa(int id) 
        {
             if(id < 1) return;
             Entidades.Cobranzas.Remesa objRemesasTemporal = new ALCSA.Datos.Cobranzas.Remesa().Buscar(id);
             FWK.Reflexion.Mapeador.MapearDatos<Entidades.Cobranzas.Remesa, Remesa>(objRemesasTemporal, this);
        }

        public void Guardar()
        {
             if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
             new ALCSA.Datos.Cobranzas.Remesa().Insertar(this);
        }

        public void Actualizar()
        {
             new ALCSA.Datos.Cobranzas.Remesa().Actualizar(this);
        }

        public void Eliminar()
        {
             new ALCSA.Datos.Cobranzas.Remesa().Eliminar(this.ID);
        }

        public IList<Entidades.Cobranzas.Remesa> Listar(string rutCliente)
        {
            return new ALCSA.Datos.Cobranzas.Remesa().Listar(rutCliente);
        }
    }
}
