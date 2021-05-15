using System;
using System.Collections.Generic;

namespace Program { };

namespace Rabbit
{
    class Limits //limity
    {
        public int age = 40;
        public int foodCapacity = 200;
        public int foodConsumprionMinimum = 2;
        public int speed = 80;
        public int see = 80;
    }
    class Stats
    {
        private readonly Limits limits = new Limits();
        public bool alive = true;
        private int age;
        private int foodCapacity;
        private int foodConsumption;
        public int food;
        private int see;
        private int speed;
        public Program.Position rabbitPos;
        public string priority;

        public int See
        {
            get => see / 10;
            set
            {
                see = value;
            }
        }
        public int Speed
        {
            get => speed / 10;
            set
            {
                speed = value;
            }
        }
        public int Age
        {
            get => age;
            set
            {
                age = value;
                Console.WriteLine("the rabbit has " + food + "food, and eats" + FoodConsumption);
                food = food - FoodConsumption;
                Console.WriteLine("now he has " + food + " out of " + foodCapacity);
                if (food < foodConsumption || age == limits.age)
                {
                    alive = false;
                    rabbitPos.posX = -1000;
                    rabbitPos.posY = -1000;
                }
                switch (food >= foodConsumption * 4)
                {
                    case true: priority = "Horny"; break;
                    case false: priority = "Hungry"; break; 
                }
            }
        }
        int FoodConsumption // výpočer žravosti
        {
            get => foodConsumption; // gettery jsou špatně
            set // min consumption is 2
            {
                foodConsumption = value;
                if (foodConsumption < 2)
                {
                    foodConsumption = 2;
                }
            }
        }


        public Stats(Program.Map map) //gen one
        {
            age = 0;
            rabbitPos = Generate.Paths.Position(map);
            Speed = RandomGenerator.NahodneCislo.Cele(20, 40);
            See = RandomGenerator.NahodneCislo.Cele(20, 40);
            FoodConsumption = Convert.ToInt32(Math.Sqrt(see + speed)-6)*2;
            foodCapacity = RandomGenerator.NahodneCislo.Cele(30, 60) + FoodConsumption * 2;
            food = foodCapacity;
            Console.WriteLine("Position of " + rabbitPos.posX + " posX  and " + rabbitPos.posY + " posY\nspeed of " + Speed + "\nsees on " + See + "\nconsumes" + foodConsumption + "\ncaries" + foodCapacity);
        }
        public Stats(Stats mom, Stats dad) //newborn
        {
            age = 0;
            rabbitPos = mom.rabbitPos;
            Speed = (mom.speed+dad.speed)/2 + RandomGenerator.NahodneCislo.Cele(-10, 10);
            See = (mom.see + dad.see) / 2 + RandomGenerator.NahodneCislo.Cele(-10, 10);
            FoodConsumption = Convert.ToInt32(Math.Sqrt(see + speed) - 6) * 2;
            foodCapacity = RandomGenerator.NahodneCislo.Cele(30, 60) + FoodConsumption * 2;
            food = foodCapacity;
            Console.WriteLine("Position of " + rabbitPos.posX + " posX  and " + rabbitPos.posY + " posY\nspeed of " + Speed + "\nsees on " + See + "\nconsumes" + foodConsumption + "\ncaries" + foodCapacity);
        }
    }
    class Actions
    {
        static public Program.Position GoTo(Rabbit.Stats currentRabbit, Program.Position whantToGetTo)
        {
            int distance = Math.Abs(currentRabbit.rabbitPos.posX - whantToGetTo.posX) + Math.Abs(currentRabbit.rabbitPos.posY - whantToGetTo.posY);
            if (currentRabbit.Speed >= distance) { return whantToGetTo; }
            for (int i = 0; i < distance - currentRabbit.Speed; i++)
            {
                if (currentRabbit.rabbitPos.posX > whantToGetTo.posX && currentRabbit.rabbitPos.posY > whantToGetTo.posY)
                {
                    whantToGetTo.posX++;
                    whantToGetTo.posY++;
                }
                if (currentRabbit.rabbitPos.posX < whantToGetTo.posX && currentRabbit.rabbitPos.posY > whantToGetTo.posY)
                {
                    whantToGetTo.posX--;
                    whantToGetTo.posY++;
                }
                if (currentRabbit.rabbitPos.posX > whantToGetTo.posX && currentRabbit.rabbitPos.posY < whantToGetTo.posY)
                {
                    whantToGetTo.posX++;
                    whantToGetTo.posY--;
                }
                if (currentRabbit.rabbitPos.posX < whantToGetTo.posX && currentRabbit.rabbitPos.posY < whantToGetTo.posY)
                {
                    whantToGetTo.posX--;
                    whantToGetTo.posY--;
                }
                if (currentRabbit.rabbitPos.posX == whantToGetTo.posX && currentRabbit.rabbitPos.posY > whantToGetTo.posY)
                {
                    whantToGetTo.posY++;
                }
                if (currentRabbit.rabbitPos.posX == whantToGetTo.posX && currentRabbit.rabbitPos.posY < whantToGetTo.posY)
                {
                    whantToGetTo.posY--;
                }
                if (currentRabbit.rabbitPos.posX > whantToGetTo.posX && currentRabbit.rabbitPos.posY == whantToGetTo.posY)
                {
                    whantToGetTo.posX++;
                }
                if (currentRabbit.rabbitPos.posX < whantToGetTo.posX && currentRabbit.rabbitPos.posY == whantToGetTo.posY)
                {
                    whantToGetTo.posX--;
                }
            }
            return whantToGetTo;
        }
        public static void RunForFood(Rabbit.Stats currentRabbit, Program.Position[] foodList)
        {
            Program.Position nearesrFoodPos = Generate.Paths.SearchFood(currentRabbit, foodList); // will always give a way to go, maybe out of the world but it will
            currentRabbit.rabbitPos = Rabbit.Actions.GoTo(currentRabbit, nearesrFoodPos);
            if (nearesrFoodPos == currentRabbit.rabbitPos)
            {
                currentRabbit.food += 10;
                Console.WriteLine("rabbit ate and got 10 food");
            }

        }
        public static void RunForMate(Rabbit.Stats currentRabbit, List<Rabbit.Stats> rabbitList)
        {
            int dadId = Generate.Paths.SearchMate2(currentRabbit, rabbitList);
            Program.Position nearesrMatePos = Generate.Paths.SearchMate(currentRabbit, rabbitList); // will always give a way to go, maybe out of the world but it will
            currentRabbit.rabbitPos = Rabbit.Actions.GoTo(currentRabbit, nearesrMatePos);
            if (nearesrMatePos == currentRabbit.rabbitPos)
            {
                rabbitList.Add(new Stats(currentRabbit, rabbitList[dadId]));
                return;
            }
            return;
        }
    }
}
