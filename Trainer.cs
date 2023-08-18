
namespace PokemonGame
{

    public class Trainer
    {
        public string trainerName;
        public string gender;
        public List<Pokemon> team = new List<Pokemon>();
        public bool isPlayer;


        //Arrays for Trainers
        public static List<Trainer> Players = new List<Trainer>();
        public static List<Trainer> Trainers = new List<Trainer>();
        
        public Trainer(string thistrainername, string thisgender, bool isPlayer)
        {
            this.trainerName = thistrainername;
            this.gender = thisgender;
            this.isPlayer = isPlayer;
            Trainers.Add(this);

            if (isPlayer == true)
            {
                Players.Add(this);
                Console.WriteLine($"Congratulations! You can now begin your journey, {trainerName}!");
            }
        }
        public static void ShowAllTrainers()
        {
            Console.WriteLine("\nList of Playable Trainers: ");
            foreach (var item in Players)
            {
                if (item.team.Count == 0)
                    Console.WriteLine($"{item.trainerName} - (No Pokemon)");
                else
                {
                    Console.WriteLine($"{item.trainerName} - Pokemon: {item.team.Count}/6");
                }
            }
            Console.WriteLine("--------------------");
            Console.WriteLine("List of Nearby Trainers: ");
            foreach (var item in Trainers)
            {
                if (item.isPlayer == false)
                {
                    if (item.team.Count == 0)
                        Console.WriteLine($"{item.trainerName} - (No Pokemon)");
                    else
                    {
                        Console.WriteLine($"{item.trainerName} - Pokemon: {item.team.Count}/6");
                    }
                }
            }
            Console.WriteLine();
        }




        //*CATCHING SYSTEM*


        //Catch a Pokemon
        public void Catch()
        {
            var isCatchable = false;
            while (isCatchable == false)
            {
                Pokemon.ShowAllPokemon();
                Console.Write($"{trainerName} - Choose Pokemon to catch: ");
                string? chosenPokemon = Console.ReadLine();



                for (int i = 0; i < Pokemon.AllPokemon.Count; i++)
                {
                    if (Pokemon.AllPokemon[i].pokeName.ToLower() == chosenPokemon.ToLower() && Pokemon.AllPokemon[i].ownerTrainer == "none")
                    {
                        Console.Clear();
                        team.Add(Pokemon.AllPokemon[i]);
                        Pokemon.AllPokemon[i].ownerTrainer = this.trainerName;
                        Console.WriteLine($"Congratulations {trainerName}, you've successfully caught {Pokemon.AllPokemon[i].pokeName}[Lv.{Pokemon.AllPokemon[i].pokelevel}].");
                        Console.WriteLine($"Its stats are: HP:{Pokemon.AllPokemon[i].hp} Attack:{Pokemon.AllPokemon[i].atk} Def:{Pokemon.AllPokemon[i].def} Speed:{Pokemon.AllPokemon[i].speed}\n");
                        isCatchable = true;
                        Console.Beep();

                        break;
                    }
                    if (Pokemon.AllPokemon[i].pokeName == chosenPokemon && Pokemon.AllPokemon[i].ownerTrainer != "none")
                    {
                        Console.WriteLine("That Pokemon already has its Trainer!");
                        continue;
                    }
                }

                if (chosenPokemon == "none")
                {
                    isCatchable = true;
                    break;
                }

                if (isCatchable == false)
                {
                    Console.WriteLine("Please select a catchable Pokemon.");
                    continue;
                }

            }
        }


        //Show a player's Team
        public void ShowTeam()
        {
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine($"{trainerName}'s Team:");
            foreach (var item in team)
            {
                if (item.combathp > 0)
                {
                    Console.WriteLine($"[Lv. {item.pokelevel}] {item.pokeName} - HP: {item.combathp}/{item.hp}");
                }
                else
                {
                    Console.WriteLine($"[Lv. {item.pokelevel}] {item.pokeName} - HP: *Fainted*");
                }

                Console.WriteLine($"Atk:{item.atk} Def:{item.def} Speed:{item.speed}\n");
            }
            Console.WriteLine("---------------------------------------------------------------------------\n");
        }


        //Shows All Challengable Trainers
        public static void ShowAllPlayers()
        {
            Console.WriteLine("\nMain Trainers: ");
            foreach (var item in Players)
            {
                if (item.team.Count == 0)
                    Console.WriteLine($"{item.trainerName} - (No Pokemon)");
                else
                {
                    Console.WriteLine($"{item.trainerName} - Pokemon: {item.team.Count}/6");
                }
            }
            // Console.WriteLine("--------------------");
            // Console.WriteLine("Nearby Trainers:");

            Console.WriteLine();
        }



        //Challenge a Trainer
        public void Challenge()
        {

            bool playerExists = false;
            while (playerExists == false)
            {
                Console.Write($"{trainerName} - Enter a Trainer to duel with: ");
                string? duelledTrainer = Console.ReadLine();
                //Checks if the specified player exists
                for (int i = 0; i < Trainers.Count; i++)
                {
                    if (Trainers[i].trainerName.ToLower() == duelledTrainer.ToLower() && duelledTrainer.ToLower() != trainerName.ToLower() && Trainers[i].team.Count != 0)
                    {
                        playerExists = true;
                        Console.Beep();
                        Console.Clear();
                        Battle.BattlingTrainers.Add(this);
                        Battle.BattlingTrainers.Add(Trainers[i]);
                        Console.WriteLine("\n---------------------------------------------------------------------------");
                        Console.WriteLine($"{Battle.BattlingTrainers[0].trainerName} has challenged {Battle.BattlingTrainers[1].trainerName} to a Pokemon Battle!");
                        Console.WriteLine("---------------------------------------------------------------------------");
                        Battle.PokemonBattle();
                        break;
                    }
                    if (Trainers[i].trainerName.ToLower() == duelledTrainer.ToLower() && duelledTrainer.ToLower() != trainerName.ToLower() && Trainers[i].team.Count == 0)
                    {
                        Console.WriteLine($"{Trainers[i].trainerName} doesn't have any Pokemon!");
                        break;
                    }

                }

                if (trainerName == duelledTrainer)
                {
                    Console.WriteLine("You can't challenge yourself!");
                    continue;
                }
                if (duelledTrainer == "none" || duelledTrainer == "None")
                {
                    playerExists = true;
                    break;
                }
                if (playerExists == false)
                {
                    Console.WriteLine("Please enter a valid trainer's name!");
                    continue;
                }
            }
        }

        //Heal your Pokemon at the Pokemon Center
        public void PokemonCenter()
        {
            foreach (var pokemon in this.team)
            {
                pokemon.combathp = pokemon.hp;
            }
            Console.WriteLine("\nNurse Joy:");
            Console.WriteLine("-Thank you for waiting, your Pokemon have been restored to full health.");
            Console.WriteLine("-We hope to see you again!\n");
        }





        //*NON-PLAYER TRAINERS*

        public static Trainer Steve = new Trainer("Steve", "m", false);
        public static Trainer Alex = new Trainer("Alex", "f", false);


        private void AddNPPokemon(Pokemon pokemon, int level)
        {
            Pokemon NPpokemon = pokemon;
            NPpokemon.ownerTrainer = this.trainerName;
            NPpokemon.pokelevel = level;
            this.team.Add(NPpokemon);
        }


        public static void InitializeNPTrainers()
        {
            Steve.AddNPPokemon(Pokemon.Ninetales, 5);
            Steve.AddNPPokemon(Pokemon.Golurk, 5);

            Alex.AddNPPokemon(Pokemon.Espeon, 6);
        }


    }
}


