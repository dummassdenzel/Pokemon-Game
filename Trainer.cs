
namespace PokemonGame
{

    public class Trainer
    {
        public string trainerName;
        public string gender;

        //Arrays for Pokemon
        public List<Pokemon> team = new List<Pokemon>();
        //Arrays for Trainers
        public static List<Trainer> Players = new List<Trainer>();
        //Arrays for Combat
        public static List<Trainer> BattlingTrainers = new List<Trainer>();
        public static List<Pokemon> ActivePokemon = new List<Pokemon>();



        //Start your Journey
        public static void StartJourney()
        {
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
            Console.Beep();
        }

        //Player Constructor
        public Trainer(string thistrainername, string thisgender)
        {
            this.trainerName = thistrainername;
            Console.WriteLine($"Congratulations! You can now begin your journey, {trainerName}!");
            Players.Add(this);
        }





        //*GAME SYSTEM*


        //Catch a Pokemon
        public void Catch()
        {
            var isCatchable = false;
            while (isCatchable == false)
            {
                Console.Write($"{trainerName} - Choose Pokemon to catch: ");
                string? chosenPokemon = Console.ReadLine();



                for (int i = 0; i < Pokemon.AllPokemon.Count; i++)
                {
                    if (Pokemon.AllPokemon[i].pokeName.ToLower() == chosenPokemon.ToLower() && Pokemon.AllPokemon[i].ownerTrainer == "none")
                    {
                        team.Add(Pokemon.AllPokemon[i]);
                        Pokemon.AllPokemon[i].ownerTrainer = this.trainerName;
                        Console.WriteLine($"Congratulations {trainerName}, you've successfully caught {Pokemon.AllPokemon[i].pokeName}.");
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

        //Catch a Pokemon Instantaneously
        public void CatchPokemon(Pokemon caughtpokemon)
        {
            team.Add(caughtpokemon);
            caughtpokemon.ownerTrainer = this.trainerName;
        }

        //Show a player's Team
        public void ShowTeam()
        {
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine($"{trainerName}'s Team:");
            foreach (var item in team)
            {
                Console.WriteLine($"{item.pokeName} - HP: {item.combathp}/{item.hp}");
                Console.WriteLine($"Atk:{item.atk} Def:{item.def} Speed:{item.speed}\n");
            }
            Console.WriteLine("---------------------------------------------------------------------------\n");
        }






        //*COMBAT SYSTEM*





        //Shows All Challengable Trainers
        public static void ShowAllTrainers()
        {
            Console.WriteLine("\nList of all Trainers: ");
            foreach (var item in Players)
            {
                Console.WriteLine(item.trainerName);
            }
            Console.WriteLine();
        }


        //Challenges a Trainer
        public void Challenge()
        {

            bool playerExists = false;
            while (playerExists == false)
            {
                Console.Write($"{trainerName} - Enter a Trainer to duel with: ");
                string? duelledTrainer = Console.ReadLine();
                //Checks if the specified player exists
                for (int i = 0; i < Players.Count; i++)
                {
                    if (Players[i].trainerName.ToLower() == duelledTrainer.ToLower() && duelledTrainer.ToLower() != trainerName.ToLower() && Players[i].team.Count != 0)
                    {
                        playerExists = true;
                        Console.Beep();
                        BattlingTrainers.Add(this);
                        BattlingTrainers.Add(Players[i]);
                        Console.WriteLine("\n---------------------------------------------------------------------------");
                        Console.WriteLine($"{BattlingTrainers[0].trainerName} has challenged {BattlingTrainers[1].trainerName} to a Pokemon Battle!");
                        Console.WriteLine("---------------------------------------------------------------------------");
                        PokemonBattle();
                        break;
                    }
                    if (Players[i].trainerName.ToLower() == duelledTrainer.ToLower() && duelledTrainer.ToLower() != trainerName.ToLower() && Players[i].team.Count == 0)
                    {
                        Console.WriteLine($"{Players[i].trainerName} doesn't have any Pokemon!");
                        break;
                    }

                }

                if (trainerName == duelledTrainer)
                {
                    Console.WriteLine("You can't challenge yourself!");
                    continue;
                }
                if (duelledTrainer == "none")
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

        //POKEMON BATTLE


        //Displays current HP of Battling Pokemon
        public static void HPUpdate()
        {
            Console.WriteLine("--------------------");
            Console.WriteLine($"{ActivePokemon[0].pokeName} HP: {ActivePokemon[0].combathp}");
            Console.WriteLine("--------------------");
            Console.WriteLine($"{ActivePokemon[1].pokeName} HP: {ActivePokemon[1].combathp}");
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




        //*Pokemon Battle System*
        public static void PokemonBattle()
        {

            Console.WriteLine("Battle Starting...");

            //Team 1 and Team 2
            List<Pokemon> BattlingTeam0 = new List<Pokemon>();
            List<Pokemon> BattlingTeam1 = new List<Pokemon>();
            for (int i = 0; i < BattlingTrainers[0].team.Count; i++)
            {
                BattlingTeam0.Add(BattlingTrainers[0].team[i]);
            }
            for (int i = 0; i < BattlingTrainers[1].team.Count; i++)
            {
                BattlingTeam1.Add(BattlingTrainers[1].team[i]);
            }

            //Print Team of Both Players
            Console.WriteLine($"{BattlingTrainers[0].trainerName}'s Team: ");
            foreach (var pokemoninteam0 in BattlingTeam0)
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
            foreach (var pokemoninteam1 in BattlingTeam1)
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
            Pokemon activePokemon0 = BattlingTeam0[0];
            Pokemon activePokemon1 = BattlingTeam1[0];
            ActivePokemon.Add(activePokemon0);
            ActivePokemon.Add(activePokemon1);
            //note to self, if it does not work for more pokemon, make it a while loop instead of an if statement
            if (activePokemon0.combathp <= 0)
            {
                for (int i = 0; i < BattlingTeam0.Count; i++)
                {
                    activePokemon0 = BattlingTeam0[i];
                    ActivePokemon[0] = activePokemon0;

                }
            }

            if (activePokemon1.combathp <= 0)
            {
                for (int i = 0; i < BattlingTeam1.Count; i++)
                {
                    activePokemon1 = BattlingTeam1[i];
                    ActivePokemon[1] = activePokemon1;

                }
            }

            //"Trainer sent out their Pokemon!"
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
                    HPUpdate();
                    //if current Active Pokemon is Knocked Down, Move Selection will not Initiate
                    if (ActivePokemon[0].combathp > 0)
                    {
                        //Initiates Move Selection of Active Pokemon
                        Console.WriteLine($"\n*{Trainer.ActivePokemon[0].pokeName}'s Turn*");
                        bool Useable = false;
                        while (Useable == false)
                        {
                            ShowMoves();
                            //Actual Move Selection:
                            //--------------------------------------------------------------------------------------------------//
                            Console.Write("Enter the Move you want to use: ");
                            string? specifiedMove = Console.ReadLine();

                            //NOTE TO SELF: If you find yourself using this method of making moves, compute the moveDamage with
                            // "moveDamage * Trainer.ActivePokemon[0].atk) / 100;" in Battle

                            for (int i = 0; i < ActivePokemon[0].LearnedMoves.Count; i++)
                            {
                                if (specifiedMove.ToLower() == ActivePokemon[0].LearnedMoves[i].moveName.ToLower())
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
                            Game.EndTurn();
                            ChooseMove();
                            break;
                        }

                    }
                    //Pokemon Defeated
                    else
                    {                        
                        Console.WriteLine($"*{ActivePokemon[0].pokeName} has been defeated!*");
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
                        for (int i = 0; i < BattlingTeam0.Count; i++)
                        {
                            if (BattlingTeam0[i].combathp > 0)
                            {
                                ActivePokemon[0] = BattlingTeam0[i];
                                Console.WriteLine("---------------------------------------------------------------------------");
                                Console.WriteLine($"{ActivePokemon[0].ownerTrainer} switched out {BattlingTeam0[i].pokeName}");
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

                        for (int i = 0; i < BattlingTeam1.Count; i++)
                        {
                            if (BattlingTeam1[i].combathp > 0)
                            {
                                ActivePokemon[0] = BattlingTeam1[i];
                                Console.WriteLine("---------------------------------------------------------------------------");
                                Console.WriteLine($"{ActivePokemon[0].ownerTrainer} switched out {BattlingTeam1[i].pokeName}");
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
                Console.WriteLine($"{ActivePokemon[1].ownerTrainer} has won the battle!");
                Console.WriteLine("---------------------------------------------------------------------------");
                Console.WriteLine($"The duel between {BattlingTrainers[0].trainerName} and {BattlingTrainers[1].trainerName} has concluded");
                Console.WriteLine("---------------------------------------------------------------------------\n");

                //Clears Active Pokemon slots
                ActivePokemon.Clear();
                BattlingTrainers.Clear();
                Console.Beep();
                BattleOngoing = false;
                break;
            }
        }// <----  By the time this bracket ends, it means PokemonBattle() has finished.








    }
}


