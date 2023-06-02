
namespace PokemonGame
{
    public class Pokemon
    {
        //Each individual Pokemon have these Attributes.
        public string pokeName;
        public int hp;
        public int atk;
        public int def;
        public int speed;
        public string ownerTrainer = "none";
        public int combathp;
        public Types poketype1;
        public Types poketype2;
        public List<Move> LearnedMoves = new List<Move>();
        public List<Pokemon> EvolutionStages = new List<Pokemon>();
        public int pokelevel = 5;
        public int exp;



        //Arrays
        public List<Action> Moveset = new List<Action>();
        public static List<Pokemon> AllPokemon = new List<Pokemon>();




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


        //POKEMON CONSTRUCTOR
        public Pokemon(string thisname, int thishp, int thisatk, int thisdef, int thisspeed, Types thistype1, Types thistype2)
        {

            this.pokeName = thisname;
            this.hp = thishp;
            this.atk = thisatk;
            this.def = thisdef;
            this.speed = thisspeed;
            this.combathp = hp;
            this.poketype1 = thistype1;
            this.poketype2 = thistype2;
            AllPokemon.Add(this);


        }


        //LIST OF ALL EXISTING POKEMON
        //This is where you add Pokemon into the Game.


        // Grass Type Pokemon
        public static Pokemon Venusaur = new Pokemon("Venusaur", 24, 16, 16, 14, Types.Grass, Types.Poison);
        public static Pokemon Tsareena = new Pokemon("Tsareena", 23, 18, 15, 13, Types.Grass, Types.none);


        // Fire Type Pokemon
        public static Pokemon Charizard = new Pokemon("Charizard", 24, 17, 15, 16, Types.Fire, Types.Flying);
        public static Pokemon Blaziken = new Pokemon("Blaziken", 24, 18, 13, 14, Types.Fire, Types.Fighting);
        public static Pokemon Ninetales = new Pokemon("Ninetales", 23, 14, 16, 16, Types.Fire, Types.none);
        public static Pokemon Flareon = new Pokemon("Flareon", 22, 18, 14, 13, Types.Fire, Types.none);
        public static Pokemon Arcanine = new Pokemon("Arcanine", 25, 17, 14, 16, Types.Fire, Types.none);

        // Water Type Pokemon
        public static Pokemon Swampert = new Pokemon("Swampert", 26, 17, 15, 12, Types.Water, Types.Ground);
        public static Pokemon Blastoise = new Pokemon("Blastoise", 23, 14, 16, 13, Types.Water, Types.none);
        public static Pokemon Gyarados = new Pokemon("Gyarados", 26, 19, 14, 14, Types.Water, Types.Flying);
        public static Pokemon Vaporeon = new Pokemon("Vaporeon", 29, 15, 14, 13, Types.Water, Types.none);
        public static Pokemon Greninja = new Pokemon("Greninja", 23, 16, 12, 18, Types.Water, Types.Dark);


        // Electric Type Pokemon
        public static Pokemon Pikachu = new Pokemon("Pikachu", 19, 11, 11, 21, Types.Electric, Types.none);
        public static Pokemon Jolteon = new Pokemon("Jolteon", 22, 15, 14, 19, Types.Electric, Types.none);
        public static Pokemon Luxray = new Pokemon("Luxray", 24, 18, 13, 13, Types.Electric, Types.none);


        // Psychic Type Pokemon
        public static Pokemon Alakazam = new Pokemon("Alakazam", 22, 20, 14, 18, Types.Psychic, Types.none);
        public static Pokemon Gardevoir = new Pokemon("Gardevoir", 23, 19, 15, 14, Types.Psychic, Types.Fairy);
        public static Pokemon Gallade = new Pokemon("Gallade", 22, 18, 15, 14, Types.Psychic, Types.Fighting);
        public static Pokemon Espeon = new Pokemon("Espeon", 22, 19, 14, 17, Types.Psychic, Types.none);


