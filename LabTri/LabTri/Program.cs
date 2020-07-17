using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabTri
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch time = new Stopwatch();

            string text = "Somebody once told me The world is gonna roll me I aint the sharpest tool in the shed";
            Console.WriteLine(text);
            int chose;
        vib:

            Console.Write(" Поиск подстроки - 1\n Добавить подстроку - 2\n Выход 0\n Ввод: ");
            try
            {
            chose = int.Parse(Console.ReadLine());
            }
            catch
            {
                goto vib;
            }
            
            if (chose == 1)
            {
                Console.Write(" Чувствительность к регистру. Да - 1\n Нет - 2\n Ввод: ");
                var reg2 = int.Parse(Console.ReadLine());

                Console.Write("Введите подстроку которую нужно найти - ");
                var key = Console.ReadLine();

                if (reg2 == 1)
                {
                    if (getFirstEntry(text,key) == -1)
                    {
                        Console.WriteLine("Такой подстроки нет");
                    }
                    else
                    {
                        time.Start();
                        Console.WriteLine("Подстрока начинается с " + getFirstEntry(text, key) + " позиции");
                        time.Stop();
                        Console.WriteLine(time.Elapsed+"\n");
                        time.Reset();
                        time.Start();
                        Console.WriteLine("Подстрока начинается с " + text.IndexOf(key) + " позиции");
                        time.Stop();
                        Console.WriteLine(time.Elapsed);
                    }
                }
                else
                {
                    if (getFirstEntry(text.ToLower(), key.ToLower()) == -1)
                    {
                        Console.WriteLine("Такой подстроки нет");
                    }
                    else
                    {
                        Console.WriteLine("Подстрока начинается с " + getFirstEntry(text.ToLower(), key.ToLower()) + " позиции");
                    }
                }



                goto vib;
            }
            if (chose == 2)
            {
                Console.Write("Введите слово которое хотите добавить - ");
                var key = Console.ReadLine();
                text += " " + key;
                Console.WriteLine(text);
                goto vib;
            }
            if (chose == 0)
                Environment.Exit(0);
            else
                Environment.Exit(0);
        }

        public static Dictionary<Char, int> makeOffsetTable(string pattern)
        {
            Dictionary<Char, int> offsetTable = new Dictionary<char, int>();
            for (int i = 0; i <= 255; i++)
            {
                offsetTable[(char)i]= pattern.Length;
            }
            for (int i = 0; i < pattern.Length - 1; i++)
            {
                offsetTable[pattern[i]]= pattern.Length - i - 1;
            }
            return offsetTable;
        }
        public static int getFirstEntry(String s, String p)
        {
            Dictionary<Char, int> offsetTable = makeOffsetTable(p);
            if (s.Length < p.Length)
            {
                return -1;
            }

            int i = p.Length - 1;
            int j = i;
            int k = i;

            while (j >= 0 && i <= s.Length - 1)
            {
                j = p.Length - 1;
                k = i;
                while (j >= 0 && s[k] == p[j])
                {
                    k--;
                    j--;
                }
                i += offsetTable[s[i]];
            }
            if (k >= s.Length - p.Length)
            {
                return -1;
            }
            else
            {
                return k + 1;
            }
        }
    }



























        /*
        private static int Search(string key, string text)
        {
            int res = -1;
            int[] pf = GetPref(key);
            int index = 0;

            for (int i = 0; i < text.Length; i++)
            {
                while (index > 0 && key[index] != text[i]) 
                { 
                    index = pf[index - 1]; 
                }
                if (key[index] == text[i])
                {
                    index++;
                }
                if (index == key.Length)
                {
                    return res = i - index + 1;
                }
            }

            return res;
        }

        private static int[] GetPref(string key)
        {
            int[] result = new int[key.Length];
            result[0] = 0;
            int index = 0;

            for (int i = 1; i < key.Length; i++)
            {
                while (index >= 0 && key[index] != key[i]) 
                { 
                    index--; 
                }
                index++;
                result[i] = index;
            }

            return result;
        }
        */
    
}
