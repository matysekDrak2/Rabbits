using System;

namespace RandomGenerator { };
namespace Program { };
namespace Rabbit { };

namespace Generate
{
    class Entities
    {
        static public Rabbit.Stats[] GenOne(Program.Map map, int AmmountOfGeneratedRabbits)
        {
            Rabbit.Stats[] genOneList = new Rabbit.Stats[AmmountOfGeneratedRabbits]; //list to genetate new rabbits to
            for (int Cycle = 0; Cycle < AmmountOfGeneratedRabbits; Cycle++)
            {
                Console.WriteLine("In genOne the rabbit num. " + Cycle + "has");
                genOneList[Cycle] = new Rabbit.Stats(map);
            }
            return genOneList;
        }

        static public Program.Position[] Food(int AmmountOfGeneratedFood, Program.Map map) //genetares food
        {
            Program.Position[] Food = new Program.Position[AmmountOfGeneratedFood]; // internal food list
            for (int Cycle = 0; Cycle < AmmountOfGeneratedFood; Cycle++)
            {
                Food[Cycle] = Paths.Position(map); //pos of food save to internal
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
        static public Program.Position SearchFood(Rabbit.Stats currentRabbit, Program.Position[] foodList)
        {
            for (int currentFood = 0; currentFood < foodList.Length; currentFood++)
            {
                if (foodList[currentFood].posX <= currentRabbit.rabbitPos.posX + currentRabbit.See && foodList[currentFood].posX >= currentRabbit.rabbitPos.posX - currentRabbit.See)
                {
                    if (foodList[currentFood].posY <= currentRabbit.rabbitPos.posY + currentRabbit.See && foodList[currentFood].posY >= currentRabbit.rabbitPos.posY - currentRabbit.See)
                    {
                        Console.WriteLine("rabbit found food on " + foodList[currentFood].posX + "x " + foodList[currentFood].posY + "y");
                        return foodList[currentFood];
                        foodList[currentFood].posX = -1000;
                        foodList[currentFood].posY = -1000;
                    }
                }
            }
            int speed = Convert.ToInt32(currentRabbit.Speed);
            Program.Position nope = new Program.Position(RandomGenerator.NahodneCislo.Cele(currentRabbit.rabbitPos.posX - speed, currentRabbit.rabbitPos.posX + speed), RandomGenerator.NahodneCislo.Cele(currentRabbit.rabbitPos.posY - speed, currentRabbit.rabbitPos.posY + speed));
            Console.WriteLine("rabbit didnt found food and whants to go to " + nope.posX + "x " + nope.posY + "y");
            return nope;
        }

        static public Program.Position SearchMate(Rabbit.Stats currentRabbit, Rabbit.Stats[] rabbitList)
        {
            for (int Round = 0; Round < rabbitList.Length; Round++)
            {
                if (rabbitList[Round].rabbitPos.posX <= currentRabbit.rabbitPos.posX + currentRabbit.See && rabbitList[Round].rabbitPos.posX >= currentRabbit.rabbitPos.posX - currentRabbit.See)
                {
                    if (rabbitList[Round].rabbitPos.posY <= currentRabbit.rabbitPos.posY + currentRabbit.See && rabbitList[Round].rabbitPos.posY >= currentRabbit.rabbitPos.posY - currentRabbit.See)
                    {
                        Console.WriteLine("rabbit found mate on " + rabbitList[Round].rabbitPos.posX + "x " + rabbitList[Round].rabbitPos.posY + "y");
                        return rabbitList[Round].rabbitPos;
                    }
                }
            }
            int speed = Convert.ToInt32(currentRabbit.Speed);
            Program.Position nope = new Program.Position(RandomGenerator.NahodneCislo.Cele(currentRabbit.rabbitPos.posX - speed, currentRabbit.rabbitPos.posX + speed), RandomGenerator.NahodneCislo.Cele(currentRabbit.rabbitPos.posY - speed, currentRabbit.rabbitPos.posY + speed));
            Console.WriteLine("rabbit didnt found mate and whants to go to " + nope.posX + "x " + nope.posY + "y");
            return nope;
        }
        static public int SearchMate2(Rabbit.Stats currentRabbit, Rabbit.Stats[] rabbitList)
        {
            for (int Round = 0; Round < rabbitList.Length; Round++)
            {
                if (rabbitList[Round].rabbitPos.posX <= currentRabbit.rabbitPos.posX + currentRabbit.See && rabbitList[Round].rabbitPos.posX >= currentRabbit.rabbitPos.posX - currentRabbit.See)
                {
                    if (rabbitList[Round].rabbitPos.posY <= currentRabbit.rabbitPos.posY + currentRabbit.See && rabbitList[Round].rabbitPos.posY >= currentRabbit.rabbitPos.posY - currentRabbit.See)
                    {
                        Console.WriteLine("rabbit found mate on " + rabbitList[Round].rabbitPos.posX + "x " + rabbitList[Round].rabbitPos.posY + "y");
                        return Round;
                    }
                }
            }
            return 0;
        }
    }
}
