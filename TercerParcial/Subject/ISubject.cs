using System;
using System.Collections.Generic;
using System.Text;
using TercerParcial.Observer;

namespace TercerParcial.Subject
{
    public interface ISubject
    {
        void RegistrarObserver(IObserver o);
        void EliminarObserver(IObserver o);
        void NotificarObservers();
    }
}
