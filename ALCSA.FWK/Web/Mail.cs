using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace ALCSA.FWK.Web
{
    public class Mail
    {
        public IList<String> Destinatarios { get; set; }

        public IList<String> DestinatariosCC { get; set; }

        public string Emisor { get; set; }

        public string NombreEmisor { get; set; }

        public string Mensaje { get; set; }

        public string Asunto { get; set; }

        public Mail()
        {
            Destinatarios = new List<String>();
            DestinatariosCC = new List<String>();
        }

        /// <summary>
        /// Envia un correo
        /// </summary>
        /// <param name="servidor">servidor de Correo</param>
        /// <returns>Estado del envio</returns>
        /// <creador>Jonathan Contreras</creador>
        /// <fecha_creacion>01-07-2010</fecha_creacion>
        public Boolean Enviar(string servidor)
        {
            return Enviar(servidor, string.Empty, string.Empty, string.Empty);
        }

        /// <summary>
        /// Envia un correo
        /// </summary>
        /// <param name="servidor">Servidor</param>
        /// <param name="usuario">Credenciales: Usuario</param>
        /// <param name="password">Credenciales: Password</param>
        /// <param name="dominio">Credenciales: Dominio</param>
        /// <returns>Estado del envio</returns>
        /// <creador>Jonathan Contreras</creador>
        /// <fecha_creacion>01-07-2010</fecha_creacion>
        public Boolean Enviar(string servidor, string usuario, string password, string dominio)
        {
            try
            {
                MailMessage objMensaje = ConstruirMail();
                SmtpClient objClienteSmtp = new SmtpClient(servidor);

                if (!String.IsNullOrEmpty(usuario) && !String.IsNullOrEmpty(password) && !String.IsNullOrEmpty(dominio))
                    objClienteSmtp.Credentials = new System.Net.NetworkCredential(usuario, password, dominio);

                objClienteSmtp.Send(objMensaje);
                return true;
            }
            catch (Exception exExcepcion)
            {
                Console.WriteLine(String.Format("Error al enviar correo: Excepcion '{0}' : Detalle Excepcion '{1}'", exExcepcion.Message, exExcepcion.InnerException == null ? String.Empty : exExcepcion.InnerException.Message));
                return false;
            }
        }

        public Boolean Enviar(string servidor, int puerto, bool habilitarSSL, string contrasenaEmidor)
        {
            try
            {
                MailMessage objMensaje = ConstruirMail();
                SmtpClient objClienteSmtp = new SmtpClient()
                               {
                                   Host = servidor,
                                   Port = puerto,
                                   EnableSsl = habilitarSSL,
                                   DeliveryMethod = SmtpDeliveryMethod.Network,
                                   UseDefaultCredentials = false,
                                   Credentials = new System.Net.NetworkCredential(Emisor, contrasenaEmidor)
                               };

                objClienteSmtp.Send(objMensaje);
                return true;
            }
            catch (Exception exExcepcion)
            {
                Console.WriteLine(String.Format("Error al enviar correo: Excepcion '{0}' : Detalle Excepcion '{1}'", exExcepcion.Message, exExcepcion.InnerException == null ? String.Empty : exExcepcion.InnerException.Message));
                return false;
            }
        }

        private MailMessage ConstruirMail()
        {
            MailMessage objMensaje = new MailMessage();
            int intIndice;

            if (String.IsNullOrEmpty(NombreEmisor))
                objMensaje.From = new MailAddress(Emisor);
            else objMensaje.From = new MailAddress(Emisor, NombreEmisor);

            for (intIndice = 0; intIndice < Destinatarios.Count; intIndice++)
                objMensaje.To.Add(new MailAddress(Destinatarios[intIndice]));

            for (intIndice = 0; intIndice < DestinatariosCC.Count; intIndice++)
                objMensaje.CC.Add(new MailAddress(DestinatariosCC[intIndice]));

            objMensaje.Subject = Asunto;
            objMensaje.Body = Mensaje;
            objMensaje.IsBodyHtml = true;

            return objMensaje;
        }

        /// <summary>
        /// Valida que un correo sea valido
        /// </summary>
        /// <param name="email">direccion de correo</param>
        /// <returns>true si es valido y false para caso contrario</returns>
        /// <creador>Jonathan Contreras</creador>
        /// <fecha_creacion>01-07-2010</fecha_creacion>
        public static bool EmailValido(string email)
        {
            string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (System.Text.RegularExpressions.Regex.IsMatch(email, expresion) && System.Text.RegularExpressions.Regex.Replace(email, expresion, String.Empty).Length == 0)
                return true;
            return false;
        }
    }
}
