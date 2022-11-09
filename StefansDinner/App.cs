using StefansDinner;

public class App
{
    public void Run()
    {
        var round = 1;
        var game = new Game();
        while (true)
        {
            Console.WriteLine($"Spelomgång {round}");
            game.Run();
            System.Threading.Thread.Sleep(5000);
            round++;
        }
    }
}