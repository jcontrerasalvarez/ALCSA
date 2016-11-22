using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Generador.Negocio.Capas
{
    public class GeneradorNegocio : BaseGenerador
    {
        public GeneradorNegocio(BD.Tabla tabla, string ruta, string espacioNombre) : base(tabla, ruta, espacioNombre) { }

        public void GenerarClase()
        {
            List<String> arrLineas = new List<string>();
            string strNombreEntidad = InfoTabla.Nombre.Replace("_", " ").Replace(" ", String.Empty);// ALCSA.FWK.Texto.ConvertirAMinusculaPrimeraEnMayuscula(InfoTabla.Nombre.Replace("_", " ")).Replace(" ", String.Empty);

            GenerarNamespaces(arrLineas);
            arrLineas.Add("");
            arrLineas.Add(String.Format("namespace ALCSA.Negocio.{0}", EspacioNombre.Substring(0, EspacioNombre.Length - 1)));
            arrLineas.Add("{");
            GenerarComentarioClase(arrLineas);
            arrLineas.Add(string.Format("    public class {1}  : ALCSA.Entidades.{0}{1}", EspacioNombre, strNombreEntidad));
            arrLineas.Add("    {");

            GenerarConstructores(arrLineas, strNombreEntidad);
            GenerarMetodoGuardar(arrLineas);
            GenerarMetodoInsertar(arrLineas, strNombreEntidad);
            GenerarMetodoActualizar(arrLineas, strNombreEntidad);
            GenerarMetodoEliminar(arrLineas, strNombreEntidad);
            GenerarMetodoListar(arrLineas, strNombreEntidad);

            arrLineas.Add("    }");
            arrLineas.Add("}");

            GuardarArchivo(arrLineas, strNombreEntidad, ".cs");
        }

        private void GenerarConstructores(List<String> lineas, string nombreEntidad)
        {
            string strNombreParametro = nombreEntidad.ToLower();
            lineas.Add(string.Format("        public {0}() ", nombreEntidad) + "{ }");
            lineas.Add(string.Empty);
            lineas.Add(string.Format("        public {0}(int id) ", nombreEntidad));

            lineas.Add("        {");
            lineas.Add("             if(id < 1) return;");
            lineas.Add(string.Format("             ALCSA.Entidades.{0}{1} objTemporal = new ALCSA.Datos.{0}{1}().Buscar(id);", EspacioNombre, nombreEntidad));
            lineas.Add(string.Format("             ALCSA.FWK.Reflexion.Mapeador.MapearDatos<ALCSA.Entidades.{0}{1}, {1}>(objTemporal, this);", EspacioNombre, nombreEntidad));
            lineas.Add("        }");
            lineas.Add(string.Empty);
        }

        private void GenerarMetodoListar(List<String> lineas, string nombreEntidad)
        {
            string strNombreParametro = nombreEntidad.ToLower();

            lineas.Add(string.Format("        public IList<ALCSA.Entidades.{0}{1}> Listar()", EspacioNombre, nombreEntidad));
            lineas.Add("        {");

            lineas.Add(string.Format("             return new ALCSA.Datos.{0}{1}().Listar();", EspacioNombre, nombreEntidad));
            lineas.Add("        }");
            lineas.Add("");
        }

        private void GenerarMetodoInsertar(List<String> lineas, string nombreEntidad)
        {
            string strNombreParametro = nombreEntidad.ToLower();

            lineas.Add("        public void Insertar()");
            lineas.Add("        {");
            lineas.Add(string.Format("             new ALCSA.Datos.{0}{1}().Insertar(this);", EspacioNombre, nombreEntidad));
            lineas.Add("        }");
            lineas.Add("");
        }

        private void GenerarMetodoGuardar(List<String> lineas)
        {
            lineas.Add("        public void Guardar()");
            lineas.Add("        {");
            lineas.Add("             if (this.ID > 0) Actualizar(); else Insertar();");
            lineas.Add("        }");
            lineas.Add("");
        }

        private void GenerarMetodoActualizar(List<String> lineas, string nombreEntidad)
        {
            string strNombreParametro = nombreEntidad.ToLower();

            lineas.Add("        public void Actualizar()");
            lineas.Add("        {");
            lineas.Add(string.Format("             new ALCSA.Datos.{0}{1}().Actualizar(this);", EspacioNombre, nombreEntidad));
            lineas.Add("        }");
            lineas.Add("");
        }

        private void GenerarMetodoEliminar(List<String> lineas, string nombreEntidad)
        {
            string strNombreParametro = nombreEntidad.ToLower();

            lineas.Add(string.Format("        public void Eliminar()",
                InfoTabla.LlavesPrimarias.Count > 0 ? Nomenclatura.BuscarTipoDatoNetDesdeBD(InfoTabla.LlavesPrimarias[0]) : string.Empty,
                Nomenclatura.CrearNombreParametroMetodo(InfoTabla.LlavesPrimarias[0])
            ));
            lineas.Add("        {");
            lineas.Add(string.Format("             new ALCSA.Datos.{0}{1}().Eliminar(this.ID);", 
                EspacioNombre, 
                nombreEntidad
            ));
            lineas.Add("        }");
            lineas.Add("");
        }

        private void GenerarNamespaces(List<string> lineas)
        {
            lineas.Add("using System;");
            lineas.Add("using System.Text;");
            lineas.Add("using System.Collections.Generic;");
        }
    }
}
