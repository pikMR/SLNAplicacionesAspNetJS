using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AplicacionesAspNetJS.Pages
{
    public class ContactModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {

            try
            {
                var instanceDS = Services.DomainService.Instance; // recibe lista de contactos
                var contactos = instanceDS.GetListaContactos();
                var jsonContactos = Services.UtilService.GenerarJSON(contactos); // genera json contactos
                var AnyContactos = Services.UtilService.AnyElementsJSON(jsonContactos); // comprueba los multiples contactos
                var jsonContacto = Services.UtilService.GenerarJSON(contactos[0]); // genera json contactoscontactos[0]
                AnyContactos = Services.UtilService.AnyElementsJSON(jsonContacto); // comprueba los multiples contactos
                ViewData["contactos"] = contactos;
                Message = "Your contact page.";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("_ CONTACTOS : " + ex.Message);
            }
        }
    }
}
