using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

namespace ALCSA.FWK.BD
{
    public class Servicio
    {
        #region Campos y Propiedades"

        public int TiempoEjecucionEnSegundos { get; set; }

        private string strConexion;
        public string Conexion
        {
            get { return strConexion; }
            set { strConexion = value; }
        }

        private List<Parametro> arrParametros;
        public List<Parametro> Parametros
        {
            get {
                if (arrParametros == null) arrParametros = new List<Parametro>();
                return arrParametros; 
            }
            set { arrParametros = value; }
        }

        private Enumeradores.TiposComandos objTipoComando;
        public Enumeradores.TiposComandos TipoComando
        {
            get { return objTipoComando; }
            set { objTipoComando = value; }
        }

        private string strComando;
        public string Comando
        {
            get { return strComando; }
            set { strComando = value; }
        }

        #endregion

        #region Contructores

        public Servicio()
        {
            TipoComando = Enumeradores.TiposComandos.SP;
            CargarTiempoEspera();
        }

        #endregion

        #region Ejecutar

        public int EjecutarSinRetorno()
        {
            int intNumeroFilaAfectadas = -1;
            using (SqlConnection objConexion = CrearConeccion(Conexion))
            {
                using (SqlCommand objComando = new SqlCommand())
                {
                    try
                    {
                        objComando.Connection = objConexion;
                        objComando.CommandType = BuscarTipoComando();
                        objComando.CommandText = Comando;
                        objComando.CommandTimeout = TiempoEjecucionEnSegundos;
                        ValorizarParametrosSQL(objComando);

                        objConexion.Open();
                        intNumeroFilaAfectadas = objComando.ExecuteNonQuery();
                        ValorizarParametros(objComando);
                    }
                    catch (Exception exExcepcion)
                    {
                        throw exExcepcion;
                    }
                    finally
                    {
                        CerrarConexion(objConexion);
                    }
                }
            }
            return intNumeroFilaAfectadas;
        }

        public T EjecutarPrimerRegistro<T>()
        {
            IList<T> arrLista = Ejecutar<T>();
            return arrLista.Count > 0 ? arrLista[0] : default(T);
        }

        public IList<T> Ejecutar<T>()
        {
            IList<T> arrLista = null;
            using (SqlConnection objConexion = CrearConeccion(Conexion))
            {
                using (SqlCommand objComando = new SqlCommand())
                {
                    SqlDataReader objLector = null;
                    try
                    {
                        objComando.Connection = objConexion;
                        objComando.CommandType = BuscarTipoComando();
                        objComando.CommandText = Comando;
                        objComando.CommandTimeout = TiempoEjecucionEnSegundos;
                        ValorizarParametrosSQL(objComando);

                        objConexion.Open();
                        objLector = objComando.ExecuteReader();
                        arrLista = ALCSA.FWK.Reflexion.Conversor.ConvertirDataReaderEnListaDTO<T>(objLector);
                        ValorizarParametros(objComando);
                    }
                    catch (Exception exExcepcion)
                    {
                        throw exExcepcion;
                    }
                    finally
                    {
                        CerrarConexion(objConexion);
                        CerrarDataReader(objLector);
                    }
                }
            }
            return arrLista;
        }

        public object EjecutarEscalar()
        {
            object objRetorno = null;
            using (SqlConnection objConexion = CrearConeccion(Conexion))
            {
                using (SqlCommand objComando = new SqlCommand())
                {
                    try
                    {
                        objComando.Connection = objConexion;
                        objComando.CommandType = BuscarTipoComando();
                        objComando.CommandText = Comando;
                        objComando.CommandTimeout = TiempoEjecucionEnSegundos;
                        ValorizarParametrosSQL(objComando);

                        objConexion.Open();
                        objRetorno = objComando.ExecuteScalar();
                        ValorizarParametros(objComando);
                    }
                    catch (Exception exExcepcion)
                    {
                        throw exExcepcion;
                    }
                    finally
                    {
                        CerrarConexion(objConexion);
                    }
                }
            }
            return objRetorno;
        }

        public DataSet EjecutarDataSet()
        {
            DataSet objRetorno = new DataSet();
            using (SqlConnection objConexion = CrearConeccion(Conexion))
            {
                using (SqlCommand objComando = new SqlCommand())
                {
                    try
                    {
                        objComando.Connection = objConexion;
                        objComando.CommandType = BuscarTipoComando();
                        objComando.CommandText = Comando;
                        objComando.CommandTimeout = TiempoEjecucionEnSegundos;
                        ValorizarParametrosSQL(objComando);
                        using (SqlDataAdapter objAdaptador = new SqlDataAdapter(objComando))
                        {
                            objAdaptador.Fill(objRetorno);
                        }
                        ValorizarParametros(objComando);
                    }
                    catch (Exception exExcepcion)
                    {
                        throw exExcepcion;
                    }
                    finally
                    {
                        CerrarConexion(objConexion);
                    }
                }
            }
            return objRetorno;
        }

