using System;

namespace lab10.p
{
    class CrossoverManager
    {
        private Random Random;
        private int IterationCount;


        public CrossoverManager(Random rand, int iterCount)
        {
            Random = rand;
            IterationCount = iterCount;
        }

        //Кроссоверы?????????????????????????????????????????????????????????????
        public Set DoubleCross(Set[] pair, Item[] Items)
        {//Кроссовер случайный двухточечный
            Set result = new Set(Items, IterationCount);
            Set set_1 = pair[0];
            Set set_2 = pair[1];

            
            int reverseArg = Random.Next(2);
            for (int i = 0; i < IterationCount / 3; i++)
            {
                result.Encoding[i] = reverseArg == 0 ? set_1.Encoding[i] : set_2.Encoding[i];
            }
            
            reverseArg = Random.Next(2);
            for (int i = IterationCount / 3; i < 2 * IterationCount / 3; i++)
            {
                result.Encoding[i] = reverseArg == 0 ? set_1.Encoding[i] : set_2.Encoding[i];
            }
           
            reverseArg = Random.Next(2);
            for (int i = 2 * IterationCount / 3; i < IterationCount; i++)
            {
                result.Encoding[i] = reverseArg == 0 ? set_1.Encoding[i] : set_2.Encoding[i];
            }

            result.Refresh();
            return result;
        }

        public Set ClassicCross(Set[] pair, Item[] Items, int dividerPoint)
        {//Кроссовер классический одноточечный
            Set result = new Set(Items, IterationCount);
            Set set_1 = pair[0];
            Set set_2 = pair[1];

            int reverseArg = Random.Next(2);
                for (int i = 0; i < dividerPoint; i++)
                {
                result.Encoding[i] = reverseArg == 0 ? set_1.Encoding[i] : set_2.Encoding[i];
                }

                for (int i = dividerPoint; i < IterationCount; i++)
                {
                result.Encoding[i] = reverseArg == 0 ? set_2.Encoding[i] : set_1.Encoding[i];
                }

            result.Refresh();
            return result;
        }
    }
}