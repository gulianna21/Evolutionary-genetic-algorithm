using lab10.p;
using System;

namespace Lab10
{
    class MainClass
    {
        private static int ITERATION_COUNT = 15;
        private static int CHILDS_COUNT = ITERATION_COUNT * 2;


        public static void Main(string[] args)
        {
            Random rand = new Random();
            ItemSetController itemSetController = new ItemSetController(rand, ITERATION_COUNT);
            PopulationSelector populationSelector = new PopulationSelector(1, 106, rand, ITERATION_COUNT);
            CrossoverManager crossoverManager = new CrossoverManager(rand, ITERATION_COUNT);
            SelectionManager selectionManager = new SelectionManager(rand);
            MutationManager mutationManager = new MutationManager(rand, ITERATION_COUNT);

            for (int i = 0; i < ITERATION_COUNT; i++)
            {
                itemSetController.addItem(new Item(rand.Next(1, 30), rand.Next(1, 30)), i);
            }

            itemSetController.ShowItems();
            itemSetController.IniSets();
            itemSetController.ShowSets();

            string pairSelection;
            do
            {
                Console.WriteLine("Выберите тип выборки пары: 1 - Лучшая пара 2 - Случайный");
                pairSelection = Console.ReadLine();
            } while (pairSelection != "1" && pairSelection != "2");

            string crossover;
            do
            {
                Console.WriteLine("Выберите вид кроссовера: 1 - Двухточечный(Случайный) 2 - Одноточечный классический");
                crossover = Console.ReadLine();
            } while (crossover != "1" && crossover != "2");

            string mutation;
            do
            {
                Console.WriteLine("Выберите вид мутации: 1 - изменеие бита на противоположный 2 - инверсия в случайном интервале");
                mutation = Console.ReadLine();
            } while (mutation != "1" && mutation != "2");

            string selection;
            do
            {
                Console.WriteLine("Выберите вид селекции: 1 - Бинарный турнир 2 - Пропорциональная");
                selection = Console.ReadLine();
            } while (selection != "1" && selection != "2");
            do
            {
                if (pairSelection == "1")
                {
                    populationSelector.ChooseBestPair(itemSetController.getSets());

                }
                else
                {
                    populationSelector.ChoosePair(itemSetController.getSets());
                }

                Set[] childrens = new Set[CHILDS_COUNT];
                int dividerPoint = rand.Next(1, ITERATION_COUNT - 1);
                Set[] bestPair = populationSelector.getPair();
                for (int i = 0; i < childrens.Length; i++)
                {
                    childrens[i] = crossover == "1" ? crossoverManager.DoubleCross(bestPair, itemSetController.getItems()) :
                        crossoverManager.ClassicCross(bestPair, itemSetController.getItems(), dividerPoint);
                    if (mutation == "1")
                    {
                        mutationManager.RandomMutation(childrens[i]);
                    }
                    else
                    {
                        mutationManager.InversionMutation(childrens[i]);
                    }
                }

                populationSelector.NewPopulation(itemSetController.getSets(), selection == "1" ?
                    selectionManager.BinaryTournament(childrens, CHILDS_COUNT / 2) :
                    selectionManager.ProportionallySelection(childrens, CHILDS_COUNT / 2));

                Console.WriteLine("Новая популяция:");
                itemSetController.ShowSets();

                populationSelector.ShowBestOf(itemSetController.getSets());
            } while (!populationSelector.End(itemSetController.getSets(), 85) && populationSelector.getAge() != 10);
            Console.ReadKey();
        }
    }
}