using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Datos.Abonos
{
    public class AbonoCheque
    {
        public ALCSA.Entidades.Abonos.AbonoCheque Buscar(int id)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Comando = "";
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdAbonomch", Valor = id, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            IList<ALCSA.Entidades.Abonos.AbonoCheque> arrRespuesta = objServicio.Ejecutar<ALCSA.Entidades.Abonos.AbonoCheque>();
            return arrRespuesta.Count > 0 ? arrRespuesta[0] : null;
        }

        public void Insertar(ALCSA.Entidades.Abonos.AbonoCheque cheque)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Comando = "dbo.SPALC_ABONOSMCH_INSERTAR";
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdCobranza", Valor = cheque.IdCobranza, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdAbonoComprobante", Valor = cheque.IdAbonoComprobante, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@DAT_Fpago", Valor = cheque.Fpago, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_Nrocheque", Valor = cheque.Nrocheque, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_Serie", Valor = cheque.Serie, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@FLT_Montoabono", Valor = cheque.Montoabono, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_Username", Valor = cheque.Username, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdAbonomchSalida", Valor = 0, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Salida });

            objServicio.EjecutarSinRetorno();

            cheque.ID = Convert.ToInt32(objServicio.Parametros[objServicio.Parametros.Count - 1].Valor);
        }

        public void Actualizar(ALCSA.Entidades.Abonos.AbonoCheque cheque)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Comando = "";
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdAbonomch", Valor = cheque.ID, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_Cuentadeposito", Valor = cheque.Cuentadeposito, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@CHR_Estado", Valor = cheque.Estado, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@DAT_Fechadeposito", Valor = cheque.Fechadeposito, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@DAT_Fechaliberacion", Valor = cheque.Fechaliberacion, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@DAT_Fpago", Valor = cheque.Fpago, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@DAT_Fproceso", Valor = cheque.Fproceso, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdAbonoComprobante", Valor = cheque.IdAbonoComprobante, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdBanco", Valor = cheque.IdBanco, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdCobranza", Valor = cheque.IdCobranza, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@FLT_Montoabono", Valor = cheque.Montoabono, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_Nrocheque", Valor = cheque.Nrocheque, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_Nrocomprobantedeposito", Valor = cheque.Nrocomprobantedeposito, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_RutDeudor", Valor = cheque.RutDeudor, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_Serie", Valor = cheque.Serie, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_Userdeposito", Valor = cheque.Userdeposito, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@VC_Username", Valor = cheque.Username, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.EjecutarSinRetorno();
        }

        public void Eliminar(int id)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Comando = "";
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdAbonomch", Valor = id, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.EjecutarSinRetorno();
        }

        public IList<ALCSA.Entidades.Abonos.AbonoCheque> Listar(int idAbonoComprobante)
        {
            ALCSA.FWK.BD.Servicio objServicio = new ALCSA.FWK.BD.Servicio();
            objServicio.Conexion = Conexion.ALCSA;
            objServicio.Parametros.Add(new ALCSA.FWK.BD.Parametro() { Nombre = "@INT_IdAbonoComprobante", Valor = idAbonoComprobante, Direccion = ALCSA.FWK.BD.Enumeradores.Direcciones.Entrada });
            objServicio.Comando = "";
            return objServicio.Ejecutar<ALCSA.Entidades.Abonos.AbonoCheque>();
        }
    }
}
