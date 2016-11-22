using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Collections;

using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.SS.UserModel;
using NPOI.HSSF.Util;
using NPOI.XSSF.UserModel;

namespace ALCSA.Negocio.Documentos
{
    public class GeneradorExcel
    {
        #region Leer Excel

        public DataTable ExportarExcelADataTable(Stream archivoExcel, bool exArchivoXLSX)
        {
            IWorkbook objArchivoExcelNPOI;

            if (exArchivoXLSX) objArchivoExcelNPOI = new XSSFWorkbook(archivoExcel);
            else objArchivoExcelNPOI = new HSSFWorkbook(archivoExcel);

            ISheet objHoja = objArchivoExcelNPOI.GetSheetAt(0);

            DataTable objTablaFinal = new DataTable();
            IRow objCabeceraExcel = objHoja.GetRow(0);
            IEnumerator arrFilas = objHoja.GetRowEnumerator();
            IRow objFilaExcel;

            int intNumeroColumnas = objCabeceraExcel.LastCellNum;

            for (int intIndice = 0; intIndice < intNumeroColumnas; intIndice++)
                objTablaFinal.Columns.Add(objCabeceraExcel.GetCell(intIndice).ToString());

            while (arrFilas.MoveNext())
            {
                if (exArchivoXLSX) objFilaExcel = (XSSFRow)arrFilas.Current;
                else objFilaExcel = (HSSFRow)arrFilas.Current;

                DataRow objFilaTabla = objTablaFinal.NewRow();

                for (int intIndice = 0; intIndice < intNumeroColumnas; intIndice++)
                {
                    ICell objCelda = objFilaExcel.GetCell(intIndice);

                    if (objCelda != null)
                        objFilaTabla[intIndice] = objCelda.ToString();
                }

                objTablaFinal.Rows.Add(objFilaTabla);
            }

            return objTablaFinal;
        }

        #endregion

        #region Generar Excel

        public System.IO.MemoryStream ExportarDataTableAExcel(DataTable datos, string nombreHoja)
        {
            List<string> arrColumnas = new List<string>();
            foreach (DataColumn objColumna in datos.Columns)
                arrColumnas.Add(objColumna.ColumnName);

            return ExportarDataTableAExcel(datos, nombreHoja, arrColumnas.ToArray());
        }

        public System.IO.MemoryStream ExportarDataTableAExcel(DataTable datos, string nombreHoja, string[] columnasDataTable)
        {
            return ExportarDataTableAExcel(datos, nombreHoja, columnasDataTable, columnasDataTable);
        }

        public System.IO.MemoryStream ExportarDataTableAExcel(DataTable datos, string nombreHoja, string[] columnasDataTable, string[] nombresColumnas)
        {
            HSSFWorkbook objArchivoExcel = new HSSFWorkbook();
            ISheet objPagina = objArchivoExcel.CreateSheet(!string.IsNullOrEmpty(nombreHoja) ? nombreHoja : "Hoja1");
            ICell objCelda = null;
            IRow objFila = null;

            int intIndice = 0, intIndiceUno = 0, intPosicionFila = 0;
            object objDato = null;
            string strDato = string.Empty, strNombreColumna = string.Empty;
            decimal decDato = 0;
            Type objTipo;

            ICellStyle objEstilo = CrearEstiloCabecera(objArchivoExcel);
            objFila = objPagina.CreateRow(intPosicionFila);
            for (intIndice = 0; intIndice < nombresColumnas.Length; intIndice++)
            {
                objCelda = objFila.CreateCell(intIndice);
                strNombreColumna = nombresColumnas[intIndice];
                if (!strNombreColumna.ToUpper().Equals(strNombreColumna))
                    strNombreColumna = FWK.Texto.SepararTextoPorMayusculas(strNombreColumna);

                objCelda.SetCellValue(strNombreColumna);
                objCelda.CellStyle = objEstilo;
            }

            for (intIndice = 0; intIndice < datos.Rows.Count; intIndice++)
            {
                intPosicionFila++;
                objFila = objPagina.CreateRow(intPosicionFila);
                for (intIndiceUno = 0; intIndiceUno < columnasDataTable.Length; intIndiceUno++)
                {
                    objDato = datos.Rows[intIndice][columnasDataTable[intIndiceUno]];
                    strDato = objDato == null ? String.Empty : objDato.ToString().Trim();
                    objTipo = objDato.GetType();

                    if (objTipo.Equals(typeof(DateTime)))
                        objFila.CreateCell(intIndiceUno, CellType.String).SetCellValue(Convert.ToDateTime(objDato).ToString("dd/MM/yyyy").Replace("-", "/"));
                    else if ((objTipo.Equals(typeof(Int32)) || objTipo.Equals(typeof(Int16)) || objTipo.Equals(typeof(Int64)) || objTipo.Equals(typeof(Double)) || objTipo.Equals(typeof(decimal))) && decimal.TryParse(strDato, out decDato))
                        objFila.CreateCell(intIndiceUno, CellType.Numeric).SetCellValue(Convert.ToDouble(decDato));
                    else
                        objFila.CreateCell(intIndiceUno, CellType.String).SetCellValue(strDato);
                }
            }

            for (intIndice = 0; intIndice < columnasDataTable.Length; intIndice++)
                objPagina.AutoSizeColumn(intIndice);

            System.IO.MemoryStream objStream = new System.IO.MemoryStream();
            objArchivoExcel.Write(objStream);
            objStream.Close();

            return objStream;
        }

