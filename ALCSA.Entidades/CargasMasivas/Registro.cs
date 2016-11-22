using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.CargasMasivas
{
    public class Registro
    {
        public string RutCliente { get; set; }

        public string Rut { get; set; }
        public string DigitoVerificador { get; set; }

        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }

        public string Calle { get; set; }
        public string Numero { get; set; }
        public string NumeroDpto { get; set; }
        public string Villa { get; set; }
        public string Block { get; set; }
        public string Comuna { get; set; }

        public string Monto { get; set; }
        public string FechaVencimiento { get; set; }

        public string IdTipoCobranza { get; set; }
        public string NombreTipoCobranza { get; set; }

        public string IdProcedimiento { get; set; }
        public string NombreProcedimiento { get; set; }

        public string IdMateria { get; set; }
        public string NombreMateria { get; set; }

        public string IdProducto { get; set; }
        public string NombreProducto { get; set; }

        public int IdRemesa { get; set; }
        public string NombreRemesa { get; set; }

        public string Estado { get; set; }
        public string Mensaje { get; set; }
    }
}
