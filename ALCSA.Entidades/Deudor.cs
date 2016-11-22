using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades
{
    public class Deudor : Base
    {
        public string RutDeudor { get; set; }

        public string Amaterno { get; set; }

        public string Apaterno { get; set; }

        public string Celular1 { get; set; }

        public string Ctacte { get; set; }

        public int Ecivil { get; set; }

        public string Email { get; set; }

        public DateTime Fcreacion { get; set; }

        public DateTime Fmodificacion { get; set; }

        public DateTime Fnacimiento { get; set; }

        public int IdBanco { get; set; }

        public int IdProfesion { get; set; }

        public string Nombres { get; set; }

        public string Rsocial { get; set; }

        public string RutUsuCrea { get; set; }

        public string RutUsuModi { get; set; }

        public string Status { get; set; }

        public string Telefono1 { get; set; }

        public string Telefono2 { get; set; }

        public string Tipopersona { get; set; }
    }
}
