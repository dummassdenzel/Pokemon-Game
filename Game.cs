
namespace PokemonGame
{

    class Game
    {
        public static bool inBattle = false;
        public static bool GameOngoing = false;
        public static List<Trainer> currentPlayer = new List<Trainer>();

        //The algorithm of the game itself, by yours truly.

        public static void StartGame()
        {

            GameOngoing = true;
            while (GameOngoing == true)
            {
                bool playerExists = false;
                while (playerExists == false)
                {
                    Trainer.ShowAllPlayers();
                    Console.Write("\nWho do you wish to play as?: ");
                    string? playerName = Console.ReadLine();
                    for (int i = 0; i < Trainer.Players.Count; i++)
                    {
                        if (playerName?.ToLower() == Trainer.Players[i].trainerName.ToLower())
                        {
                            playerExists = true;
                            currentPlayer.Add(Trainer.Players[i]);
                            Console.Clear();
                            Console.Beep();
                            Console.WriteLine($"Current Trainer: {currentPlayer[0].trainerName}\n");
                            break;
                        }
                    }
                    if (playerExists == false)
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter a valid trainer's name!");
                        continue;
                    }
                }

                bool mainMenu = true;
                bool showmenu = true;
                while (mainMenu == true)
                {

                    if (showmenu)
                    {
                        showAllActions();
                    }
                    showmenu = true;
                    Console.WriteLine("---------------------------------------------------------------------------");
                    Console.Write($"What do you want to do, {currentPlayer[0].trainerName}?: ");
                    string? whatDoYouWannaDo = Console.ReadLine();
                    switch (whatDoYouWannaDo?.ToLower())
                    {

                        //Catch a Pokemon
                        case "catch a pokemon" or "1":
                            Console.Clear();
                            currentPlayer[0].Catch();
                            break;

                        //Challenge a Trainer
                        case "challenge a trainer" or "2":
                            Console.Clear();
                            Trainer.ShowAllTrainers();
                            currentPlayer[0].Challenge();
                            showmenu = false;
                            break;

                        //Show Current Trainer's Team
                        case "show team" or "3":
                            currentPlayer[0].ShowTeam();
                            Console.Beep();
                            showmenu = false;
                            break;

                        //Heals the current Player's Pokemon
                        case "heal pokemon" or "4":
                            Console.Clear();
                            currentPlayer[0].PokemonCenter();
                            Console.Beep();
                            continue;

                        //Shows all Pokemon
                        case "show all pokemon" or "5":
                            Console.Clear();
                            Pokemon.ShowAllPokemon();
                            Console.Beep();
                            continue;

                        //Shows all Trainers
                        case "show all trainers" or "6":
                            Console.Clear();
                            Trainer.ShowAllTrainers();
                            Console.WriteLine("--------------------");
                            Console.Beep();
                            showmenu = false;
                            continue;

                        //Select a different Trainer
                        case "switch to a different trainer" or "7":
                            Console.Clear();
                            mainMenu = false;
                            currentPlayer.Clear();
                            Console.WriteLine("Understood!\n");
                            Console.Beep();
                            break;

                        //Shows all possible actions
                        case "h":
                            showAllActions();
                            continue;

                        //End the Game
                        case "end game" or "8":
                            mainMenu = false;
                            GameOngoing = false;
                            break;

                        //No Match
                        default:
                            Console.Clear();
                            Console.WriteLine("Please enter a valid action!");
                            continue;
                    }
                    if (mainMenu == false)
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

        //CHARACTER CUSTOMIZATION: Gender*
        public static string enterYourGender()
        {

            string? newchargender = null;
            while (string.IsNullOrEmpty(newchargender))
            {
                Console.WriteLine("\nFirst off, trainer, are you a boy or a girl?: ");
                Console.WriteLine($"\n             [Boy]          [Girl]");
                Console.Write("-");
                string? boyorgirl = Console.ReadLine();

                switch (boyorgirl?.ToLower())
                {
                    case "m":
                    case "male":
                    case "boy":
                        Console.WriteLine("\nUnderstood!\n");
                        newchargender = "m";
                        break;

                    case "f":
                    case "female":
                    case "girl":
                        Console.WriteLine("\nUnderstood!\n");
                        newchargender = "f";
                        break;

                    case "g":
                    case "gay":
                    case "im gay":
                    case "lesbian":
                    case "bi":
                    case "bisexual":
                        Console.WriteLine("Sorry, please enter only your biological gender...");
                        continue;

                    default:
                        Console.WriteLine("Please answer the question properly.");
                        continue;
                }

            }
            return newchargender;
        }

        //CHARACTER CUSTOMIZATION: Name*
        public static string enterYourName()
        {
            //Enter your Name
            string? newcharname = null;
            while (string.IsNullOrEmpty(newcharname))
            {
                Console.WriteLine("Well then, Can I have your name, trainer?: ");
                Console.Write("-");
                newcharname = Console.ReadLine();
                bool alreadyExists = false;
                if (string.IsNullOrEmpty(newcharname))
                {
                    Console.WriteLine("Please enter a valid name.\n");
                }
                else
                {
                    for (int i = 0; i < Trainer.Players.Count; i++)
                    {
                        if (Trainer.Players[i] != null && newcharname != null &&
                            newcharname.ToLower() == Trainer.Players[i].trainerName?.ToLower())
                        {
                            Console.WriteLine("\nSorry, that trainer already exists.\n");
                            alreadyExists = true;
                            break;
                        }
                    }
                    if (alreadyExists == true)
                    {
                        newcharname = null; //Reset the name and continue the loop
                        continue;
                    }

                    if (newcharname?.ToLower().Contains("gay") == true ||
                        newcharname?.ToLower().Contains("shit") == true ||
                        newcharname?.ToLower().Contains("fuck") == true ||
                        newcharname?.ToLower().Contains("tangina") == true)
                    {
                        Console.WriteLine("How rude! Please enter a proper name.\n");
                        newcharname = null; //Reset the name and continue the loop
                        continue;
                    }
                }
            }
            return newcharname;
        }

        //Custom Character Creation!!!
        public static void CustomTrainerCreation()
        {
            bool charcreation = true;
            while (charcreation)
            {
                Console.WriteLine("-Would you like to create your own character?: ");
                Console.WriteLine($"\n             [Yes]          [No]");
                Console.Write("-");
                string? createchar = Console.ReadLine();

                if (createchar?.ToLower().Contains("yes") == true)
                {
                    Console.Beep();
                    Console.WriteLine("\nUnderstood!\n");


                    //CHARACTER CUSTOMIZATION PHASE 1

                    string yourCharGender = enterYourGender();
                    string yourCharName = enterYourName();


                    //CHARACTER CUSTOMIZATION PHASE 2

                    Console.Clear();
                    Trainer newTrainer = new Trainer(yourCharName, yourCharGender, true);
                    break;
                    //End of Character Creation : "Yes"                
                }

                if (createchar?.ToLower().Contains("no") == true)
                {
                    Console.Clear();
                    Console.WriteLine("Understood!");
                    break;
                    //End of Character Creation   : "No"
                }
                if (charcreation == true)
                {
                    Console.WriteLine("Please answer in Yes or No.\n");
                    continue;
                }
            }
            Console.WriteLine("---------------------------------------------------------------------------\n");
        }


        //Start your Journey
        public static void StartJourney()
        {
            Trainer Denzel = new Trainer("Denzel", "m", true);
            Trainer Adrian = new Trainer("Adrian", "m", true);
            Trainer Dominic = new Trainer("Dominic", "m", true);
            Trainer Shawn = new Trainer("Shawn", "m", true);
            Trainer Vince = new Trainer("Vince", "m", true);
            Trainer Iverson = new Trainer("Iverson", "m", true);
            Trainer AJ = new Trainer("AJ", "m", true);
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("Press any key to Start your journey...");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.ReadKey();
            Console.Beep();
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("Professor Eugene:  Welcome to the world of Pokemon!");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("Professor Eugene:  You can start by capturing Pokemon to accompany you on your journey,\n they will serve as your partners as you embark on the path of greatness.");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("Professor Eugene:  Goodluck!");
            Console.WriteLine("---------------------------------------------------------------------------\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            Console.Beep();
        }

        //Show All Available Actions
        public static void showAllActions()
        {
            Console.WriteLine("\nEnter the phrase or the number:");
            Console.WriteLine("(1) - Catch a Pokemon");
            Console.WriteLine("(2) - Challenge a Trainer ");
            Console.WriteLine("(3) - Show Team ");
            Console.WriteLine("(4) - Heal Pokemon ");
            Console.WriteLine("(5) - Show All Pokemon ");
            Console.WriteLine("(6) - Show All Trainers ");
            Console.WriteLine("(7) - Switch to a Different Trainer ");
            Console.WriteLine("(8) - End Game ");
            Console.WriteLine("*Enter 'none' if you wish to go back to choosing an Action.*\n");
        }




    }
}