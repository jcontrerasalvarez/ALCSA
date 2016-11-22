using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Generador.Negocio
{
    public class GeneradorPieza : BaseGenerador
    {
        public GeneradorPieza(string tabla, string ruta) : base(tabla, ruta) { }

        public void GenerarPiezas(string strEspacioNombre)
        {
            if (InfoTabla.LlavesPrimarias.Count == 0) return;

            string strRutaTemporal = RutaCarpeta + "SP";
            if (!System.IO.Directory.Exists(strRutaTemporal)) System.IO.Directory.CreateDirectory(strRutaTemporal);
            BD.GeneradorSP objGeneradorSP = new BD.GeneradorSP(InfoTabla, strRutaTemporal);
            objGeneradorSP.GenerarProcedimientos();

            strRutaTemporal = RutaCarpeta + "Entidades";
            if (!System.IO.Directory.Exists(strRutaTemporal)) System.IO.Directory.CreateDirectory(strRutaTemporal);
            Capas.GeneradorEntidad objEntidades = new Capas.GeneradorEntidad(InfoTabla, strRutaTemporal, strEspacioNombre);
            objEntidades.GenerarClase();

            strRutaTemporal = RutaCarpeta + "Datos";
            if (!System.IO.Directory.Exists(strRutaTemporal)) System.IO.Directory.CreateDirectory(strRutaTemporal);
            Capas.GeneradorDatos objDatos = new Capas.GeneradorDatos(InfoTabla, strRutaTemporal, strEspacioNombre);
            objDatos.GenerarClase();

            strRutaTemporal = RutaCarpeta + "Negocio";
            if (!System.IO.Directory.Exists(strRutaTemporal)) System.IO.Directory.CreateDirectory(strRutaTemporal);
            Capas.GeneradorNegocio objNegocio = new Capas.GeneradorNegocio(InfoTabla, strRutaTemporal, strEspacioNombre);
            objNegocio.GenerarClase();

            // strRutaTemporal = RutaCarpeta + "Presentacion";
            // if (!System.IO.Directory.Exists(strRutaTemporal)) System.IO.Directory.CreateDirectory(strRutaTemporal);
            // Capas.GeneradorPresentacion objPresentacion = new Capas.GeneradorPresentacion(InfoTabla, strRutaTemporal, strEspacioNombre);
            // objPresentacion.GenerarPaginas();
        }
    }
}