        public DataTable EjecutarDataTable()
        {
            DataSet objRetorno = EjecutarDataSet();
            return objRetorno.Tables.Count > 0 ? objRetorno.Tables[0] : null;
        }

        #endregion

        #region Conexion y Comando

        private void CerrarDataReader(SqlDataReader lector)
        {
            if (lector != null)
            {
                lector.Close();
                lector.Dispose();
            }
        }

        private void CerrarConexion(SqlConnection conexion)
        {
            if (conexion != null) conexion.Close();
        }

        private SqlConnection CrearConeccion(String nombreConeccion)
        {
            string strConexion = string.Empty;
            if(ConfigurationManager.ConnectionStrings[nombreConeccion] != null)
                strConexion = System.Configuration.ConfigurationManager.ConnectionStrings[nombreConeccion].ConnectionString;
            if (string.IsNullOrEmpty(strConexion))
                strConexion = System.Configuration.ConfigurationManager.AppSettings[nombreConeccion];

            return new System.Data.SqlClient.SqlConnection(strConexion);
        }

        private CommandType BuscarTipoComando()
        {
            switch (TipoComando)
            { 
                case Enumeradores.TiposComandos.Query :
                    return CommandType.Text;
                default :
                    return CommandType.StoredProcedure;
            }
        }

        #endregion

        #region Parametros

        private void ValorizarParametrosSQL(SqlCommand comando)
        {
            SqlParameter objParametro;
            for (int intIndice = 0; intIndice < Parametros.Count; intIndice++)
            {
                ValidarParametrosFecha(Parametros[intIndice]);
                objParametro = new SqlParameter(Parametros[intIndice].Nombre, Parametros[intIndice].Valor);
                switch (Parametros[intIndice].Direccion)
                {
                    case Enumeradores.Direcciones.Entrada:
                        objParametro.Direction = ParameterDirection.Input;
                        break;
                    case Enumeradores.Direcciones.Salida: 
                        objParametro.Direction = ParameterDirection.Output;
                        break;
                    default :
                        objParametro.Direction = ParameterDirection.ReturnValue;
                        break;
                }
                if (Parametros[intIndice].Tamano > 0)
                    objParametro.Size = Parametros[intIndice].Tamano;
                comando.Parameters.Add(objParametro);
            }
        }

        private void ValorizarParametros(SqlCommand comando)
        {
            Parametros = new List<Parametro>();
            for (int intIndice = 0; intIndice < comando.Parameters.Count; intIndice++)
                Parametros.Add(new Parametro()
                {
                    Nombre = comando.Parameters[intIndice].ParameterName,
                    Valor = comando.Parameters[intIndice].Value,
                    Direccion = comando.Parameters[intIndice].Direction == ParameterDirection.Input
                                ? Enumeradores.Direcciones.Entrada
                                : comando.Parameters[intIndice].Direction == ParameterDirection.Output
                                ? Enumeradores.Direcciones.Salida
                                : Enumeradores.Direcciones.Retorno
                });
        }

        private void ValidarParametrosFecha(Parametro parametro)
        {
            if (parametro != null && parametro.Valor != null && parametro.Valor.GetType().Equals(typeof(DateTime)) && Convert.ToDateTime(parametro.Valor).Year < 1900)
                parametro.Valor = new DateTime(1900, 1, 1);
        }

        #endregion

        #region Otros

        private void CargarTiempoEspera()
        {
            string strMinutos = System.Configuration.ConfigurationManager.AppSettings["TiempoEsperaBDMinutos"];
            string strSegundos = System.Configuration.ConfigurationManager.AppSettings["TiempoEsperaBDSegundos"];
            int intMinutos = 0;
            int intSegundos = 0;
            if (!string.IsNullOrEmpty(strMinutos)) int.TryParse(strMinutos, out intMinutos);
            if (!string.IsNullOrEmpty(strSegundos)) int.TryParse(strSegundos, out intSegundos);

            if (intMinutos + intSegundos < 1) TiempoEjecucionEnSegundos = 30;

            TiempoEjecucionEnSegundos = Convert.ToInt32(new TimeSpan(0, intMinutos, intSegundos).TotalSeconds);
        }

        #endregion
    }
}
