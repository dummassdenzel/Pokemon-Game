namespace PokemonGame{

    public class Battle{
        
        public static List<Pokemon> ActivePokemon = new List<Pokemon>();
        public static List<Trainer> BattlingTrainers = new List<Trainer>();

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
            Console.WriteLine($"[Lv. {ActivePokemon[0].pokelevel}] {ActivePokemon[0].pokeName} HP: {ActivePokemon[0].combathp}");
            Console.WriteLine("--------------------");
            Console.WriteLine($"[Lv. {ActivePokemon[1].pokelevel}] {ActivePokemon[1].pokeName} HP: {ActivePokemon[1].combathp}");
            Console.WriteLine("--------------------");
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
            

            //Team 1 and Team 2
            List<Pokemon> LeftTeam = new List<Pokemon>();
            List<Pokemon> RightTeam = new List<Pokemon>();
            for (int i = 0; i < BattlingTrainers[0].team.Count; i++)
            {
                LeftTeam.Add(BattlingTrainers[0].team[i]);
            }
            for (int i = 0; i < BattlingTrainers[1].team.Count; i++)
            {
                RightTeam.Add(BattlingTrainers[1].team[i]);
            }

            //Print Team of Both Players
            Console.WriteLine($"{BattlingTrainers[0].trainerName}'s Team: ");
            foreach (var pokemoninteam0 in LeftTeam)
            {
                if (pokemoninteam0.combathp <= 0)
                {
                    Console.WriteLine($"{pokemoninteam0.pokeName} - Knocked Out");
                }
                else
                {
                    Console.WriteLine($"{pokemoninteam0.pokeName} - HP: {pokemoninteam0.combathp}/{pokemoninteam0.hp}");
                }
            }
            Console.WriteLine();
            Console.WriteLine($"{BattlingTrainers[1].trainerName}'s Team: ");
            foreach (var pokemoninteam1 in RightTeam)
            {
                if (pokemoninteam1.combathp <= 0)
                {
                    Console.WriteLine($"{pokemoninteam1.pokeName} - Knocked Out");
                }
                else
                {
                    Console.WriteLine($"{pokemoninteam1.pokeName} - HP: {pokemoninteam1.combathp}/{pokemoninteam1.hp}");
                }
            }
            Console.WriteLine("---------------------------------------------------------------------------");

            //Sets Active Pokemon
            Pokemon activePokemon0 = LeftTeam[0];
            Pokemon activePokemon1 = RightTeam[0];
            ActivePokemon.Add(activePokemon0);
            ActivePokemon.Add(activePokemon1);
            //note to self, if it does not work for more pokemon, make it a while loop instead of an if statement
            if (activePokemon0.combathp <= 0)
            {
                for (int i = 0; i < LeftTeam.Count; i++)
                {
                    activePokemon0 = LeftTeam[i];
                    ActivePokemon[0] = activePokemon0;

                }
            }

            if (activePokemon1.combathp <= 0)
            {
                for (int i = 0; i < RightTeam.Count; i++)
                {
                    activePokemon1 = RightTeam[i];
                    ActivePokemon[1] = activePokemon1;

                }
            }

            //"Trainers sent out their Pokemon!"
            Console.WriteLine($"{BattlingTrainers[0].trainerName} sent out {ActivePokemon[0].pokeName}!");
            Console.WriteLine($"{BattlingTrainers[1].trainerName} sent out {ActivePokemon[1].pokeName}!");
            Console.WriteLine("---------------------------------------------------------------------------");



            bool BattleOngoing = true;
            bool stillHasPokemon = false;
            while (BattleOngoing == true)
            {
                //Initiate Move Selection
                ChooseMove();



                //Move Selection:
                //--------------------------------------------------------------------------------------------------//
                static void ChooseMove()
                {
                    Battle.HPUpdate();
                    //if current Active Pokemon is Knocked Down, Move Selection will not Initiate
                    if (ActivePokemon[0].combathp > 0)
                    {
                        //Initiates Move Selection of Active Pokemon
                        Console.WriteLine($"\n*{ActivePokemon[0].pokeName}'s Turn*");

                        bool Useable = false;
                        while (Useable == false)
                        {
                            Battle.ShowMoves();
                            //Actual Move Selection:
                            //--------------------------------------------------------------------------------------------------//
                            Console.Write("Enter the Move you want to use: ");
                            string? specifiedMove = Console.ReadLine();

                            //NOTE TO SELF: If you find yourself using this method of making moves, compute the moveDamage with
                            // "moveDamage * ActivePokemon[0].atk) / 100;" in Battle

                            for (int i = 0; i < ActivePokemon[0].LearnedMoves.Count; i++)
                            {
                                if (specifiedMove?.ToLower() == ActivePokemon[0].LearnedMoves[i].moveName.ToLower())
                                {

                                    int movePower = ActivePokemon[0].LearnedMoves[i].moveDamage;

                                    //SAME TYPE ATTACK BONUS
                                    if (ActivePokemon[0].LearnedMoves[i].movetype == ActivePokemon[0].poketype1 || ActivePokemon[0].LearnedMoves[i].movetype == ActivePokemon[0].poketype2)
                                    {
                                        movePower = movePower + (movePower / 2);
                                    }
                                    //DAMAGE CALCULATOR
                                    int AttackDMG = (((2 * ActivePokemon[0].pokelevel) / 5 + 2) * movePower * ActivePokemon[0].atk / ActivePokemon[1].def) / 50 + 2;


                                    //TYPE DAMAGE BONUS

                                    //Resistances
                                    int Effectiveness = 0;
                                    for (int rs1 = 0; rs1 < ActivePokemon[1].poketype1.Resistances.Count; rs1++)
                                    {
                                        if (ActivePokemon[1].poketype1.Resistances[rs1] == ActivePokemon[0].LearnedMoves[i].movetype)
                                        {
                                            Effectiveness -= 1;
                                        }
                                    }
                                    for (int rs2 = 0; rs2 < ActivePokemon[1].poketype2.Resistances.Count; rs2++)
                                    {
                                        if (ActivePokemon[1].poketype2.Resistances[rs2] == ActivePokemon[0].LearnedMoves[i].movetype)
                                        {
                                            Effectiveness -= 1;
                                        }
                                    }
                                    //Weaknesses
                                    for (int wk1 = 0; wk1 < ActivePokemon[1].poketype1.Weaknesses.Count; wk1++)
                                    {
                                        if (ActivePokemon[1].poketype1.Weaknesses[wk1] == ActivePokemon[0].LearnedMoves[i].movetype)
                                        {
                                            Effectiveness += 1;
                                        }
                                    }
                                    for (int wk2 = 0; wk2 < ActivePokemon[1].poketype2.Weaknesses.Count; wk2++)
                                    {
                                        if (ActivePokemon[1].poketype2.Weaknesses[wk2] == ActivePokemon[0].LearnedMoves[i].movetype)
                                        {
                                            Effectiveness += 1;
                                        }
                                    }
                                    //Immunities
                                    for (int im1 = 0; im1 < ActivePokemon[1].poketype1.Immunities.Count; im1++)
                                    {
                                        if (ActivePokemon[1].poketype1.Immunities[im1] == ActivePokemon[0].LearnedMoves[i].movetype)
                                        {
                                            Effectiveness = -3;
                                        }
                                    }
                                    for (int im2 = 0; im2 < ActivePokemon[1].poketype2.Immunities.Count; im2++)
                                    {
                                        if (ActivePokemon[1].poketype2.Immunities[im2] == ActivePokemon[0].LearnedMoves[i].movetype)
                                        {
                                            Effectiveness = -3;
                                        }
                                    }


                                    Console.WriteLine();

                                    switch (Effectiveness)
                                    {
                                        case 1:
                                            AttackDMG = AttackDMG * 2;
                                            Console.WriteLine("It was super effective!");
                                            break;
                                        case 2:
                                            AttackDMG = AttackDMG * 2 + (AttackDMG / 2);
                                            Console.WriteLine("It was drastically effective!!");
                                            break;
                                        case -1:
                                            AttackDMG = AttackDMG - (AttackDMG / 2);
                                            Console.WriteLine("It was not very effective.");
                                            break;
                                        case -2:
                                            AttackDMG = (AttackDMG - (AttackDMG / 2)) / 2;
                                            Console.WriteLine("It was extremely ineffective.");
                                            break;
                                        case -3:
                                            AttackDMG = 0;
                                            Console.WriteLine($"Oh no! {ActivePokemon[1].pokeName} was immune to the move!");
                                            break;

                                        default:
                                            break;
                                    }

                                    //Deal Damage
                                    Console.Clear();
                                    ActivePokemon[1].combathp -= AttackDMG;
                                    Console.WriteLine($"{ActivePokemon[0].LearnedMoves[i].moveName} dealt {AttackDMG} damage!");
                                    Useable = true;
                                }
                            }

                            if (Useable == false)
                            {
                                Console.WriteLine("*Please enter a move your current Pokemon can use!");
                                continue;
                            }

                            //--------------------------------------------------------------------------------------------------//
                            //End of Move Selection


                            //Ends turn of Current Active Pokemon
                            Battle.EndTurn();
                            ChooseMove();
                            break;
                        }

                    }
                    //Pokemon Defeated
                    else
                    {
                        Console.WriteLine($"*{ActivePokemon[0].pokeName} has been defeated!*");
                        ActivePokemon[1].GainExp(ActivePokemon[0]);
                    }

                }// <----  By the time this bracket ends, it means ChooseMove() has finished, and we're now back to the PokemonBattle() loop;
                 //--------------------------------------------------------------------------------------------------//



                //Back to PokemonBattle()



                //Checks if Trainers' team still has elligible Pokemon:
                //--------------------------------------------------------------------------------------------------//
                if (ActivePokemon[0].combathp < 1)
                {
                    if (ActivePokemon[0].ownerTrainer == BattlingTrainers[0].trainerName)
                    {
                        for (int i = 0; i < LeftTeam.Count; i++)
                        {
                            if (LeftTeam[i].combathp > 0)
                            {
                                ActivePokemon[0] = LeftTeam[i];
                                Console.WriteLine("---------------------------------------------------------------------------");
                                Console.WriteLine($"{ActivePokemon[0].ownerTrainer} switched out {LeftTeam[i].pokeName}");
                                Console.WriteLine("---------------------------------------------------------------------------");
                                stillHasPokemon = true;
                                break;
                            }
                            else
                            {
                                stillHasPokemon = false;
                            }
                        }
                    }
                    if (ActivePokemon[0].ownerTrainer == BattlingTrainers[1].trainerName)
                    {

                        for (int i = 0; i < RightTeam.Count; i++)
                        {
                            if (RightTeam[i].combathp > 0)
                            {
                                ActivePokemon[0] = RightTeam[i];
                                Console.WriteLine("---------------------------------------------------------------------------");
                                Console.WriteLine($"{ActivePokemon[0].ownerTrainer} switched out {RightTeam[i].pokeName}");
                                Console.WriteLine("---------------------------------------------------------------------------");
                                stillHasPokemon = true;
                                break;
                            }
                            else
                            {
                                stillHasPokemon = false;
                            }
                        }
                    }
                }
                if (stillHasPokemon == true)
                {
                    continue;
                }
                //--------------------------------------------------------------------------------------------------//


                //Victory Statement
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------------------------------");
                Console.WriteLine($"{ActivePokemon[1].ownerTrainer} has won the battle!");
                Console.WriteLine("---------------------------------------------------------------------------");
                Console.WriteLine($"The duel between {BattlingTrainers[0].trainerName} and {BattlingTrainers[1].trainerName} has concluded");
                Console.WriteLine("---------------------------------------------------------------------------\n");


                //note to self change this to a proper for loop
                //Reset NPTrainers
                foreach(var item in BattlingTrainers){
                    if(item.isPlayer == false){
                        foreach(var pokemon in item.team){
                            pokemon.combathp = pokemon.hp;
                        }
                    }
                }                

                //Clears Active Pokemon slots
                ActivePokemon.Clear();
                BattlingTrainers.Clear();
                Console.Beep();
                BattleOngoing = false;
                break;


            }
        }
    }
}