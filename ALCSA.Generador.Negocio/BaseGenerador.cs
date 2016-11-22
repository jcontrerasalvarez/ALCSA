using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Generador.Negocio
{
    public class BaseGenerador
    {
        private BD.Tabla objInfoTabla;
        public BD.Tabla InfoTabla
        {
            get { return objInfoTabla; }
            protected set { objInfoTabla = value; }
        }

        private string strRutaCarpeta;
        public string RutaCarpeta
        {
            get
            {
                if (strRutaCarpeta == null) strRutaCarpeta = String.Empty;
                if (!strRutaCarpeta.EndsWith("\\")) strRutaCarpeta += "\\";
                return strRutaCarpeta;
            }
            protected set { strRutaCarpeta = value; }
        }

        private string strEspacioNombre;
        public string EspacioNombre
        {
            get {
                if (strEspacioNombre == null) strEspacioNombre = string.Empty;
                if (!strEspacioNombre.EndsWith(".")) strEspacioNombre = strEspacioNombre + ".";
                return strEspacioNombre; 
            }
            set { strEspacioNombre = value; }
        }

        public BaseGenerador(string tabla, string ruta) : this(new BD.Tabla(tabla), ruta, string.Empty) { }

        public BaseGenerador(string tabla, string ruta, string espacioNombre) : this(new BD.Tabla(tabla), ruta) { }

        public BaseGenerador(BD.Tabla tabla, string ruta) : this(tabla, ruta, string.Empty) { }

        public BaseGenerador(BD.Tabla tabla, string ruta, string espacioNombre)
        {
            InfoTabla = tabla;
            RutaCarpeta = ruta;
            EspacioNombre = espacioNombre;
            if (!System.IO.Directory.Exists(RutaCarpeta)) System.IO.Directory.CreateDirectory(RutaCarpeta);
        }

        protected void GuardarArchivo(List<string> lineas, string nombre, string extension)
        {
            if (!System.IO.Directory.Exists(RutaCarpeta)) System.IO.Directory.CreateDirectory(RutaCarpeta);
            if (!extension.StartsWith(".")) extension = "." + extension;
            string strRuta = RutaCarpeta + nombre + extension;
            if (System.IO.File.Exists(strRuta)) System.IO.File.Delete(strRuta);
            new ALCSA.FWK.IO.ArchivoTextoPlano().GuardarTextosEnArchivo(strRuta, lineas.ToArray());
        }

        protected void GenerarComentarioClase(List<string> lineas)
        {
            lineas.Add("    /// <summary>");
            lineas.Add("    /// ");
            lineas.Add("    /// </summary>");
            lineas.Add("    /// <creador>Generador Código</creador>");
            lineas.Add(String.Format("    /// <fecha_creacion>{0}</fecha_creacion>", DateTime.Now.ToString("dd-MM-yyyy")));
        }
    }
}
