namespace PokemonGame
{
    public class AllNPTrainers : Trainer
    {
        private string? TrainerClass { get; set; }
        public AllNPTrainers(string thistrainername, char thisgender) : base(thistrainername, thisgender)
        {
            isPlayer = false;
        }
        private void AddNPPokemon(Pokemon pokemon, int level)
        {   
            Pokemon newPokemon = new Pokemon(
                pokemon.PokeName,
                pokemon.hp,
                pokemon.atk,
                pokemon.def,
                pokemon.spatk,
                pokemon.spdef,
                pokemon.speed,
                pokemon.poketype1,
                pokemon.poketype2,
                pokemon.expYield,
                pokemon.evolvelevel
            );
            newPokemon.LearnedMoves.AddRange(pokemon.LearnedMoves);
            newPokemon.ownerTrainer = trainerName;
            newPokemon.pokelevel = level;
            Team.Add(newPokemon);
        }

        //Regular Trainers
        public class NPTrainer : AllNPTrainers
        {
            public static List<NPTrainer> NPTrainers = new List<NPTrainer>();
            public NPTrainer(string thistrainername, char thisgender) : base(thistrainername, thisgender)
            {
                TrainerClass = "Trainer";
                NPTrainers.Add(this);
            }
            //Instances
            public static NPTrainer Steve = new NPTrainer("Steve", 'm');
            public static NPTrainer Alex = new NPTrainer("Alex", 'f');
            public static NPTrainer Galino = new NPTrainer("Galino", 'm');
            public static NPTrainer Agasa = new NPTrainer("Agasa", 'f');
            public static NPTrainer Hizola = new NPTrainer("Hizola", 'm');
            public static NPTrainer Triumfante = new NPTrainer("Triumfante", 'm');
            public static NPTrainer Roa = new NPTrainer("Roa", 'm');

            static NPTrainer() //Set their Pokemon
            {
                Steve.AddNPPokemon(Pokemon.Squirtle, 5);
                Steve.AddNPPokemon(Pokemon.Froakie, 5);

                Alex.AddNPPokemon(Pokemon.Starly, 4);
                Alex.AddNPPokemon(Pokemon.Starly, 5);
                Alex.AddNPPokemon(Pokemon.Starly, 5);

                Galino.AddNPPokemon(Pokemon.Gible, 7);

                Agasa.AddNPPokemon(Pokemon.Mudkip, 7);
                Agasa.AddNPPokemon(Pokemon.Zorua, 8);

                Triumfante.AddNPPokemon(Pokemon.Growlithe, 8);
                Triumfante.AddNPPokemon(Pokemon.Shinx, 9);

                Roa.AddNPPokemon(Pokemon.Froakie, 12);
                Roa.AddNPPokemon(Pokemon.Kadabra, 16);
            }
        }

        //Gym Leaders
        public class GymLeader : AllNPTrainers
        {
            public Types gymType;
            public static List<GymLeader> GymLeaders = new List<GymLeader>();
            public GymLeader(string thistrainername, char thisgender, Types thisgymType) : base(thistrainername, thisgender)
            {
                TrainerClass = "Gym Leader";
                gymType = thisgymType;
                GymLeaders.Add(this);
            }
            //Instances
            public static GymLeader Viacrusis = new GymLeader("Viacrusis", 'm', Types.Water);
            public static GymLeader Hizola = new GymLeader("Hizola", 'm', Types.Fighting);

            static GymLeader() //Set their Pokemon
            {
                Hizola.AddNPPokemon(Pokemon.Machop, 14);
                Hizola.AddNPPokemon(Pokemon.Machop, 14);
                Hizola.AddNPPokemon(Pokemon.Riolu, 17);


                Viacrusis.AddNPPokemon(Pokemon.Squirtle, 18);
                Viacrusis.AddNPPokemon(Pokemon.Frogadier, 20);
                Viacrusis.AddNPPokemon(Pokemon.Marshtomp, 22);

            }
        }






    }

}