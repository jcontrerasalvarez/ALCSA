using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.FWK.Web
{
    public class Sitio
    {
        /// <summary>
        /// Funcion que permite al usuario descargar un archivo
        /// </summary>
        /// <param name="respuesta">Response del sitio web</param>
        /// <param name="datos">Datos a descargar</param>
        /// <param name="nombre">Nombre del archivo</param>
        /// <creador>Jonathan Contreras</creador>
        /// <fecha_creacion>03-10-2011</fecha_creacion>
        public void DescargarArchivo(System.Web.HttpResponse respuesta, System.IO.MemoryStream datos, String nombre)
        {
            DescargarArchivo(respuesta, datos, nombre, "application/octet-stream", System.Text.Encoding.Default);
        }

        /// <summary>
        /// Funcion que permite al usuario descargar un archivo
        /// </summary>
        /// <param name="respuesta">Response del sitio web</param>
        /// <param name="datos">Datos a descargar</param>
        /// <param name="nombre">Nombre del archivo</param>
        /// <creador>Jonathan Contreras</creador>
        /// <fecha_creacion>03-10-2011</fecha_creacion>
        public void DescargarArchivo(System.Web.HttpResponse respuesta, System.IO.MemoryStream datos, String nombre, String tipo, System.Text.Encoding codificacion)
        {
            try
            {
                nombre = nombre.Replace(" ", "_");

                string[] arrCaracteres = { ",", "?", "¿", "'", "!", "¡", "=", "|", "/", "\\" };
                for (int intIndice = 0; intIndice < arrCaracteres.Length; intIndice++)
                    nombre = nombre.Replace(arrCaracteres[intIndice], string.Empty);

                byte[] arrDatos = datos.ToArray();

                respuesta.Clear();
                respuesta.Buffer = true;
                respuesta.AddHeader("content-disposition", String.Format("attachment;filename={0}", nombre));
                respuesta.AddHeader("Content-Length", arrDatos.Length.ToString());
                respuesta.Charset = "";
                respuesta.ContentType = tipo;
                respuesta.ContentEncoding = codificacion;
                respuesta.BinaryWrite(arrDatos);
                respuesta.Flush();
                respuesta.End();
            }
            catch { }
        }

        public static string ExtraerValorQueryString(System.Web.HttpRequest solicitud, string nombreLlave)
        {
            string strValor = solicitud.QueryString[nombreLlave];
            return string.IsNullOrWhiteSpace(strValor) ? string.Empty : strValor;
        }

        public static int ExtraerValorQueryStringComoEntero(System.Web.HttpRequest solicitud, string nombreLlave)
        {
            string strValor = ExtraerValorQueryString(solicitud, nombreLlave);
            if (string.IsNullOrEmpty(strValor)) return 0;
            int intValor = 0;
            int.TryParse(strValor, out intValor);
            return intValor;
        }
    }
}
