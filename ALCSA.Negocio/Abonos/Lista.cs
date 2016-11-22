using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Abonos
{
    public class Lista
    {
        public DataTable ListarDesglose(int idAbono, int idCobranza)
        {
            return new Datos.Abonos.Lista().ListarDesglose(idAbono, idCobranza);
        }
    }
}
