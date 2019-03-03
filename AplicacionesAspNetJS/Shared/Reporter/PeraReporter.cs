using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplicacionesAspNetJS.Model;

namespace AplicacionesAspNetJS.Shared.Reporter
{
    public class PeraReporter : IObserver<Fruta>
    {
        private IDisposable unsubscriber; // variable utilizada para salir de la subscripción.
        private Pera last;
        private List<Pera> listaFinal = new List<Pera>();

        public void OnError(Exception error)
        {
            //throw new NotImplementedException();
        }

        public void OnNext(Fruta value)
        {
            if (value.GetType() == typeof(Pera))
            {
                last = (Pera)value;
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
