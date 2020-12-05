using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shuffles
{
    class Random_Throw
    {
        public static int[] Mix(int[] array)
        {
            Random rand = new Random();
            long n = rand.Next(array.Length * 10);

            int from, to;

            for (long i = 0; i < n; i++)
            {
                from = rand.Next(array.Length);
                to = rand.Next(array.Length);

                int t = array[from];
                array[from] = array[to];
                array[to] = t;
            }
            return array;
        }
    }
}
