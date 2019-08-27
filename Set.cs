using System;

namespace lab10.p
{
    public class Set
    {
        public int[] Encoding;
        public int WeightSum;
        public int CostSum;
        public float SpecValueSum;
        private Item[] Items; // Набор особей (?)
        private int IterationCount;

        public Set(Item[] items, int iterationsCount)
        {
            Items = items;
            CostSum = 0;
            WeightSum = 0;
            SpecValueSum = 0;
            IterationCount = iterationsCount;
            Encoding = new int[IterationCount];
        }

        public Set(Item[] items, Random rand, int iterCount)
        {
            IterationCount = iterCount;
            Encoding = new int[IterationCount];
            Items = items;
            for (int i = 0; i < IterationCount; i++)
            {
                Encoding[i] = rand.Next(0, 2);
            }
            Refresh();
        }

        public void show()
        {
            for (int i = 0; i < Encoding.Length; i++)
            {
                Console.Write(Encoding[i]);
            }
            Console.WriteLine("  Общий вес = " + WeightSum + " Общая ценность = " + CostSum + " U=" + SpecValueSum);
        }

        public void Refresh()
        {
            WeightSum = 0;
            CostSum = 0;
            for (int i = 0; i < IterationCount; i++)
            {
                if (Encoding[i] == 1)
                {
                    WeightSum += Items[i].getWeight();
                    CostSum += Items[i].getCost();
                }
            }
            SpecValueSum = (float)CostSum / (float)WeightSum;
           // Console.WriteLine(SumW /*+ SumC*/);
        }
    }
}