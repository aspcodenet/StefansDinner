using System.Net.Http.Headers;

namespace StefansDinner;

public class Game
{
    public static Random Random = new Random();

    public Human stefan = new Human("Stefan");
    public Human kerstin = new Human("Kerstin");
    public Human oliver = new Human("Oliver");
    public Fly fly = new Fly();
    public Game()
    {
        
    }
    public void Run()
    {
        stefan.Act();
        kerstin.Act();
        oliver.Act();
        fly.Act();
    }
}

public class Fly
{
    public void Act()
    {
        var items = new[] { "flyger", "surrar", "landar i maten" };
        Console.WriteLine($"Flugan {items[Game.Random.Next(items.Length)]}");
    }
}

public class Human
{
    public Human(string name)
    {
        Name = name;
    }
    public string Name { get; set; }
    public void Act()
    {
        var items = new[] { "rapar", "äter", "dricker", "pratar" };
        Console.WriteLine($"{Name} {items[Game.Random.Next(items.Length)]}");

    }
}