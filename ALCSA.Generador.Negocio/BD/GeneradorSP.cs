using System;
using System.Collections.Generic;
using System.Text;

namespace ALCSA.Generador.Negocio.BD
{
    public class GeneradorSP : BaseGenerador
    {
        public GeneradorSP(Tabla tabla, string ruta) : base(tabla, ruta) { }

        public void GenerarProcedimientos()
        {
            GenerarProcedimientoEliminar();
            GenerarProcedimientoBuscar();
            GenerarProcedimientoListar();
            GenerarProcedimientoInsertar();
            GenerarProcedimientoActualizar();
        }

        public void GenerarProcedimientoEliminar()
        {
            List<String> arrLineas = new List<string>();
            GenerarComentarios(arrLineas);
            string strNombreSP = String.Format("{0}{1}_ELIMINAR", Nomenclatura.SP, InfoTabla.NombreSinNomenclatura.ToUpper());
            arrLineas.Add(String.Format("CREATE PROCEDURE dbo.{0}", strNombreSP));

            GenerarParametrosEntrada(InfoTabla.LlavesPrimarias, null, arrLineas);

            arrLineas.Add("AS");
            arrLineas.Add("BEGIN");

            arrLineas.Add(String.Format("     DELETE FROM {0}", InfoTabla.Nombre));
            GenerarWhere(InfoTabla.LlavesPrimarias, arrLineas);

            arrLineas.Add("END");

            GuardarArchivo(arrLineas, strNombreSP, ".sql");
        }

        public void GenerarProcedimientoBuscar()
        {
            List<String> arrLineas = new List<string>();
            GenerarComentarios(arrLineas);
            string strNombreSP = String.Format("{0}{1}_BUSCAR", Nomenclatura.SP, InfoTabla.NombreSinNomenclatura.ToUpper());
            arrLineas.Add(String.Format("CREATE PROCEDURE dbo.{0}", strNombreSP));

            if (InfoTabla.LlavesPrimarias.Count > 0)
            {
                arrLineas.Add("(");
                for (int intIndice = 0; intIndice < InfoTabla.LlavesPrimarias.Count; intIndice++)
                    arrLineas.Add(String.Format("    {0}    {1}",
                        Nomenclatura.ConcatenarParametroSP(InfoTabla.LlavesPrimarias[intIndice]),
                        Nomenclatura.ConcatenarTipoDato(InfoTabla.LlavesPrimarias[intIndice])));
                arrLineas.Add(")");
            }

            arrLineas.Add("AS");
            arrLineas.Add("BEGIN");

            GenerarSelect(InfoTabla.Columnas, arrLineas);
            arrLineas.Add(String.Format("     FROM    {0}", InfoTabla.Nombre));
            GenerarWhere(InfoTabla.LlavesPrimarias, arrLineas);

            arrLineas.Add("END");

            GuardarArchivo(arrLineas, strNombreSP, ".sql");
        }

        public void GenerarProcedimientoListar()
        {
            List<String> arrLineas = new List<string>();
            GenerarComentarios(arrLineas);
            string strNombreSP = String.Format("{0}{1}_LISTAR", Nomenclatura.SP, InfoTabla.NombreSinNomenclatura.ToUpper());
            arrLineas.Add(String.Format("CREATE PROCEDURE dbo.{0}", strNombreSP));

            arrLineas.Add("AS");
            arrLineas.Add("BEGIN");

            GenerarSelect(InfoTabla.Columnas, arrLineas);
            arrLineas.Add(String.Format("     FROM    {0}", InfoTabla.Nombre));

            arrLineas.Add("END");

            GuardarArchivo(arrLineas, strNombreSP, ".sql");
        }

        public void GenerarProcedimientoInsertar()
        {
            List<String> arrLineas = new List<string>();
            GenerarComentarios(arrLineas);
            string strNombreSP = String.Format("{0}{1}_INSERTAR", Nomenclatura.SP, InfoTabla.NombreSinNomenclatura.ToUpper());
            arrLineas.Add(String.Format("CREATE PROCEDURE dbo.{0}", strNombreSP));
            int intIndice;

            GenerarParametrosEntrada(InfoTabla.ColumnasSinLlavesPrimarias, InfoTabla.LlavesPrimarias, arrLineas);

            arrLineas.Add("AS");
            arrLineas.Add("BEGIN");

            arrLineas.Add(String.Format("     INSERT INTO {0}", InfoTabla.Nombre));
            arrLineas.Add("     (");

            for (intIndice = 0; intIndice < InfoTabla.ColumnasSinLlavesPrimarias.Count; intIndice++)
                arrLineas.Add(String.Format("          {0}{1}", InfoTabla.ColumnasSinLlavesPrimarias[intIndice].Nombre, InfoTabla.ColumnasSinLlavesPrimarias.Count - 1 == intIndice ? String.Empty : ","));

            arrLineas.Add("     )");
            arrLineas.Add("     VALUES");
            arrLineas.Add("     (");

            for (intIndice = 0; intIndice < InfoTabla.ColumnasSinLlavesPrimarias.Count; intIndice++)
                arrLineas.Add(String.Format("          {0}{1}", Nomenclatura.ConcatenarParametroSP(InfoTabla.ColumnasSinLlavesPrimarias[intIndice]), InfoTabla.ColumnasSinLlavesPrimarias.Count - 1 == intIndice ? String.Empty : ","));

            arrLineas.Add("     )");

            if (InfoTabla.LlavesPrimarias.Count > 0)
            {
                arrLineas.Add(String.Empty);
                arrLineas.Add(string.Format("     SELECT {0} = SCOPE_IDENTITY()", Nomenclatura.ConcatenarParametroSP(InfoTabla.LlavesPrimarias[0])));
                arrLineas.Add(String.Empty);
            }

            arrLineas.Add("END");

            GuardarArchivo(arrLineas, strNombreSP, ".sql");
        }

