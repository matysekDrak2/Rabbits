using System;

namespace RandomGenerator
{
    class NahodneCislo
    {
        public static int Cele(int min, int max)
        {
            Random generetor = new Random();
            return generetor.Next(min, (max + 1));
        }
        public static double Desetine(int min, int max)
        {
            Random generetor = new Random();
            return generetor.NextDouble() * (max - min) + min;
        }
    }
}
