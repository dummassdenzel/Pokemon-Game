namespace PokemonGame
{

    public class Types
    {

        string type;
        public List<Types> Resistances = new List<Types>();
        public List<Types> Weaknesses = new List<Types>();
        public List<Types> Immunities = new List<Types>();

        public Types(string thistype)
        {
            type = thistype;
        }

        public static Types Normal = new Types("Normal"){};
        public static Types Fire = new Types("Fire");
        public static Types Water = new Types("Water");
        public static Types Grass = new Types("Grass");
        public static Types Electric = new Types("Electric");
        public static Types Ice = new Types("Ice");
        public static Types Fighting = new Types("Fighting");
        public static Types Poison = new Types("Poison");
        public static Types Ground = new Types("Ground");
        public static Types Flying = new Types("Flying");
        public static Types Psychic = new Types("Psychic");
        public static Types Bug = new Types("Bug");
        public static Types Rock = new Types("Rock");
        public static Types Ghost = new Types("Ghost");
        public static Types Dark = new Types("Dark");
        public static Types Steel = new Types("Steel");
        public static Types Dragon = new Types("Dragon");
        public static Types Fairy = new Types("Fairy");
        public static Types none = new Types("none");

        static Types(){
            Normal.Weaknesses.Add(Fighting);
            Normal.Immunities.Add(Ghost);

            Fire.Resistances.Add(Grass);
            Fire.Resistances.Add(Bug);
            Fire.Resistances.Add(Ice);
            Fire.Resistances.Add(Fire);
            Fire.Resistances.Add(Steel);
            Fire.Weaknesses.Add(Water);
            Fire.Weaknesses.Add(Ground);
            Fire.Weaknesses.Add(Rock);

            Water.Resistances.Add(Fire);
            Water.Resistances.Add(Ice);
            Water.Resistances.Add(Steel);
            Water.Resistances.Add(Water);
            Water.Weaknesses.Add(Electric);
            Water.Weaknesses.Add(Grass);

            Grass.Resistances.Add(Water);
            Grass.Resistances.Add(Ground);
            Grass.Resistances.Add(Electric);
            Grass.Resistances.Add(Grass);
            Grass.Weaknesses.Add(Bug);
            Grass.Weaknesses.Add(Fire);
            Grass.Weaknesses.Add(Flying);
            Grass.Weaknesses.Add(Ice);
            Grass.Weaknesses.Add(Poison);

            Electric.Resistances.Add(Water);
            Electric.Resistances.Add(Flying);
            Electric.Resistances.Add(Steel);
            Electric.Immunities.Add(Ground);

            Psychic.Resistances.Add(Fighting);
            Psychic.Resistances.Add(Psychic);
            Psychic.Weaknesses.Add(Ghost);
            Psychic.Weaknesses.Add(Dark);
            Psychic.Weaknesses.Add(Bug);

            Ice.Resistances.Add(Ice);            
            Ice.Weaknesses.Add(Fire);
            Ice.Weaknesses.Add(Fighting);
            Ice.Weaknesses.Add(Rock);
            Ice.Weaknesses.Add(Steel);

            Dragon.Resistances.Add(Electric);
            Dragon.Resistances.Add(Fire);
            Dragon.Resistances.Add(Grass);
            Dragon.Resistances.Add(Water);
            Dragon.Weaknesses.Add(Dragon);
            Dragon.Weaknesses.Add(Ice);

            Dark.Resistances.Add(Dark);
            Dark.Resistances.Add(Ghost);
            Dark.Weaknesses.Add(Fighting);
            Dark.Weaknesses.Add(Bug);
            Dark.Weaknesses.Add(Fairy);
            Dark.Immunities.Add(Psychic);

            Fairy.Resistances.Add(Bug);
            Fairy.Resistances.Add(Dark);
            Fairy.Resistances.Add(Fighting);
            Fairy.Weaknesses.Add(Poison);
            Fairy.Weaknesses.Add(Steel);
            Fairy.Immunities.Add(Dragon);

            Fighting.Resistances.Add(Bug);
            Fighting.Resistances.Add(Dark);
            Fighting.Resistances.Add(Rock);
            Fighting.Weaknesses.Add(Flying);
            Fighting.Weaknesses.Add(Psychic);

            Flying.Resistances.Add(Bug);
            Flying.Resistances.Add(Fighting);
            Flying.Resistances.Add(Grass);
            Flying.Weaknesses.Add(Electric);
            Flying.Weaknesses.Add(Ice);
            Flying.Weaknesses.Add(Rock);
            Flying.Immunities.Add(Ground);

            Poison.Resistances.Add(Bug);
            Poison.Resistances.Add(Poison);
            Poison.Resistances.Add(Fighting);
            Poison.Resistances.Add(Grass);
            Poison.Resistances.Add(Fairy);
            Poison.Weaknesses.Add(Ground);
            Poison.Weaknesses.Add(Psychic);

            Ground.Resistances.Add(Rock);
            Ground.Resistances.Add(Poison);
            Ground.Weaknesses.Add(Grass);
            Ground.Weaknesses.Add(Ice);
            Ground.Weaknesses.Add(Water);
            Ground.Immunities.Add(Electric);

            Rock.Resistances.Add(Fire);
            Rock.Resistances.Add(Normal);
            Rock.Resistances.Add(Flying);
            Rock.Resistances.Add(Poison);
            Rock.Weaknesses.Add(Fighting);
            Rock.Weaknesses.Add(Grass);
            Rock.Weaknesses.Add(Ground);
            Rock.Weaknesses.Add(Water);

            Bug.Resistances.Add(Fighting);
            Bug.Resistances.Add(Grass);
            Bug.Resistances.Add(Ground);
            Bug.Weaknesses.Add(Fire);
            Bug.Weaknesses.Add(Rock);
            Bug.Weaknesses.Add(Flying);

            Ghost.Resistances.Add(Bug);
            Ghost.Resistances.Add(Poison);
            Ghost.Weaknesses.Add(Dark);
            Ghost.Weaknesses.Add(Ghost);
            Ghost.Immunities.Add(Normal);
            Ghost.Immunities.Add(Fighting);

            Steel.Resistances.Add(Bug);
            Steel.Resistances.Add(Dark);
            Steel.Resistances.Add(Dragon);
            Steel.Resistances.Add(Flying);
            Steel.Resistances.Add(Ghost);
            Steel.Resistances.Add(Grass);
            Steel.Resistances.Add(Ice);
            Steel.Resistances.Add(Normal);
            Steel.Resistances.Add(Psychic);
            Steel.Resistances.Add(Rock); 
            Steel.Resistances.Add(Steel);  
            Steel.Weaknesses.Add(Fire);
            Steel.Weaknesses.Add(Fighting);
            Steel.Weaknesses.Add(Ground);  
        }
        
    }
}