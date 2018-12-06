using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionesAspNetJS.Services
{
    /// <summary>
    /// Servicio para los ejemplos que utiliza el patrón Singleton con inicialización diferida
    /// La inicialización diferida de un objeto implica que su creación se aplaza hasta que 
    /// se usa por primera vez. (En este tema, los términos inicialización diferida y creación 
    /// diferida de instancias son sinónimos). La inicialización diferida se usa principalmente 
    /// para mejorar el rendimiento, evitar la pérdida de tiempo en los cálculos y reducir los 
    /// requisitos de memoria de los programas. 
    /// </summary>
    public sealed class UtilService
    {
        private static readonly Lazy<UtilService> lazyService =
            new Lazy<UtilService>(() => new UtilService());

        public static UtilService Instance { get { return lazyService.Value; } }

        private UtilService() { }

        /// <summary>
        /// Obtenemos un objeto cualquiera apartir un json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T DeserializarJSON<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// Generar un objeto string JSON a partir de un objeto cualquiera.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GenerarJSON(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }

        /// <summary>
        /// Comprueba si el elemento obtenido es un Objeto o un array mediante un json
        /// pasado por parametro.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static bool AnyElementsJSON(string json)
        {
            try
            {
                JToken objeto = JToken.Parse(json);
                //var token = objeto["value"];
                if (objeto is JArray)
                {
                    return true;
                }
                /*
                 * -- el objeto será seguramente un JObject
                else if (objeto is JObject)
                {
                    return false;
                }
                */
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }
    }
}
