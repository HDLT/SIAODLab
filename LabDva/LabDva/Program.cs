using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LabDva
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch time = new Stopwatch();

            string massiv;
            Random r = new Random();
            var list = new List<int>();
            var raz = r.Next(5, 20);
            for (int i = 0;  i < raz; i++)
            {
                list.Add(r.Next(100));
            }
            Console.WriteLine("Unsorted: " + string.Join(", ", list));
            vsort(list,raz);
            Console.WriteLine("sorted: " + string.Join(", ", list));
        vib:
            Console.Write(" Поиск элемента - 1\n Добавить элемент - 2\n Удалить элекмент - 3\n Выход 0\n Выбор: ");
            var chose = int.Parse(Console.ReadLine());
            if (chose == 1)
            {
                Console.Write("Введите число которое нужно найти - ");
                var key = int.Parse(Console.ReadLine());
                time.Start();
                Console.WriteLine("Искомый элеменет на " + (Poisk(list, key, raz) + 1) + " позиции");
                time.Stop();
                Console.WriteLine(time.Elapsed+"\n");
                time.Reset();
                massiv = list[0].ToString();
                for (int i = 1; i<list.Count;i++)
                {
                    massiv += list[i];
                }
                time.Start();
                Console.WriteLine("Искомый элеменет на " + (massiv.IndexOf(Convert.ToString(key)) + 1) + " позиции");
                time.Stop();
                Console.WriteLine(time.Elapsed);
                goto vib;
            }
            if (chose == 2)
            {
                Console.Write("Введите число которое хотите добавить - ");
                var key = int.Parse(Console.ReadLine());
                list.Add(key);
                raz += 1;
                vsort(list, raz);
                Console.WriteLine("sorted: " + string.Join(", ", list));
                goto vib;
            }
            if ( chose ==3)
            {
                Console.Write("Введите число которое нужно удалить - ");
                var key = int.Parse(Console.ReadLine());
                list.RemoveAt(Poisk(list, key, raz) );
                raz -= 1;
                vsort(list, raz);
                Console.WriteLine("sorted: " + string.Join(", ", list));
                goto vib;
            }
            if (chose == 0)
                Environment.Exit(0);
            else
                Environment.Exit(0);
        }

        private static int Poisk(List<int> list, int key, int raz)
        {
            int left = 0;
            int right = raz;

            while (true)
            {
                int mid = left + (right - left) / 2;

                if (list[mid] == key)
                    return mid;

                if (list[mid] > key)
                    right = mid;
                else
                    left = mid + 1;
            }
        }

        private static void vsort(List<int> list, int raz)
        {
            int temp;
            for (int i = 0; i < raz; i++)
            {
                for (int j = i + 1; j < raz; j++)
                {
                    if (list[i] > list[j])
                    {
                        temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
        }
    }
}
