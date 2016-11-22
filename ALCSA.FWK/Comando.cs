using System;
using System.Text;
using System.Diagnostics;

namespace ALCSA.FWK
{
    public class Comando
    {
        /// <summary>
        /// Correv un ejecutable via line de comando
        /// </summary>
        /// <param name="rutaEjecutable">Ruta y nombre del ejecutable</param>
        /// <returns>Salida por linea de comando (output)</returns>
        /// <creador>Jonathan Contreras</creador>
        /// <fecha_creacion>24-02-2011</fecha_creacion>
        public static string EjecutarLineaDeComando(string rutaEjecutable)
        {
            return EjecutarLineaDeComando(rutaEjecutable, null);
        }

        /// <summary>
        /// Correv un ejecutable via line de comando
        /// </summary>
        /// <param name="rutaEjecutable">Ruta y nombre del ejecutable</param>
        /// <param name="argumentos">Argumentos</param>
        /// <returns>Salida por linea de comando (output)</returns>
        /// <creador>Jonathan Contreras</creador>
        /// <fecha_creacion>24-02-2011</fecha_creacion>
        public static string EjecutarLineaDeComando(string rutaEjecutable, string[] argumentos)
        {
            Process objProceso = new Process();
            objProceso.StartInfo.FileName = rutaEjecutable;
            if (argumentos != null && argumentos.Length > 0)
            {
                StringBuilder strbArgumentos = new StringBuilder();
                for (int intIndice = 0; intIndice < argumentos.Length; intIndice++)
                    strbArgumentos.AppendFormat("{0} ", argumentos[intIndice]);
                objProceso.StartInfo.Arguments = strbArgumentos.ToString();
            }
            objProceso.StartInfo.UseShellExecute = false;
            objProceso.StartInfo.CreateNoWindow = true;
            objProceso.StartInfo.RedirectStandardOutput = true;
            objProceso.Start();
            objProceso.WaitForExit();
            return objProceso.StandardOutput.ReadToEnd();
        }
    }
}
