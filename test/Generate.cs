using System;
using System.Collections.Generic;

namespace RandomGenerator { };
namespace Program { };
namespace Rabbit { };

namespace Generate
{
    class Entities
    {
        static public List<Rabbit.Stats> GenOne(Program.Map map, int AmmountOfGeneratedRabbits)
        {
            List<Rabbit.Stats> genOneList = new List<Rabbit.Stats>(); //list to genetate new rabbits to
            for (int Cycle = 0; Cycle < AmmountOfGeneratedRabbits; Cycle++)
            {
                genOneList.Add(new Rabbit.Stats(map));
            }
            return genOneList;
        }

        static public List<Program.Position> Food(int AmmountOfGeneratedFood, Program.Map map) //genetares food
        {
            List<Program.Position> Food = new List<Program.Position>(); // internal food list
            for (int Cycle = 0; Cycle < AmmountOfGeneratedFood; Cycle++)
            {
                Food.Add(Paths.Position(map)); //pos of food save to internal
            }
            return Food; // export
        }
    }
    class Paths
    {
        static public Program.Position Position(Program.Map map)
        {
            Program.Position pos = new Program.Position(0, 0);
            pos.posX = RandomGenerator.NahodneCislo.Cele(map.min, map.max);
            pos.posY = RandomGenerator.NahodneCislo.Cele(map.min, map.max);
            return pos;
        }
        static public Program.Position SearchFood(Rabbit.Stats currentRabbit, List<Program.Position> foodList)
        {
            for (int currentFood = 0; currentFood < foodList.Count; currentFood++)
            {
                if (foodList[currentFood].posX <= currentRabbit.rabbitPos.posX + currentRabbit.See && foodList[currentFood].posX >= currentRabbit.rabbitPos.posX - currentRabbit.See)
                {
                    if (foodList[currentFood].posY <= currentRabbit.rabbitPos.posY + currentRabbit.See && foodList[currentFood].posY >= currentRabbit.rabbitPos.posY - currentRabbit.See)
                    {
                        return foodList[currentFood];
                        foodList.Remove(foodList[currentFood]);
                    }
                }
            }
            int speed = Convert.ToInt32(currentRabbit.Speed);
            Program.Position nope = new Program.Position(RandomGenerator.NahodneCislo.Cele(currentRabbit.rabbitPos.posX - speed, currentRabbit.rabbitPos.posX + speed), RandomGenerator.NahodneCislo.Cele(currentRabbit.rabbitPos.posY - speed, currentRabbit.rabbitPos.posY + speed));
            return nope;
        }

        static public Program.Position SearchMate(Rabbit.Stats currentRabbit, List<Rabbit.Stats> rabbitList)
        {
            for (int Round = 0; Round < rabbitList.Count; Round++)
            {
                if (rabbitList[Round].rabbitPos.posX <= currentRabbit.rabbitPos.posX + currentRabbit.See && rabbitList[Round].rabbitPos.posX >= currentRabbit.rabbitPos.posX - currentRabbit.See)
                {
                    if (rabbitList[Round].rabbitPos.posY <= currentRabbit.rabbitPos.posY + currentRabbit.See && rabbitList[Round].rabbitPos.posY >= currentRabbit.rabbitPos.posY - currentRabbit.See)
                    {
                        return rabbitList[Round].rabbitPos;
                    }
                }
            }
            int speed = Convert.ToInt32(currentRabbit.Speed);
            Program.Position nope = new Program.Position(RandomGenerator.NahodneCislo.Cele(currentRabbit.rabbitPos.posX - speed, currentRabbit.rabbitPos.posX + speed), RandomGenerator.NahodneCislo.Cele(currentRabbit.rabbitPos.posY - speed, currentRabbit.rabbitPos.posY + speed));
            return nope;
        }
        static public int SearchMate2(Rabbit.Stats currentRabbit, List<Rabbit.Stats> rabbitList)
        {
            for (int Round = 0; Round < rabbitList.Count; Round++)
            {
                if (rabbitList[Round].rabbitPos.posX <= currentRabbit.rabbitPos.posX + currentRabbit.See && rabbitList[Round].rabbitPos.posX >= currentRabbit.rabbitPos.posX - currentRabbit.See)
                {
                    if (rabbitList[Round].rabbitPos.posY <= currentRabbit.rabbitPos.posY + currentRabbit.See && rabbitList[Round].rabbitPos.posY >= currentRabbit.rabbitPos.posY - currentRabbit.See)
                    {
                        return Round;
                    }
                }
            }
            return 0;
        }
    }
}
