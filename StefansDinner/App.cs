using StefansDinner;

public class App
{
    public void Run()
    {
        var round = 1;
        var game = new Game();
        Console.WriteLine("Prexx x to exit");
        while (true)
        {
            Console.WriteLine($"Spelomgång {round}");
            game.Run();
            round++;
            Console.WriteLine("Enter any key to go on - or x to quit ");
            var ch = System.Console.ReadKey();
            if (ch.KeyChar == 'x')
                break;
        }

        game.Save();
    }
}