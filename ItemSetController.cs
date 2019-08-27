using System;
using System.Linq;

namespace lab10.p
{
    class ItemSetController
    {
        private Item[] Items;
        private Set[] Sets;
        private Random Random;
        private int IterationCount;


        public ItemSetController(Random rand, int iterCount)
        {
            Random = rand;
            IterationCount = iterCount;
            Items = new Item[IterationCount];
            Sets = new Set[IterationCount];
        }

        public void addItem(Item item, int index)
        {
            Items[index] = item;
        }

        public Set[] getSets()
        {
            return Sets;
        }

        public Item[] getItems()
        {
            return Items;
        }

        public void IniSets()
        {    //Метод случайного формирования начальной популяции
            int i = 0;
            Set tmp;
            while (i < IterationCount)
            {
                tmp = new Set(Items, Random, IterationCount);
                if (tmp.WeightSum <= 106 && IsUnique(tmp,Sets))
                {
                    Sets[i] = tmp;
                    i++;
                }
            }
        }

        public static bool IsUnique(Set set, Set[] arr)
        {
            foreach (Set s in arr)
            {
                if (s!=null && Enumerable.SequenceEqual(set.Encoding, s.Encoding))
                {
                    return false;
                }
            }
            return true;
        }

        public void ShowItems()
        {
            for (int i = 0; i < Items.Length; i++)
            {
                Items[i].Show((i + 1).ToString());
            }
        }

        public void ShowSets()
        {
            for (int i = 0; i < Sets.Length - 1; i++)
            {
                Sets[i].show();
            }
        }   
    }
}