        // Fighting Type Pokemon     
        public static Pokemon Lucario = new Pokemon("Lucario", 23, 17, 13, 15, Types.Fighting, Types.Steel);
        public static Pokemon Machamp = new Pokemon("Machamp", 25, 19, 14, 12, Types.Fighting, Types.none);


        // Normal Type Pokemon
        public static Pokemon Snorlax = new Pokemon("Snorlax", 32, 17, 15, 9, Types.Normal, Types.none);
        public static Pokemon Eevee = new Pokemon("Eevee", 21, 11, 12, 11, Types.Normal, Types.none);


        // Ghost Type Pokemon
        public static Pokemon Gengar = new Pokemon("Gengar", 22, 19, 14, 17, Types.Ghost, Types.Poison);


        // Dark Type Pokemon
        public static Pokemon Umbreon = new Pokemon("Umbreon", 25, 12, 18, 13, Types.Dark, Types.none);
        public static Pokemon Zoroark = new Pokemon("Zoroak", 22, 18, 12, 17, Types.Dark, Types.none);


        // Bug Type Pokemon


        // Rock Type Pokemon
        public static Pokemon Tyranitar = new Pokemon("Tyranitar", 26, 19, 17, 12, Types.Rock, Types.Dark);


        // Ground Type Pokemon
        public static Pokemon Krookodile = new Pokemon("Krookodile", 26, 18, 14, 15, Types.Ground, Types.Dark);
        public static Pokemon Golurk = new Pokemon("Golurk", 24, 18, 14, 11, Types.Ground, Types.Ghost);


        // Steel Type Pokemon
        public static Pokemon Metagross = new Pokemon("Metagross", 24, 20, 19, 13, Types.Steel, Types.Psychic);
        public static Pokemon Aggron = new Pokemon("Aggron", 23, 17, 24, 11, Types.Steel, Types.Rock);

        // Dragon Type Pokemon
        public static Pokemon Garchomp = new Pokemon("Garchomp", 26, 19, 15, 16, Types.Dragon, Types.Ground);
        public static Pokemon Dragonite = new Pokemon("Dragonite", 25, 19, 15, 14, Types.Dragon, Types.Flying);

        //Flying Type Pokemon
        public static Pokemon Staraptor = new Pokemon("Staraptor", 24, 18, 13, 16, Types.Flying, Types.Normal);

        //Fairy Type Pokemon
        public static Pokemon Sylveon = new Pokemon("Sylveon", 25, 17, 14, 12, Types.Fairy, Types.none);


        //*POKEMON MOVES SYSTEM*