        public System.IO.MemoryStream ExportarListaDtoAExcel<T>(IList<T> datos, string nombreHoja, string[] nombresColumnas)
        {
            HSSFWorkbook objArchivoExcel = new HSSFWorkbook();
            CrearHojaExcel<T>(objArchivoExcel, datos, !string.IsNullOrEmpty(nombreHoja) ? nombreHoja : "Hoja1", nombresColumnas);

            System.IO.MemoryStream objStream = new System.IO.MemoryStream();
            objArchivoExcel.Write(objStream);
            objStream.Close();

            return objStream;
        }

        public System.IO.MemoryStream ExportarListaDtoAExcel<A, B>(IList<A> datosUno, IList<B> datosDos, string nombreHojaUno, string nombreHojaDos, string[] nombresColumnasUno, string[] nombresColumnasDos)
        {
            HSSFWorkbook objArchivoExcel = new HSSFWorkbook();
            CrearHojaExcel<A>(objArchivoExcel, datosUno, !string.IsNullOrEmpty(nombreHojaUno) ? nombreHojaUno : "Hoja1", nombresColumnasUno);
            CrearHojaExcel<B>(objArchivoExcel, datosDos, !string.IsNullOrEmpty(nombreHojaDos) ? nombreHojaDos : "Hoja2", nombresColumnasDos);

            System.IO.MemoryStream objStream = new System.IO.MemoryStream();
            objArchivoExcel.Write(objStream);
            objStream.Close();

            return objStream;
        }

        private void CrearHojaExcel<T>(HSSFWorkbook archivoExcel, IList<T> datos, string nombreHoja, string[] nombresColumnas)
        {
            ISheet objPagina = archivoExcel.CreateSheet(nombreHoja);
            ICell objCelda = null;
            Type objTipo = typeof(T);
            System.Reflection.PropertyInfo objPropiedad = null;

            int intIndice = 0, intIndiceUno = 0, intPosicionFila = 0;
            object objDato = null;
            string strDato = string.Empty, strNombreColumna = string.Empty;
            decimal decDato = 0;

            IRow objFila = null;

            ICellStyle objEstilo = CrearEstiloCabecera(archivoExcel);
            objFila = objPagina.CreateRow(intPosicionFila);
            for (intIndice = 0; intIndice < nombresColumnas.Length; intIndice++)
            {
                objCelda = objFila.CreateCell(intIndice);
                strNombreColumna = nombresColumnas[intIndice];
                if (!strNombreColumna.ToUpper().Equals(strNombreColumna))
                    strNombreColumna = FWK.Texto.SepararTextoPorMayusculas(strNombreColumna);

                objCelda.SetCellValue(strNombreColumna);
                objCelda.CellStyle = objEstilo;
            }

            for (intIndice = 0; intIndice < datos.Count; intIndice++)
            {
                intPosicionFila++;
                objFila = objPagina.CreateRow(intPosicionFila);
                for (intIndiceUno = 0; intIndiceUno < nombresColumnas.Length; intIndiceUno++)
                {
                    objPropiedad = objTipo.GetProperty(nombresColumnas[intIndiceUno]);
                    objDato = objPropiedad.GetValue(datos[intIndice], System.Reflection.BindingFlags.Default, null, null, null);

                    strDato = objDato == null ? String.Empty : objDato.ToString().Trim();

                    if (objPropiedad.PropertyType.Equals(typeof(DateTime)))
                        objFila.CreateCell(intIndiceUno, CellType.String).SetCellValue(FormatearFecha(objDato));
                    else if (decimal.TryParse(strDato, out decDato))
                        objFila.CreateCell(intIndiceUno, CellType.Numeric).SetCellValue(Convert.ToDouble(decDato));
                    else
                        objFila.CreateCell(intIndiceUno, CellType.String).SetCellValue(strDato);
                }
            }

            for (intIndice = 0; intIndice < nombresColumnas.Length; intIndice++)
                objPagina.AutoSizeColumn(intIndice);
        }

        private string FormatearFecha(object valor)
        { 
            DateTime datFecha = Convert.ToDateTime(valor);
            if (datFecha < ALCSA.FWK.Tiempo.FECHA_MINIMA) return string.Empty;
            return datFecha.ToString("dd/MM/yyyy").Replace("-", "/");
        }

        private static ICellStyle CrearEstiloCabecera(HSSFWorkbook excel)
        {
            ICellStyle objEstilo = excel.CreateCellStyle();
            objEstilo.FillForegroundColor = HSSFColor.Black.Index;
            objEstilo.FillPattern = FillPattern.SolidForeground;

            IFont objFuente = excel.CreateFont();
            objFuente.Color = HSSFColor.White.Index;
            objFuente.Boldweight = (short)FontBoldWeight.Bold;
            objEstilo.SetFont(objFuente);

            return objEstilo;
        }

        private static ICellStyle CrearEstiloTitulo(HSSFWorkbook excel)
        {
            ICellStyle objEstilo = excel.CreateCellStyle();
            // objEstilo.FillForegroundColor = HSSFColor.WHITE.index;
            // objEstilo.FillPattern = FillPatternType.SOLID_FOREGROUND;

            IFont objFuente = excel.CreateFont();
            objFuente.Color = HSSFColor.Black.Index;
            objFuente.Boldweight = (short)FontBoldWeight.Bold;
            objEstilo.SetFont(objFuente);

            return objEstilo;
        }

        #endregion
    }
}
