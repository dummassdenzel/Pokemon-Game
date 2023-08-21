
namespace PokemonGame
{

    public class Trainer
    {
        public string trainerName;
        public char gender;
        public List<Pokemon> Team = new List<Pokemon>();
        public List<Pokemon> battlingTeam = new List<Pokemon>();
        public bool isPlayer;


        public static List<Trainer> MainTrainers = new List<Trainer>();
        public static List<Trainer> Trainers = new List<Trainer>();
        public Trainer(string thistrainername, char thisgender)
        {
            this.trainerName = thistrainername;
            this.gender = thisgender;
            // this.isPlayer = isPlayer;
            MainTrainers.Add(this);          
            Trainers.Add(this);
        }

        

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
                    if (Pokemon.AllPokemon[i].pokeName.ToLower() == chosenPokemon?.ToLower() && Pokemon.AllPokemon[i].ownerTrainer == "none")
                    {
                        Console.Clear();
                        Team.Add(Pokemon.AllPokemon[i]);
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


        //Show current Trainer's Team
        public void ShowTeam()
        {
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine($"{trainerName}'s Team:");
            foreach (var item in Team)
            {
                if (item.combathp > 0)
                {
                    Console.WriteLine($"[Lv. {item.pokelevel}] {item.pokeName} - HP: {item.combathp}/{item.hp}");
                }
                else
                {
                    Console.WriteLine($"[Lv. {item.pokelevel}] {item.pokeName} - HP: *Fainted*");
                }

                Console.WriteLine($"Atk:{item.atk} Def:{item.def} Speed:{item.speed}");
                Console.WriteLine($"Total Exp Gained: {item.totalExp}\n");
            }
            Console.WriteLine("---------------------------------------------------------------------------\n");
        }


        //Shows All Main Trainers
        public static void ShowAllPlayers()
        {
            Console.WriteLine("\nMain Trainers: ");
            foreach (var item in MainTrainers)
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



        //Challenge a Trainer (kinda proud of this one)
        public void Challenge()
        {
            foreach (var pokemon in Team)
            {
                if (pokemon.combathp > 0)
                {
                    battlingTeam.Add(pokemon);
                }
            }
            if (battlingTeam.Any())
            {
                bool playerExists = false;
                while (playerExists == false)
                {
                    Console.Write($"{trainerName} - Enter a Trainer to duel with: ");
                    string? duelledTrainer = Console.ReadLine();

                    //Checks if the specified player exists
                    for (int i = 0; i < Trainers.Count; i++)
                    {
                        if (Trainers[i].trainerName.ToLower() == duelledTrainer?.ToLower() &&
                            duelledTrainer.ToLower() != trainerName.ToLower())
                        {
                            playerExists = true;
                            foreach (var pokemon in Trainers[i].Team)
                            {
                                if (pokemon.combathp > 0)
                                {
                                    Trainers[i].battlingTeam.Add(pokemon);
                                }
                            }
                            if (Trainers[i].battlingTeam.Any())
                            {
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
                            else
                            {
                                Console.WriteLine($"*{Trainers[i].trainerName} doesn't have any elligible Pokemon!*\n");
                                playerExists = false;
                                continue;
                            }
                        }

                    }

                    if (trainerName == duelledTrainer)
                    {
                        Console.WriteLine("You can't challenge yourself!");
                        continue;
                    }
                    if (duelledTrainer?.ToLower() == "none")
                    {
                        playerExists = true;
                        break;
                    }
                    if (playerExists == false)
                    {
                        Console.WriteLine("Please enter a valid trainer's name.");
                        continue;
                    }
                }
            }
            else
            {
                Console.WriteLine("*You dont have any elligible Pokemon!*");
            }
        }

        //Heal your Pokemon at the Pokemon Center
        public void PokemonCenter()
        {
            foreach (var pokemon in Team)
            {
                pokemon.combathp = pokemon.hp;
            }
            Console.WriteLine("\nNurse Joy:");
            Console.WriteLine("-Thank you for waiting, your Pokemon have been restored to full health.");
            Console.WriteLine("-We hope to see you again!\n");
        }





    }
}


