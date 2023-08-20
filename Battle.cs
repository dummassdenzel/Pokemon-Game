namespace PokemonGame
{

    public class Battle
    {

        public static List<Pokemon> ActivePokemon = new List<Pokemon>();
        public static List<Trainer> BattlingTrainers = new List<Trainer>();

        //Turn-Based Battle System
        public static void EndTurn()
        {
            Pokemon pokemonSwitcher = ActivePokemon[0];
            ActivePokemon[0] = ActivePokemon[1];
            ActivePokemon[1] = pokemonSwitcher;
        }

        //Returns the who takes their turn first
        static Pokemon firstMove(Pokemon leftside, Pokemon rightside)
        {
            if (leftside.speed > rightside.speed)
            {
                return leftside;
            }
            if (rightside.speed > leftside.speed)
            {
                return rightside;
            }
            else
            {
                Random random = new Random();
                int num = random.Next(1, 3);
                if (num == 1)
                {
                    return leftside;
                }
                else
                {
                    return rightside;
                }
            }
        }

        //Displays current HP of Battling Pokemon
        public static void HPUpdate()
        {
            Console.WriteLine("--------------------");
            foreach (var pokemon in ActivePokemon)
            {
                Console.WriteLine($"[Lv. {pokemon.pokelevel}] {pokemon.pokeName} HP: {pokemon.combathp}");
                Console.WriteLine("--------------------");
            }
            Console.Beep();
        }

        //Displays all possible moves of the current Active Pokemon
        public static void ShowMoves()
        {
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine($"{ActivePokemon[0].pokeName}'s Moves: ");
            foreach (var moves in ActivePokemon[0].LearnedMoves)
            {
                Console.WriteLine(moves.moveName);
            }
            Console.WriteLine("---------------------------------------------------------------------------");
        }




        //POKEMON BATTLE SYSTEM - by yours truly

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
                        Console.WriteLine($"{pokemon.pokeName} - *Knocked Out*");
                    }
                    else
                    {
                        Console.WriteLine($"{pokemon.pokeName} - HP: {pokemon.combathp}/{pokemon.hp}");
                    }
                }
            }
            Console.WriteLine("---------------------------------------------------------------------------");

            
            //"Trainers sent out their Pokemon!"  
            foreach (var trainer in BattlingTrainers)
            {
                Console.WriteLine($"{trainer.trainerName} sent out {trainer.battlingTeam[0].pokeName}!");
            }
            Console.WriteLine("---------------------------------------------------------------------------");                     
            ActivePokemon.Add(BattlingTrainers[0].battlingTeam[0]);
            ActivePokemon.Add(BattlingTrainers[1].battlingTeam[0]);



            //MAIN BATTLE SYSTEM
            bool BattleOngoing = true;
            while (BattleOngoing == true)
            {
                //First Move
                if (ActivePokemon[0] != firstMove(ActivePokemon[0], ActivePokemon[1]))
                {
                    Pokemon pokemonSwitcher = ActivePokemon[0];
                    ActivePokemon[0] = ActivePokemon[1];
                    ActivePokemon[1] = pokemonSwitcher;
                }

                //Initiate Move Selection              
                bool Turns = true;
                while (Turns)
                {
                    HPUpdate();
                    Console.WriteLine($"\n*{ActivePokemon[0].pokeName}'s Turn*");
                    ShowMoves();

    
                    ActivePokemon[0].Attack(ActivePokemon[1]);


                    if (ActivePokemon[1].combathp < 1)
                    {
                        Console.WriteLine($"*{ActivePokemon[1].pokeName} has been defeated!*");
                        ActivePokemon[0].GainExp(ActivePokemon[1]);

                        //Switch Pokemon
                        var trainer = BattlingTrainers.Find(t => ActivePokemon[1]?.ownerTrainer == t.trainerName);
                        trainer?.battlingTeam?.RemoveAt(0);
                        if (trainer?.battlingTeam?.Count > 0)
                        {
                            ActivePokemon[1] = trainer.battlingTeam[0];
                            Console.WriteLine("---------------------------------------------------------------------------");
                            Console.WriteLine($"{ActivePokemon[1].ownerTrainer} switched out {trainer.battlingTeam[0].pokeName}");
                            Console.WriteLine("---------------------------------------------------------------------------");
                            break;
                        }
                        else if (trainer?.battlingTeam.Count == 0)
                        {
                            BattleOngoing = false;
                            break;
                        }
                    }
                    EndTurn();
                }

                if (BattleOngoing == true)
                {
                    continue;
                }
                else
                {
                    //Victory Statement
                    Console.WriteLine();
                    Console.WriteLine("---------------------------------------------------------------------------");
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
    }
}