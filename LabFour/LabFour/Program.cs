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
    class Deq<String>//класс дека, типа строка
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
        public void PushTop(String item)//добавить в начало
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
        public String PopTop()//удаление с начала
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
                    izz.PushTop(mas[i]);
                }
                else
                {
                    izz.PushBack(mas[i]);
                }
            }
            string fileName = @"D:\Делааем\Opa\мое\СИАОД\out.txt";
            FileStream aFile = new FileStream(fileName, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(aFile);
            aFile.Seek(0, SeekOrigin.End);
            for (int i =0;i<mas.Length;i++)
            {
                sw.Write(izz.Front + " ");
                izz.PopTop();
                //так же можно отсортировать в этом месте,а не в том где заполняется дек
            }

            sw.Close();
        }
        

    }
}
