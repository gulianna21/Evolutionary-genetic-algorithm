using System;
using System.Collections.Generic;

namespace lab10.p
{
    class SelectionManager
    {
        private Random Random;


        public SelectionManager(Random rand)
        {
            Random = rand;
        }

        //Бинарный турнир
        public Set[] BinaryTournament(Set[] childs, int filterCount)
        {
            List<Set> childsList = new List<Set>(childs);
            Set[] result = new Set[filterCount];
            int count = 0;

            do
            {
                List<Set> selection = new List<Set>(2);
                for (int i = 0; i < 2; i++)
                {
                    int Rand = Random.Next(childsList.Count);
                    selection.Add(childsList[Rand]);
                    childsList.RemoveAt(Rand);
                }

                float max = 0;
                int index_max = 0;
                for (int i = 0; i < selection.Count; i++)
                {
                    if (selection[i].SpecValueSum >= max)
                    {
                        max = selection[i].SpecValueSum;
                        index_max = i;
                    }
                }
                result[count] = selection[index_max];
                selection.RemoveAt(index_max);
                childsList.AddRange(selection);
                count++;
            } while (count < filterCount);
            return result;
        }

        //Пропорциональная селекция
        public Set[] ProportionallySelection(Set[] childs, int filterCount)
        {
            float avgSpecValue = 0;
            List<Set> childsList = new List<Set>(childs);
            List<Set> result = new List<Set>();

            foreach (Set set in childs)
            {
                avgSpecValue += set.SpecValueSum;
            }
            avgSpecValue = avgSpecValue / childs.Length;

            do
            {
                double coefficient = Convert.ToDouble(Random.Next(100)) / 100;
                for (int i = 0; i < childsList.Count; i++)
                {
                    if ((coefficient - (childsList[i].SpecValueSum / avgSpecValue)) < 0)
                    {
                        result.Add(childsList[i]);
                        childsList.RemoveAt(i);
                        break;
                    }
                }
            } while (result.Count < filterCount);

            return result.ToArray();
        }
    }
}