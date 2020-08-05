using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Тес1
{
    class Program
    {
        static void Main(string[] args)
        {
            string m = "1,2,4,76,-4,5,54";
            int col = 0, max = Int32.MinValue;

            List<int> mem = new List<int>(m.Split(',').Select(int.Parse));
            for (int i = 0; i < mem.Count; i++)
            {
                if (mem[i] > max)
                    max = mem[i];
            }
            
            Console.WriteLine(max);
            Console.ReadLine();

        }
    }
}
