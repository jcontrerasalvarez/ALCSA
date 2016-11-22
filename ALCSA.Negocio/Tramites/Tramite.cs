using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Tramites
{
    public class Tramite : Entidades.Tramites.Tramite
    {
        public Tramite() { }

        public Tramite(int id) 
        {
             if(id < 1) return;
             Entidades.Tramites.Tramite objTemporal = new Datos.Tramites.Tramite().Buscar(id);
             ALCSA.FWK.Reflexion.Mapeador.MapearDatos<Entidades.Tramites.Tramite, Tramite>(objTemporal, this);
        }

        public void Guardar()
        {
             if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
            new Datos.Tramites.Tramite().Insertar(this);
        }

        public void Actualizar()
        {
            new Datos.Tramites.Tramite().Actualizar(this);
        }

        public void Eliminar()
        {
            new Datos.Tramites.Tramite().Eliminar(this.ID);
        }

        public IList<Entidades.Tramites.Tramite> Listar(int idSubTramite)
        {
            return new Datos.Tramites.Tramite().Listar(idSubTramite, Enumeradores.Estado.Basico.Vigente.GetHashCode(), string.Empty);
        }

        public IList<Entidades.Tramites.Tramite> Listar(Enumeradores.Estado.Basico estado)
        {
            return new Datos.Tramites.Tramite().Listar(0, estado.GetHashCode(), string.Empty);
        }

        public IList<Entidades.Tramites.Tramite> Listar(string tipo, Enumeradores.Estado.Basico estado)
        {
            return new Datos.Tramites.Tramite().Listar(0, estado.GetHashCode(), tipo);
        }

        public IList<Entidades.Base> ListarEtapas()
        {
            return new Datos.Tramites.Tramite().ListarEtapas();
        }
    }
}
