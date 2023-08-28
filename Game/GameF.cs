namespace PokemonGame{

    public class GameF{
        public static void PressAnyKeyToContinue(){
            Console.ReadKey();
            Console.Clear();
            Console.Beep();
        }

        public static void Line(){
            Console.WriteLine("---------------------------------------------------------------------------");
        }

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
    }
}