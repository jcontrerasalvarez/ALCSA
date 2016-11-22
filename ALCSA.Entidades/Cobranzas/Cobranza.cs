using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.Cobranzas
{
    /// <summary>
    /// 
    /// </summary>
    /// <creador>Generador Código</creador>
    /// <fecha_creacion>20-04-2014</fecha_creacion>
    public class Cobranza : Base
    {
        public string EstadoOt { get; set; }

        public DateTime FechaAsignacion { get; set; }

        public DateTime FechaTermino { get; set; }

        public DateTime Fproceso { get; set; }

        public int IdMateria { get; set; }

        public int IdProcedimiento { get; set; }

        public int IdProducto { get; set; }

        public int IdRemesa { get; set; }

        public string NombreCargaMasiva { get; set; }

        public string Nrooperacion { get; set; }

        public string RutCli { get; set; }

        public string RutDeudor { get; set; }

        public string Tipo { get; set; }

        public string Tipocobranza { get; set; }

        public string UserAsignador { get; set; }

        public string UserResponsable { get; set; }

        public string Usuario { get; set; }

        public string UsuarioProceso { get; set; }

        public bool EsDemandaImpresa { get; set; }

        public string TipoActividad { get; set; }

        public string NombreDeudor { get; set; }

        public string NombreCliente { get; set; }
    }
}
