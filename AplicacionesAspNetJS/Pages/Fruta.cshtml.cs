using AplicacionesAspNetJS.Shared;
using AplicacionesAspNetJS.Shared.Reporter;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionesAspNetJS.Pages
{
    public class FrutaModel : PageModel
    {
        public void OnGet()
        {
            CestaFruta cesta = new CestaFruta();
            ManzanaReporter obsManzanas = new ManzanaReporter();
            PeraReporter obsPeras = new PeraReporter();
            cesta.AddObserverFrutal(obsManzanas);
            cesta.AddObserverFrutal(obsPeras);
            cesta.LanzarFrutas();
            ViewData["manzanas"] = obsManzanas.GetListaFinal();
            ViewData["peras"] = obsPeras.GetListaFinal();
        }
    }
}
