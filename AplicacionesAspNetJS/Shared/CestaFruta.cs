using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplicacionesAspNetJS.Model;

namespace AplicacionesAspNetJS.Shared
{
    public class CestaFruta : IObservable<Fruta>
    {

        private List<IObserver<Fruta>> observers;
        private List<Fruta> frutas;

        public CestaFruta()
        {
            observers = new List<IObserver<Fruta>>();
            frutas = new List<Fruta>();
            frutas.Add(new Manzana() { ArbolId = 2 , Color ="Roja"});
            frutas.Add(new Manzana() { ArbolId = 2, Color = "Verde" });
            frutas.Add(new Pera() { ArbolId = 5, Color = "Amarilla" });
            frutas.Add(new Pera() { ArbolId = 8, Color = "Roja" });
        }

        public void AddObserverFrutal(IObserver<Fruta> observerFrutal)
        {
            observers.Add(observerFrutal);
        }

        public void LanzarFrutas()
        {
            foreach (var fr in frutas)
            {
                foreach (var observer in observers)
                {
                    observer.OnNext(fr);
                }
            }

            foreach (var observer in observers)
            {
                observer.OnCompleted();
            }
        }

        public IDisposable Subscribe(IObserver<Fruta> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);

                /*foreach(var item in frutas)
                {
                    // envio de datos
                    observer.OnNext(item);
                }*/
            }
            return new Unsubscriber<Fruta>(observers,observer);
        }

    }

    internal class Unsubscriber<Fruta> : IDisposable
    {
        private List<IObserver<Fruta>> _observers;
        private IObserver<Fruta> _observer;

        internal Unsubscriber(List<IObserver<Fruta>> observers, IObserver<Fruta> observer)
        {
            this._observers = observers;
            this._observer = observer;
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}
