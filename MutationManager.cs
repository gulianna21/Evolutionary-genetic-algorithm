using System;

namespace lab10.p
{
    class MutationManager
    {
        private Random Random;
        private int IterationCount;

        public MutationManager(Random rand, int iterCount)
        {
            Random = rand;
            IterationCount = iterCount;
        }


        //??????????????????????????????????????????????????????????????????????
        //МУТАЦИИ ##############################################################
        public void InversionMutation(Set child)
        {//Инверсия на инетрвале
            if (Random.Next(0, 2) == 1)
            {
                int firstDividerPoint = Random.Next(0, IterationCount - 1);
                int secondDividerPoint = Random.Next(firstDividerPoint + 1, IterationCount);
                for (int i = firstDividerPoint; i <= secondDividerPoint; i++)
                {
                    child.Encoding[i] = child.Encoding[i] == 0 ? 1 : 0;
                }
                child.Refresh();
            }
        }

        public void RandomMutation(Set child)
        {//Мутация случайного коофициэнта на противоположный
            if (Random.Next(0, 2) == 1)
            {
                int index = Random.Next(child.Encoding.Length);
                child.Encoding[index] = child.Encoding[index] == 0 ? 1 : 0;
                child.Refresh();
            }
        }
    }
}