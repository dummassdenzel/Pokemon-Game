namespace PokemonGame
{

    public class Battle
    {

        //POKEMON BATTLE SYSTEM - by yours truly

        public static List<Pokemon> ActivePokemon = new List<Pokemon>();
        public static List<Trainer> BattlingTrainers = new List<Trainer>();
        public static void PokemonBattle()
        {
            //Print Team of Both Players
            foreach (var trainers in BattlingTrainers)
            {
                Console.WriteLine($"{trainers.trainerName}'s Team: ");
                foreach (var pokemon in trainers.Team)
                {
                    if (pokemon.combathp <= 0)
                    {
                        Console.WriteLine($"{pokemon.PokeName} - *Knocked Out*");
                    }
                    else
                    {
                        Console.WriteLine($"{pokemon.PokeName} - HP: {pokemon.combathp}/{pokemon.hp}");
                    }
                }
            }
            Console.WriteLine("---------------------------------------------------------------------------");

            
            //"Trainers sent out their Pokemon!"  
            foreach (var trainer in BattlingTrainers)
            {
                Console.WriteLine($"{trainer.trainerName} sent out {trainer.battlingTeam[0].PokeName}!");
            }
            Console.WriteLine("---------------------------------------------------------------------------");                     
            ActivePokemon.Add(BattlingTrainers[0].battlingTeam[0]);
            ActivePokemon.Add(BattlingTrainers[1].battlingTeam[0]);



            //MAIN BATTLE SYSTEM
            bool BattleOngoing = true;
            while (BattleOngoing == true)
            {
                
                //First Move
                ActivePokemon = ActivePokemon.OrderByDescending(pokemon => pokemon.speed).ToList();

                //Initiate Move Selection              
                bool Turns = true;
                while (Turns)
                {
                    HPUpdate();
                    Console.WriteLine($"\n*{ActivePokemon[0].PokeName}'s Turn*");
                    ShowMoves();    
                    ActivePokemon[0].Attack(ActivePokemon[1]);

                    //Enemy Defeated?
                    if (ActivePokemon[1].combathp < 1)
                    {
                        Console.WriteLine($"*{ActivePokemon[1].PokeName} has been defeated!*");
                        ActivePokemon[0].GainExp(ActivePokemon[1]);

                        //Switch Pokemon
                        var trainer = BattlingTrainers.Find(t => ActivePokemon[1]?.ownerTrainer == t.trainerName);
                        trainer?.battlingTeam?.RemoveAt(0);
                        if (trainer?.battlingTeam?.Count > 0)
                        {
                            ActivePokemon[1] = trainer.battlingTeam[0];
                            Console.WriteLine("---------------------------------------------------------------------------");
                            Console.WriteLine($"{ActivePokemon[1].ownerTrainer} switched out {trainer.battlingTeam[0].PokeName}");
                            Console.WriteLine("---------------------------------------------------------------------------");
                            break;
                        }
                        else if (trainer?.battlingTeam.Count == 0)
                        {
                            BattleOngoing = false;
                            break;
                        }
                    }
                    //End Turn
                    EndTurn();
                }

                if (BattleOngoing == true)
                {
                    continue;
                }
                else
                {
                    //Victory Statement                    
                    Console.WriteLine("\n---------------------------------------------------------------------------");
                    Console.WriteLine($"{ActivePokemon[0].ownerTrainer} has won the battle!");
                    Console.WriteLine("---------------------------------------------------------------------------");
                    Console.WriteLine($"The duel between {BattlingTrainers[0].trainerName} and {BattlingTrainers[1].trainerName} has concluded");
                    Console.WriteLine("---------------------------------------------------------------------------\n");
                }

                //Reset NPTrainers
                foreach (var item in BattlingTrainers)
                {
                    if (item.isPlayer == false)
                    {
                        foreach (var pokemon in item.Team)
                        {
                            pokemon.combathp = pokemon.hp;
                        }
                    }
                }
                //Clears Active Pokemon slots
                ActivePokemon.Clear();
                foreach (var trainer in BattlingTrainers)
                {
                    trainer.battlingTeam.Clear();
                }
                BattlingTrainers.Clear();
                Console.Beep();
                BattleOngoing = false;
                break;


            }
        }

        //Turn-Based Battle System
        public static void EndTurn()
        {
            Pokemon pokemonSwitcher = ActivePokemon[0];
            ActivePokemon[0] = ActivePokemon[1];
            ActivePokemon[1] = pokemonSwitcher;
        }

        //Displays current HP of Battling Pokemon
        public static void HPUpdate()
        {
            Console.WriteLine("--------------------");
            foreach (var pokemon in ActivePokemon)
            {
                Console.WriteLine($"[Lv. {pokemon.pokelevel}] {pokemon.PokeName} HP: {pokemon.combathp}");
                Console.WriteLine("--------------------");
            }
            Console.Beep();
        }

        //Displays all possible moves of the current Active Pokemon
        public static void ShowMoves()
        {
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine($"{ActivePokemon[0].PokeName}'s Moves: ");
            foreach (var moves in ActivePokemon[0].LearnedMoves)
            {
                Console.WriteLine(moves.moveName);
            }
            Console.WriteLine("---------------------------------------------------------------------------");
        }






    }
}