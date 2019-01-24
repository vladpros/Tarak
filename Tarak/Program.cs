using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tarak
{
    class Program
    {
        static int[] Mass = new int[4];
        static object _locker = new object();

        static void Main(string[] args)
        {
            var pts1 = new ParameterizedThreadStart(Threads);
            TimerCallback tm = new TimerCallback(Monitor);


            Timer timer = new Timer(tm, null, 0, 10000);
            Thread.Sleep(1000);

            List<Tarak> tarak = new List<Tarak>();

            for (int i = 0; i < 4; i++)
            {
                tarak.Add(new Tarak());
            }

            for (int i = 0; i < 4; i++)
            {
                Thread thread = new Thread(pts1);
                tarak[i].i = i;
                thread.Start(tarak[i]);
            }

            Console.ReadLine();

        }

        static void Threads(object obj1)
        {

            Tarak tar = (Tarak)obj1;

            while (true)
            {
                Mass[tar.i] += tar.Move();

                Thread.Sleep(3000);
            }

        }

        static void Monitor(object obj)
        {

            Console.Clear();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Tarakan #{i} proshol {Mass[i]}m");
            }
        }
    }
}
