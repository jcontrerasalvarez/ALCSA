using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.FWK.IO
{
    /// <summary>
    /// Permite manipular archivos de texto plano
    /// </summary>
    /// <creador>Jonathan Contreras</creador>
    /// <fecha_creacion>23-04-2010</fecha_creacion>
    public class ArchivoTextoPlano
        {
            private Encoding objCodificacion;
            private const String strTextoReeplazoUno = "#";
            private const String strTextoReeplazoDos = "@";

            /// <summary>
            /// Constructor por defecto
            /// </summary>
            /// <creador>Jonathan Contreras</creador>
            /// <fecha_creacion>08-06-2010</fecha_creacion>
            public ArchivoTextoPlano()
                : this(Encoding.Unicode)
            {
            }

            /// <summary>
            /// Asigna una copdificacion para los archivos que se escriban (no funciona para metodos que guardan Stream pasados por parametros)
            /// </summary>
            /// <param name="codificacion">Codificacion</param>
            /// <creador>Jonathan Contreras</creador>
            /// <fecha_creacion>08-06-2010</fecha_creacion>
            public ArchivoTextoPlano(Encoding codificacion)
            {
                objCodificacion = codificacion;
            }

            /// <summary>
            /// Guarda los datos de unam lista en un archivo de texto plano
            /// </summary>
            /// <typeparam name="T">Tipo DTO</typeparam>
            /// <param name="nombreArchivo">Ruta y nombre del archivo</param>
            /// <param name="separadorColumnas">Separador entre datos</param>
            /// <param name="incluirNombresColumnas">Indica si se deben guardar los nombre de las columnas</param>
            /// <param name="listaDTO">Lista de instancias del DTO</param>
            /// <creador>Jonathan Contreras</creador>
            /// <fecha_creacion>23-04-2010</fecha_creacion>
            public void GuardarListaEnArchivo<T>(String nombreArchivo, String separadorColumnas, Boolean incluirNombresColumnas, IList<T> listaDTO)
            {
                System.IO.FileStream objArchivo = null;
                System.IO.StreamWriter objEscritor = null;
                try
                {
                    objArchivo = new System.IO.FileStream(nombreArchivo, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
                    objEscritor = new System.IO.StreamWriter(objArchivo, objCodificacion);
                    if (incluirNombresColumnas)
                        objEscritor.WriteLine(ConcatenarLineaTxt<T>(separadorColumnas));

                    for (int intIndice = 0; intIndice < listaDTO.Count; intIndice++)
                        objEscritor.WriteLine(ConcatenarLineaTxt<T>(listaDTO[intIndice], separadorColumnas));
                }
                catch (Exception exExcepcion)
                {
                    throw exExcepcion;
                }
                finally
                {
                    objEscritor.Close();
                }
            }

            /// <summary>
            /// Guarda los datos de un DataTable en un archivo de texto plano
            /// </summary>
            /// <param name="nombreArchivo">Ruta y nombre del archivo</param>
            /// <param name="separadorColumnas">Separador entre datos</param>
            /// <param name="incluirNombresColumnas">Indica si se deben guardar los nombre de las columnas</param>
            /// <param name="tabla">Tabla con datos</param>
            /// <returns>Numero de lineas guardadas</returns>
            /// <creador>Jonathan Contreras</creador>
            /// <fecha_creacion>23-04-2010</fecha_creacion>
            public Int32 GuardarDataTableEnArchivo(String nombreArchivo, String separadorColumnas, Boolean incluirNombresColumnas, System.Data.DataTable tabla)
            {
                return GuardarDataTableEnArchivo(nombreArchivo, separadorColumnas, incluirNombresColumnas, tabla, 0, tabla.Rows.Count, String.Empty);
            }

            /// <summary>
            /// Guarda los datos de un DataTable en un archivo de texto plano
            /// </summary>
            /// <param name="nombreArchivo">Ruta y nombre del archivo</param>
            /// <param name="separadorColumnas">Separador entre datos</param>
            /// <param name="incluirNombresColumnas">Indica si se deben guardar los nombre de las columnas</param>
            /// <param name="tabla">Tabla con datos</param>
            /// <param name="indiceFilaInicial">Indice el indice de fila inicial de la tabla</param>
            /// <param name="numeroDeFilas">Indica cuantas filas se van a guardar en el archivo</param>
            /// <returns>Numero de lineas guardadas</returns>
            /// <creador>Jonathan Contreras</creador>
            /// <fecha_creacion>23-04-2010</fecha_creacion>
            public Int32 GuardarDataTableEnArchivo(String nombreArchivo, String separadorColumnas, Boolean incluirNombresColumnas, System.Data.DataTable tabla, int indiceFilaInicial, int numeroDeFilas)
            {
                return GuardarDataTableEnArchivo(nombreArchivo, separadorColumnas, incluirNombresColumnas, tabla, indiceFilaInicial, numeroDeFilas, String.Empty);
            }

            /// <summary>
            /// Guarda los datos de un DataTable en un archivo de texto plano
            /// </summary>
            /// <param name="nombreArchivo">Ruta y nombre del archivo</param>
            /// <param name="separadorColumnas">Separador entre datos</param>
            /// <param name="incluirNombresColumnas">Indica si se deben guardar los nombre de las columnas</param>
            /// <param name="tabla">Tabla con datos</param>
            /// <param name="indiceFilaInicial">Indice el indice de fila inicial de la tabla</param>
            /// <param name="numeroDeFilas">Indica cuantas filas se van a guardar en el archivo</param>
            /// <returns>Numero de lineas guardadas</returns>
            /// <creador>Jonathan Contreras</creador>
            /// <fecha_creacion>23-04-2010</fecha_creacion>
            public Int32 GuardarDataTableEnArchivo(String nombreArchivo, String separadorColumnas, Boolean incluirNombresColumnas, System.Data.DataTable tabla, int indiceFilaInicial, int numeroDeFilas, String textoPieDePagina)
            {
                System.IO.FileStream objArchivo = null;
                System.IO.StreamWriter objEscritor = null;
                try
                {
                    objArchivo = new System.IO.FileStream(nombreArchivo, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
                    objEscritor = new System.IO.StreamWriter(objArchivo, objCodificacion);

                    if (incluirNombresColumnas)
                        objEscritor.WriteLine(ConcatenarLineaTxt(tabla.Columns, separadorColumnas));

                    numeroDeFilas += indiceFilaInicial;
                    if (numeroDeFilas > tabla.Rows.Count) numeroDeFilas = tabla.Rows.Count;

                    for (int intIndice = indiceFilaInicial; intIndice < numeroDeFilas; intIndice++)
                        objEscritor.WriteLine(ConcatenarLineaTxt(tabla.Rows[intIndice], separadorColumnas, tabla.Columns.Count));
                    if (!String.IsNullOrEmpty(textoPieDePagina))
                    {
                        objEscritor.WriteLine(textoPieDePagina);
                        numeroDeFilas++;
                    }
                }
                catch (Exception exExcepcion)
                {
                    throw exExcepcion;
                }
                finally
                {
                    objEscritor.Close();
                }
                return numeroDeFilas;
            }

            /// <summary>
            /// Guarda un Stream en un archivo fisico
            /// </summary>
            /// <param name="datos">Stream</param>
            /// <param name="nombreArchivo">Ruta y nombre del archivo</param>
            /// <creador>Jonathan Contreras</creador>
            /// <fecha_creacion>23-04-2010</fecha_creacion>
            public void GuardarStreamEnArchivo(System.IO.Stream datos, String nombreArchivo)
            {
                System.IO.FileStream objEscritor = null;
                try
                {
                    objEscritor = new System.IO.FileStream(nombreArchivo, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
                    int intLargo = 256;
                    Byte[] arrBitsBuffer = new Byte[intLargo];
                    int intBytesLectura = datos.Read(arrBitsBuffer, 0, intLargo);
                    while (intBytesLectura > 0)
                    {
                        objEscritor.Write(arrBitsBuffer, 0, intBytesLectura);
                        intBytesLectura = datos.Read(arrBitsBuffer, 0, intLargo);
                    }
                }
                catch (Exception exExcepcion)
                {
                    throw exExcepcion;
                }
                finally
                {
                    objEscritor.Close();
                    datos.Close();
                }
            }

            /// <summary>
            /// Guarda un texto en un archivo de texto plano
            /// </summary>
            /// <param name="nombreArchivo">Nombre del archivo</param>
            /// <param name="texto">Texto a Guardar</param>
            /// <creador>Jonathan Contreras</creador>
            /// <fecha_creacion>16-06-2010</fecha_creacion>
            public void GuardarTextoEnArchivo(String nombreArchivo, String texto)
            {
                System.IO.FileStream objArchivo = null;
                System.IO.StreamWriter objEscritor = null;
                try
                {
                    objArchivo = new System.IO.FileStream(nombreArchivo, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
                    objEscritor = new System.IO.StreamWriter(objArchivo, objCodificacion);
                    objEscritor.WriteLine(texto);
                }
                catch (Exception exExcepcion)
                {
                    throw exExcepcion;
                }
                finally
                {
                    objEscritor.Close();
                }
            }

            /// <summary>
            /// Guarda una lista de textos en un archivo de texto plano
            /// </summary>
            /// <param name="nombreArchivo">Nombre del archivo</param>
            /// <param name="textos">Textos a Guardar</param>
            /// <creador>Jonathan Contreras</creador>
            /// <fecha_creacion>16-06-2010</fecha_creacion>
            public void GuardarTextosEnArchivo(String nombreArchivo, string[] textos)
            {
                System.IO.FileStream objArchivo = null;
                System.IO.StreamWriter objEscritor = null;
                try
                {
                    objArchivo = new System.IO.FileStream(nombreArchivo, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
                    objEscritor = new System.IO.StreamWriter(objArchivo, objCodificacion);
                    for (int intIndice = 0; intIndice < textos.Length; intIndice++)
                        objEscritor.WriteLine(textos[intIndice]);
                }
                catch (Exception exExcepcion)
                {
                    throw exExcepcion;
                }
                finally
                {
                    objEscritor.Close();
                }
            }

            /// <summary>
            /// Concatena los nombres de las propiedades de un DTO
            /// </summary>
            /// <typeparam name="T">Tipo DTO</typeparam>
            /// <param name="separadorColumnas">Separador entre datos</param>
            /// <returns>Texto concatenado</returns>
            /// <creador>Jonathan Contreras</creador>
            /// <fecha_creacion>23-04-2010</fecha_creacion>
            private String ConcatenarLineaTxt<T>(String separadorColumnas)
            {
                StringBuilder strbTexto = new StringBuilder();
                System.Reflection.PropertyInfo[] arrPropiedades = typeof(T).GetProperties();
                for (int intIndice = 0; intIndice < arrPropiedades.Length; intIndice++)
                    strbTexto.Append(ConcatenarTexto(arrPropiedades[intIndice].Name, separadorColumnas));
                return strbTexto.ToString();
            }

            /// <summary>
            /// Concatena los datos de una fila de una tabla
            /// </summary>
            /// <param name="fila">Fila de la tabla</param>
            /// <param name="separadorColumnas">Separador entre datos</param>
            /// <param name="numeroFilas">umero de filas de la tabla</param>
            /// <returns>Texto concatenado</returns>
            /// <creador>Jonathan Contreras</creador>
            /// <fecha_creacion>23-04-2010</fecha_creacion>
            private String ConcatenarLineaTxt(System.Data.DataRow fila, String separadorColumnas, int numeroFilas)
            {
                StringBuilder strbTexto = new StringBuilder();
                for (int intIndice = 0; intIndice < numeroFilas; intIndice++)
                    strbTexto.Append(ConcatenarTexto(fila[intIndice].ToString(), separadorColumnas));
                return strbTexto.ToString();
            }

            /// <summary>
            /// Concatena los nombres de las columnas de una tabla
            /// </summary>
            /// <param name="listaColumnas">Lista de columnas</param>
            /// <param name="separadorColumnas">Separador entre datos</param>
            /// <returns>Texto concatenado</returns>
            /// <creador>Jonathan Contreras</creador>
            /// <fecha_creacion>23-04-2010</fecha_creacion>
            private String ConcatenarLineaTxt(System.Data.DataColumnCollection listaColumnas, String separadorColumnas)
            {
                StringBuilder strbTexto = new StringBuilder();
                for (int intIndice = 0; intIndice < listaColumnas.Count; intIndice++)
                    strbTexto.Append(ConcatenarTexto(listaColumnas[intIndice].ColumnName, separadorColumnas));
                return strbTexto.ToString();
            }

            /// <summary>
            /// Concatena los datos de un DTO
            /// </summary>
            /// <typeparam name="T">Tipo DTO</typeparam>
            /// <param name="dato">Instancia del DTO</param>
            /// <param name="separadorColumnas">Separador entre datos</param>
            /// <returns>Texto concatenado</returns>
            /// <creador>Jonathan Contreras</creador>
            /// <fecha_creacion>23-04-2010</fecha_creacion>
            private String ConcatenarLineaTxt<T>(T dato, String separadorColumnas)
            {
                StringBuilder strbTexto = new StringBuilder();
                System.Reflection.PropertyInfo[] arrPropiedades = typeof(T).GetProperties();
                for (int intIndice = 0; intIndice < arrPropiedades.Length; intIndice++)
                    strbTexto.Append(ConcatenarTexto(arrPropiedades[intIndice].GetValue(dato, System.Reflection.BindingFlags.Default, null, null, null).ToString(), separadorColumnas));
                return strbTexto.ToString();
            }

            /// <summary>
            /// Concatena dos textos y reeplaza el separador de columnas en el contenido del texto
            /// </summary>
            /// <param name="texto">Texto</param>
            /// <param name="separadorColumnas">Separador</param>
            /// <returns>texto concatenado</returns>
            private String ConcatenarTexto(String texto, String separadorColumnas)
            {
                return texto.Replace(separadorColumnas, separadorColumnas == strTextoReeplazoUno ? strTextoReeplazoDos : strTextoReeplazoUno) + separadorColumnas;
            }

            /// <summary>
            /// Lista de las lineas de un archivo de texto plano
            /// </summary>
            /// <param name="archivo">Ruta y nombre de archivo</param>
            /// <returns>Lineas del archivo</returns>
            /// <creador>Jonathan Contreras</creador>
            /// <fecha_creacion>30-06-2010</fecha_creacion>
            public String[] ListarLineasDeArchivo(String archivo)
            {
                System.IO.StreamReader objLector = null;
                List<String> arrLineas = new List<String>();
                try
                {
                    objLector = new System.IO.StreamReader(archivo, true);
                    while (!objLector.EndOfStream)
                        arrLineas.Add(objLector.ReadLine());
                }
                catch (Exception exExcepcion)
                {
                    throw exExcepcion;
                }
                finally
                {
                    if (objLector != null) objLector.Close();
                }
                return arrLineas.ToArray();
            }
        }
}
