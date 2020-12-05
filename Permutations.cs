using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shuffles
{
    class Permutation
    {
        public static int[] Next(int[] Razm)
        {
            int n = Razm.Length;
            int j = n - 2;
            while (j != -1 && Razm[j] >= Razm[j + 1]) j--;//Последовательность элементов простматривается
            if (j == -1)                                  //пока прорамма находит элемент j, меньший чем следующий
                return Razm; //(Если больше перестановок нет)
            int k = n - 1;                                //Изначально, k - последний элемент
            while (Razm[j] >= Razm[k]) k--;               //Но, если j > k, то переносим k левее
            swap(Razm, j, k);                             //Меняем местами j и k
            int l = j + 1, r = n - 1;                     //Сортируем оставшуюся часть последовательности
            while (l < r)
                swap(Razm, l++, r--);
            return Razm;
        }
        static void swap(int[] Razm, int i, int j)
        {
            int s = Razm[i];
            Razm[i] = Razm[j];
            Razm[j] = s;
        }

        //public static int[] numPermutation(int k, int[] array)
        //{
        //    long K = Convert.ToInt64(k);
        //    int n = array.Length;
        //    bool[] was = new bool[n];
        //    long alreadyWas = 0;
        //    int[] perm = new int[n];
        //    for (int i = 1; i < n; i++)
        //    {
        //        alreadyWas = K / Factorial(n - i);
        //        K %= Factorial(n - i);
        //        int curFree = 0;
        //        for (int j = 1; j < n; j++)
        //        {
        //            if (was[j] == false)
        //            {
        //                curFree++;
        //                if (curFree == alreadyWas + 1)
        //                {
        //                    perm[i] = j;
        //                    was[j] = true;
        //                }
        //            }
        //        }
        //    }
        //    return perm;
        //}

        //public static long Factorial(int N)
        //{
        //    long factorial = 1;
        //    for (int counter = 1; counter <= N; counter++)
        //    {
        //        factorial = factorial * counter;
        //    }

        //    return factorial;
        //}
    }
}
