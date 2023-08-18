
using PokemonGame;

public class ActualGame
{       
        
    static void Main(string[] args)
    {

        Pokemon.InitializePokemonMoves();
        Types.InitializeWeaknesses();
        Trainer.InitializeNPTrainers();
        Console.Beep();

        Game.StartJourney();               
        Game.CustomTrainerCreation();        
        Console.Beep();

        Game.StartGame();


    }

}
