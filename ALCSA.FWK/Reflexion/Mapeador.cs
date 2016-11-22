using System;
using System.Collections.Generic;
using System.Text;

namespace ALCSA.FWK.Reflexion
{
    public class Mapeador
    {
        /// <summary>
        /// Metodo que permite copiar los valores de las propiedades del mismo nombre entre un DTO y otro
        /// </summary>
        /// <typeparam name="T">Tipo de dato DTO origen</typeparam>
        /// <typeparam name="X">Tipo de dato DTO destino</typeparam>
        /// <param name="datoOriginal">DTO origen</param>
        /// <param name="datoCopia">DTO destino</param>
        /// <creador>Jonathan Contreras</creador>
        /// <fecha_creacion>27-09-2010</fecha_creacion>
        public static void MapearDatos<T, X>(T datoOriginal, X datoCopia)
        {
            if (datoOriginal == null || datoCopia == null) return;
            System.Reflection.PropertyInfo[] arrPropiedades = typeof(T).GetProperties();
            List<String> arrListaNombrePropiedades = new List<string>();
            for (int intIndice = 0; intIndice < arrPropiedades.Length; intIndice++)
                arrListaNombrePropiedades.Add(arrPropiedades[intIndice].Name);
            MapearDatos<T, X>(datoOriginal, datoCopia, arrListaNombrePropiedades.ToArray());
        }

        /// <summary>
        /// Metodo que permite copiar los valores de las propiedades del mismo nombre entre un DTO y otro
        /// </summary>
        /// <typeparam name="T">Tipo de dato DTO origen</typeparam>
        /// <typeparam name="X">Tipo de dato DTO destino</typeparam>
        /// <param name="datoOriginal">DTO origen</param>
        /// <param name="datoCopia">DTO destino</param>
        /// <creador>Jonathan Contreras</creador>
        /// <fecha_creacion>27-09-2010</fecha_creacion>
        public static void MapearDatos<T, X>(T datoOriginal, X datoCopia, String[] listaPropiedades)
        {
            if (datoOriginal == null || datoCopia == null) return;

            System.Reflection.PropertyInfo objPropiedadX = null, objPropiedadT = null;
            Type objTipoX = typeof(X), objTipoT = typeof(T), objTipoConversion = null;

            Object objValorOriginal = null;
            System.ComponentModel.NullableConverter objConversor = null;

            for (int intIndice = 0; intIndice < listaPropiedades.Length; intIndice++)
            {
                objPropiedadT = objTipoT.GetProperty(listaPropiedades[intIndice]);
                if (objPropiedadT != null)
                {
                    objPropiedadX = objTipoX.GetProperty(listaPropiedades[intIndice]);
                    if (objPropiedadX == null) objPropiedadX = objTipoX.GetProperty(Texto.SepararTextoPorMayusculas(listaPropiedades[intIndice]).Replace(" ", "_").ToUpper());
                    if (objPropiedadX == null) objPropiedadX = objTipoX.GetProperty(Texto.ConvertirAMinusculaPrimeraEnMayuscula(listaPropiedades[intIndice].ToLower().Replace("_", " ")).Replace(" ", ""));

                    if (objPropiedadX != null && objPropiedadX.CanWrite)
                    {
                        objTipoConversion = objPropiedadX.PropertyType;
                        if (objTipoConversion.IsGenericType)
                        {
                            objConversor = new System.ComponentModel.NullableConverter(objTipoConversion);
                            objTipoConversion = objConversor.UnderlyingType;
                        }

                        if ((objValorOriginal = objPropiedadT.GetValue(datoOriginal, null)) != null)
                        {
                            objValorOriginal = Convert.ChangeType(objValorOriginal, objTipoConversion);
                            if (objValorOriginal != null) objPropiedadX.SetValue(datoCopia, objValorOriginal, System.Reflection.BindingFlags.Default, null, null, null);
                        }
                    }
                }
            }
            ValidarDatosFecha<X>(ref datoCopia);
        }

        /// <summary>
        /// Las fechas que tengan valeres menores a 01/01/1900, se les asocia el valor mensionado.
        /// Esto es para evitar problemas en las consultas a SQL
        /// </summary>
        /// <typeparam name="T">Tipo de Dato</typeparam>
        /// <param name="dato">DTO</param>
        /// <creador>Jonathan Contreras</creador>
        /// <fecha_creacion>06-10-2010</fecha_creacion>
        public static void ValidarDatosFecha<T>(ref T dato)
        {
            System.Reflection.PropertyInfo[] arrPropiedades = typeof(T).GetProperties();
            DateTime datFecha;
            for (int intIndice = 0; intIndice < arrPropiedades.Length; intIndice++)
                if (arrPropiedades[intIndice].PropertyType == typeof(DateTime) && (datFecha = Convert.ToDateTime(arrPropiedades[intIndice].GetValue(dato, null))).Year < 1900)
                    arrPropiedades[intIndice].SetValue(dato, new DateTime(1900, 1, 1), System.Reflection.BindingFlags.Default, null, null, null);
        }
    }
}
