using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStringPerformance
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime start = DateTime.Now;
            string x = "";
            for (int i = 0; i < 200000; i++)
            {
                x += "!";
            }
            DateTime end = DateTime.Now;
            Console.WriteLine("Time taken: {0}", end - start);
            Console.ReadLine();
        }
    }
}
