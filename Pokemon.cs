
namespace PokemonGame
{
    public class Pokemon
    {
        //STATS
        public int PokeID;
        public string PokeName { get; set; }
        public int hp;
        public int combathp;
        public int atk;
        public int spatk;
        public int def;
        public int spdef;
        public int speed;
        public Types poketype1;
        public Types poketype2;
        //EXP & LEVEL UP SYSTEM
        public int pokelevel = 5;
        public double totalExp;
        public double expGained;
        public int expYield;
        //EVOLUTION SYSTEM
        public List<Pokemon> EvolutionStages = new List<Pokemon>();
        public int evolvelevel;
        public bool CanEvolve
        {
            get
            {
                if (pokelevel >= evolvelevel && EvolutionStages.Count != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        //BATTLE SYSTEM
        public string ownerTrainer = "none";
        public List<Move> LearnedMoves = new List<Move>();
        public List<Move> LearnableMoves = new List<Move>();



        //POKEMON CONSTRUCTOR       
        public static List<Pokemon> AllPokemon = new List<Pokemon>();
        public static int pokeIDPool = 1;
        public Pokemon(string thisname, int thishp, int thisatk, int thisdef, int thisspatk, int thisspdef, int thisspeed, Types thistype1, Types thistype2, int thisexpy, int thisevolvelevel)
        {   
            // PokeID = pokeIDPool;
            PokeName = thisname;
            hp = thishp;
            atk = thisatk;
            def = thisdef;
            spatk = thisspatk;
            spdef = thisspdef;
            speed = thisspeed;
            combathp = hp;
            poketype1 = thistype1;
            poketype2 = thistype2;
            expYield = thisexpy;
            evolvelevel = thisevolvelevel;

            totalExp = Math.Pow(pokelevel, 3);
            AllPokemon.Add(this); 
            // pokeIDPool++;           
        }

        //Attack for Battle
        public void Attack(Pokemon target)
        {
            bool Useable = false;
            while (Useable == false)
            {
                Console.Write("Enter the Move you want to use: ");
                string? specifiedMove = Console.ReadLine();

                for (int i = 0; i < LearnedMoves.Count; i++)
                {
                    //If move is Usable
                    if (specifiedMove?.ToLower() == LearnedMoves[i].moveName.ToLower())
                    {
                        Useable = true;
                        int movePower = LearnedMoves[i].moveBasePower;
                        int Effectiveness = 0;
                        int AttackDMG;

                        //SAME TYPE ATTACK BONUS
                        if (LearnedMoves[i].movetype == poketype1 || LearnedMoves[i].movetype == poketype2)
                        {
                            movePower = movePower + (movePower / 2);
                        }
                        //DAMAGE CALCULATOR
                        AttackDMG = (((2 * pokelevel) / 5 + 2) * movePower * atk / target.def) / 50 + 2;



                        //Resistances                        
                        for (int rs1 = 0; rs1 < target.poketype1.Resistances.Count; rs1++)
                        {
                            if (target.poketype1.Resistances[rs1] == LearnedMoves[i].movetype)
                            {
                                Effectiveness -= 1;
                            }
                        }
                        for (int rs2 = 0; rs2 < target.poketype2.Resistances.Count; rs2++)
                        {
                            if (target.poketype2.Resistances[rs2] == LearnedMoves[i].movetype)
                            {
                                Effectiveness -= 1;
                            }
                        }
                        //Weaknesses
                        for (int wk1 = 0; wk1 < target.poketype1.Weaknesses.Count; wk1++)
                        {
                            if (target.poketype1.Weaknesses[wk1] == LearnedMoves[i].movetype)
                            {
                                Effectiveness += 1;
                            }
                        }
                        for (int wk2 = 0; wk2 < target.poketype2.Weaknesses.Count; wk2++)
                        {
                            if (target.poketype2.Weaknesses[wk2] == LearnedMoves[i].movetype)
                            {
                                Effectiveness += 1;
                            }
                        }
                        //Immunities
                        for (int im1 = 0; im1 < target.poketype1.Immunities.Count; im1++)
                        {
                            if (target.poketype1.Immunities[im1] == LearnedMoves[i].movetype)
                            {
                                Effectiveness = -3;
                            }
                        }
                        for (int im2 = 0; im2 < target.poketype2.Immunities.Count; im2++)
                        {
                            if (target.poketype2.Immunities[im2] == LearnedMoves[i].movetype)
                            {
                                Effectiveness = -3;
                            }
                        }
                        Console.Clear();
                        Console.WriteLine("---------------------------------------------------------------------------");
                        Console.WriteLine($"{PokeName} used {LearnedMoves[i].moveName}!");

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
                                Console.WriteLine($"Oh no! {target.PokeName} was immune to the move!");
                                break;

                            default:
                                break;
                        }
                        target.combathp -= AttackDMG;
                        Console.WriteLine($"{LearnedMoves[i].moveName} dealt {AttackDMG} damage!");
                        Console.WriteLine("---------------------------------------------------------------------------");
                    }
                    //If move is not Usable


                }
                if (Useable == false)
                {
                    Console.WriteLine("*Please enter a move your current Pokemon can use!");
                    continue;
                }
            }
        }

        //Evolve System
        public void Evolve(Pokemon evolvedpokemon)
        {
            string priorName = PokeName;
            PokeName = evolvedpokemon.PokeName;
            hp = evolvedpokemon.hp;
            atk = evolvedpokemon.atk;
            def = evolvedpokemon.def;
            speed = evolvedpokemon.speed;
            poketype1 = evolvedpokemon.poketype1;
            poketype2 = evolvedpokemon.poketype2;
            expYield = evolvedpokemon.expYield;
            evolvelevel = evolvedpokemon.evolvelevel;
            LearnedMoves = evolvedpokemon.LearnedMoves;
            EvolutionStages = evolvedpokemon.EvolutionStages;
            Console.WriteLine($"Congratulations! Your {priorName} evolved into {PokeName}");
        }

        //EXP System
        public void GainExp(Pokemon pokemon)
        {
            int priorlevel = this.pokelevel;

            expGained = ((pokemon.expYield * pokemon.pokelevel) / 7) * 1.5;
            this.totalExp += (int)expGained;
            Console.WriteLine($"{PokeName} gained {(int)expGained} Exp.");

            double expToLevel = Math.Floor(Math.Cbrt(this.totalExp));
            pokelevel = (int)expToLevel;

            //Level Up
            if (priorlevel < pokelevel)
            {
                Console.WriteLine($"{PokeName} leveled up to Lv.{pokelevel}!");
                if (CanEvolve == true)
                {
                    Evolve(EvolutionStages[0]);
                }
            }
        }

        //Show All Pokemon
        public static void ShowAllPokemon()
        {
            Console.WriteLine("\nList of all Pokemon: ");
            foreach (var item in AllPokemon)
            {
                Console.WriteLine(item.PokeName);
            }
            Console.WriteLine();
        }




        //*LIST OF ALL EXISTING POKEMON*

        // GRASS TYPE POKEMON

        //Bulbasaur Line
        public static Pokemon Venusaur = new Pokemon("Venusaur", 80, 82, 83, 100, 100, 80, Types.Grass, Types.Poison, 208, 0)
        {
            LearnedMoves = { Move.SolarBeam, Move.PetalDance, Move.TakeDown }
        };
        public static Pokemon Ivysaur = new Pokemon("Ivysaur", 60, 62, 63, 80, 80, 60, Types.Grass, Types.Poison, 141, 32)
        {
            EvolutionStages = { Venusaur },
            LearnedMoves = { Move.RazorLeaf, Move.TakeDown }
        };
        public static Pokemon Bulbasaur = new Pokemon("Bulbasaur", 45, 49, 49, 65, 65, 45, Types.Grass, Types.Poison, 64, 16)
        {
            EvolutionStages = { Ivysaur, Venusaur },
            LearnedMoves = { Move.RazorLeaf, Move.Tackle }
        };
        //Bounsweet Line
        public static Pokemon Tsareena = new Pokemon("Tsareena", 72, 120, 98, 50, 98, 72, Types.Grass, Types.none, 230, 0)
        {
            LearnedMoves = { Move.TropKick, Move.HighJumpKick, Move.PlayRough, Move.Stomp }
        };
        public static Pokemon Steenee = new Pokemon("Steenee", 52, 40, 48, 40, 48, 62, Types.Grass, Types.none, 102, 28)
        {
            EvolutionStages = { Tsareena },
            LearnedMoves = { Move.RazorLeaf }
        };
        public static Pokemon Bounsweet = new Pokemon("Bounsweet", 42, 30, 38, 30, 38, 32, Types.Grass, Types.none, 42, 18)
        {
            EvolutionStages = { Steenee, Tsareena },
            LearnedMoves = { Move.RazorLeaf }
        };
        //Chikorita Line
        public static Pokemon Meganium = new Pokemon("Meganium", 80, 82, 100, 83, 100, 80, Types.Grass, Types.none, 208, 0)
        {
            LearnedMoves = { Move.PetalDance, Move.EnergyBall, Move.BodySlam }
        };
        public static Pokemon Bayleef = new Pokemon("Bayleef", 60, 62, 80, 63, 80, 60, Types.Grass, Types.none, 141, 32)
        {
            EvolutionStages = { Meganium },
            LearnedMoves = { Move.EnergyBall, Move.Stomp }
        };
        public static Pokemon Chikorita = new Pokemon("Chikorita", 45, 209, 65, 49, 65, 10, Types.Grass, Types.none, 64, 16)
        {
            EvolutionStages = { Bayleef, Meganium },
            LearnedMoves = { Move.RazorLeaf, Move.Tackle }
        };


        // FIRE TYPE POKEMON

        //Charmander Line
        public static Pokemon Charizard = new Pokemon("Charizard", 78, 74, 78, 109, 85, 100, Types.Fire, Types.Flying, 209, 0)
        {
            LearnedMoves = { Move.Flamethrower, Move.DragonClaw, Move.Fly }
        };
        public static Pokemon Charmeleon = new Pokemon("Charmeleon", 58, 64, 58, 80, 65, 80, Types.Fire, Types.none, 142, 36)
        {
            EvolutionStages = { Charizard },
            LearnedMoves = { Move.FireFang, Move.DragonBreath, Move.Scratch }
        };
        public static Pokemon Charmander = new Pokemon("Charmander", 39, 55, 50, 60, 50, 65, Types.Fire, Types.none, 65, 16)
        {
            EvolutionStages = { Charmeleon, Charizard },
            LearnedMoves = { Move.Ember, Move.Scratch }
        };
        //Torchic Line
        public static Pokemon Blaziken = new Pokemon("Blaziken", 80, 120, 70, 110, 70, 80, Types.Fire, Types.Fighting, 209, 0)
        {
            LearnedMoves = { Move.Flamethrower, Move.CloseCombat, Move.BraveBird }
        };
        public static Pokemon Combusken = new Pokemon("Combusken", 60, 85, 60, 85, 60, 55, Types.Fire, Types.Fighting, 142, 36)
        {
            EvolutionStages = { Blaziken },
            LearnedMoves = { Move.Ember, Move.DoubleKick, Move.AerialAce }
        };
        public static Pokemon Torchic = new Pokemon("Torchic", 45, 60, 40, 70, 50, 45, Types.Fire, Types.Fighting, 65, 16)
        {
            EvolutionStages = { Combusken, Blaziken },
            LearnedMoves = { Move.Ember, Move.Scratch }
        };
        //Vulpix Line
        public static Pokemon Ninetales = new Pokemon("Ninetales", 73, 76, 75, 81, 100, 100, Types.Fire, Types.none, 178, 0)
        {
            LearnedMoves = { Move.Flamethrower, Move.QuickAttack, Move.FireBlast }
        };
        public static Pokemon Vulpix = new Pokemon("Vulpix", 38, 41, 40, 50, 65, 65, Types.Fire, Types.none, 63, 30)
        {
            EvolutionStages = { Ninetales },
            LearnedMoves = { Move.Ember, Move.QuickAttack }
        };
        //Growlithe Line
        public static Pokemon Arcanine = new Pokemon("Arcanine", 90, 110, 80, 100, 80, 95, Types.Fire, Types.none, 213, 0)
        {
            LearnedMoves = { Move.Extremespeed, Move.Flamethrower, Move.Crunch }
        };
        public static Pokemon Growlithe = new Pokemon("Growlithe", 55, 70, 45, 70, 50, 60, Types.Fire, Types.none, 91, 30)
        {
            EvolutionStages = { Arcanine },
            LearnedMoves = { Move.FireFang, Move.Bite }
        };


        // WATER TYPE POKEMON

        //Squirtle Line
        public static Pokemon Blastoise = new Pokemon("Blastoise", 79, 83, 100, 85, 105, 78, Types.Water, Types.none, 210, 0)
        {
            LearnedMoves = { Move.Surf, Move.FlashCannon, Move.DoubleEdge, Move.Bite }
        };
        public static Pokemon Wartortle = new Pokemon("Wartortle", 59, 63, 80, 65, 80, 58, Types.Water, Types.none, 143, 36)
        {
            EvolutionStages = { Blastoise },
            LearnedMoves = { Move.WaterPulse, Move.Tackle, Move.Bite }
        };
        public static Pokemon Squirtle = new Pokemon("Squirtle", 44, 48, 65, 50, 64, 43, Types.Water, Types.none, 66, 16)
        {
            EvolutionStages = { Wartortle, Blastoise },
            LearnedMoves = { Move.WaterGun, Move.Tackle }
        };
        //Mudkip Line
        public static Pokemon Swampert = new Pokemon("Swampert", 100, 110, 90, 85, 90, 60, Types.Water, Types.Ground, 210, 0)
        {
            LearnedMoves = { Move.Surf, Move.Earthquake, Move.HammerArm }
        };
        public static Pokemon Marshtomp = new Pokemon("Marshtomp", 70, 85, 70, 60, 70, 50, Types.Water, Types.Ground, 143, 36)
        {
            EvolutionStages = { Swampert },
            LearnedMoves = { Move.WaterGun, Move.Tackle, Move.MudShot }
        };
        public static Pokemon Mudkip = new Pokemon("Mudkip", 50, 70, 50, 50, 50, 40, Types.Water, Types.none, 65, 16)
        {
            EvolutionStages = { Marshtomp, Swampert },
            LearnedMoves = { Move.WaterGun, Move.Tackle, Move.MudSlap }
        };
        //Froakie Line
        public static Pokemon Greninja = new Pokemon("Greninja", 72, 95, 67, 103, 71, 122, Types.Water, Types.Dark, 239, 0)
        {
            LearnedMoves = { Move.WaterShuriken, Move.NightSlash, Move.AerialAce, Move.Waterfall }
        };
        public static Pokemon Frogadier = new Pokemon("Frogadier", 54, 63, 52, 83, 56, 97, Types.Water, Types.Dark, 142, 36)
        {
            EvolutionStages = { Greninja },
            LearnedMoves = { Move.WaterPulse, Move.QuickAttack }
        };
        public static Pokemon Froakie = new Pokemon("Froakie", 41, 56, 40, 62, 44, 71, Types.Water, Types.Dark, 63, 16)
        {
            EvolutionStages = { Frogadier, Greninja },
            LearnedMoves = { Move.WaterGun, Move.Pound }
        };
        //Magikarp Line
        public static Pokemon Gyarados = new Pokemon("Gyarados", 95, 125, 79, 60, 100, 81, Types.Water, Types.Flying, 214, 0)
        {
            LearnedMoves = { Move.AquaTail, Move.Earthquake, Move.Crunch }
        };
        public static Pokemon Magikarp = new Pokemon("Magikarp", 20, 10, 55, 15, 20, 80, Types.Water, Types.Flying, 20, 20)
        {
            EvolutionStages = { Gyarados },
            LearnedMoves = { Move.Flail }
        };


        // Electric Type Pokemon

        //Pikachu Line
        public static Pokemon Pikachu = new Pokemon("Pikachu", 60, 70, 40, 70, 40, 100, Types.Electric, Types.none, 82, 0)
        {
            LearnedMoves = { Move.Thunderbolt, Move.Spark, Move.QuickAttack, Move.Slam }
        };
        //Shinx Line
        public static Pokemon Luxray = new Pokemon("Luxray", 80, 120, 79, 95, 79, 70, Types.Electric, Types.none, 194, 0)
        {
            LearnedMoves = { Move.WildCharge, Move.Crunch, Move.Tackle }
        };
        public static Pokemon Luxio = new Pokemon("Luxio", 60, 85, 49, 60, 49, 60, Types.Electric, Types.none, 117, 30)
        {
            EvolutionStages = { Luxray },
            LearnedMoves = { Move.Spark, Move.Bite, Move.Tackle }
        };
        public static Pokemon Shinx = new Pokemon("Shinx", 45, 65, 34, 40, 34, 45, Types.Electric, Types.none, 60, 15)
        {
            EvolutionStages = { Luxio, Luxray },
            LearnedMoves = { Move.Spark, Move.Tackle }
        };


        // Psychic Type Pokemon

        //Ralts Line
        public static Pokemon Gardevoir = new Pokemon("Gardevoir", 68, 65, 65, 125, 115, 80, Types.Psychic, Types.Fairy, 208, 0)
        {
            LearnedMoves = { Move.Psychic, Move.MoonBlast }
        };
        public static Pokemon Gallade = new Pokemon("Gallade", 68, 125, 65, 65, 115, 80, Types.Psychic, Types.Fighting, 208, 0)
        {
            LearnedMoves = { Move.PsychoCut, Move.CloseCombat, Move.LeafBlade, Move.NightSlash }
        };
        public static Pokemon Kirlia = new Pokemon("Kirlia", 38, 35, 35, 65, 55, 50, Types.Psychic, Types.Fairy, 140, 30)
        {
            EvolutionStages = { Gardevoir, Gallade },
            LearnedMoves = { Move.Psybeam, Move.DisarmingVoice }
        };
        public static Pokemon Ralts = new Pokemon("Ralts", 28, 25, 25, 45, 35, 40, Types.Psychic, Types.Fairy, 70, 20)
        {
            EvolutionStages = { Kirlia, Gardevoir, Gallade },
            LearnedMoves = { Move.Confusion, Move.DisarmingVoice }
        };
        //Abra Line
        public static Pokemon Alakazam = new Pokemon("Alakazam", 55, 50, 45, 135, 85, 120, Types.Psychic, Types.none, 186, 0)
        {
            LearnedMoves = { Move.Psychic, Move.EnergyBall, Move.ShadowBall, Move.DazzlingGleam }
        };
        public static Pokemon Kadabra = new Pokemon("Kadabra", 40, 35, 30, 120, 70, 105, Types.Psychic, Types.none, 145, 36)
        {
            EvolutionStages = { Alakazam },
            LearnedMoves = { Move.Psybeam, Move.EnergyBall, Move.ShadowBall }
        };
        public static Pokemon Abra = new Pokemon("Abra", 25, 20, 15, 105, 55, 90, Types.Psychic, Types.none, 73, 16)
        {
            EvolutionStages = { Kadabra, Alakazam },
            LearnedMoves = { Move.Confusion }
        };


        // Fighting Type Pokemon  

        //Riolu Line   
        public static Pokemon Lucario = new Pokemon("Lucario", 70, 110, 70, 115, 70, 90, Types.Fighting, Types.Steel, 204, 0)
        {
            LearnedMoves = { Move.CloseCombat, Move.AuraSphere, Move.MeteorMash, Move.Extremespeed }
        };
        public static Pokemon Riolu = new Pokemon("Riolu", 40, 70, 40, 35, 40, 60, Types.Fighting, Types.none, 72, 30)
        {
            EvolutionStages = { Lucario },
            LearnedMoves = { Move.ForcePalm, Move.QuickAttack }
        };
        //Machop Line
        public static Pokemon Machamp = new Pokemon("Machamp", 90, 130, 80, 65, 85, 55, Types.Fighting, Types.none, 193, 0)
        {
            LearnedMoves = { Move.CloseCombat, Move.StoneEdge, Move.CrossChop }
        };
        public static Pokemon Machoke = new Pokemon("Machoke", 80, 100, 70, 50, 60, 45, Types.Fighting, Types.none, 146, 42)
        {
            EvolutionStages = { Machamp },
            LearnedMoves = { Move.Submission, Move.RockSlide }
        };
        public static Pokemon Machop = new Pokemon("Machop", 70, 80, 50, 35, 35, 35, Types.Fighting, Types.none, 88, 28)
        {
            EvolutionStages = { Machoke, Machamp },
            LearnedMoves = { Move.KarateChop }
        };


        // Normal Type Pokemon

        //Munchlax Line
        public static Pokemon Snorlax = new Pokemon("Snorlax", 160, 110, 65, 65, 110, 30, Types.Normal, Types.none, 154, 0)
        {
            LearnedMoves = { Move.BodySlam, Move.HeavySlam, Move.Earthquake, Move.Crunch }
        };


        // Ghost Type Pokemon

        //Gastly Line
        public static Pokemon Gengar = new Pokemon("Gengar", 60, 65, 60, 130, 75, 110, Types.Ghost, Types.Poison, 190, 0)
        {
            LearnedMoves = { Move.ShadowBall, Move.DarkPulse, Move.SludgeBomb }
        };
        public static Pokemon Haunter = new Pokemon("Haunter", 45, 50, 45, 115, 55, 95, Types.Ghost, Types.Poison, 126, 40)
        {
            EvolutionStages = { Gengar },
            LearnedMoves = { Move.ShadowBall, Move.SuckerPunch, Move.ShadowPunch }
        };
        public static Pokemon Gastly = new Pokemon("Gastly", 30, 35, 30, 100, 35, 80, Types.Ghost, Types.Poison, 95, 25)
        {
            EvolutionStages = { Haunter, Gengar },
            LearnedMoves = { Move.NightShade }
        };


        // Dark Type Pokemon

        //Zorua Line
        public static Pokemon Zoroark = new Pokemon("Zoroark", 60, 105, 60, 120, 60, 105, Types.Dark, Types.none, 179, 0)
        {
            LearnedMoves = { Move.DarkPulse, Move.NightSlash, Move.AerialAce }
        };
        public static Pokemon Zorua = new Pokemon("Zorua", 40, 65, 40, 80, 40, 65, Types.Dark, Types.none, 66, 30)
        {
            EvolutionStages = { Zoroark },
            LearnedMoves = { Move.FaintAttack, Move.Scratch }
        };


        // Bug Type Pokemon




        // Rock Type Pokemon

        //Larvitar Line
        public static Pokemon Tyranitar = new Pokemon("Tyranitar", 100, 134, 110, 95, 100, 61, Types.Rock, Types.Dark, 218, 0)
        {
            LearnedMoves = { Move.StoneEdge, Move.Crunch, Move.Earthquake }
        };
        public static Pokemon Pupitar = new Pokemon("Pupitar", 70, 84, 70, 65, 70, 51, Types.Rock, Types.Ground, 144, 55)
        {
            EvolutionStages = { Tyranitar },
            LearnedMoves = { Move.RockSlide, Move.Crunch, Move.Tackle }
        };
        public static Pokemon Larvitar = new Pokemon("Larvitar", 50, 64, 50, 45, 50, 41, Types.Rock, Types.Ground, 67, 30)
        {
            EvolutionStages = { Pupitar, Tyranitar },
            LearnedMoves = { Move.RockThrow, Move.Bite, Move.Tackle }
        };


        // Ground Type Pokemon

        //Sandile Line
        public static Pokemon Krookodile = new Pokemon("Krookodile", 95, 117, 70, 65, 70, 92, Types.Ground, Types.Dark, 229, 0)
        {
            LearnedMoves = { Move.Earthquake, Move.Crunch }
        };
        public static Pokemon Krokorok = new Pokemon("Krokorok", 60, 82, 45, 45, 45, 72, Types.Ground, Types.Dark, 123, 40)
        {
            EvolutionStages = { Krookodile },
            LearnedMoves = { Move.Bulldoze, Move.Crunch }
        };
        public static Pokemon Sandile = new Pokemon("Sandile", 50, 72, 35, 35, 35, 65, Types.Ground, Types.Dark, 58, 29)
        {
            EvolutionStages = { Krokorok, Krookodile },
            LearnedMoves = { Move.Bite }
        };
        //Trapinch Line
        public static Pokemon Flygon = new Pokemon("Flygon", 80, 100, 80, 80, 80, 100, Types.Ground, Types.Dragon, 197, 0)
        {
            LearnedMoves = { Move.DragonClaw, Move.Earthquake, Move.Crunch, Move.RockSlide }
        };
        public static Pokemon Vibrava = new Pokemon("Vibrava", 50, 70, 50, 50, 50, 70, Types.Ground, Types.Dragon, 126, 45)
        {
            EvolutionStages = { Flygon },
            LearnedMoves = { Move.DragonBreath, Move.Bulldoze, Move.Crunch }
        };
        public static Pokemon Trapinch = new Pokemon("Trapinch", 45, 100, 45, 45, 45, 10, Types.Ground, Types.none, 73, 35)
        {
            EvolutionStages = { Vibrava, Flygon },
            LearnedMoves = { Move.Bite, Move.SandTomb }
        };


        // Steel Type Pokemon

        //Beldum Line
        public static Pokemon Metagross = new Pokemon("Metagross", 80, 135, 130, 95, 90, 70, Types.Steel, Types.Psychic, 210, 0)
        {
            LearnedMoves = { Move.MeteorMash, Move.Psychic, Move.HammerArm, Move.Earthquake }
        };
        public static Pokemon Metang = new Pokemon("Metang", 60, 75, 100, 55, 80, 50, Types.Steel, Types.Psychic, 153, 45)
        {
            EvolutionStages = { Metagross },
            LearnedMoves = { Move.MetalClaw, Move.Psychic, Move.TakeDown }
        };
        public static Pokemon Beldum = new Pokemon("Beldum", 40, 55, 80, 35, 60, 30, Types.Steel, Types.Psychic, 103, 20)
        {
            EvolutionStages = { Metang, Metagross },
            LearnedMoves = { Move.TakeDown }
        };
        //Aron Line
        public static Pokemon Aggron = new Pokemon("Aggron", 70, 110, 180, 60, 60, 50, Types.Steel, Types.Rock, 205, 0)
        {
            LearnedMoves = { Move.HeavySlam, Move.RockSlide, Move.DoubleEdge, Move.IronTail }
        };
        public static Pokemon Lairon = new Pokemon("Lairon", 60, 90, 140, 50, 50, 40, Types.Steel, Types.Rock, 152, 42)
        {
            EvolutionStages = { Aggron },
            LearnedMoves = { Move.IronHead, Move.RockSlide, Move.TakeDown }
        };
        public static Pokemon Aron = new Pokemon("Aron", 50, 70, 100, 50, 50, 40, Types.Steel, Types.Rock, 96, 32)
        {
            EvolutionStages = { Lairon, Aggron },
            LearnedMoves = { Move.MetalClaw, Move.RockThrow, Move.Tackle }
        };


        // Dragon Type Pokemon

        //Gible Line
        public static Pokemon Garchomp = new Pokemon("Garchomp", 108, 130, 95, 80, 85, 102, Types.Dragon, Types.Ground, 218, 0)
        {
            LearnedMoves = { Move.DragonClaw, Move.Earthquake, Move.Crunch, Move.TakeDown }
        };
        public static Pokemon Gabite = new Pokemon("Gabite", 68, 90, 65, 50, 55, 82, Types.Dragon, Types.Ground, 144, 48)
        {
            EvolutionStages = { Garchomp },
            LearnedMoves = { Move.DragonBreath, Move.Bulldoze, Move.Bite, Move.Slash }
        };
        public static Pokemon Gible = new Pokemon("Gible", 58, 70, 45, 40, 45, 42, Types.Dragon, Types.Ground, 67, 24)
        {
            EvolutionStages = { Gabite, Garchomp },
            LearnedMoves = { Move.DragonBreath, Move.SandTomb, Move.Bite }
        };
        //Dratini Line
        public static Pokemon Dragonite = new Pokemon("Dragonite", 91, 134, 95, 100, 100, 80, Types.Dragon, Types.Flying, 218, 0)
        {
            LearnedMoves = { Move.Hurricane, Move.DragonClaw, Move.AquaTail, Move.Extremespeed }
        };
        public static Pokemon Dragonair = new Pokemon("Dragonair", 61, 84, 65, 70, 70, 70, Types.Dragon, Types.none, 144, 55)
        {
            EvolutionStages = { Dragonite },
            LearnedMoves = { Move.DragonTail, Move.AquaTail, Move.Slam }
        };
        public static Pokemon Dratini = new Pokemon("Dratini", 41, 64, 45, 50, 50, 50, Types.Dragon, Types.none, 67, 30)
        {
            EvolutionStages = { Dragonair, Dragonite },
            LearnedMoves = { Move.Slam }
        };

        //Flying Type Pokemon
        public static Pokemon Staraptor = new Pokemon("Staraptor", 85, 120, 70, 50, 50, 100, Types.Flying, Types.Normal, 172, 0)
        {
            LearnedMoves = { Move.CloseCombat, Move.BraveBird, Move.AerialAce }
        };
        public static Pokemon Staravia = new Pokemon("Staravia", 55, 75, 50, 40, 40, 80, Types.Flying, Types.Normal, 113, 34)
        {
            EvolutionStages = { Staraptor },
            LearnedMoves = { Move.AerialAce, Move.WingAttack, Move.TakeDown }
        };
        public static Pokemon Starly = new Pokemon("Starly", 40, 55, 30, 30, 30, 60, Types.Flying, Types.Normal, 56, 14)
        {
            EvolutionStages = { Staravia, Staraptor },
            LearnedMoves = { Move.WingAttack, Move.QuickAttack }
        };









        // //Eevee Pokemon
        // public static Pokemon Vaporeon = new Pokemon("Vaporeon", 29, 15, 14, 13, Types.Water, Types.none, 196, 0);
        // public static Pokemon Jolteon = new Pokemon("Jolteon", 22, 15, 14, 19, Types.Electric, Types.none, 197, 0);
        // public static Pokemon Flareon = new Pokemon("Flareon", 22, 18, 14, 13, Types.Fire, Types.none, 198, 0);
        // public static Pokemon Sylveon = new Pokemon("Sylveon", 25, 17, 14, 12, Types.Fairy, Types.none, 184, 0);
        // public static Pokemon Espeon = new Pokemon("Espeon", 22, 19, 14, 17, Types.Psychic, Types.none, 197, 0);
        // public static Pokemon Umbreon = new Pokemon("Umbreon", 25, 12, 18, 13, Types.Dark, Types.none, 197, 0);
        // public static Pokemon Eevee = new Pokemon("Eevee", 21, 11, 12, 11, Types.Normal, Types.none, 92, 0);


    }

}