
namespace PokemonGame
{

    public class Trainer
    {   
        public string trainerName;
        public char gender;
        public List<Pokemon> Team = new List<Pokemon>();
        public List<Pokemon> battlingTeam = new List<Pokemon>();
        public bool isPlayer;
        public List<Locations> CurrentLocation = new List<Locations>();
        public bool HasNoElligiblePokemon
        {
            get
            {
                if (battlingTeam.All(pokemon => pokemon.combathp == 0))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public static List<Trainer> MainTrainers = new List<Trainer>();
        public static List<Trainer> Trainers = new List<Trainer>();
        public Trainer(string thistrainername, char thisgender)
        {
            trainerName = thistrainername;
            gender = thisgender;
            isPlayer = true;
            Trainers.Add(this);
            if (isPlayer == true)
            {
                MainTrainers.Add(this);
            }
        }

        public void Catch(Pokemon? pokemon)
        {
            if (pokemon == null)
            {
                Console.WriteLine("Invalid Pokemon.");
                return;
            }

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
            newPokemon.LearnedMoves.AddRange(pokemon.LearnedMoves);
            newPokemon.EvolutionStages.AddRange(pokemon.EvolutionStages);
            newPokemon.PokeID = Pokemon.pokeIDPool;
            Pokemon.pokeIDPool++;
            newPokemon.ownerTrainer = this.trainerName;
            Team.Add(newPokemon);
            Pokemon.AllPokemon.Remove(newPokemon);

            Console.Clear();
            Console.WriteLine($"Congratulations {trainerName}, you've successfully caught {newPokemon.PokeName}[Lv.{newPokemon.pokelevel}].");
            Console.WriteLine($"Its stats are: HP:{newPokemon.hp} Attack:{newPokemon.atk} Def:{newPokemon.def} Speed:{newPokemon.speed}\n");

        }

        //Catch a Pokemon
        public void CatchPokemon()
        {
            Pokemon.ShowAllPokemon();
            string? chosenPokemon = null;
            while (string.IsNullOrEmpty(chosenPokemon))
            {
                Console.Write($"{trainerName} - Choose Pokemon to catch: ");
                chosenPokemon = Console.ReadLine();

                if (Pokemon.AllPokemon.Any(pokemon => pokemon.PokeName.ToLower() == chosenPokemon?.ToLower()))
                {
                    Catch(Pokemon.AllPokemon.Find(pokemon => pokemon.PokeName.ToLower() == chosenPokemon?.ToLower()));
                    break;
                }
                if (chosenPokemon == "none")
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.WriteLine("Please select a catchable Pokemon.");
                    chosenPokemon = null;
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
                    Console.WriteLine($"[ID No.{item.PokeID}] [Lv. {item.pokelevel}] {item.PokeName} - HP: {item.combathp}/{item.hp}");
                }
                else
                {
                    Console.WriteLine($"[ID No.{item.PokeID}] [Lv. {item.pokelevel}] {item.PokeName} - HP: *Fainted*");
                }

                Console.WriteLine($"[Atk:{item.atk} Def:{item.def} Speed:{item.speed}]");
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


