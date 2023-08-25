namespace PokemonGame
{
    public class AllNPTrainers : Trainer
    {
        private string? TrainerClass { get; set; }
        public AllNPTrainers(string thistrainername, char thisgender) : base(thistrainername, thisgender)
        {
            isPlayer = false;
        }
        private void SetTeam(Pokemon pokemon, int level)
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
            public static NPTrainer Triumfante = new NPTrainer("Triumfante", 'm');
            public static NPTrainer Roa = new NPTrainer("Roa", 'm');


            
            static NPTrainer() //Set their Pokemon
            {
                Steve.SetTeam(Pokemon.Squirtle, 5);
                Steve.SetTeam(Pokemon.Froakie, 5);                
                Alex.SetTeam(Pokemon.Starly, 4);
                Alex.SetTeam(Pokemon.Starly, 5);
                Alex.SetTeam(Pokemon.Starly, 5);
                
                Galino.SetTeam(Pokemon.Gible, 7);
                                
                Agasa.SetTeam(Pokemon.Mudkip, 7);
                Agasa.SetTeam(Pokemon.Zorua, 8);
                           
                Triumfante.SetTeam(Pokemon.Growlithe, 8);
                Triumfante.SetTeam(Pokemon.Shinx, 9);
                
                Roa.SetTeam(Pokemon.Froakie, 12);
                Roa.SetTeam(Pokemon.Kadabra, 16);
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
                Hizola.SetTeam(Pokemon.Machop, 14);
                Hizola.SetTeam(Pokemon.Machop, 14);
                Hizola.SetTeam(Pokemon.Riolu, 17);


                Viacrusis.SetTeam(Pokemon.Squirtle, 18);
                Viacrusis.SetTeam(Pokemon.Frogadier, 20);
                Viacrusis.SetTeam(Pokemon.Marshtomp, 22);

            }
        }






    }

}