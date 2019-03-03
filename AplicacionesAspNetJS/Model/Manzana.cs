using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionesAspNetJS.Model
{
    public class Manzana : Fruta
    {
        public override string ToString()
        {
            return "Manzana color : " + this.Color + " y Manzana arbol : " + this.ArbolId;
        }
    }
}
