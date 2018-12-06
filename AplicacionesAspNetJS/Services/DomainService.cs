using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionesAspNetJS.Services
{
    /// <summary>
    /// Servicio Singleton que maneja elementos del dominio
    /// versión que es segura para subprocesos
    /// </summary>
    public sealed class DomainService
    {
        private static DomainService instance = null;
        private static readonly object padlock = new object();
        public static List<Model.Contacto> LISTA_CONTACTOS = null;

        DomainService(){}

        public static DomainService Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        GenerarMocks();
                        instance = new DomainService();
                    }
                    return instance;
                }
            }
        }

        private static void GenerarMocks()
        {
            if(LISTA_CONTACTOS == null)
            {
                LISTA_CONTACTOS = new List<Model.Contacto>() {
                    new Model.Contacto(){ Nombre = "Benjamin",Telefono = "123.456.789",Url="www.google.es"},
                    new Model.Contacto(){ Nombre = "Ricardo",Telefono = "023.456.789",Url="www.google.es"},
                    new Model.Contacto(){ Nombre = "Vicente",Telefono = "003.456.789",Url="www.google.es"},
                    new Model.Contacto(){ Nombre = "Ana",Telefono = "000.456.789",Url="www.google.es"},
                    new Model.Contacto(){ Nombre = "Antonio",Telefono = "000.056.789",Url="www.google.es"},
                };
            }
            // if(... == null) { ..
        }

        public List<Model.Contacto> GetListaContactos()
        {
            if (LISTA_CONTACTOS == null)
                GenerarMocks();

            return LISTA_CONTACTOS;
        }
    } 
}
