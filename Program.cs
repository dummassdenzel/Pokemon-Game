
using System.Security.Cryptography;
using PokemonGame;

public class ActualGame
{       
        
    static void Main(string[] args)
    {      
        Console.Beep();
        Game.StartJourney();               
        Game.CustomTrainerCreation();  
        foreach(var item in Pokemon.PokeDex){
            Console.WriteLine(item.PokeName);
        }      
        Console.Beep();
        Game.StartGame();
        
    
    }

}
