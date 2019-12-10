using System;
using System.Collections.Generic;
using System.Text;
using TercerParcial.Subject;

namespace TercerParcial.Observer
{
    public class Observer : IObserver
    {
        private static readonly int MIN_CARGA = 0;
        private static readonly int MAX_CARGA = 100;

        private Boolean conectado;
        private Boolean cargando;
        private int carga;
        private int tiempo;

        private ISubject subject;

        public Observer(ISubject subject)
        {
            this.subject = subject;
            subject.RegistrarObserver(this);
        }

        public void Update(object o)
        {
            int[] arrayInt = null;
            if (o.GetType() == typeof(int[]))
                arrayInt = (int[])o;

            if ((arrayInt != null) && (arrayInt.Length == 4))
            {
                if (arrayInt[0] == 1)
                    conectado = true;
                else
                    conectado = false;

                if (arrayInt[1] == 1)
                    cargando = true;
                else
                    cargando = false;

                carga = arrayInt[2];
                tiempo = arrayInt[3];
            }
        }
    }
}
