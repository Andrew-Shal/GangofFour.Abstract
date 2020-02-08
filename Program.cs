using System;

namespace DOFactory.GangofFour.Abstract.RealWorld
{
    /// <summary>
    /// Program startup class for Real-World
    /// Abstract Factory Design Pattern.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main(string[] args)
        {
            // Create and run the African american world
            ContinentFactory africa = new AfricaFactory();
            AnimalWorld world = new AnimalWorld(africa);
            world.RunFoodChain();

            // Create and run the American animal world
            ContinentFactory america = new AmericaFactory();
            world = new AnimalWorld(america);
            world.RunFoodChain();
        }
    }
    /// <summary>
    /// The 'AbstractFactory' abstract class
    /// </summary>
    abstract class ContinentFactory {
        public abstract Herbivore CreateHerbivore();
        public abstract Carnivore CreateCarnivore();
    }
    /// <summary>
    /// The 'ConcreateFactory1' class
    /// </summary>
    class AfricaFactory: ContinentFactory {
        public override Herbivore CreateHerbivore()
        {
            return new Wildbeest();
        }
        public override Carnivore CreateCarnivore() {
            return new Lion();
        }
    }
    /// <summary>
    /// The 'Concretefactory2' class
    /// </summary>
    class AmericaFactory : ContinentFactory {
        public override Herbivore CreateHerbivore()
        {
            return new Bison();
        }
        public override Carnivore CreateCarnivore()
        {
            return new Wolf();
        }
    }
    /// <summary>
    /// The 'AbstractProductA' abstract class
    /// </summary>
    abstract class Herbivore { }

    /// <summary>
    /// The 'AbstractProductB' abstract class
    /// </summary>
    abstract class Carnivore {
        public abstract void Eat(Herbivore h);
    }
    /// <summary>
    /// The 'ProductA1' class
    /// </summary>
    class Wildbeest : Herbivore { 
    }
    /// <summary>
    /// The 'ProductB1' class
    /// </summary>
    class Lion : Carnivore {
        public override void Eat(Herbivore h) {
            Console.WriteLine(this.GetType().Name + " eats " + h.GetType().Name);
        }
    }
    /// <summary>
    /// The 'ProductA2' class
    /// </summary>
    class Bison : Herbivore { 
        
    }
    /// <summary>
    /// The 'ProductB2' class
    /// </summary>
    class Wolf : Carnivore {
        public override void Eat(Herbivore h)
        {
            Console.WriteLine(this.GetType().Name + " eats " + h.GetType().Name);
        }
    }
    /// <summary>
    /// The 'Client' class
    /// </summary>
    class AnimalWorld {
        private Herbivore _herbivore;
        private Carnivore _carnivore;

        public AnimalWorld(ContinentFactory factory)
        {
            _carnivore = factory.CreateCarnivore();
            _herbivore = factory.CreateHerbivore();
        }

        public void RunFoodChain() {
            _carnivore.Eat(_herbivore);
        }
    }

}
