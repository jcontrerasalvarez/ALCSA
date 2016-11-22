// -----------------------------------------------------------------------
// <copyright file="Encriptacion.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace ALCSA.FWK.Seguridad
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Security.Cryptography;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Encriptacion
    {
        #region Simples

        /// <summary>
        /// Encripta un texto en clave CENIT POLAR
        /// </summary>
        /// <param name="texto">Texto a encriptar</param>
        /// <returns>Texto Encriptado</returns>
        /// <creador>Jonathan Contreras</creador>
        /// <fecha_creacion>27-05-2010</fecha_creacion>
        public static String EncriptarEnClaveCenitPolar(String texto)
        {
            return ClaveReemplazoCaracteres(texto, "CENITcenit", "POLARpolar");
        }

        /// <summary>
        /// Desencripta un texto en clave CENIT POLAR
        /// </summary>
        /// <param name="texto">Texto encriptado</param>
        /// <returns>Texto Desencriptado</returns>
        /// <creador>Jonathan Contreras</creador>
        /// <fecha_creacion>27-05-2010</fecha_creacion>
        public static String DesencriptarEnClaveCenitPolar(String texto)
        {
            return ClaveReemplazoCaracteres(texto, "POLARpolar", "CENITcenit");
        }

        /// <summary>
        /// Encripta un texto en clave murcielago
        /// </summary>
        /// <param name="texto">Texto a encriptar</param>
        /// <returns>Texto Encriptado</returns>
        /// <creador>Jonathan Contreras</creador>
        /// <fecha_creacion>27-05-2010</fecha_creacion>
        public static String EncriptarEnMurcielago(String texto)
        {
            return ClaveReemplazoCaracteres(texto, "murcielagoMURCIELAGO", "01234567890123456789");
        }

        /// <summary>
        /// Desencripta un texto en clave Murcielago
        /// </summary>
        /// <param name="texto">Texto encriptado</param>
        /// <returns>Texto Desencriptado</returns>
        /// <creador>Jonathan Contreras</creador>
        /// <fecha_creacion>27-05-2010</fecha_creacion>
        public static String DesencriptarEnMurcielago(String texto)
        {
            return ClaveReemplazoCaracteres(texto, "01234567890123456789", "murcielagoMURCIELAGO");
        }

        /// <summary>
        /// Encripta o desencrita texto en base a reemplazo de caracteres
        /// </summary>
        /// <param name="texto">Texto a encriptar o desencriptar</param>
        /// <param name="datoOriginal">Dato original </param>
        /// <param name="datoReemplazo">dato reemplazo</param>
        /// <returns>Texto encriptado o desencriptado</returns>
        public static String ClaveReemplazoCaracteres(String texto, String datoOriginal, String datoReemplazo)
        {
            Char[] arrCaracteresTexto = texto.ToCharArray();
            Char[] arrCaracteresOriginal = datoOriginal.ToCharArray();
            Char[] arrCaracteresReemplazo = datoReemplazo.ToCharArray();
            StringBuilder strbTextoEncriptado = new StringBuilder();
            int intIndice, intIndiceUno, intIndicador;

            for (intIndice = 0; intIndice < arrCaracteresTexto.Length; intIndice++)
            {
                intIndicador = 0;
                for (intIndiceUno = 0; intIndiceUno < arrCaracteresOriginal.Length; intIndiceUno++)
                    if (arrCaracteresTexto[intIndice] == arrCaracteresOriginal[intIndiceUno])
                    {
                        strbTextoEncriptado.Append(arrCaracteresReemplazo[intIndiceUno]);
                        intIndicador = 1;
                        break;
                    }
                if (intIndicador == 0) strbTextoEncriptado.Append(arrCaracteresTexto[intIndice]);
            }
            return strbTextoEncriptado.ToString();
        }

        #endregion

        #region MD5

        private static String LLAVE_MD5 = "ABCDEFGHIJKLMÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz";

        /// <summary>
        /// Encripta un texto en clave MD5
        /// </summary>
        /// <param name="texto">Texto a encriptar</param>
        /// <returns>Texto Encriptado</returns>
        /// <creador>Jonathan Contreras</creador>
        /// <fecha_creacion>27-05-2010</fecha_creacion>
        public static String EncriptarMD5(string texto)
        {
            //arreglo de bytes donde guardaremos la llave
            byte[] arrListaLlaves;
            //arreglo de bytes donde guardaremos el texto que vamos a encriptar
            byte[] arrListaACifrar = UTF8Encoding.UTF8.GetBytes(texto);

            //se utilizan las clases de encriptación provistas por el Framework Algoritmo MD5
            MD5CryptoServiceProvider objHashmd5 = new MD5CryptoServiceProvider();
            //se guarda la llave para que se le realice hashing
            arrListaLlaves = objHashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(LLAVE_MD5));
            objHashmd5.Clear();

            //Algoritmo 3DAS
            TripleDESCryptoServiceProvider objAlgoritmo = new TripleDESCryptoServiceProvider();
            objAlgoritmo.Key = arrListaLlaves;
            objAlgoritmo.Mode = CipherMode.ECB;
            objAlgoritmo.Padding = PaddingMode.PKCS7;

            //se empieza con la transformación de la cadena
            ICryptoTransform objTransformador = objAlgoritmo.CreateEncryptor();

            //arreglo de bytes donde se guarda la cadena cifrada
            byte[] arrListaResultado = objTransformador.TransformFinalBlock(arrListaACifrar, 0, arrListaACifrar.Length);
            objAlgoritmo.Clear();

            //se regresa el resultado en forma de una cadena
            return Convert.ToBase64String(arrListaResultado, 0, arrListaResultado.Length);
        }

        /// <summary>
        /// Desencripta un texto en clave MD5
        /// </summary>
        /// <param name="texto">Texto encriptado</param>
        /// <returns>Texto Desencriptado</returns>
        /// <creador>Jonathan Contreras</creador>
        /// <fecha_creacion>27-05-2010</fecha_creacion>
        public static string DesencriptarMD5(string texto)
        {
            byte[] arrListaLlaves;
            //convierte el texto en una secuencia de bytes
            byte[] arrListaADescifrar = Convert.FromBase64String(texto);

            //se llama a las clases que tienen los algoritmos de encriptación se le aplica hashing algoritmo MD5
            MD5CryptoServiceProvider objHashmd5 = new MD5CryptoServiceProvider();
            arrListaLlaves = objHashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(LLAVE_MD5));
            objHashmd5.Clear();

            TripleDESCryptoServiceProvider objAlgoritmo = new TripleDESCryptoServiceProvider();
            objAlgoritmo.Key = arrListaLlaves;
            objAlgoritmo.Mode = CipherMode.ECB;
            objAlgoritmo.Padding = PaddingMode.PKCS7;

            ICryptoTransform objTransformador = objAlgoritmo.CreateDecryptor();

            byte[] arrListaResultado = objTransformador.TransformFinalBlock(arrListaADescifrar, 0, arrListaADescifrar.Length);

            objAlgoritmo.Clear();
            //se regresa en forma de cadena
            return UTF8Encoding.UTF8.GetString(arrListaResultado);
        }

        #endregion
    }
}
