using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.Cobranzas
{
    public class DocumentoEstandard2 : Base
    {
        public DateTime Fproceso { get; set; }

        public int IdCobranza { get; set; }

        public string Txtabogado { get; set; }

        public string Txtactividad { get; set; }

        public string Txtactividad2 { get; set; }

        public string Txtcaratulajuicio { get; set; }

        public string Txtdemandado { get; set; }

        public string Txtdemandante { get; set; }

        public string Txtdocumentosfundantes { get; set; }

        public string Txtdomicilio { get; set; }

        public string Txtdomicilioabogado { get; set; }

        public string Txtdomiciliodemandante { get; set; }

        public DateTime Txtfechasubasta { get; set; }

        public string Txtjuzgado { get; set; }

        public string Txtmateria { get; set; }

        public string Txtminimosubasta { get; set; }

        public decimal Txtmontodemandado { get; set; }

        public string Txtnrotitulo { get; set; }

        public string Txtobservacion { get; set; }

        public string Txtrepresentante { get; set; }

        public string Txtrepresentante2 { get; set; }

        public string Txtrol { get; set; }

        public string Txtrutabogado { get; set; }

        public string Txtrutdemandado { get; set; }

        public string Txtrutdemandante { get; set; }

        public string Txttipojuicio { get; set; }

        public string Txttiponotificacion { get; set; }

        public string Txttitulofunda { get; set; }

        public string Urldocumento { get; set; }
    }
}
