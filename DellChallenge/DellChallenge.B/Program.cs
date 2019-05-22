using System;

namespace DellChallenge.B
{
    class Program
    {
        static void Main(string[] args)
        {
            // Given the classes and interface below, please constructor the proper hierarchy.
            // Feel free to refactor and restructure the classes/interface below.
            // (Hint: Not all species and Fly and/or Swim)
            Species human = new Human();
            human.GetSpecies();

            Species bird = new Bird();
            bird.GetSpecies();

            Console.Read();
        }
    }

    public interface ISpecies
    {
        void Eat();
        void Drink();
    }

    public interface ISwimmer
    {
        void Swim();
    }

    public interface IFlyer
    {
        void Fly();
    }

    public class Species
    {
        public virtual void GetSpecies()
        {
            Console.WriteLine($"Echo who am I?");
        }
    }

    public class Human : Species, ISpecies, ISwimmer
    {
        public void Drink()
        {
            Console.WriteLine("Human drinks");
        }

        public void Eat()
        {
            Console.WriteLine("Human eats");
        }

        public override void GetSpecies()
        {
            base.GetSpecies();
            Console.WriteLine("I'm human !");
        }

        public void Swim()
        {
            Console.WriteLine("Human swim"); // ask Michael Phelps
        }
    }

    public class Bird : Species, ISpecies, IFlyer
    {
        public void Drink()
        {
            Console.WriteLine("Bird drinks");
        }

        public void Eat()
        {
            Console.WriteLine("Bird eats");
        }

        public void Fly()
        {
            Console.WriteLine("Bird flies");
        }

        public override void GetSpecies()
        {
            base.GetSpecies();
            Console.WriteLine("I'm bird !");
        }
    }

    public class Fish : Species, ISpecies, ISwimmer
    {
        public void Drink()
        {
            Console.WriteLine("Fish drinks");
        }

        public void Eat()
        {
            Console.WriteLine("Fish eats");
        }

        public void Swim()
        {
            Console.WriteLine("Fish swim");
        }

        public override void GetSpecies()
        {
            base.GetSpecies();
            Console.WriteLine("I'm fish !");
        }
    }
}

