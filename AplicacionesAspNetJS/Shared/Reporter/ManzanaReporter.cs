using AplicacionesAspNetJS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionesAspNetJS.Shared.Reporter
{
    public class ManzanaReporter : IObserver<Fruta>
    {
        private IDisposable unsubscriber; // variable utilizada para salir de la subscripción.
        private Manzana last;
        private List<Manzana> listaFinal = new List<Manzana>();

        public void OnError(Exception error)
        {
            //throw new NotImplementedException();
        }

        public void OnNext(Fruta value)
        {
            if(value.GetType() == typeof(Manzana))
            {
                last = (Manzana)value;
                listaFinal.Add(last);
            }
        }

        public virtual void Subscribe(CestaFruta provider)
        {
            unsubscriber = provider.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }

        public virtual void OnCompleted()
        {
            Console.WriteLine("Fruta añadida: " + last.ToString());
        }

        public IEnumerable<Fruta> GetListaFinal()
        {
            return listaFinal;
        }

    }
}
