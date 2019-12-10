using System;
using System.Timers;
using TercerParcial.Observer;
using TercerParcial.Subject;

namespace TercerParcial
{
    class Program
    {
        static void Main(string[] args)
        {
            ISubject _bateria = new Bateria(false, false, 55, 50);
            IObserver _display = new Observer.Observer(_bateria);

            Console.WriteLine("Presiona 1 para conectar la batería.\n");
            Console.WriteLine("Presiona 2 para desconectar la batería.\n");

            while (true)
            {
                var aux = Console.ReadKey();

                if (aux.Key == ConsoleKey.D1)
                {
                    Console.WriteLine("\n");
                    ((Bateria)_bateria).Conectado = true;
                    ((Bateria)_bateria).Cargando = true;
                }
                if (aux.Key == ConsoleKey.D2)
                {
                    Console.WriteLine("\n");
                    ((Bateria)_bateria).Conectado = false;
                    ((Bateria)_bateria).Cargando = false;
                }
            }
        }

    }
}
