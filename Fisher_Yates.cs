using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shuffles
{
    class Fisher_Yates
    {
        private int[] ArrayToShuffle;
        private Random rand;
        private int CurrentPosition;

        public int[] Shuffle(int[] array)
        {
            rand = new Random();
            ArrayToShuffle = array;

            for (CurrentPosition = ArrayToShuffle.Length - 1; CurrentPosition > 0; CurrentPosition--)
                RollAndSwap();

            return ArrayToShuffle;
        }

        private void RollAndSwap()
        {
            var roll = Roll();
            var j = ArrayToShuffle[CurrentPosition];
            ArrayToShuffle[CurrentPosition] = ArrayToShuffle[roll];
            ArrayToShuffle[roll] = j;
        }

        private int Roll()
        {
            return rand.Next(CurrentPosition + 1);
        }
    }
}
