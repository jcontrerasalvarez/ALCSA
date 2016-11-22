using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio
{
    public class Deudor : Entidades.Deudor
    {
        public Deudor() { }

        public Deudor(string rut) 
        {
             if(string.IsNullOrEmpty(rut)) return;
             ALCSA.Entidades.Deudor objTemporal = new ALCSA.Datos.Deudor().Buscar(rut);
             ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Deudor, Deudor>(objTemporal, this);
        }

        public void Guardar()
        {
             if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
            new ALCSA.Datos.Deudor().Insertar(this);
        }

        public void Actualizar()
        {
            new ALCSA.Datos.Deudor().Actualizar(this);
        }

        public void Eliminar()
        {
            new ALCSA.Datos.Deudor().Eliminar(this.RutDeudor);
        }

        public IList<ALCSA.Entidades.Deudor> Listar()
        {
            return new ALCSA.Datos.Deudor().Listar();
        }

        public IList<Entidades.Parametros.Salidas.Personas.Basico> ListarSimilares(string rut)
        {
            if (string.IsNullOrEmpty(rut)) return null;
            rut = rut.Replace(".", string.Empty);
            IList<Entidades.Parametros.Salidas.Personas.Basico> arrDatos = new ALCSA.Datos.Deudor().ListarSimilares(rut);
            foreach (Entidades.Parametros.Salidas.Personas.Basico objDato in arrDatos)
                objDato.Rut = FWK.IdentificacionTributaria.FormatearRut(objDato.Rut);

            return arrDatos;
        }
    }
}
