namespace PokemonGame{

    public class Locations{

        public string LocationName;
        public string Region;
        public List<People> Peoples = new List<People>();
        public List<Pokemon> Pokemons = new List<Pokemon>();
        public List<Locations> AvailableRoutes = new List<Locations>();
        

        public static List<Locations> WorldMap = new List<Locations>();
        public Locations(string name, string region){
            LocationName = name;
            Region = region;
            WorldMap.Add(this);
        }

        public void AddInhabitant(Pokemon pokemon, int pokemonlevel){
            Pokemon newPokemon = pokemon;
            newPokemon.pokelevel = pokemonlevel;
            Pokemons.Add(newPokemon);
        }

        
    }
}