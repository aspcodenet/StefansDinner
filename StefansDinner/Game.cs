using System.Net.Http.Headers;

namespace StefansDinner;

public interface IDinnerGuest
{
    void Act();
}
public class Fly : IDinnerGuest
{
    public void Act()
    {
        var items = new[] { "flyger", "surrar", "landar i maten" };
        Console.WriteLine($"Flugan {items[Game.Random.Next(items.Length)]}");
    }
}
public class Human : IDinnerGuest
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


public class Game
{
    public static Random Random = new Random();

    public List<IDinnerGuest> guests = new List<IDinnerGuest>();

    public Game()
    {
        guests.Add(new Human("Stefan"));
        guests.Add(new Human("Richard"));
        guests.Add(new Human("Kerstin"));
        guests.Add(new Human("Oliver"));
        guests.Add(new Fly());
    }
    public void Run()
    {
        foreach (var x in guests)
            x.Act();
    }
}

