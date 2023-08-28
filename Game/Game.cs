
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
                    for (int i = 0; i < Trainer.MainTrainers.Count; i++)
                    {
                        if (playerName?.ToLower() == Trainer.MainTrainers[i].trainerName.ToLower())
                        {
                            playerExists = true;
                            currentPlayer.Add(Trainer.MainTrainers[i]);
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
                        GameF.showAllActions();
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
                            currentPlayer[0].CatchPokemon();
                            break;

                        //Challenge a Trainer
                        case "challenge a trainer" or "2":
                            Console.Clear();
                            ShowAllTrainers();
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
                            ShowAllTrainers();
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
                            GameF.showAllActions();
                            showmenu = false;
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
            GameF.PressAnyKeyToContinue();
        }

        //CHARACTER CUSTOMIZATION: Gender*
        public static string EnterYourGender()
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
                        Console.Clear();
                        Console.WriteLine("Sorry, please enter only your biological gender...");
                        continue;

                    default:
                        Console.Clear();
                        Console.WriteLine("Please answer the question properly.");
                        continue;
                }

            }
            return newchargender;
        }

        //CHARACTER CUSTOMIZATION: Name*
        public static string EnterYourName()
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
                    Console.Clear();
                    Console.WriteLine("Please enter a valid name.\n");
                }
                else
                {
                    for (int i = 0; i < Trainer.MainTrainers.Count; i++)
                    {
                        if (Trainer.MainTrainers[i] != null && newcharname != null &&
                            newcharname.ToLower() == Trainer.MainTrainers[i].trainerName?.ToLower())
                        {
                            Console.Clear();
                            Console.WriteLine("Sorry, that trainer already exists.\n");
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
                        Console.Clear();
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
                    Console.Clear();
                    Console.WriteLine("Understood!\n");


                    //CHARACTER CUSTOMIZATION PHASE 1

                    char yourCharGender = char.Parse(EnterYourGender());
                    Console.Clear();
                    string yourCharName = EnterYourName();


                    //CHARACTER CUSTOMIZATION PHASE 2

                    Console.Clear();
                    Trainer newTrainer = new Trainer(yourCharName, yourCharGender);
                    Console.WriteLine($"Congratulations! You can now begin your journey, {yourCharName}!");
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
            GameF.Line();
            Console.WriteLine("Press any key to Start your journey...");
            GameF.Line();
            GameF.PressAnyKeyToContinue();
            
            Trainer Denzel = new Trainer("Denzel", 'm');
            Trainer Adrian = new Trainer("Adrian", 'm');
            Trainer Dominic = new Trainer("Dominic", 'm');
            Trainer Shawn = new Trainer("Shawn", 'm');
            Trainer Vince = new Trainer("Vince", 'm');
            Trainer Iverson = new Trainer("Iverson", 'm');
            Trainer AJ = new Trainer("AJ", 'm');
            Console.Clear();

            GameF.Line();
            Console.WriteLine("Professor Eugene:  Welcome to the world of Pokemon!");
            GameF.Line();
            Console.WriteLine("Professor Eugene:  You can start by capturing Pokemon to accompany you on your journey,\n they will serve as your partners as you embark on the path of greatness.");
            GameF.Line();
            Console.WriteLine("Professor Eugene:  Goodluck!");
            GameF.Line();
            
            Console.WriteLine("\nPress any key to continue...");
            GameF.PressAnyKeyToContinue();
            
        }

        public static void Starters()
        {
            // Console.WriteLine("Professor Eugene: To start your journey, here are 5 Starter Pokemon to accompany you in your adventure.");
            // GameF.Line();
            // Console.WriteLine("Professor Eugene: Inside these Pokeballs reside strong and unique Pokemon.");
            // GameF.Line();
            // Console.WriteLine("Professor Eugene: Choose wisely...");
            // GameF.Line();

            Console.WriteLine("Choose among these 5 Pokemon to begin your journey! ");
            Console.WriteLine("(1) - Charmander");
            Console.WriteLine("(2) - Chikorita");
            Console.WriteLine("(3) - Mudkip");
            Console.WriteLine("(4) - Aron");
            Console.WriteLine("(5) - Pikachu");

            Console.Write($"Who do you wish to have, {currentPlayer[0].trainerName}?: ");

            string? whatDoYouWannaDo = Console.ReadLine();
            switch (whatDoYouWannaDo?.ToLower())
            {
                case "1" or "charmander":
                ReceivePokemon(Pokemon.Charmander, 5);
                break;
                case "2" or "chikorita":
                ReceivePokemon(Pokemon.Chikorita, 5);
                break;
                case "3" or "mudkip":
                ReceivePokemon(Pokemon.Mudkip, 5);
                break;
                case "4" or "aron":
                ReceivePokemon(Pokemon.Aron, 5);
                break;
                case "5" or "Pikachu":
                ReceivePokemon(Pokemon.Pikachu, 5);
                break;
            }
        }

        public static void ReceivePokemon(Pokemon pokemon, int level){
            Pokemon newPokemon = new Pokemon(
                pokemon.PokeName,
                pokemon.hp,
                pokemon.atk,
                pokemon.def,
                pokemon.spatk,
                pokemon.spdef,
                pokemon.speed,
                pokemon.poketype1,
                pokemon.poketype2,
                pokemon.expYield,
                pokemon.evolvelevel
            );
            newPokemon.pokelevel = level;
            newPokemon.LearnedMoves.AddRange(pokemon.LearnedMoves);
            newPokemon.EvolutionStages.AddRange(pokemon.EvolutionStages);
            newPokemon.PokeID = Pokemon.pokeIDPool;
            Pokemon.pokeIDPool++;
            newPokemon.ownerTrainer = currentPlayer[0].trainerName;
            currentPlayer[0].Team.Add(newPokemon);
            Pokemon.AllPokemon.Remove(newPokemon);
        }

        public static void ShowAllTrainers()
        {
            Console.WriteLine("\nList of Playable Trainers: ");
            foreach (var item in Trainer.MainTrainers)
            {
                if (item.Team.Count == 0)
                    Console.WriteLine($"{item.trainerName} - (No Pokemon)");
                else
                {
                    Console.WriteLine($"{item.trainerName} - Pokemon: {item.Team.Count}/6");
                }
            }
            Console.WriteLine("--------------------");
            Console.WriteLine("List of Nearby Trainers: ");
            foreach (var item in AllNPTrainers.NPTrainer.NPTrainers)
            {
                if (item.Team.Count == 0)
                    Console.WriteLine($"{item.trainerName} - (No Pokemon)");
                else
                {
                    Console.WriteLine($"{item.trainerName} - Pokemon: {item.Team.Count}/6");
                }
            }
            Console.WriteLine("--------------------");
            Console.WriteLine("Gym Leaders: ");
            foreach (var item in AllNPTrainers.GymLeader.GymLeaders)
            {
                if (item.Team.Count == 0)
                    Console.WriteLine($"{item.trainerName} - (No Pokemon)");
                else
                {
                    Console.WriteLine($"{item.trainerName} - Pokemon: {item.Team.Count}/6");
                }
            }
            Console.WriteLine();
        }



    }
}