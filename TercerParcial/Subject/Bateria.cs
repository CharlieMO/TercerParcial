using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using TercerParcial.Observer;
using TercerParcial.Subject;

namespace TercerParcial.Subject
{
    public class Bateria:ISubject
    {
        private Boolean conectado;
        private Boolean cargando;
        private int carga;
        private int tiempo;

        private int MAX_CARGA = 100;
        private int MIN_CARGA = 0;

        private readonly IList _suscriptores;

        public Boolean Conectado
        {
            get => conectado;

            set
            {
                if(conectado != value)
                {
                    conectado = value;
                    NotificarObservers();
                }
            }
        }

        public Boolean Cargando
        {
            get => cargando;

            set
            {
                if(cargando != value)
                {
                    cargando = value;
                    NotificarObservers();
                }
            }
        }

        public int Carga
        {
            get => carga;

            set
            {
                if (carga != value)
                {
                    carga = value;
                    NotificarObservers();
                }
            }
        }

        public int Tiempo
        {
            get => tiempo;

            set
            {
                if (tiempo != value)
                {
                    tiempo = value;
                    NotificarObservers();
                }
            }
        }

        public Bateria(Boolean conectado, Boolean cargando, int carga, int tiempo)
        {
            _suscriptores = new ArrayList();
            this.conectado = conectado;
            this.cargando = cargando;
            this.carga = carga;
            this.tiempo = tiempo;

            Timer ActualizarCargaAutomatica = new Timer();
            ActualizarCargaAutomatica.Interval = 10000;
            ActualizarCargaAutomatica.Elapsed += timermethod;
            ActualizarCargaAutomatica.Start();

        }

        private void timermethod(object sender, ElapsedEventArgs e)
        {
            if (conectado)
                carga += 10;
            else
                carga -= 10;

            Imprimir();
        }

        public void EliminarObserver(IObserver o)
        {
            if (_suscriptores.Contains(o))
                _suscriptores.Remove(o);
        }

        public void NotificarObservers()
        {
            int numconectado = 0;
            int numcargando = 0;

            if (conectado)
                numconectado = 1;
            else
                numconectado = 0;

            if (cargando)
                numcargando = 1;
            else
                numcargando = 0;

            int[] valores = { numconectado, numcargando, carga, tiempo };

            foreach (var o in _suscriptores)
            {
                var observer = (IObserver)o;
                observer.Update(valores);
            }
        }

        public void RegistrarObserver(IObserver o)
        {
            if (!_suscriptores.Contains(o))
                _suscriptores.Add(o);
        }

        public void Imprimir()
        {
            Console.Clear();

            if (conectado)
                Console.WriteLine("La batería está conectada.\n");
            else
                Console.WriteLine("La batería no está conectada.\n");

            if (cargando && carga < 100)
                Console.WriteLine("La batería está cargando.\n");
            else if((cargando && carga > 100))
                Console.WriteLine("La batería está al máximo.\n");
            else if(cargando == false)
                Console.WriteLine("La batería no está cargando.\n");

            if (carga > MAX_CARGA)
                carga = 100;

            if (carga < MIN_CARGA)
                carga = 0;

            Console.WriteLine("La carga es de " + carga + "%.\n");

            if (cargando)
            {
                int aux = 100 - carga;

                Console.WriteLine("Quedan " + aux + " segundos para finalizar la carga.\n");
            }
            else
                Console.WriteLine("Quedan " + carga + " segundos para la descarga.\n");
        }
    }
}