        public void GenerarProcedimientoActualizar()
        {
            List<String> arrLineas = new List<string>();
            GenerarComentarios(arrLineas);
            string strNombreSP = String.Format("{0}{1}_ACTUALIZAR", Nomenclatura.SP, InfoTabla.NombreSinNomenclatura.ToUpper());
            arrLineas.Add(String.Format("CREATE PROCEDURE dbo.{0}", strNombreSP));

            GenerarParametrosEntrada((List<ALCSA.Generador.Entidades.BD.Columna>)InfoTabla.Columnas, null, arrLineas);

            arrLineas.Add("AS");
            arrLineas.Add("BEGIN");

            arrLineas.Add(String.Format("     UPDATE {0}", InfoTabla.Nombre));
            arrLineas.Add("     SET");

            for (int intIndice = 0; intIndice < InfoTabla.ColumnasSinLlavesPrimarias.Count; intIndice++)
                arrLineas.Add(String.Format("            {0} = {1}{2}", InfoTabla.ColumnasSinLlavesPrimarias[intIndice].Nombre,
                    Nomenclatura.ConcatenarParametroSP(InfoTabla.ColumnasSinLlavesPrimarias[intIndice]), InfoTabla.ColumnasSinLlavesPrimarias.Count - 1 == intIndice ? String.Empty : ","));

            GenerarWhere(InfoTabla.LlavesPrimarias, arrLineas);
            arrLineas.Add("END");
            GuardarArchivo(arrLineas, strNombreSP, ".sql");
        }

        private void GenerarSelect(IList<ALCSA.Generador.Entidades.BD.Columna> columnas, List<string> lineas)
        {
            if (columnas.Count == 0) return;
            lineas.Add(String.Format("     SELECT  {0}{1}", columnas[0].Nombre, columnas.Count == 1 ? String.Empty : ","));
            for (int intIndice = 1; intIndice < columnas.Count; intIndice++)
                lineas.Add(String.Format("             {0}{1}", columnas[intIndice].Nombre, columnas.Count - 1 == intIndice ? String.Empty : ","));
        }

        private void GenerarWhere(IList<ALCSA.Generador.Entidades.BD.Columna> columnas, List<string> lineas)
        {
            if (columnas.Count == 0) return;
            lineas.Add(String.Format("     WHERE  {0} = {1}", columnas[0].Nombre, Nomenclatura.ConcatenarParametroSP(columnas[0])));
            for (int intIndice = 1; intIndice < columnas.Count; intIndice++)
                lineas.Add(String.Format("           AND {0} = {1}", columnas[intIndice].Nombre, Nomenclatura.ConcatenarParametroSP(columnas[intIndice])));
        }

        private void GenerarParametrosEntrada(IList<ALCSA.Generador.Entidades.BD.Columna> entradas, IList<ALCSA.Generador.Entidades.BD.Columna> salidas, List<string> lineas)
        {
            int intIndice;
            bool blnConSalidas = salidas != null && salidas.Count > 0 ? true : false;

            lineas.Add("(");
            for (intIndice = 0; intIndice < entradas.Count; intIndice++)
                lineas.Add(String.Format("     {0}     {1}{2}",
                    Nomenclatura.ConcatenarParametroSP(entradas[intIndice]),
                    Nomenclatura.ConcatenarTipoDato(entradas[intIndice]),
                    entradas.Count - 1 == intIndice ? blnConSalidas ? "," : string.Empty : ","));

            if (blnConSalidas)
                lineas.Add(String.Format("     {0}Salida     {1} OUTPUT", 
                    Nomenclatura.ConcatenarParametroSP(salidas[0]), 
                    Nomenclatura.ConcatenarTipoDato(salidas[0])));

            lineas.Add(")");
        }

        private void GenerarComentarios(IList<string> lineas)
        {
            lineas.Add("-- ****************************************************************");
            lineas.Add("-- * DESCRIPCION    : ");
            lineas.Add("-- * CREADOR        : Generador de Codigo");
            lineas.Add(String.Format("-- * FECHA CREACION : {0}", DateTime.Now.ToString("dd-MM-yyyy")));
            lineas.Add("-- ****************************************************************");
        }
    }
}
