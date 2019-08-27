using System;

namespace lab10.p
{
    public class Item
    {
        private int Cost;
        private int Weight;
        private float SpecValue;

        public Item(Random r) : this(r.Next(1, 100), r.Next(1, 30)) {}

        public Item(int cost, int weight)
        {
            Cost = cost;
            Weight = weight;
            SpecValue = (float)Cost / (float)Weight;
        }

        public int getCost()
        {
            return Cost;
        }

        public int getWeight()
        {
            return Weight;
        }

        public void Show(string s)
        {
            Console.WriteLine("Name " + s + " |Ценность(Cost) = " + Cost + " |Вес(Weight) = " + Weight + " |Удельная ценность = " + SpecValue);
        }
    }
}