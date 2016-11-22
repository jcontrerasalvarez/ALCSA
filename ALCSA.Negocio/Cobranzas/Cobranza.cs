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
    public class Cobranza : ALCSA.Entidades.Cobranzas.Cobranza
    {
        public static string TIPO_COBRANZA_DOCUMENTO_JUICIO = "DOCUJUICIO";
        public static string TIPO_COBRANZA_DOCUMENTO_PAGARE = "DOCUPAGARE";
        public static string TIPO_COBRANZA_MUTUO = "DOCUMUTUO";
        public static string TIPO_COBRANZA_DOCUMENTO_ESTANDAR_UNO = "ESTANDARD1";
        public static string TIPO_COBRANZA_DOCUMENTO_ESTANDAR_DOS = "ESTANDARD2";
        public static string TIPO_COBRANZA_DOCUMENTO_ESTANDAR_TRES = "ESTANDARD3";
        public static string TIPO_COBRANZA_DOCUMENTO_ESTANDAR_CUATRO = "ESTANDARD4";
        public static string TIPO_COBRANZA_CUOTA_COLEGIO = "CUOTA_COLEGIO";

        public static string ESTADO_COBRANZA_ACTIVO = "A";
        public static string ESTADO_COBRANZA_SUSPENDIDO = "S";
        public static string ESTADO_COBRANZA_REACTIVADO = "R";
        public static string ESTADO_COBRANZA_PROCESO_TERMINO = "P";
        public static string ESTADO_COBRANZA_TERMINADO = "N";

        public Cobranza() { }

        public Cobranza(int id)
        {
            if (id < 1) return;
            ALCSA.Entidades.Cobranzas.Cobranza objTemporal = new ALCSA.Datos.Cobranzas.Cobranza().Buscar(id, string.Empty, string.Empty);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Cobranzas.Cobranza, Cobranza>(objTemporal, this);
            BuscarTipoActividad();
        }

        public Cobranza(string numeroOperacion, string rutCliente)
        {
            if (string.IsNullOrEmpty(numeroOperacion) || string.IsNullOrEmpty(rutCliente)) return;
            ALCSA.Entidades.Cobranzas.Cobranza objTemporal = new ALCSA.Datos.Cobranzas.Cobranza().Buscar(0, numeroOperacion, rutCliente);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Cobranzas.Cobranza, Cobranza>(objTemporal, this);
            BuscarTipoActividad();
        }

        public void Guardar()
        {
            if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
            new ALCSA.Datos.Cobranzas.Cobranza().Insertar(this);
        }

        public void Actualizar()
        {
            new ALCSA.Datos.Cobranzas.Cobranza().Actualizar(this);
        }

        public void Eliminar()
        {
            new ALCSA.Datos.Cobranzas.Cobranza().Eliminar(this.ID);
        }

        public string BuscarTipoActividad()
        {
            if (this.ID < 1) return string.Empty;
            this.TipoActividad = BuscarTipoActividad(this.ID);
            return this.TipoActividad;
        }

        public string BuscarTipoActividad(int idCobranza)
        {
            if (idCobranza < 1) return string.Empty;
            return new ALCSA.Datos.Cobranzas.Cobranza().BuscarTipoActividad(idCobranza);
        }

        public void ActualizarEstado(int idCobranza, string estado)
        {
            new ALCSA.Datos.Cobranzas.Cobranza().ActualizarEstado(idCobranza, estado);
        }

        #region Listados

        public IList<ALCSA.Entidades.Cobranzas.Cobranza> Listar()
        {
            return new ALCSA.Datos.Cobranzas.Cobranza().Listar();
        }

        public IList<Entidades.Parametros.Salidas.Cobranzas.ListadoDemanda> Listar(Entidades.Parametros.Entradas.Cobranzas.ListadoDemanda entrada)
        {
            return new ALCSA.Datos.Cobranzas.Cobranza().Listar(entrada);
        }

        #endregion
    }
}
