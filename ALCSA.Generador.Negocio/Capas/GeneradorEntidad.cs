using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Generador.Negocio.Capas
{
    public class GeneradorEntidad : BaseGenerador
    {
        public GeneradorEntidad(BD.Tabla tabla, string ruta, string espacioNombre) : base(tabla, ruta, espacioNombre) { }

        public void GenerarClase()
        {
            List<String> arrLineas = new List<string>();
            string strTipoDato, strCampo, strGetSet = " { get; set; }";
            string strNombreEntidad = InfoTabla.Nombre.Replace("_", " ").Replace(" ", String.Empty);// ALCSA.FWK.Texto.ConvertirAMinusculaPrimeraEnMayuscula(InfoTabla.Nombre.Replace("_", " ")).Replace(" ", String.Empty);
            arrLineas.Add("using System;");
            arrLineas.Add("using System.Text;");
            arrLineas.Add("");
            arrLineas.Add(String.Format("namespace ALCSA.Entidades.{0}", EspacioNombre.Substring(0, EspacioNombre.Length - 1)));
            arrLineas.Add("{");
            GenerarComentarioClase(arrLineas);
            arrLineas.Add(string.Format("    public class {0} : Base", strNombreEntidad));
            arrLineas.Add("    {");

            for (int intIndice = 0; intIndice < InfoTabla.ColumnasSinLlavesPrimarias.Count; intIndice++)
            {
                if (!BD.Nomenclatura.DescartarColumna(InfoTabla.ColumnasSinLlavesPrimarias[intIndice].Nombre))
                {
                    strTipoDato = Nomenclatura.BuscarTipoDatoNetDesdeBD(InfoTabla.ColumnasSinLlavesPrimarias[intIndice]);
                    strCampo = Nomenclatura.CrearNombreCampo(InfoTabla.ColumnasSinLlavesPrimarias[intIndice]);
                    arrLineas.Add(string.Format("        public {0} {1}", strTipoDato, Nomenclatura.CrearNombrePropiedad(InfoTabla.ColumnasSinLlavesPrimarias[intIndice])) + strGetSet);
                    arrLineas.Add("");
                }
            }

            arrLineas.Add("    }");
            arrLineas.Add("}");

            GuardarArchivo(arrLineas, strNombreEntidad, ".cs");
        }
    }
}
