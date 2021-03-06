﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Entidades.Cobranzas
{
    public class DocumentoEstandard3 : Base
    {
        public decimal Cuantia { get; set; }

        public string DireRepresLegal { get; set; }

        public string DocFundantes { get; set; }

        public DateTime Fproceso { get; set; }

        public int IdCobranza { get; set; }

        public int IdDomicilioDemandado { get; set; }

        public int IdDomicilioDemandado2 { get; set; }

        public string NomRepresLegal { get; set; }

        public string Observacion { get; set; }

        public string Petitorio { get; set; }

        public string ProfesionRepresLegal { get; set; }

        public string RelacionHechos { get; set; }

        public string RutDemandado2 { get; set; }

        public string RutRepresLegal { get; set; }

        public string Txtcargo { get; set; }

        public DateTime Txtfechainiciorelacionlaboral { get; set; }

        public DateTime Txtfechaterminorelacionlaboral { get; set; }

        public decimal Txtmontoremuneracion { get; set; }

        public string Urldocumento { get; set; }

        public string NombreDemandadoDos { get; set; }

        public string DireccionDemandadoDos { get; set; }

        public string DireccionDemandado { get; set; }
    }
}
