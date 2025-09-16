// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;

namespace MyWorldAbstractFactory
{
    // === Abstract Products ===
    public interface ICreature
    {
        void Describe();
    }

    public interface IEnvironment
    {
        void Describe();
    }

    // === Abstract Factory ===
    public interface IWorldFactory
    {
        ICreature CreateCreature();
        IEnvironment CreateEnvironment();
    }

    // === Fantasy World ===
    public class Elf : ICreature
    {
        public void Describe()
        {
            Console.WriteLine("🧝 An elegant elf with a magical bow.");
        }
    }

    public class EnchantedForest : IEnvironment
    {
        public void Describe()
        {
            Console.WriteLine("🌲 A glowing enchanted forest full of mysteries.");
        }
    }

    public class FantasyWorldFactory : IWorldFactory
    {
        public ICreature CreateCreature()
        {
            return new Elf();
        }

        public IEnvironment CreateEnvironment()
        {
            return new EnchantedForest();
        }
    }

    // === Sci-Fi World ===
    public class Robot : ICreature
    {
        public void Describe()
        {
            Console.WriteLine("🤖 A humanoid robot powered by AI.");
        }
    }

    public class SpaceStation : IEnvironment
    {
        public void Describe()
        {
            Console.WriteLine("🛰️ A futuristic space station orbiting a distant planet.");
        }
    }

    public class SciFiWorldFactory : IWorldFactory
    {
        public ICreature CreateCreature()
        {
            return new Robot();
        }

        public IEnvironment CreateEnvironment()
        {
            return new SpaceStation();
        }
    }

    // === Client Code ===
    public class World
    {
        private readonly ICreature _creature;
        private readonly IEnvironment _environment;

        public World(IWorldFactory factory)
        {
            _creature = factory.CreateCreature();
            _environment = factory.CreateEnvironment();
        }

        public void Explore()
        {
            Console.WriteLine("🌍 Welcome to your custom world!");
            _creature.Describe();
            _environment.Describe();
        }
    }

    // === Main Program ===
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Để in emoji nếu cần

            Console.WriteLine("=== Welcome to My World Creator ===");
            Console.WriteLine("Choose your world:");
            Console.WriteLine("1 - Fantasy World 🧝");
            Console.WriteLine("2 - Sci-Fi World 🤖");
            Console.Write("Your choice: ");

            string? choice = Console.ReadLine();

            IWorldFactory factory;

            switch (choice)
            {
                case "1":
                    factory = new FantasyWorldFactory();
                    break;
                case "2":
                    factory = new SciFiWorldFactory();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Defaulting to Fantasy World.");
                    factory = new FantasyWorldFactory();
                    break;
            }

            World myWorld = new World(factory);
            Console.WriteLine();
            myWorld.Explore();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
