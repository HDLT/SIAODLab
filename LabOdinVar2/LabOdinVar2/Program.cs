using System;

namespace LabOdinVar2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размер массива - ");
            DateTime Start = DateTime.Now;
            var mas = InitmasayOfRandomValues(int.Parse(Console.ReadLine()));
            Console.WriteLine("Unsorted: " + string.Join(", ", mas));
            bubsort(mas);
            Console.WriteLine("Sorted: " + string.Join(", ", mas));
            DateTime End = DateTime.Now;
            Console.WriteLine(End - Start);
            Console.ReadKey();
        }

        private static void bubsort(int[] mas)
        {
            int temp;
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[i]>mas[j])
                    {
                        temp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = temp;
                    }
                }
            }
        }

        private static int[] InitmasayOfRandomValues(int size)
        {
            var mas = new int[size];
            var rand = new Random();
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = rand.Next(100);
            }

            return mas;
        }
    }
}
