using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace ALCSA.Negocio.CargasMasivas
{
    public class Proceso : Entidades.CargasMasivas.Proceso
    {
        #region Propiedades

        private List<Entidades.CargasMasivas.Registro> _Registros;
        public List<Entidades.CargasMasivas.Registro> Registros
        {
            get {
                if (_Registros == null) _Registros = new List<Entidades.CargasMasivas.Registro>();
                return _Registros;
            }
            set { _Registros = value; }
        }

        private string CodigoTemporal { get; set; }

        #endregion

        #region Constructores

        public Proceso() { }

        public Proceso(string codigo, string usuario)
        {
            this.Codigo = codigo;
            this.UsuarioDueno = usuario;

            IList<Entidades.Temporales.Temporal> arrDatos = new Datos.Temporales.Temporal().Listar(codigo, usuario);
            if (arrDatos.Count.Equals(0)) return;

            CodigoTemporal = arrDatos[0].Codigo;
            Registros = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Entidades.CargasMasivas.Registro>>(arrDatos[0].TextoTemporal);
        }

        #endregion

        #region CRUD

        public void GuardarTemporal()
        {
            Eliminar();

            Entidades.Temporales.Temporal objEntidad = new Entidades.Temporales.Temporal() { 
                Codigo = string.Empty, 
                CodigoProceso = this.Codigo, 
                UsuarioDueno = this.UsuarioDueno,
                Estado = Estatico.ESTADO_PENDIENTE,
                TextoTemporal = Newtonsoft.Json.JsonConvert.SerializeObject(Registros)
            };

            new Datos.Temporales.Temporal().Insertar(objEntidad);
        }

        public void GuardarTablasFinales()
        {
            Datos.CargasMasivas.Proceso objProcesoDatos = new Datos.CargasMasivas.Proceso();
            foreach (Entidades.CargasMasivas.Registro objRegistro in Registros)
                objProcesoDatos.Insertar(objRegistro, this.Codigo, this.UsuarioDueno);

            Temporales.Temporal objTemporal = new Temporales.Temporal(CodigoTemporal);
            objTemporal.Estado = Estatico.ESTADO_OK;
            objTemporal.TextoTemporal = Newtonsoft.Json.JsonConvert.SerializeObject(Registros);
            objTemporal.Actualizar();
        }

        public void Eliminar()
        {
            new Temporales.Temporal().EliminarPorProcesoUsuario(this.Codigo, this.UsuarioDueno);
        }

        #endregion

        #region Asignar Datos que no estan en archivo

        public void AsignarCliente(string rutCliente)
        {
            foreach (Entidades.CargasMasivas.Registro objRegistro in Registros)
                objRegistro.RutCliente = rutCliente;
        }

        public void ValidarDatos()
        {
            foreach (Entidades.CargasMasivas.Registro objRegistro in Registros)
            {
                objRegistro.Estado = Estatico.ESTADO_OK;

                if (!FWK.IdentificacionTributaria.RutValido(string.Format("{0}{1}", objRegistro.Rut, objRegistro.DigitoVerificador)))
                    objRegistro.Mensaje = "El Rut del deudor no es válido";
                else if (string.IsNullOrEmpty(objRegistro.Nombre))
                    objRegistro.Mensaje = "El nombre está vacio";
                else if (string.IsNullOrEmpty(objRegistro.ApellidoPaterno))
                    objRegistro.Mensaje = "El apellido paterno está vacio";
                else if (string.IsNullOrEmpty(objRegistro.Nombre))
                    objRegistro.Mensaje = "El apellido materno está vacio";

                else if (string.IsNullOrEmpty(objRegistro.Calle))
                    objRegistro.Mensaje = "La calle esta vacia";
                else if (string.IsNullOrEmpty(objRegistro.Comuna))
                    objRegistro.Mensaje = "La comuna esta vacia";

                objRegistro.Estado = string.IsNullOrEmpty(objRegistro.Mensaje) ? Estatico.ESTADO_OK : Estatico.ESTADO_ERROR;
            }
        }

        #endregion

        #region Carga de datos desde archivo Excel

        public void CargarDesdeArchivo(Stream archivoExcel, Enumerador.TipoArchivoExcel tipo, bool limpiarListaActual)
        {
            if (limpiarListaActual) Registros.Clear();
            LeerArchivoExcel(archivoExcel, tipo);
        }

        private void LeerArchivoExcel(Stream archivoExcel, Enumerador.TipoArchivoExcel tipo)
        {
            if (tipo == Enumerador.TipoArchivoExcel.XLS)
                LeerArchivoExcel(new HSSFWorkbook(archivoExcel));
            else LeerArchivoExcel(new XSSFWorkbook(archivoExcel));
        }

        private void LeerArchivoExcel(IWorkbook archivoExcel)
        {
            ISheet objHoja = archivoExcel.GetSheetAt(0);
            if (objHoja == null) return;

            int intUltimaFila = objHoja.LastRowNum;
            if (intUltimaFila.Equals(0)) return;

            Entidades.CargasMasivas.Registro objRegistro = null;

            for (int intIndice = 1; intIndice <= intUltimaFila; intIndice++)
            {
                objRegistro = LeerRegistroDesdeFila(objHoja.GetRow(intIndice));
                if (objRegistro == null) break;
                Registros.Add(objRegistro);
            }
        }

        private Entidades.CargasMasivas.Registro LeerRegistroDesdeFila(IRow fila)
        {
            if (fila == null) return null;
            Entidades.CargasMasivas.Registro objRegistro = new Entidades.CargasMasivas.Registro();
            // ----------------------------------------------------------------------------
            objRegistro.Rut = LeerCelda(fila.GetCell(Estatico.POSICION_RUT, MissingCellPolicy.RETURN_NULL_AND_BLANK));
            objRegistro.DigitoVerificador = LeerCelda(fila.GetCell(Estatico.POSICION_DIGITO_VERIFICADOR, MissingCellPolicy.RETURN_NULL_AND_BLANK));
            objRegistro.Nombre = LeerCelda(fila.GetCell(Estatico.POSICION_NOMBRE, MissingCellPolicy.RETURN_NULL_AND_BLANK));
            objRegistro.ApellidoPaterno = LeerCelda(fila.GetCell(Estatico.POSICION_APELLIDO_PATERNO, MissingCellPolicy.RETURN_NULL_AND_BLANK));
            objRegistro.ApellidoMaterno = LeerCelda(fila.GetCell(Estatico.POSICION_APELLIDO_MATERNO, MissingCellPolicy.RETURN_NULL_AND_BLANK));
            // ----------------------------------------------------------------------------
            objRegistro.Calle = LeerCelda(fila.GetCell(Estatico.POSICION_CALLE, MissingCellPolicy.RETURN_NULL_AND_BLANK));
            objRegistro.Numero = LeerCelda(fila.GetCell(Estatico.POSICION_NUMERO, MissingCellPolicy.RETURN_NULL_AND_BLANK));
            objRegistro.NumeroDpto = LeerCelda(fila.GetCell(Estatico.POSICION_NUMERODPTO, MissingCellPolicy.RETURN_NULL_AND_BLANK));
            objRegistro.Block = LeerCelda(fila.GetCell(Estatico.POSICION_BLOCK, MissingCellPolicy.RETURN_NULL_AND_BLANK));
            objRegistro.Villa = LeerCelda(fila.GetCell(Estatico.POSICION_VILLA, MissingCellPolicy.RETURN_NULL_AND_BLANK));
            objRegistro.Comuna = LeerCelda(fila.GetCell(Estatico.POSICION_COMUNA, MissingCellPolicy.RETURN_NULL_AND_BLANK));
            // ----------------------------------------------------------------------------
            objRegistro.Monto = LeerCelda(fila.GetCell(Estatico.POSICION_MONTO, MissingCellPolicy.RETURN_NULL_AND_BLANK));
            // ----------------------------------------------------------------------------
            objRegistro.Rut = objRegistro.Rut.Replace(".", string.Empty).Replace("-", string.Empty);
            // ----------------------------------------------------------------------------
            if (string.IsNullOrEmpty(objRegistro.Monto)) objRegistro.Monto = "0";
            if (string.IsNullOrEmpty(objRegistro.DigitoVerificador) && objRegistro.Rut.Length > 1)
            {
                objRegistro.DigitoVerificador = objRegistro.Rut.Substring(objRegistro.Rut.Length - 1);
                objRegistro.Rut = objRegistro.Rut.Substring(0, objRegistro.Rut.Length - 1);
            }
            // ----------------------------------------------------------------------------
            return objRegistro;
        }

        private string LeerCelda(ICell celda)
        {
            if (celda == null) return string.Empty;
            object objValor = null;

            switch (celda.CellType)
            {
                case CellType.Blank:
                    objValor = string.Empty;
                    break;
                case CellType.Boolean: 
                    objValor = celda.BooleanCellValue;
                    break;
                case CellType.Error:
                     objValor = string.Empty;
                    break;
                case CellType.Formula:
                    objValor = celda.ToString();
                    break;
                case CellType.Numeric:
                    objValor = celda.NumericCellValue;
                    break;
                case CellType.String:
                     objValor = celda.StringCellValue;
                    break;
                case CellType.Unknown: 
                    objValor = celda.ToString();
                    break;
            }

            return objValor != null ? objValor.ToString().Trim() : string.Empty;
        }

        #endregion
    }
}
