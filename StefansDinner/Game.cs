using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace StefansDinner;


public interface IGameStorage
{
    public void Save(List<IDinnerGuest> list);
    public List<IDinnerGuest> Load();
}

public class JsonGameStorage : IGameStorage
{
    private JsonSerializerSettings _settings = new JsonSerializerSettings
    {
        TypeNameHandling = TypeNameHandling.All
    };

    public JsonGameStorage()
    {
    }
    public void Save(List<IDinnerGuest> list)
    {
        var s = JsonConvert.SerializeObject(list,_settings);
        File.WriteAllText("save.txt", s);
    }

    public List<IDinnerGuest> Load()
    {
        if (!File.Exists("save.txt")) return new List<IDinnerGuest>(); 
        return JsonConvert.DeserializeObject<List<IDinnerGuest>>(File.ReadAllText("save.txt"), _settings);
    }
}


public interface IDinnerGuest
{
    void Act();
    void MightLevelUp();
}
public class Fly : IDinnerGuest
{
    private int level = 0;
    public string latestAction = "";
    public void Act()
    {
        var items = new[] { "flyger", "surrar", "landar i maten" };
        latestAction = items[Game.Random.Next(items.Length)];
        Console.WriteLine($"Flugan {latestAction}");
    }

    public void MightLevelUp()
    {
        if (latestAction == "landar i maten")
            level++;
    }
}
public class Human : IDinnerGuest
{
    private int level = 0;
    public int burpsInARow = 0;
    public string latestAction = "";

    public Human(string name)
    {
        Name = name;
    }
    public string Name { get; set; }
    public void Act()
    {
        var items = new[] { "rapar", "äter", "dricker", "pratar" };
        latestAction = items[Game.Random.Next(items.Length)];
        Console.WriteLine($"{Name} {latestAction}");

    }

    public void MightLevelUp()
    {
        if (latestAction == "rapar")
            burpsInARow++;
        else
            burpsInARow = 0;

        if (burpsInARow == 3)
        {
            level++;
            burpsInARow = 0;
        }
    }
}


public class Game
{
    public static Random Random = new Random();
    public IGameStorage storage = new JsonGameStorage();

    public List<IDinnerGuest> guests = new List<IDinnerGuest>();

    public void Save()
    {
        storage.Save(guests);
    }

    public Game()
    {
        guests = storage.Load();

        if (guests.Count() == 0) // Never played before????
        {
            guests.Add(new Human("Stefan"));
            guests.Add(new Human("Richard"));
            guests.Add(new Human("Kerstin"));
            guests.Add(new Human("Oliver"));
            guests.Add(new Fly());
        }
    }
    public void Run()
    {
        foreach (var x in guests)
        {
            x.Act();
            x.MightLevelUp();
        }
    }
}

