using System;
using System.Collections.Generic;

namespace lab10.p
{
    class PopulationSelector
    {
        private int Age;
        private int MaxWeight;
        private Set[] Pair;
        private Random Random;
        private int IterationCount;

        public PopulationSelector(int age, int maxWeight, Random rand, int iterCount)
        {
            MaxWeight = maxWeight;
            Age = age;
            Pair = new Set[2];
            Random = rand;
            IterationCount = iterCount;
        }

        public Set[] getPair()
        {
            return Pair;
        }

        public int getAge()
        {
            return Age;
        }

        public void ShowBestOf(Set[] Sets)
        {
            int max = 0;
            int index_max = 0;

            for (int i = 0; i < Sets.Length - 1; i++)
            {
                if (Sets[i].CostSum > max && Sets[i].WeightSum < MaxWeight && Sets[i].WeightSum > (MaxWeight * 0.7f))
                {
                    max = Sets[i].CostSum;
                    index_max = i;
                }
            }

            if (max == 0)
            {
                for (int i = 0; i < Sets.Length - 1; i++)
                {
                    if (Sets[i].CostSum > max && Sets[i].WeightSum < MaxWeight)
                    {
                        max = Sets[i].CostSum;
                        index_max = i;
                    }
                }
            }
            Console.WriteLine("Лучший в поколении: ");
            Sets[index_max].show();
        }

        public void ChoosePair(Set[] Sets)
        {//Выбор родителей
            Pair[0] = Sets[Random.Next(IterationCount)];
            do
            {
                Pair[1] = Sets[Random.Next(IterationCount)];
            } while (Pair[0] == Pair[1]);
          
            Console.WriteLine("Первый родитель: ");
            Pair[0].show();

            Console.WriteLine("Второй родитель: ");
            Pair[1].show();
        }

        public void ChooseBestPair(Set[] Sets)
        {
            List<Set> Select = new List<Set>(Sets);
            List<Set> pair = new List<Set>(2);
            do
            {
                float max = 0;
                int index_max = 0;
                for (int i = 0; i < Select.Count; i++)
                {
                    if (Select[i].SpecValueSum >= max && Select[i].SpecValueSum < 1.2f && Select[i].WeightSum > 80)
                    {
                        max = Select[i].SpecValueSum;
                        index_max = i;
                    }
                }

                pair.Add(Sets[index_max]);
                Select.RemoveAt(index_max);
            } while (pair.Count < 2);

            Pair[0] = pair[0];
            Console.WriteLine("Первый родитель: ");
            Pair[0].show();

            Pair[1] = pair[1];
            Console.WriteLine("Второй родитель: ");
            Pair[1].show();
        }
		
		private Set[] filterPopulationByMaxWeight(Set[] childs)
		{
			List<Set> filteredChildsList = new List<Set>(childs.Length);
			foreach(Set child in childs) {
				if(child.WeightSum <= MaxWeight) {
					filteredChildsList.Add(child);
				}
			}
			return filteredChildsList.ToArray(); 
		}

        public void NewPopulation(Set[] Sets, Set[] NewPopulation)
        {//Полное замещение популяции
            Sets = filterPopulationByMaxWeight(NewPopulation);
            Age++;
            Console.WriteLine();
            Console.WriteLine("!!!ПОКОЛЕНИЕ: " + Age);
        }

        public bool End(Set[] Sets, int minWeight)
        {//Завершение алгоритма, если все решения оптимальны
            for (int i = 0; i < Sets.Length; i++)
            {
                if (Sets[i].WeightSum > MaxWeight || Sets[i].WeightSum < minWeight)
                {
                    return false;
                }
            }
            return true;
        }
    }
}