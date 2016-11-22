using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Temporales
{
    public class Temporal : Entidades.Temporales.Temporal
    {
        public Temporal() { }

        public Temporal(int id)
        {
            FWK.Reflexion.Mapeador.MapearDatos<Entidades.Temporales.Temporal, Temporal>(
                new Datos.Temporales.Temporal().Buscar(id, string.Empty), this);
        }

        public Temporal(string codigo)
        {
            FWK.Reflexion.Mapeador.MapearDatos<Entidades.Temporales.Temporal, Temporal>(
                new Datos.Temporales.Temporal().Buscar(0, codigo), this);
        }

        public void Guardar()
        {
            if (this.ID > 0 && !string.IsNullOrEmpty(this.Codigo))
                Actualizar();
            else Insertar();
        }

        public void Insertar()
        {
            new Datos.Temporales.Temporal().Insertar(this);
        }

        public void Actualizar()
        {
            new Datos.Temporales.Temporal().Actualizar(this);
        }

        public void Eliminar()
        {
            new Datos.Temporales.Temporal().Eliminar(this);
        }

        public void EliminarPorProcesoUsuario()
        {
            EliminarPorProcesoUsuario(this.CodigoProceso, this.UsuarioDueno);
        }

        public void EliminarPorProcesoUsuario(string codigoProceso, string usuarioDueno)
        {
            Entidades.Temporales.Temporal objTemporal = new Entidades.Temporales.Temporal()
            {
                Codigo = string.Empty,
                CodigoProceso = codigoProceso,
                UsuarioDueno = usuarioDueno
            };

            new Datos.Temporales.Temporal().Eliminar(objTemporal);
        }

        public IList<Entidades.Temporales.Temporal> Listar(string codigoProceso, string usuario)
        {
            return new Datos.Temporales.Temporal().Listar(codigoProceso, usuario);
        }
    }
}
