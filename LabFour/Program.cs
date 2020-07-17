using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Threading;

namespace LabFour
{
    /*class Deq
    {
        private int dMaxSize;
        private int dSize;
        private string[] dArray;
        private int dTop;
        private int dBot;


        public Deq(int n)
        {
            this.dMaxSize = n;
            dArray = new string[n];
            dTop = 0;
            dBot = 0;
            dSize = 0;
        }

        public int Count
        {
            return dArray.
        }

        public Boolean isFull()
        {
            return (dMaxSize == dSize);
        }

        public Boolean isEmpty()
        {
            return (dSize == 0);
        }

        public void addTop(string element)
        {
            if (isFull())
            {
                Console.WriteLine("Deque is full");
                return;
            }

            else if (isEmpty())
            {
                dTop = dBot;
                dArray[dTop] = element;
                dSize++;
            }

            else
            {
                dBot--;
                if (dBot < 0)
                    dBot = dMaxSize - 1;
                dArray[dBot] = element;
                dSize++;
            }

        }

        public void addBot(string element)
        {
            if (isFull())
            {
                Console.WriteLine("Deque is full");
                return;
            }

            else if (isEmpty())
            {
                dTop = dBot;
                dArray[dTop] = element;
                dSize++;
            }

            else
            {
                dTop++;
                if (dTop >= dMaxSize)
                    dTop = 0;
                dArray[dTop] = element;
                dSize++;
            }

        }


        public void clear()
        {
            dTop = dBot = dSize = 0;
        }

        public object deleteTop()
        {
            if (!isEmpty())
            {
                string buf = dArray[dTop];
                dTop--;
                if (dTop < 0)
                    dTop = dMaxSize - 1;
                dSize--;
                return buf;
            }
            return -1;
        }

        public object deleteBot()
        {
            if (!isEmpty())
            {
                string buf = dArray[dBot];
                dBot++;
                if (dTop >= dMaxSize)
                    dBot = 0;
                dSize--;
                return buf;
            }
            return -1;
        }

    }*/



    class Deq<String>
    {
        String[] array;

        public Deq()//создание массива
        {
            array = new String[0];
        }
        public int Count//длина массива
        {
            get
            {
                return array.Length;
            }
        }
        public bool Empty//пуст или не пуст массив
        {
            get
            {
                return array.Length > 0;
            }
        }
        public void PushBack(String item)//добавить в конце
        {
            Array.Resize(ref array, array.Length + 1);
            array[array.Length - 1] = item;
        }
        public void PushFront(String item)//добавить в начало
        {
            Array.Resize(ref array, array.Length + 1);
            for (int i = array.Length - 1; i > 0; i--)
                array[i] = array[i - 1];
            array[0] = item;
        }
        public String PopBack()//удалить с конца
        {
            String item = array[array.Length - 1];
            Array.Resize(ref array, array.Length - 1);
            return item;
        }
        public String PopFront()//удаление с начала
        {
            String item = array[0];
            for (int i = 0; i < array.Length - 1; i++)
                array[i] = array[i + 1];
            Array.Resize(ref array, array.Length - 1);
            return item;
        }
        public String Front
        {
            get
            {
                return array[0];
            }
        }
        public String Back
        {
            get
            {
                return array[array.Length - 1];
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            String line;
            // Для открытия файла используем Stream reader, Encoding.Default для чтения файла в ANSI-кодировке
            using (StreamReader sr = new StreamReader(@"D:\Делааем\Opa\мое\СИАОД\prog.txt", Encoding.Default))
                line = sr.ReadToEnd();
            string[] mas = line.Split(' ');
            Deq<string> izz = new Deq<string>();

            for(int i = 0; i<mas.Length;i++)
            {
                if (Int32.TryParse(mas[i], out int u) == false)
                {
                    izz.PushFront(mas[i]);
                }
                else
                {
                    izz.PushBack(mas[i]);
                }
            }
            string fileName = @"D:\Делааем\Opa\мое\СИАОД\LabFour\out.txt";
            FileStream aFile = new FileStream(fileName, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(aFile);
            aFile.Seek(0, SeekOrigin.End);
            for (int i =0;i<mas.Length;i++)
            {
                sw.Write(izz.Front + " ");
                izz.PopFront();
            }

            sw.Close();

            
            Console.ReadLine();
            
        }
        

    }
}
