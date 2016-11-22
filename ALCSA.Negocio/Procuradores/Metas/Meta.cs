using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALCSA.Negocio.Procuradores.Metas
{
    public class Meta : ALCSA.Entidades.Procuradores.Metas.Meta
    {
        public IList<Entidades.Base> Tramites { get; set; }

        public Meta() 
        {
            Tramites = new List<Entidades.Base>();
        }

        public Meta(int id) : this()
        {
            if (id < 1) return;
            ALCSA.Entidades.Procuradores.Metas.Meta objTemporal = new ALCSA.Datos.Procuradores.Metas.Meta().Buscar(id);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Procuradores.Metas.Meta, Metas.Meta>(objTemporal, this);
            if (this.ID < 1) return;

            Tramites = new ALCSA.Datos.Procuradores.Metas.Meta().ListarTramites(this.ID, string.Empty);
        }

        public void Guardar()
        {
            if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
            new ALCSA.Datos.Procuradores.Metas.Meta().Insertar(this);
            GuardarTramites();
        }

        public void Actualizar()
        {
            new ALCSA.Datos.Procuradores.Metas.Meta().Actualizar(this);
            GuardarTramites();
        }

        public void Eliminar()
        {
            new ALCSA.Datos.Procuradores.Metas.Meta().Eliminar(this.ID);
        }

        public IList<ALCSA.Entidades.Procuradores.Metas.Meta> Listar()
        {
            return new ALCSA.Datos.Procuradores.Metas.Meta().Listar();
        }

        public IList<ALCSA.Entidades.Base> ListarTramites(string etapa)
        {
            return new ALCSA.Datos.Procuradores.Metas.Meta().ListarTramites(0, etapa);
        }

        public IList<ALCSA.Entidades.Base> ListarEtapas()
        {
            return new ALCSA.Datos.Procuradores.Metas.Meta().ListarEtapas();
        }

        public DataTable ListarResumenMetas(string rutProcurador, DateTime fecha)
        {
            return new ALCSA.Datos.Procuradores.Metas.Meta().ListarDetalle(rutProcurador, fecha, true);
        }

        public DataTable ListarDetalleCobranzasMetas(string rutProcurador, DateTime fecha)
        {
            return new ALCSA.Datos.Procuradores.Metas.Meta().ListarDetalle(rutProcurador, fecha, false);
        }

        private void GuardarTramites()
        { 
            ALCSA.Datos.Procuradores.Metas.Meta objDatos = new Datos.Procuradores.Metas.Meta();
            foreach (Entidades.Base objTramite in Tramites)
                objDatos.InsertarTramite(this.ID, objTramite.Nombre);
        }
    }
}
