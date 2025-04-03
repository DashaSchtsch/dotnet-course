using System;

struct PlayerStats
{
    public int Level { get; set; }
    public string GameClass { get; set; }

    public PlayerStats(int level, string gameClass)
    {
        Level = level;
        GameClass = gameClass;
    }
}

class Player
{
    public string Name { get; set; }
    public PlayerStats Stats { get; set; }

    public Player(string name, PlayerStats stats)
    {
        Name = name;
        Stats = stats;
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        PlayerStats pl1Stats = new PlayerStats(7, "Launcher");
        PlayerStats pl2Stats = new PlayerStats(6, "Battle Mage");
        Player player1 = new Player("Cintia", pl1Stats);
        Player player2 = new Player("Mike", pl2Stats);
        /*
        Стек

        player2 → (Посилання на об'єкт у купі)
        player1 → (Посилання на об'єкт у купі)
        pl2Stats(Level: 6, GameClass: → "Battle Mage")
        pl1Stats (Level: 7, GameClass: → "Launcher")


        Купа

        "Launcher"
        "Battle Mage"
        "Cintia"
        "Mike"
        Player object ("Cintia", Stats → {Level: 7, GameClass: → "Launcher"})
        Player object ("Mike", Stats → {Level: 6, GameClass: → "Battle Mage"})

        */

        Console.WriteLine("=== Перед змінами ===");
        Console.WriteLine($"Player 1: {player1.Name}, Level: {player1.Stats.Level}, Class: {player1.Stats.GameClass}");
        Console.WriteLine($"Player 2: {player2.Name}, Level: {player2.Stats.Level}, Class: {player2.Stats.GameClass}");

        pl1Stats.Level = 15;

        /*
        Стек

        player2 → (Посилання на об'єкт у купі)
        player1 → (Посилання на об'єкт у купі)
        pl2Stats(Level: 6, GameClass: → "Battle Mage")
        pl1Stats (Level: 15, GameClass: → "Launcher")


        Купа

        "Launcher"
        "Battle Mage"
        "Cintia"
        "Mike"
        Player object ("Cintia", Stats → {Level: 7, GameClass: → "Launcher"})
        Player object ("Mike", Stats → {Level: 6, GameClass: → "Battle Mage"})

        */

        PlayerStats pl3Stats = pl1Stats;
        Player player3 = new Player("Celia", pl3Stats);

        /*
        Стек

        player3 → (Посилання на об'єкт у купі)
        pl3Stats (Level: 15, GameClass: → "Launcher")
        player2 → (Посилання на об'єкт у купі)
        player1 → (Посилання на об'єкт у купі)
        pl2Stats(Level: 6, GameClass: → "Battle Mage")
        pl1Stats (Level: 15, GameClass: → "Launcher")


        Купа

        "Launcher"
        "Battle Mage"
        "Cintia"
        "Mike"
        "Celia"
        Player object ("Cintia", Stats → {Level: 7, GameClass: → "Launcher"})
        Player object ("Mike", Stats → {Level: 6, GameClass: → "Battle Mage"})
        Player object ("Celia", Stats → {Level: 15, GameClass: → "Launcher"})

        */

        Player player4 = player2;
        player4.Name = "Martin";
        player4.Stats = new PlayerStats(6, "Archer");

        /*
        Стек

        player4 → (те саме посилання, що і у player2)
        player3 → (Посилання на об'єкт у купі)
        pl3Stats (Level: 15, GameClass: → "Launcher")
        player2 → (Посилання на об'єкт у купі)
        player1 → (Посилання на об'єкт у купі)
        pl2Stats(Level: 6, GameClass: → "Battle Mage")
        pl1Stats (Level: 15, GameClass: → "Launcher")


        Купа

        "Launcher"
        "Battle Mage"
        "Cintia"
        "Celia"
        "Martin"
        "Archer"
        Player object ("Cintia", Stats → {Level: 7, GameClass: → "Launcher"})
        Player object ("Martin", Stats → {Level: 6, GameClass: → "Archer"})
        Player object ("Celia", Stats → {Level: 15, GameClass: → "Launcher"})

        */

        PlayerStats pl5Stats = pl1Stats;
        pl3Stats.Level = 9;
        Player player5 = new Player("Celine", pl3Stats);

        /*
        Стек

        player5 → (Посилання на новий об'єкт у купі)
        player4 → (те саме посилання, що і у player2)
        player3 → (Посилання на об'єкт у купі)
        pl3Stats (Level: 9, GameClass: → "Launcher")
        player2 → (Посилання на об'єкт у купі)
        player1 → (Посилання на об'єкт у купі)
        pl2Stats(Level: 6, GameClass: → "Battle Mage")
        pl1Stats (Level: 15, GameClass: → "Launcher")


        Купа

        "Launcher"
        "Battle Mage"
        "Cintia"
        "Celia"
        "Martin"
        "Archer"
        "Celine"
        Player object ("Celine", Stats → {Level: 9, GameClass: → "Launcher"})
        Player object ("Martin", Stats → {Level: 6, GameClass: → "Archer"})
        Player object ("Celia", Stats → {Level: 15, GameClass: → "Launcher"})

        */

        Console.WriteLine("\n=== Після змін ===");
        Console.WriteLine($"Player 1: {player1.Name}, Level: {player1.Stats.Level}, Class: {player1.Stats.GameClass}");
        Console.WriteLine($"Player 2: {player2.Name}, Level: {player2.Stats.Level}, Class: {player2.Stats.GameClass}");
        Console.WriteLine($"Player 3: {player3.Name}, Level: {player3.Stats.Level}, Class: {player3.Stats.GameClass}");
        Console.WriteLine($"Player 4: {player4.Name}, Level: {player4.Stats.Level}, Class: {player4.Stats.GameClass}");
        Console.WriteLine($"Player 5: {player5.Name}, Level: {player5.Stats.Level}, Class: {player5.Stats.GameClass}");
    }
}