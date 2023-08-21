
using System.Security.Cryptography;
using PokemonGame;

public class ActualGame
{       
        
    static void Main(string[] args)
    {      
        Console.Beep();
        Game.StartJourney();               
        Game.CustomTrainerCreation();        
        Console.Beep();
        Game.StartGame();


    }

}
