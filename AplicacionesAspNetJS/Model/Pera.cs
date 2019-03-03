using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionesAspNetJS.Model
{
    public class Pera : Fruta
    {
        public override string ToString()
        {
            return "Pera color : " + this.Color + " y Pera arbol : " + this.ArbolId;
        }
    }
}
