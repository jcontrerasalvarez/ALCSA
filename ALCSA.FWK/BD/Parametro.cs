using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.FWK.BD
{
    public class Parametro
    {
        private string strNombre;
        public string Nombre
        {
            get { return strNombre; }
            set { strNombre = value; }
        }

        private object objValor;
        public object Valor
        {
            get { return objValor; }
            set { objValor = value; }
        }

        private Enumeradores.Direcciones objDireccion;
        public Enumeradores.Direcciones Direccion
        {
            get { return objDireccion; }
            set { objDireccion = value; }
        }

        private int intTamano;
        public int Tamano
        {
            get { return intTamano; }
            set { intTamano = value; }
        }
    }
}
