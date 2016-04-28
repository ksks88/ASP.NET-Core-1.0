using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EularTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 3, 5 };
            int range = 1000;

            Console.WriteLine("Total sum is: {0}", GetSumOfMultiples(array, range));
            Console.ReadLine();
        }

        static int GetSumOfMultiples(int [] arrayOfMultiples, int range)
        {
            int sum = 0;
            int counter = 1;
            int someRes = arrayOfMultiples.Where(x => x % 1000 == 0).Sum();
            for (int i = 1; i < range; i++)
            {
                sum += arrayOfMultiples[0] * i < range ? arrayOfMultiples[0] * i : 0;
                sum += arrayOfMultiples[1] * i < range ? arrayOfMultiples[1] * i : 0;
            }

            while ((arrayOfMultiples[0] * counter) < range)
            {
                sum += arrayOfMultiples[0] * counter;
            }

            return sum;
        }
    }
}
