﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALCSA.Entidades.Alzamientos
{
    public class Actividad : Base
    {
        public string Codigo { get; set; }

        public string Nombre { get; set; }

        public int Orden { get; set; }
    }
}
