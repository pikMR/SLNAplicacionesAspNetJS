using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplicacionesAspNetJS.Model;
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

        public static List<Model.Contacto> GetListaContactos()
        {
            if (LISTA_CONTACTOS == null)
                GenerarMocks();

            return LISTA_CONTACTOS;
        }

        public static dynamic GetListaContactosJSON()
        {
            return UtilService.GenerarJSON(GetListaContactos());
        }

        public static List<Model.Contacto> GetListaContactosLinq()
        {
            var textJSON = GetListaContactosJSON();
            var root = (JContainer)JToken.Parse(textJSON);
            dynamic elementosJSON = JToken.Parse(textJSON);

            // Obtener lista de telefonos ContactoTelefonico
            var _telefonos = root.Descendants().Select(x => ((JToken)x))
       .Where(x => (x.Parent.Type == JTokenType.Object && ((JProperty)x).Name == "Telefono"))
           .Select(t => new ContactoTelefonico { Telefono = ((JProperty)t).Value.ToString() }).ToList();

            // Crear una GuiaTelefonica y Agregar Lista de ContactoTelefonico
            var guia = new GuiaTelefonica()
            {
                Contactos =
                root.Descendants().Select(x => ((JToken)x))
                    .Where(x => (x.Parent.Type == JTokenType.Object && ((JProperty)x).Name == "Telefono"))
                        .Select(t => new ContactoTelefonico { Telefono = ((JProperty)t).Value.ToString() }).ToList()
            };
            
            return new List<Model.Contacto>();
        }

        private static dynamic getListaDebug()
        {
            var textJSON = GetListaContactosJSON();
            var root = (JContainer)JToken.Parse(textJSON);
            var query = root.Descendants().Where(jt => (jt.Type == JTokenType.Object) || (jt.Type == JTokenType.Array))
                .Select(jo =>
                {
                    if (jo is JObject)
                    {
                        if (jo.Parent != null && jo.Parent.Type == JTokenType.Array)
                            return jo["Telefono"];
                                    // No help needed in this section               
                                    // populate and return a JObject for the List<JObject> result 
                                    // next line appears for compilation purposes only--I actually want a populated JObject to be returned
                                    return new JObject();
                    }
                
                    if (jo is JArray)
                    {
                        var items = jo.Children<JObject>().SelectMany(o => o.Properties()).Where(p => p.Value.Type == JTokenType.String);
                        return new JObject(items);
                    }
                    return null;
                }).Where(jo => jo != null)
                .ToList();

            return query;
        }
    } 
}
