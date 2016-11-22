using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Documentos.Fisicos
{
    public class TipoIdentificador : Entidades.Documentos.Fisicos.TipoIdentificador
    {
        public static string INICIAL_TIPO_IDENTIFICADOR = "TI";

        public static string TIPO_IDENTIFICADOR_COBRANZA = "TICOB";
        public static string TIPO_IDENTIFICADOR_JUICIO = "TIJUI";
        public static string TIPO_IDENTIFICADOR_EXHORTO = "TIEXH";

        public static string TIPO_IDENTIFICADOR_DOCUMENTO_PAGARE = "TIDPA";
        public static string TIPO_IDENTIFICADOR_MUTUO = "TIMUT";
        public static string TIPO_IDENTIFICADOR_DOCUMENTO_JUICIO = "TIDJU";
        public static string TIPO_IDENTIFICADOR_CUOTA_COLEGIO = "TICUO";

        public static string TIPO_IDENTIFICADOR_DOCUMENTO_ESTANDAR_1 = "TIDS1";
        public static string TIPO_IDENTIFICADOR_DOCUMENTO_ESTANDAR_2 = "TIDS2";
        public static string TIPO_IDENTIFICADOR_DOCUMENTO_ESTANDAR_3 = "TIDS3";
        public static string TIPO_IDENTIFICADOR_DOCUMENTO_ESTANDAR_4 = "TIDS4";

        public TipoIdentificador() { }

        public TipoIdentificador(int id) 
        {
             if(id < 1) return;
             ALCSA.Entidades.Documentos.Fisicos.TipoIdentificador objTemporal = new ALCSA.Datos.Documentos.Fisicos.TipoIdentificador().Buscar(id, string.Empty);
             ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Documentos.Fisicos.TipoIdentificador, TipoIdentificador>(objTemporal, this);
        }

        public TipoIdentificador(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo)) return;
            ALCSA.Entidades.Documentos.Fisicos.TipoIdentificador objTemporal = new ALCSA.Datos.Documentos.Fisicos.TipoIdentificador().Buscar(0, codigo);
            ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.Documentos.Fisicos.TipoIdentificador, TipoIdentificador>(objTemporal, this);
        }

        public void Guardar()
        {
             if (this.ID > 0) Actualizar(); else Insertar();
        }

        public void Insertar()
        {
             new ALCSA.Datos.Documentos.Fisicos.TipoIdentificador().Insertar(this);
        }

        public void Actualizar()
        {
             new ALCSA.Datos.Documentos.Fisicos.TipoIdentificador().Actualizar(this);
        }

        public void Eliminar()
        {
             new ALCSA.Datos.Documentos.Fisicos.TipoIdentificador().Eliminar(this.ID);
        }

        public IList<ALCSA.Entidades.Documentos.Fisicos.TipoIdentificador> Listar()
        {
             return new ALCSA.Datos.Documentos.Fisicos.TipoIdentificador().Listar();
        }
    }
}
