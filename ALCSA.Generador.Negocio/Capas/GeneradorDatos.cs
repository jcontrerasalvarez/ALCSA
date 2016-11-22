using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Generador.Negocio.Capas
{
    public class GeneradorDatos : BaseGenerador
    {
        public GeneradorDatos(BD.Tabla tabla, string ruta, string espacioNombre) : base(tabla, ruta, espacioNombre) { }

        public void GenerarClase()
        {
            List<String> arrLineas = new List<string>();
            string strNombreEntidad = InfoTabla.Nombre.Replace("_", " ").Replace(" ", String.Empty);// ALCSA.FWK.Texto.ConvertirAMinusculaPrimeraEnMayuscula(InfoTabla.Nombre.Replace("_", " ")).Replace(" ", String.Empty);

            GenerarNamespaces(arrLineas);
            arrLineas.Add("");
            arrLineas.Add(String.Format("namespace ALCSA.Datos.{0}", EspacioNombre.Substring(0, EspacioNombre.Length - 1)));
            arrLineas.Add("{");
            GenerarComentarioClase(arrLineas);
            arrLineas.Add(string.Format("    public class {0}", strNombreEntidad));
            arrLineas.Add("    {");

            GenerarMetodoBuscar(arrLineas, strNombreEntidad);
            GenerarMetodoInsertar(arrLineas, strNombreEntidad);
            GenerarMetodoActualizar(arrLineas, strNombreEntidad);
            GenerarMetodoEliminar(arrLineas, strNombreEntidad);
            GenerarMetodoListar(arrLineas, strNombreEntidad);

            arrLineas.Add("    }");
            arrLineas.Add("}");

            GuardarArchivo(arrLineas, strNombreEntidad, ".cs");
        }

        private void GenerarMetodoBuscar(List<String> lineas, string nombreEntidad)
        {
            string strNombreParametro = nombreEntidad.ToLower();

            lineas.Add(string.Format("        public ALCSA.Entidades.{0}{1} Buscar({2} id)", 
                new object[]{
                    EspacioNombre, 
                    nombreEntidad,
                    InfoTabla.LlavesPrimarias.Count > 0 ? Nomenclatura.BuscarTipoDatoNetDesdeBD(InfoTabla.LlavesPrimarias[0]) : string.Empty
                }));
            lineas.Add("        {");
            lineas.Add("             ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();");
            lineas.Add("             objServicio.Conexion = Conexion.ALCSA;");
            lineas.Add("             objServicio.Comando = \"\";");

            GenerarParametrosBD(InfoTabla.LlavesPrimarias, lineas, string.Empty);

            lineas.Add(string.Format("             IList<ALCSA.Entidades.{0}{1}> arrRespuesta = objServicio.Ejecutar<ALCSA.Entidades.{0}{1}>();", EspacioNombre, nombreEntidad));
            lineas.Add(string.Format("             return arrRespuesta.Count > 0 ? arrRespuesta[0] : null;", strNombreParametro));
            lineas.Add("        }");
            lineas.Add("");
        }

        private void GenerarMetodoListar(List<String> lineas, string nombreEntidad)
        {
            string strNombreParametro = nombreEntidad.ToLower();

            lineas.Add(string.Format("        public IList<ALCSA.Entidades.{0}{1}> Listar()", EspacioNombre, nombreEntidad));
            lineas.Add("        {");
            lineas.Add("             ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();");
            lineas.Add("             objServicio.Conexion = Conexion.ALCSA;");
            lineas.Add("             objServicio.Comando = \"\";");

            lineas.Add(string.Format("             return objServicio.Ejecutar<ALCSA.Entidades.{0}{1}>();", EspacioNombre, nombreEntidad));
            lineas.Add("        }");
            lineas.Add("");
        }

        private void GenerarMetodoInsertar(List<String> lineas, string nombreEntidad)
        {
            string strNombreParametro = nombreEntidad.ToLower();

            lineas.Add(string.Format("        public void Insertar(ALCSA.Entidades.{0}{1} {2})", EspacioNombre, nombreEntidad, strNombreParametro));
            lineas.Add("        {");
            lineas.Add("             ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();");
            lineas.Add("             objServicio.Conexion = Conexion.ALCSA;");
            lineas.Add("             objServicio.Comando = \"\";");

            GenerarParametrosBD(InfoTabla.ColumnasSinLlavesPrimarias, lineas, strNombreParametro, false);
            GenerarParametrosBD(InfoTabla.LlavesPrimarias, lineas, strNombreParametro, true);

            lineas.Add("             objServicio.EjecutarSinRetorno();");

            lineas.Add(string.Empty);
            lineas.Add(string.Format("             {0}.ID = Convert.ToInt32(objServicio.Parametros[objServicio.Parametros.Count - 1].Valor);", strNombreParametro));

            lineas.Add("        }");
            lineas.Add(string.Empty);
        }

        private void GenerarMetodoActualizar(List<String> lineas, string nombreEntidad)
        {
            string strNombreParametro = nombreEntidad.ToLower();

            lineas.Add(string.Format("        public void Actualizar(ALCSA.Entidades.{0}{1} {2})", EspacioNombre, nombreEntidad, strNombreParametro));
            lineas.Add("        {");
            lineas.Add("             ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();");
            lineas.Add("             objServicio.Conexion = Conexion.ALCSA;");
            lineas.Add("             objServicio.Comando = \"\";");

            GenerarParametrosBD(InfoTabla.Columnas, lineas, strNombreParametro);

            lineas.Add("             objServicio.EjecutarSinRetorno();");
            lineas.Add("        }");
            lineas.Add("");
        }

        private void GenerarMetodoEliminar(List<String> lineas, string nombreEntidad)
        {
            string strNombreParametro = nombreEntidad.ToLower();

            lineas.Add(string.Format("        public void Eliminar({0} id)",
                InfoTabla.LlavesPrimarias.Count > 0 ? Nomenclatura.BuscarTipoDatoNetDesdeBD(InfoTabla.LlavesPrimarias[0]) : string.Empty
            ));
            lineas.Add("        {");
            lineas.Add("             ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();");
            lineas.Add("             objServicio.Conexion = Conexion.ALCSA;");
            lineas.Add("             objServicio.Comando = \"\";");

            GenerarParametrosBD(InfoTabla.LlavesPrimarias, lineas, string.Empty);

            lineas.Add("             objServicio.EjecutarSinRetorno();");
            lineas.Add("        }");
            lineas.Add("");
        }

        private void GenerarParametrosBD(IList<ALCSA.Generador.Entidades.BD.Columna> columnas, List<String> lineas, string nombreParametroMetodo)
        {
            GenerarParametrosBD(columnas, lineas, nombreParametroMetodo, false);
        }

        private void GenerarParametrosBD(IList<ALCSA.Generador.Entidades.BD.Columna> columnas, List<String> lineas, string nombreParametroMetodo, bool esSalida)
        {
            if (!string.IsNullOrEmpty(nombreParametroMetodo)) nombreParametroMetodo += ".";
            StringBuilder strbTexto;
            for (int intIndice = 0; intIndice < columnas.Count; intIndice++)
            {
                if (!BD.Nomenclatura.DescartarColumnaComoParametro(columnas[intIndice].Nombre))
                {
                    strbTexto = new StringBuilder();
                    strbTexto.Append("             objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { ");
                    strbTexto.AppendFormat("Nombre = \"{0}\", Valor = {1}{2}, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.{3}",
                        new object[]{
                                string.Format(esSalida ? "{0}Salida" : "{0}", BD.Nomenclatura.ConcatenarParametroSP(columnas[intIndice])),
                                nombreParametroMetodo,
                                !string.IsNullOrEmpty(nombreParametroMetodo) ? Nomenclatura.CrearNombrePropiedad(columnas[intIndice]) : "id",
                                esSalida ? "Salida" : "Entrada"
                        });
                    strbTexto.Append(" });");
                    lineas.Add(strbTexto.ToString());
                }
            }
        }

        private void GenerarNamespaces(List<string> lineas)
        {
            lineas.Add("using System;");
            lineas.Add("using System.Text;");
            lineas.Add("using System.Collections.Generic;");
        }
    }
}
