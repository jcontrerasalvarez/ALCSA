using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Tramites
{
    public class SubTramite : Entidades.Tramites.SubTramite
    {
        public SubTramite() { }

        public SubTramite(int id) 
        {
             if(id < 1) return;
             Entidades.Tramites.SubTramite objTemporal = new Datos.Tramites.SubTramite().Buscar(id);
             ALCSA.FWK.Reflexion.Mapeador.MapearDatos<Entidades.Tramites.SubTramite, SubTramite>(objTemporal, this);
        }

        public void Guardar()
        {
             if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
            new Datos.Tramites.SubTramite().Insertar(this);
        }

        public void Actualizar()
        {
            new Datos.Tramites.SubTramite().Actualizar(this);
        }

        public void Eliminar()
        {
            new Datos.Tramites.SubTramite().Eliminar(this.ID);
        }

        public void AsociarTramite(int idTramite)
        {
            if (this.ID < 1) return;
            new Datos.Tramites.SubTramite().AsociarTramite(idTramite, this.ID);
        }

        public void DesasociarTramite(int idTramite)
        {
            if (this.ID < 1) return;
            new Datos.Tramites.SubTramite().DesasociarTramite(idTramite, this.ID);
        }

        public IList<Entidades.Tramites.SubTramite> Listar()
        {
            return new Datos.Tramites.SubTramite().Listar();
        }
    }
}
