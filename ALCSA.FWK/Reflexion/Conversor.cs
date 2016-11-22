using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.FWK.Reflexion
{
    /// <summary>
    /// Permite convertir tipos de datos en otros tipos o listas
    /// </summary>
    /// <creador>Jonathan Contreras</creador>
    /// <fecha_creacion>23-04-2010</fecha_creacion>
    public class Conversor
    {
        /// <summary>
        /// Convierte un IDataReader en una lista de instancias DTO
        /// </summary>
        /// <typeparam name="T">Tipo DTO</typeparam>
        /// <param name="datos">IDataReader</param>
        /// <returns>Lista de instancias DTO</returns>
        /// <creador>Jonathan Contreras</creador>
        /// <fecha_creacion>23-04-2010</fecha_creacion>
        public static IList<T> ConvertirDataReaderEnListaDTO<T>(System.Data.IDataReader datos)
        {
            IList<T> listaDTO = new List<T>();
            Type objTipoDato = typeof(T);
            int intIndice = 0;
            while (datos.Read())
            {
                listaDTO.Add(System.Activator.CreateInstance<T>());
                for (intIndice = 0; intIndice < datos.FieldCount; intIndice++)
                    AsignarValorPropiedad<T>(listaDTO[listaDTO.Count - 1], datos[intIndice], BuscarPropiedad(datos.GetName(intIndice), objTipoDato));
            }
            return listaDTO;
        }

        public static List<T> ConvertirDataReaderEnListaPrimitivos<T>(System.Data.IDataReader datos)
        {
            List<T> arrListaDatos = new List<T>();
            Type objTipoDato = typeof(T);
            while (datos.Read())
                arrListaDatos.Add(ConvertirTipo<T>(datos[0]));
            return arrListaDatos;
        }

        private static T ConvertirTipo<T>(Object valor)
        {
            Type objTipoConversion = typeof(T);
            if (objTipoConversion.IsGenericType) objTipoConversion = new System.ComponentModel.NullableConverter(objTipoConversion).UnderlyingType;
            return (T)Convert.ChangeType(valor, objTipoConversion);
        }

        private static System.Reflection.PropertyInfo BuscarPropiedad(string nombre, Type tipo)
        {
            System.Reflection.PropertyInfo objPropiedad = tipo.GetProperty(nombre);
            if (objPropiedad != null) return objPropiedad;
            objPropiedad = tipo.GetProperty(ALCSA.FWK.Texto.ConvertirAMinusculaPrimeraEnMayuscula(nombre.Replace("_", " ")).Replace(" ", string.Empty));
            if (objPropiedad != null) return objPropiedad;
            return null;
        }

        /// <summary>
        /// Convierte un DataTable en una lista de instancias DTO
        /// </summary>
        /// <typeparam name="T">Tipo DTO</typeparam>
        /// <param name="datos">Tabla</param>
        /// <returns>Lista de instancias DTO</returns>
        /// <creador>Jonathan Contreras</creador>
        /// <fecha_creacion>23-04-2010</fecha_creacion>
        public static IList<T> ConvertirDataTableEnListaDTO<T>(System.Data.DataTable datos)
        {
            IList<T> listaDTO = new List<T>();
            Type objTipoDato = typeof(T);
            int intIndiceColumna = 0;

            for (int intIndiceFila = 0; intIndiceFila < datos.Rows.Count; intIndiceFila++)
            {
                listaDTO.Add(System.Activator.CreateInstance<T>());
                for (intIndiceColumna = 0; intIndiceColumna < datos.Columns.Count; intIndiceColumna++)
                    AsignarValorPropiedad<T>(listaDTO[listaDTO.Count - 1], 
                                            datos.Rows[intIndiceFila][intIndiceColumna], 
                                            BuscarPropiedad(datos.Columns[intIndiceColumna].ColumnName, objTipoDato
                                        ));
            }
            return listaDTO;
        }

        /// <summary>
        /// Asigna un valor a una propiedad de un objeto
        /// </summary> 
        /// <typeparam name="T">Tipo de dato</typeparam>
        /// <param name="objeto">Objeto al cual se le asignara el valor a su propiedad</param>
        /// <param name="valorPropiedad">Valor de la propiedad</param>
        /// <param name="propiedad">Propiedad del objeto</param>
        /// <creador>Jonathan Contreras</creador>
        /// <fecha_creacion>23-04-2010</fecha_creacion>
        public static void AsignarValorPropiedad<T>(T objeto, Object valorPropiedad, System.Reflection.PropertyInfo propiedad)
        {
            if (propiedad != null && valorPropiedad != null && valorPropiedad.GetType() != typeof(System.DBNull))
            {
                Type objTipoConversion = propiedad.PropertyType;
                if (objTipoConversion.IsGenericType) objTipoConversion = new System.ComponentModel.NullableConverter(objTipoConversion).UnderlyingType;
                valorPropiedad = Convert.ChangeType(valorPropiedad, objTipoConversion);
                propiedad.SetValue(objeto, valorPropiedad, System.Reflection.BindingFlags.Default, null, null, null);
            }
        }
    }
}
