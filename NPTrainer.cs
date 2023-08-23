namespace PokemonGame
{
    public class NPTrainer : Trainer
    {    
        public static List<NPTrainer> NPTrainers = new List<NPTrainer>();
        public NPTrainer(string thistrainername, char thisgender)
            : base(thistrainername, thisgender)
        {   
            isPlayer = false;
            NPTrainers.Add(this);
        }

        //ALL NP TRAINERS
        public static NPTrainer Steve = new NPTrainer("Steve", 'm');
        public static NPTrainer Alex = new NPTrainer("Alex", 'f');
        public static NPTrainer Galino = new NPTrainer("Galino", 'm');


        private void AddNPPokemon(Pokemon pokemon, int level)
        {
            Pokemon NPpokemon = pokemon;
            NPpokemon.ownerTrainer = trainerName;
            NPpokemon.pokelevel = level;
            Team.Add(NPpokemon);
        }
        static NPTrainer()
        {
            Steve.AddNPPokemon(Pokemon.Squirtle, 5);
            Steve.AddNPPokemon(Pokemon.Froakie, 5);
            Alex.AddNPPokemon(Pokemon.Starly, 5);
            Alex.AddNPPokemon(Pokemon.Shinx, 5);
            Galino.AddNPPokemon(Pokemon.Gible, 7);
        }

    }

}