using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Generador.Datos
{
    public class Esquema
    {
        public IList<ALCSA.Generador.Entidades.BD.Columna> ListarColumnas(string tabla)
        {
            ALCSA.FWK.BD.Servicio objServicio = new FWK.BD.Servicio();
            objServicio.Conexion = "CONN";
            objServicio.Comando = CrearComandoListadoColumnas(tabla);
            objServicio.TipoComando = FWK.BD.Enumeradores.TiposComandos.Query;
            return objServicio.Ejecutar<ALCSA.Generador.Entidades.BD.Columna>();
        }

        public IList<ALCSA.Generador.Entidades.BD.Tabla> ListarTablas()
        {
            ALCSA.FWK.BD.Servicio objServicio = new FWK.BD.Servicio();
            objServicio.Conexion = "CONN";
            objServicio.Comando = CrearComandoListadoTablas();
            objServicio.TipoComando = FWK.BD.Enumeradores.TiposComandos.Query;
            return objServicio.Ejecutar<ALCSA.Generador.Entidades.BD.Tabla>();
        }

        private string CrearComandoListadoTablas()
        {
            return "SELECT TABLE_NAME AS Nombre FROM INFORMATION_SCHEMA.TABLES";
        }

        private string CrearComandoListadoColumnas(string tabla)
        {
            StringBuilder strbTexto = new StringBuilder();

            strbTexto.Append("SELECT DISTINCT COL.COLUMN_NAME AS Nombre, COL.DATA_TYPE AS TipoDato, COL.CHARACTER_MAXIMUM_LENGTH AS Largo, COL.NUMERIC_PRECISION AS Presicion, CASE WHEN TC.CONSTRAINT_TYPE = 'PRIMARY KEY' THEN 1 ELSE 0 END EsLlavePrimaria");
            strbTexto.Append(" FROM	INFORMATION_SCHEMA.COLUMNS COL");
            strbTexto.Append(" LEFT JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE KCU");
            strbTexto.Append(" ON COL.COLUMN_NAME = KCU.COLUMN_NAME");
            strbTexto.Append(" AND KCU.TABLE_NAME = COL.TABLE_NAME");
            strbTexto.Append(" AND KCU.TABLE_SCHEMA = COL.TABLE_SCHEMA");
            strbTexto.Append(" AND KCU.TABLE_CATALOG = COL.TABLE_CATALOG");
            strbTexto.Append(" LEFT JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS TC");
            strbTexto.Append(" ON KCU.CONSTRAINT_SCHEMA = TC.CONSTRAINT_SCHEMA");
            strbTexto.Append(" AND KCU.CONSTRAINT_NAME = TC.CONSTRAINT_NAME");
            strbTexto.Append(" AND KCU.TABLE_SCHEMA = TC.TABLE_SCHEMA");
            strbTexto.Append(" AND KCU.TABLE_NAME = TC.TABLE_NAME");
            strbTexto.Append(" AND KCU.COLUMN_NAME = COL.COLUMN_NAME");
            strbTexto.AppendFormat(" WHERE	COL.TABLE_NAME	= '{0}'", tabla);
            strbTexto.Append(" ORDER BY EsLlavePrimaria DESC, Nombre");
            return strbTexto.ToString();
        }
    }
}
