﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Seccion : BaseEntity
    {
        public int IdSeccion { get; set; }
        public string Nombre { get; set; }

        public Seccion()
        {
        }
    }
}
