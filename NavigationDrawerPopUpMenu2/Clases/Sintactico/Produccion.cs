﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationDrawerPopUpMenu2.Clases.Sintactico
{
    class Produccion
    {   public int n { get; set; }
        public char izq { get; set; }
        public string der { get; set; }
        public object dato { get; set; }

        public Produccion(int n, char izq, string der, object dato)
        {
            this.n = n;
            this.izq = izq;
            this.der = der;
            this.dato = dato;
        }

        public Produccion()
        {
        }
    }
}
