using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Generador.Negocio.BD
{
    public class Tabla : ALCSA.Generador.Entidades.BD.Tabla
    {
        private IList<ALCSA.Generador.Entidades.BD.Columna> arrColumnas;
        public IList<ALCSA.Generador.Entidades.BD.Columna> Columnas
        {
            get {
                if (arrColumnas == null) arrColumnas = new List<ALCSA.Generador.Entidades.BD.Columna>();
                return arrColumnas; 
            }
            protected set {
                arrColumnas = value;
                LlavesPrimarias = BuscarColumnas(true);
                ColumnasSinLlavesPrimarias = BuscarColumnas(false);
            }
        }

        private IList<ALCSA.Generador.Entidades.BD.Columna> arrLlavesPrimarias;
        public IList<ALCSA.Generador.Entidades.BD.Columna> LlavesPrimarias
        {
            get {
                if (arrLlavesPrimarias == null) arrLlavesPrimarias = new List<ALCSA.Generador.Entidades.BD.Columna>();
                return arrLlavesPrimarias;
            }
            private set { arrLlavesPrimarias = value; }
        }

        private IList<ALCSA.Generador.Entidades.BD.Columna> arrColumnasSinLlavesPrimarias;
        public IList<ALCSA.Generador.Entidades.BD.Columna> ColumnasSinLlavesPrimarias
        {
            get
            {
                if (arrColumnasSinLlavesPrimarias == null) arrColumnasSinLlavesPrimarias = new List<ALCSA.Generador.Entidades.BD.Columna>();
                return arrColumnasSinLlavesPrimarias;
            }
            private set { arrColumnasSinLlavesPrimarias = value; }
        }

        public string NombreSinNomenclatura
        {
            get { return Nombre; }
        }

        public Tabla(string nombreTabla)
        {
            Nombre = nombreTabla;
            Columnas = new ALCSA.Generador.Datos.Esquema().ListarColumnas(Nombre);
        }

        private IList<ALCSA.Generador.Entidades.BD.Columna> BuscarColumnas(bool llavePrimaria)
        {
            IList<ALCSA.Generador.Entidades.BD.Columna> arrColumnas = new List<Entidades.BD.Columna>();
            for (int intIndice = 0; intIndice < Columnas.Count; intIndice++)
                if (llavePrimaria.Equals(Columnas[intIndice].EsLlavePrimaria))
                    arrColumnas.Add(Columnas[intIndice]);
            return arrColumnas;
        }

        public static IList<ALCSA.Generador.Entidades.BD.Tabla> Listar()
        {
            return new ALCSA.Generador.Datos.Esquema().ListarTablas();
        }
    }
}
