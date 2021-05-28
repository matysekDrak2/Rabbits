using System;
using System.Collections.Generic;

namespace RandomGenerator { };
namespace Rabbit { }; 
namespace Generate { };

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map(0, 100); //mapa a její velikost
            int AmmountOfGeneratedFood = 100; // počet jídla na každou generaci
            int GenerationLimit = 200; // počet simulovaných generací
            int AmmountOfGenOneRabbits = 20;
            List<Rabbit.Stats> rabbitList = new List<Rabbit.Stats>();
            rabbitList = Generate.Entities.GenOne(map, AmmountOfGenOneRabbits);

            for (int CurrentGeneration = 0; CurrentGeneration < GenerationLimit; CurrentGeneration++) //pro každou generaci
            {
                List<Position> foodList = Generate.Entities.Food(AmmountOfGeneratedFood, map); // generuj jídlo pro tuto generaci

                for (int CurrentRabbit = 0; CurrentRabbit < rabbitList.Count; CurrentRabbit++) // pro každý oběkt druhu Rabbit, názvem rabbit v listu rabbitList
                {
                    if (!rabbitList[CurrentRabbit].alive) {rabbitList.Remove(rabbitList[CurrentRabbit]); break;} //guard třída

                    switch (rabbitList[CurrentRabbit].priority)
                    {
                        //case "Hungry": RunForFood(rabbitList[CurrentRabbit], foodList); break;
                        case "Horny": Rabbit.Actions.RunForMate(rabbitList[CurrentRabbit], rabbitList); break;
                        case "Hungry": Rabbit.Actions.RunForFood(rabbitList[CurrentRabbit], foodList); break;
                    }
                    rabbitList[CurrentRabbit].Age++;
                }
            }
        }
    }
    public class Position
    {   
        public int posX;
        public int posY;
        public Position(int posX,int posY)
        {
            this.posX = posX;
            this.posY = posY;
        }
    }
    public class Map
    {
        readonly public int min;
        readonly public int max;
        public Map(int min, int max)
        {
            this.min = min;
            this.max = max;
        }
    }
}
