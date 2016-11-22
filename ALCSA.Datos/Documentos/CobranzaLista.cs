using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Datos.Documentos
{
    public class CobranzaLista
    {
        public IList<Entidades.Documentos.CobranzaLista> Listar(
            string tipo,
            string rutCliente,
            string rutDeudor,
            int idTribunal,
            string rol,
            string rolExhorto)
        {
            FWK.BD.Servicio objServicio = new FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_Tipo", Valor = tipo, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_RutCliente", Valor = rutCliente, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_RutDeudor", Valor = rutDeudor, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@INT_IdTribunal", Valor = idTribunal, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_RolJuicio", Valor = rol, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new FWK.BD.Parametro() { Nombre = "@VC_RolExhorto", Valor = rolExhorto, Direccion = FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Comando = "dbo.SPALCDOC_COBRANZAS_LISTAR";
            return objServicio.Ejecutar<Entidades.Documentos.CobranzaLista>();
        }
    }
}