        public void LearnMove(Move specifiedMove)
        {
            this.LearnedMoves.Add(specifiedMove);
        }
        //AllPokemonMoves
        public static void InitializePokemonMoves()
        {

            //Fire Type Pokemon
            Charizard.LearnMove(Move.Flamethrower);
            Charizard.LearnMove(Move.Fly);
            Charizard.LearnMove(Move.DragonClaw);
            Blaziken.LearnMove(Move.CloseCombat);
            Blaziken.LearnMove(Move.Flamethrower);
            Ninetales.LearnMove(Move.Flamethrower);
            Ninetales.LearnMove(Move.FireFang);
            Arcanine.LearnMove(Move.Flamethrower);
            Arcanine.LearnMove(Move.FireFang);
            Flareon.LearnMove(Move.Flamethrower);
            Flareon.LearnMove(Move.QuickAttack);
            //Water Type Pokemon
            Gyarados.LearnMove(Move.AquaTail);
            Gyarados.LearnMove(Move.Earthquake);
            Gyarados.LearnMove(Move.Crunch);
            Swampert.LearnMove(Move.Earthquake);
            Swampert.LearnMove(Move.Waterfall);
            Blastoise.LearnMove(Move.Earthquake);
            Blastoise.LearnMove(Move.Waterfall);
            Blastoise.LearnMove(Move.Crunch);
            Vaporeon.LearnMove(Move.AquaTail);
            Vaporeon.LearnMove(Move.Surf);
            Vaporeon.LearnMove(Move.QuickAttack);
            Greninja.LearnMove(Move.Waterfall);
            Greninja.LearnMove(Move.Surf);
            Greninja.LearnMove(Move.DarkPulse);
            //Grass Type Pokemon
            Venusaur.LearnMove(Move.PetalDance);
            Tsareena.LearnMove(Move.TropKick);
            Tsareena.LearnMove(Move.HighJumpKick);
            Tsareena.LearnMove(Move.PlayRough);
            //Steel Type Pokemon
            Metagross.LearnMove(Move.Psychic);
            Metagross.LearnMove(Move.Earthquake);
            Metagross.LearnMove(Move.MeteorMash);
            Metagross.LearnMove(Move.HammerArm);
            Aggron.LearnMove(Move.IronHead);
            Aggron.LearnMove(Move.Earthquake);
            Aggron.LearnMove(Move.StoneEdge);
            //Rock Type Pokemon
            Tyranitar.LearnMove(Move.StoneEdge);
            Tyranitar.LearnMove(Move.Earthquake);
            Tyranitar.LearnMove(Move.Crunch);
            //Ground Type Pokemon
            Krookodile.LearnMove(Move.Crunch);
            Krookodile.LearnMove(Move.Earthquake);
            Golurk.LearnMove(Move.Earthquake);
            Golurk.LearnMove(Move.PhantomForce);
            //Ghost Type Pokemon
            Gengar.LearnMove(Move.Psychic);
            Gengar.LearnMove(Move.ShadowBall);
            Gengar.LearnMove(Move.DarkPulse);
            //Dark Type Pokemon
            Umbreon.LearnMove(Move.DarkPulse);
            Umbreon.LearnMove(Move.QuickAttack);
            Zoroark.LearnMove(Move.DarkPulse);
            //Psychic Type Pokemon
            Gardevoir.LearnMove(Move.MoonBlast);
            Gardevoir.LearnMove(Move.Psychic);
            Gardevoir.LearnMove(Move.ShadowBall);
            Gallade.LearnMove(Move.Psychic);
            Gallade.LearnMove(Move.CloseCombat);
            Alakazam.LearnMove(Move.Psychic);
            Alakazam.LearnMove(Move.ShadowBall);
            Espeon.LearnMove(Move.Psychic);
            Espeon.LearnMove(Move.QuickAttack);
            //Fighting Type Pokemon
            Lucario.LearnMove(Move.CloseCombat);     
            Lucario.LearnMove(Move.IronHead);          
            Machamp.LearnMove(Move.CloseCombat);
            Machamp.LearnMove(Move.HammerArm);
            Machamp.LearnMove(Move.StoneEdge);
            //Flying Type Pokemon
            Staraptor.LearnMove(Move.Fly);
            Staraptor.LearnMove(Move.BraveBird);
            Staraptor.LearnMove(Move.CloseCombat);
            Staraptor.LearnMove(Move.QuickAttack);
            //Normal Type Pokemon
            Snorlax.LearnMove(Move.BodySlam);
            Snorlax.LearnMove(Move.Crunch);
            Eevee.LearnMove(Move.QuickAttack);
            Eevee.LearnMove(Move.PlayRough);
            //Electric Type Pokemon
            Pikachu.LearnMove(Move.Thunderbolt);
            Jolteon.LearnMove(Move.Thunderbolt);
            Jolteon.LearnMove(Move.QuickAttack);
            Luxray.LearnMove(Move.Thunderbolt);
            Luxray.LearnMove(Move.Crunch);
            //Dragon Type Pokemon
            Garchomp.LearnMove(Move.DragonClaw);
            Garchomp.LearnMove(Move.Earthquake);
            Dragonite.LearnMove(Move.DragonClaw);
            Dragonite.LearnMove(Move.DragonPulse);
            Dragonite.LearnMove(Move.Fly);
            //Fairy Type Pokemon
            Sylveon.LearnMove(Move.PlayRough);
            Sylveon.LearnMove(Move.MoonBlast);
            Sylveon.LearnMove(Move.QuickAttack);
        }








    }

}