
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
        Console.Clear();
        Game.CustomTrainerCreation();


        Console.WriteLine("---------------------------------------------------------------------------\n");
        Console.Beep();

        Game.StartGame();


    }

}
