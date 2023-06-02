
namespace PokemonGame
{

    class Game
    {

        public static void showAllActions()
        {
            Console.WriteLine("\nEnter the phrase or the number:");
            Console.WriteLine("(1) - Catch a Pokemon");
            Console.WriteLine("(2) - Challenge a Trainer ");
            Console.WriteLine("(3) - Show Team ");
            Console.WriteLine("(4) - Heal Pokemon ");
            Console.WriteLine("(5) - Show All Pokemon ");
            Console.WriteLine("(6) - Show All Trainers ");
            Console.WriteLine("(7) - Switch to a Different Trainer ");
            Console.WriteLine("(8) - End Game ");
            Console.WriteLine("*Enter 'none' if you wish to go back to choosing an Action.*\n");
        }

        //Turn-Based System
        public static void EndTurn()
        {
            Pokemon pokemonSwitcher = Trainer.ActivePokemon[0];
            Trainer.ActivePokemon[0] = Trainer.ActivePokemon[1];
            Trainer.ActivePokemon[1] = pokemonSwitcher;
        }



        //ALL POKEMON MOVES
        //This is where you add Pokemons' moves.
        public static void Strike()
        {
            //int AquaTailDMG = (90 * Trainer.ActivePokemon[0].atk) / 100;
            int StrikeDMG = 5;
            Trainer.ActivePokemon[1].combathp -= StrikeDMG;
        }
        //Water Type Moves
        public static List<Pokemon> AquaTail = new List<Pokemon>();
        public static void AquaTailMove()
        {
            int AquaTailDMG = (90 * Trainer.ActivePokemon[0].atk) / 100;
            Trainer.ActivePokemon[1].combathp -= AquaTailDMG;
        }

        public static List<Pokemon> Waterfall = new List<Pokemon>();
        public static void WaterfallMove()
        {
            int WaterfallDMG = (80 * Trainer.ActivePokemon[0].atk) / 100;
            Trainer.ActivePokemon[1].combathp -= WaterfallDMG;
        }


        //Steel Type Moves
        public static List<Pokemon> IronHead = new List<Pokemon>();
        public static void IronHeadMove()
        {
            int IronHeadDMG = (80 * Trainer.ActivePokemon[0].atk) / 100;
            Trainer.ActivePokemon[1].combathp -= IronHeadDMG;
        }

        public static List<Pokemon> MeteorMash = new List<Pokemon>();
        public static void MeteorMashMove()
        {
            int MeteorMashDMG = (90 * Trainer.ActivePokemon[0].atk) / 100;
            Trainer.ActivePokemon[1].combathp -= MeteorMashDMG;
        }


        //Psychic Type Moves
        public static List<Pokemon> Psychic = new List<Pokemon>();
        public static void PsychicMove()
        {
            int PsychicDMG = (90 * Trainer.ActivePokemon[0].atk) / 100;
            Trainer.ActivePokemon[1].combathp -= PsychicDMG;
        }


        //Fairy Type Moves
        public static List<Pokemon> MoonBlast = new List<Pokemon>();
        public static void MoonBlastMove()
        {
            int MoonBlastDMG = (90 * Trainer.ActivePokemon[0].atk) / 100;
            Trainer.ActivePokemon[1].combathp -= MoonBlastDMG;
        }


        //Dark Type Moves
        public static List<Pokemon> Crunch = new List<Pokemon>();
        public static void CrunchMove()
        {
            int CrunchDMG = (80 * Trainer.ActivePokemon[0].atk) / 100;
            Trainer.ActivePokemon[1].combathp -= CrunchDMG;
        }


        //Ghost Type Moves
        public static List<Pokemon> ShadowBall = new List<Pokemon>();
        public static void ShadowBallMove()
        {
            int ShadowBallDMG = (80 * Trainer.ActivePokemon[0].atk) / 100;
            Trainer.ActivePokemon[1].combathp -= ShadowBallDMG;
        }


        //Fire Type Moves
        public static List<Pokemon> Flamethrower = new List<Pokemon>();
        public static void FlamethrowerMove()
        {
            int FlamethrowerDMG = (90 * Trainer.ActivePokemon[0].atk) / 100;
            Trainer.ActivePokemon[1].combathp -= FlamethrowerDMG;
        }


        //Ground Type Moves
        public static List<Pokemon> Earthquake = new List<Pokemon>();
        public static void EarthquakeMove()
        {
            int EarthquakeDMG = (100 * Trainer.ActivePokemon[0].atk) / 100;
            Trainer.ActivePokemon[1].combathp -= EarthquakeDMG;
        }






    }
}