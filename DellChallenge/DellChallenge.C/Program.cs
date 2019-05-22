using System;
using System.Linq;

namespace DellChallenge.C
{
    class Program
    {
        static void Main(string[] args)
        {
            StartHere();
            Console.Read();
        }

        private static void StartHere()
        {
            MyObject myNewObject = new MyObject();

            int sum = myNewObject.Do(1, 3);
            int otherSum = myNewObject.Do(1, 3, 5);

            Console.WriteLine(sum);
            Console.WriteLine(otherSum);
        }
    }

    internal class MyObject
    {
        public int Do(params int[] parameter)
        {
            if (parameter == null)
            {
                return 0;
            }

            return parameter.Sum();
        }
    }
}
