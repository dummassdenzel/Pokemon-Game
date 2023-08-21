
namespace PokemonGame
{
    public class Pokemon
    {
        //STATS
        public int pokeID;
        public string pokeName;
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
        public bool canEvolve()
        {
            if (pokelevel >= evolvelevel)
            {
                return true;
            }
            else if (evolvelevel == 0)
            {
                return false;
            }
            else
            {
                return false;
            }
        }
        //BATTLE SYSTEM
        public string ownerTrainer = "none";
        public List<Move> LearnedMoves = new List<Move>();
        public List<Move> LearnableMoves = new List<Move>();


        //POKEMON CONSTRUCTOR       
        public static List<Pokemon> AllPokemon = new List<Pokemon>();
        public Pokemon(string thisname, int thishp, int thisatk, int thisdef, int thisspatk, int thisspdef, int thisspeed, Types thistype1, Types thistype2, int thisexpy, int thisevolvelevel)
        {
            pokeName = thisname;
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


                        //TYPE DAMAGE CALCULATOR

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
                        Console.WriteLine($"{pokeName} used {LearnedMoves[i].moveName}!");

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
                                Console.WriteLine($"Oh no! {target.pokeName} was immune to the move!");
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

        public void Evolve(Pokemon evolvedpokemon)
        {
            string priorName = pokeName;
            pokeName = evolvedpokemon.pokeName;
            hp = evolvedpokemon.hp;
            atk = evolvedpokemon.atk;
            def = evolvedpokemon.def;
            speed = evolvedpokemon.speed;
            poketype1 = evolvedpokemon.poketype1;
            poketype2 = evolvedpokemon.poketype2;
            expYield = evolvedpokemon.expYield;
            evolvelevel = evolvedpokemon.evolvelevel;
            LearnedMoves = evolvedpokemon.LearnedMoves;
            Console.WriteLine($"Congratulations! Your {priorName} evolved into {pokeName}");
        }

        //EXP System
        public void GainExp(Pokemon pokemon)
        {
            int priorlevel = this.pokelevel;

            expGained = ((pokemon.expYield * pokemon.pokelevel) / 7) * 1.5;
            this.totalExp += (int)expGained;
            Console.WriteLine($"{pokeName} gained {(int)expGained} Exp.");

            double expToLevel = Math.Floor(Math.Cbrt(this.totalExp));
            pokelevel = (int)expToLevel;
            if (priorlevel < pokelevel)
            {
                Console.WriteLine($"{pokeName} leveled up to Lv.{pokelevel}!");
                if (canEvolve() == true)
                {
                    Evolve(EvolutionStages[0]);
                }
            }
        }



        //Show All Catchable Pokemon
        public static void ShowAllPokemon()
        {
            Console.WriteLine("\nList of all Catchable Pokemon: ");
            foreach (var item in Pokemon.AllPokemon)
            {
                Console.WriteLine(item.pokeName);
            }
            Console.WriteLine();
        }



        //*LIST OF ALL EXISTING POKEMON*

        // GRASS TYPE POKEMON

        //Bulbasaur Line
        public static Pokemon Venusaur = new Pokemon("Venusaur", 80, 82, 83, 100, 100, 80, Types.Grass, Types.Poison, 208, 0)
        {
            LearnedMoves = { Move.SolarBeam, Move.TakeDown }
        };
        public static Pokemon Ivysaur = new Pokemon("Ivysaur", 60, 62, 63, 80, 80, 60, Types.Grass, Types.Poison, 141, 32)
        {
            EvolutionStages = { Venusaur },
            LearnedMoves = { Move.RazorLeaf, Move.TakeDown }
        };
        public static Pokemon Bulbasaur = new Pokemon("Bulbasaur", 45, 49, 49, 65, 65, 45, Types.Grass, Types.Poison, 64, 16)
        {
            EvolutionStages = { Ivysaur, Venusaur },
            LearnedMoves = { Move.RazorLeaf }
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
            LearnedMoves = { Move.PetalDance, Move.BodySlam }
        };
        public static Pokemon Bayleef = new Pokemon("Bayleef", 60, 62, 80, 63, 80, 60, Types.Grass, Types.none, 141, 32)
        {
            EvolutionStages = { Meganium },
            LearnedMoves = { Move.RazorLeaf, Move.Stomp }
        };
        public static Pokemon Chikorita = new Pokemon("Chikorita", 45, 49, 65, 49, 65, 49, Types.Grass, Types.none, 64, 16)
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
            LearnedMoves = { Move.Ember, Move.Fly, Move.Scratch }
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
            LearnedMoves = { Move.Surf, Move.FlashCannon, Move.SkullBash, Move.Bite }
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
            LearnedMoves = { Move.WaterShuriken, Move.NightSlash, Move.AerialAce, Move.Extrasensory }
        };
        public static Pokemon Frogadier = new Pokemon("Frogadier", 54, 63, 52, 83, 56, 97, Types.Water, Types.Dark, 142, 36)
        {
            LearnedMoves = { Move.WaterPulse, Move.QuickAttack }
        };
        public static Pokemon Froakie = new Pokemon("Froakie", 41, 56, 40, 62, 44, 71, Types.Water, Types.Dark, 63, 16)
        {
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
        public static Pokemon Pikachu = new Pokemon("Pikachu", 35, 55, 30, 50, 40, 90, Types.Electric, Types.none, 82, 0)
        {            
            LearnedMoves = { Move.Thunderbolt, Move.QuickAttack }
        };
        public static Pokemon Luxray = new Pokemon("Luxray", 80, 120, 79, 95, 79, 70, Types.Electric, Types.none, 194, 0)
        {
            LearnedMoves = { Move.Thunderbolt, Move.Crunch, Move.Tackle }
        };
        public static Pokemon Luxio = new Pokemon("Luxio", 60, 85, 49, 60, 49, 60, Types.Electric, Types.none, 117, 30)
        {
            LearnedMoves = { Move.Spark, Move.Bite, Move.Tackle }
        };
        public static Pokemon Shinx = new Pokemon("Shinx", 80, 120, 79, 95, 79, 70, Types.Electric, Types.none, 194, 15)
        {
            LearnedMoves = { Move.Thunderbolt, Move.Crunch, Move.Tackle }
        };


        // // Psychic Type Pokemon
        // public static Pokemon Alakazam = new Pokemon("Alakazam", 22, 20, 14, 18, Types.Psychic, Types.none, 186, 0);
        // public static Pokemon Gardevoir = new Pokemon("Gardevoir", 23, 19, 15, 14, Types.Psychic, Types.Fairy, 208, 0);
        // public static Pokemon Gallade = new Pokemon("Gallade", 22, 18, 15, 14, Types.Psychic, Types.Fighting, 208, 0);


        // // Fighting Type Pokemon     
        // public static Pokemon Lucario = new Pokemon("Lucario", 23, 17, 13, 15, Types.Fighting, Types.Steel, 204, 0);
        // public static Pokemon Machamp = new Pokemon("Machamp", 25, 19, 14, 12, Types.Fighting, Types.none, 193, 0);


        // // Normal Type Pokemon
        // public static Pokemon Snorlax = new Pokemon("Snorlax", 32, 17, 15, 9, Types.Normal, Types.none, 154, 0);


        // // Ghost Type Pokemon
        // public static Pokemon Gengar = new Pokemon("Gengar", 22, 19, 14, 17, Types.Ghost, Types.Poison, 190, 0);


        // // Dark Type Pokemon
        // public static Pokemon Zoroark = new Pokemon("Zoroak", 22, 18, 12, 17, Types.Dark, Types.none, 179, 0);


        // // Bug Type Pokemon


        // // Rock Type Pokemon
        // public static Pokemon Tyranitar = new Pokemon("Tyranitar", 26, 19, 17, 12, Types.Rock, Types.Dark, 218, 0);


        // // Ground Type Pokemon
        // public static Pokemon Krookodile = new Pokemon("Krookodile", 26, 18, 14, 15, Types.Ground, Types.Dark, 229, 0);
        // public static Pokemon Golurk = new Pokemon("Golurk", 24, 18, 14, 11, Types.Ground, Types.Ghost, 169, 0);


        // // Steel Type Pokemon
        // public static Pokemon Metagross = new Pokemon("Metagross", 24, 20, 19, 13, Types.Steel, Types.Psychic, 210, 0);
        // public static Pokemon Aggron = new Pokemon("Aggron", 23, 17, 24, 11, Types.Steel, Types.Rock, 205, 0);

        // // Dragon Type Pokemon
        // public static Pokemon Garchomp = new Pokemon("Garchomp", 26, 19, 15, 16, Types.Dragon, Types.Ground, 218, 0);
        // public static Pokemon Dragonite = new Pokemon("Dragonite", 25, 19, 15, 14, Types.Dragon, Types.Flying, 218, 0);

        // //Flying Type Pokemon
        // public static Pokemon Staraptor = new Pokemon("Staraptor", 24, 18, 13, 16, Types.Flying, Types.Normal, 172, 0);

        // //Eevee Pokemon
        // public static Pokemon Vaporeon = new Pokemon("Vaporeon", 29, 15, 14, 13, Types.Water, Types.none, 196, 0);
        // public static Pokemon Jolteon = new Pokemon("Jolteon", 22, 15, 14, 19, Types.Electric, Types.none, 197, 0);
        // public static Pokemon Flareon = new Pokemon("Flareon", 22, 18, 14, 13, Types.Fire, Types.none, 198, 0);
        // public static Pokemon Sylveon = new Pokemon("Sylveon", 25, 17, 14, 12, Types.Fairy, Types.none, 184, 0);
        // public static Pokemon Espeon = new Pokemon("Espeon", 22, 19, 14, 17, Types.Psychic, Types.none, 197, 0);
        // public static Pokemon Umbreon = new Pokemon("Umbreon", 25, 12, 18, 13, Types.Dark, Types.none, 197, 0);
        // public static Pokemon Eevee = new Pokemon("Eevee", 21, 11, 12, 11, Types.Normal, Types.none, 92, 0);


        // //*POKEMON MOVES SYSTEM*

        // public void LearnMove(Move specifiedMove)
        // {
        //     this.LearnedMoves.Add(specifiedMove);
        // }
        // //AllPokemonMoves
        // public static void InitializePokemonMoves()
        // {

        //     //Fire Type Pokemon
        //     Charizard.LearnMove(Move.Flamethrower);
        //     Charizard.LearnMove(Move.Fly);
        //     Charizard.LearnMove(Move.DragonClaw);
        //     Blaziken.LearnMove(Move.CloseCombat);
        //     Blaziken.LearnMove(Move.Flamethrower);
        //     Ninetales.LearnMove(Move.Flamethrower);
        //     Ninetales.LearnMove(Move.FireFang);
        //     Arcanine.LearnMove(Move.Flamethrower);
        //     Arcanine.LearnMove(Move.FireFang);
        //     Flareon.LearnMove(Move.Flamethrower);
        //     Flareon.LearnMove(Move.QuickAttack);
        //     //Water Type Pokemon
        //     Gyarados.LearnMove(Move.AquaTail);
        //     Gyarados.LearnMove(Move.Earthquake);
        //     Gyarados.LearnMove(Move.Crunch);
        //     Swampert.LearnMove(Move.Earthquake);
        //     Swampert.LearnMove(Move.Waterfall);
        //     Blastoise.LearnMove(Move.Earthquake);
        //     Blastoise.LearnMove(Move.Waterfall);
        //     Blastoise.LearnMove(Move.Crunch);
        //     Vaporeon.LearnMove(Move.AquaTail);
        //     Vaporeon.LearnMove(Move.Surf);
        //     Vaporeon.LearnMove(Move.QuickAttack);
        //     Greninja.LearnMove(Move.Waterfall);
        //     Greninja.LearnMove(Move.Surf);
        //     Greninja.LearnMove(Move.DarkPulse);
        //     //Grass Type Pokemon
        //     Venusaur.LearnMove(Move.PetalDance);
        //     Chikorita.LearnMove(Move.PetalDance);
        //     Tsareena.LearnMove(Move.TropKick);
        //     Tsareena.LearnMove(Move.HighJumpKick);
        //     Tsareena.LearnMove(Move.PlayRough);
        //     //Steel Type Pokemon
        //     Metagross.LearnMove(Move.Psychic);
        //     Metagross.LearnMove(Move.Earthquake);
        //     Metagross.LearnMove(Move.MeteorMash);
        //     Metagross.LearnMove(Move.HammerArm);
        //     Aggron.LearnMove(Move.IronHead);
        //     Aggron.LearnMove(Move.Earthquake);
        //     Aggron.LearnMove(Move.StoneEdge);
        //     //Rock Type Pokemon
        //     Tyranitar.LearnMove(Move.StoneEdge);
        //     Tyranitar.LearnMove(Move.Earthquake);
        //     Tyranitar.LearnMove(Move.Crunch);
        //     //Ground Type Pokemon
        //     Krookodile.LearnMove(Move.Crunch);
        //     Krookodile.LearnMove(Move.Earthquake);
        //     Golurk.LearnMove(Move.Earthquake);
        //     Golurk.LearnMove(Move.PhantomForce);
        //     //Ghost Type Pokemon
        //     Gengar.LearnMove(Move.Psychic);
        //     Gengar.LearnMove(Move.ShadowBall);
        //     Gengar.LearnMove(Move.DarkPulse);
        //     //Dark Type Pokemon
        //     Umbreon.LearnMove(Move.DarkPulse);
        //     Umbreon.LearnMove(Move.QuickAttack);
        //     Zoroark.LearnMove(Move.DarkPulse);
        //     //Psychic Type Pokemon
        //     Gardevoir.LearnMove(Move.MoonBlast);
        //     Gardevoir.LearnMove(Move.Psychic);
        //     Gardevoir.LearnMove(Move.ShadowBall);
        //     Gallade.LearnMove(Move.Psychic);
        //     Gallade.LearnMove(Move.CloseCombat);
        //     Alakazam.LearnMove(Move.Psychic);
        //     Alakazam.LearnMove(Move.ShadowBall);
        //     Espeon.LearnMove(Move.Psychic);
        //     Espeon.LearnMove(Move.QuickAttack);
        //     //Fighting Type Pokemon
        //     Lucario.LearnMove(Move.CloseCombat);
        //     Lucario.LearnMove(Move.IronHead);
        //     Machamp.LearnMove(Move.CloseCombat);
        //     Machamp.LearnMove(Move.HammerArm);
        //     Machamp.LearnMove(Move.StoneEdge);
        //     //Flying Type Pokemon
        //     Staraptor.LearnMove(Move.Fly);
        //     Staraptor.LearnMove(Move.BraveBird);
        //     Staraptor.LearnMove(Move.CloseCombat);
        //     Staraptor.LearnMove(Move.QuickAttack);
        //     //Normal Type Pokemon
        //     Snorlax.LearnMove(Move.BodySlam);
        //     Snorlax.LearnMove(Move.Crunch);
        //     Eevee.LearnMove(Move.QuickAttack);
        //     Eevee.LearnMove(Move.PlayRough);
        //     //Electric Type Pokemon
        //     Pikachu.LearnMove(Move.Thunderbolt);
        //     Jolteon.LearnMove(Move.Thunderbolt);
        //     Jolteon.LearnMove(Move.QuickAttack);
        //     Luxray.LearnMove(Move.Thunderbolt);
        //     Luxray.LearnMove(Move.Crunch);
        //     //Dragon Type Pokemon
        //     Garchomp.LearnMove(Move.DragonClaw);
        //     Garchomp.LearnMove(Move.Earthquake);
        //     Dragonite.LearnMove(Move.DragonClaw);
        //     Dragonite.LearnMove(Move.DragonPulse);
        //     Dragonite.LearnMove(Move.Fly);
        //     //Fairy Type Pokemon
        //     Sylveon.LearnMove(Move.PlayRough);
        //     Sylveon.LearnMove(Move.MoonBlast);
        //     Sylveon.LearnMove(Move.QuickAttack);
        // }








    }

}