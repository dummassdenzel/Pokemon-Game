
using PokemonGame;

public class ActualGame
{

    public static bool inBattle = false;
    public static bool GameOngoing = false;
    public static List<Trainer> currentPlayer = new List<Trainer>();

    static void Main(string[] args)
    {
        Pokemon.InitializePokemonMoves();
        Types.InitializeWeaknesses();
        Console.Beep();
        Trainer.StartJourney();


        bool charcreation = true;
        while (charcreation == true)
        {
            Console.WriteLine("-Would you like to create your own character? (y/n): ");
            Console.Write("-");
            string createchar = Console.ReadLine();
            if (createchar.ToLower().Contains("yes"))
            {
                Console.Beep();
                Console.WriteLine("\nUnderstood!\n");

                string newchargender;
                string newcharname;

                bool entergender = true;
                while (entergender == true)
                {
                    Console.WriteLine("\nFirst off, trainer, are you a boy or a girl? (m/f): ");
                    Console.Write("-");
                    string boyorgirl = Console.ReadLine();
                    switch (boyorgirl.ToLower())
                    {
                        case "m" or "male" or "boy":
                            Console.WriteLine("\nUnderstood!\n");
                            newchargender = "m";
                            entergender = false;
                            break;

                        case "f" or "female" or "girl":
                            Console.WriteLine("\nUnderstood!\n");
                            newchargender = "f";
                            entergender = false;
                            break;

                        case "g" or "gay" or "im gay" or "lesbian" or "bi" or "bisexual":
                            Console.WriteLine("Sorry, please enter only your biological gender...");
                            continue;

                        default:
                            Console.WriteLine("Please answer the question properly.");
                            continue;

                    }
                    bool entername = true;
                    while (entername == true)
                    {
                        Console.WriteLine("Well then, Can I have your name, trainer?: ");
                        Console.Write("-");
                        newcharname = Console.ReadLine();

                        if (newcharname.ToLower().Contains("gay") || newcharname.ToLower().Contains("shit") || newcharname.ToLower().Contains("fuck") || newcharname.ToLower().Contains("tangina"))
                        {
                            Console.WriteLine("How rude! Please enter a proper name.\n");
                            continue;
                        }

                        Console.Clear();
                        Trainer newTrainer = new Trainer(newcharname, newchargender);
                        entername = false;
                        break;
                    }
                    charcreation = false;
                }

            }
            if (createchar.ToLower().Contains("no"))
            {
                Console.Clear();
                Console.WriteLine("Understood!\n");
                charcreation = false;
                break;
            }
            if (charcreation == true)
            {
                Console.WriteLine("Please answer in Yes or No.\n");
                continue;
            }
        }


        Trainer Denzel = new Trainer("Denzel", "m");
        Trainer Adrian = new Trainer("Adrian", "m");
        Trainer Dominic = new Trainer("Dominic", "m");
        Trainer Shawn = new Trainer("Shawn", "m");
        Trainer Vince = new Trainer("Vince", "m");
        Trainer Iverson = new Trainer("Iverson", "m");
        Console.WriteLine("---------------------------------------------------------------------------\n");
        Console.Beep();


        GameOngoing = true;
        while (GameOngoing == true)
        {
            bool playerExists = false;
            while (playerExists == false)
            {
                Trainer.ShowAllTrainers();
                Console.Write("\nWho do you wish to play as?: ");
                string playerName = Console.ReadLine();
                for (int i = 0; i < Trainer.Players.Count; i++)
                {
                    if (playerName.ToLower() == Trainer.Players[i].trainerName.ToLower())
                    {
                        playerExists = true;
                        currentPlayer.Add(Trainer.Players[i]);
                        Console.Beep();
                        Console.WriteLine($"Current Trainer: {currentPlayer[0].trainerName}\n");
                        break;
                    }
                }
                if (playerExists == false)
                {
                    Console.WriteLine("Please enter a valid trainer's name!");
                    continue;
                }
            }

            Console.WriteLine("*Enter 'h' to show list of all possible actions.*");
            bool SwitchTrainer = false;
            while (SwitchTrainer == false)
            {
                Console.Write($"What do you want to do, {currentPlayer[0].trainerName}?: ");
                string whatDoYouWannaDo = Console.ReadLine();
                switch (whatDoYouWannaDo.ToLower())
                {

                    //Catch a Pokemon
                    case "catch a pokemon" or "1":
                        Console.Clear();
                        Pokemon.ShowAllPokemon();
                        currentPlayer[0].Catch();
                        break;

                    //Challenge a Trainer
                    case "challenge a trainer" or "2":
                        if (currentPlayer[0].team.Count != 0)
                        {   
                            Console.Clear();
                            Trainer.ShowAllTrainers();
                            currentPlayer[0].Challenge();
                        }
                        else
                        {
                            Console.WriteLine("You dont have any Pokemon!");
                            continue;
                        }
                        break;

                    //Catch a Pokemon
                    case "show team" or "3":
                        currentPlayer[0].ShowTeam();
                        Console.Beep();
                        break;

                    //Shows all Trainers
                    case "heal pokemon" or "4":
                        Console.Clear();
                        currentPlayer[0].PokemonCenter();
                        Console.Beep();
                        continue;

                    //Shows all Pokemon
                    case "show all pokemon" or "5":
                        Pokemon.ShowAllPokemon();
                        Console.Beep();
                        continue;

                    //Shows all Trainers
                    case "show all trainers" or "6":
                        Trainer.ShowAllTrainers();
                        Console.Beep();
                        continue;

                    //Select a different Trainer
                    case "switch to a different trainer" or "7":
                        SwitchTrainer = true;
                        currentPlayer.Clear();
                        Console.WriteLine("Understood!\n");
                        Console.Beep();
                        break;

                    //Shows all possible actions
                    case "h":
                        Game.showAllActions();
                        continue;

                    //End the Game
                    case "end game" or "8":
                        SwitchTrainer = true;
                        GameOngoing = false;
                        break;

                    //No Match
                    default:
                        Console.WriteLine("Please enter a valid action!");
                        continue;
                }
                if (SwitchTrainer == false)
                {
                    continue;
                }
            }

            if (GameOngoing == true)
            {
                continue;
            }
        }


        Console.WriteLine("Press any key to finish the game.");
        Console.ReadKey();

    }

}
