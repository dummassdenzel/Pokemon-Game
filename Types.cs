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
            this.type = thistype;
        }

        public static Types Normal = new Types("Normal");
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

        public void AddResistance(Types strengths)
        {
            this.Resistances.Add(strengths);
        }
        public void AddWeakness(Types weaknesses)
        {
            this.Weaknesses.Add(weaknesses);
        }
        public void AddImmunity(Types weaknesses)
        {
            this.Immunities.Add(weaknesses);
        }
        public static void InitializeWeaknesses()
        {
            
            Normal.AddWeakness(Fighting);
            Normal.AddImmunity(Ghost);

            Fire.AddResistance(Grass);
            Fire.AddResistance(Bug);
            Fire.AddResistance(Ice);
            Fire.AddResistance(Fire);
            Fire.AddResistance(Steel);
            Fire.AddWeakness(Water);
            Fire.AddWeakness(Ground);
            Fire.AddWeakness(Rock);

            Water.AddResistance(Fire);
            Water.AddResistance(Ice);
            Water.AddResistance(Steel);
            Water.AddResistance(Water);
            Water.AddWeakness(Electric);
            Water.AddWeakness(Grass);

            Grass.AddResistance(Water);
            Grass.AddResistance(Ground);
            Grass.AddResistance(Electric);
            Grass.AddResistance(Grass);
            Grass.AddWeakness(Bug);
            Grass.AddWeakness(Fire);
            Grass.AddWeakness(Flying);
            Grass.AddWeakness(Ice);
            Grass.AddWeakness(Poison);

            Electric.AddResistance(Water);
            Electric.AddResistance(Flying);
            Electric.AddResistance(Steel);
            Electric.AddImmunity(Ground);

            Psychic.AddResistance(Fighting);
            Psychic.AddResistance(Psychic);
            Psychic.AddWeakness(Ghost);
            Psychic.AddWeakness(Dark);
            Psychic.AddWeakness(Bug);

            Ice.AddResistance(Ice);            
            Ice.AddWeakness(Fire);
            Ice.AddWeakness(Fighting);
            Ice.AddWeakness(Rock);
            Ice.AddWeakness(Steel);

            Dragon.AddResistance(Electric);
            Dragon.AddResistance(Fire);
            Dragon.AddResistance(Grass);
            Dragon.AddResistance(Water);
            Dragon.AddWeakness(Dragon);
            Dragon.AddWeakness(Ice);

            Dark.AddResistance(Dark);
            Dark.AddResistance(Ghost);
            Dark.AddWeakness(Fighting);
            Dark.AddWeakness(Bug);
            Dark.AddWeakness(Fairy);
            Dark.AddImmunity(Psychic);

            Fairy.AddResistance(Bug);
            Fairy.AddResistance(Dark);
            Fairy.AddResistance(Fighting);
            Fairy.AddWeakness(Poison);
            Fairy.AddWeakness(Steel);
            Fairy.AddImmunity(Dragon);

            Fighting.AddResistance(Bug);
            Fighting.AddResistance(Dark);
            Fighting.AddResistance(Rock);
            Fighting.AddWeakness(Flying);
            Fighting.AddWeakness(Psychic);

            Flying.AddResistance(Bug);
            Flying.AddResistance(Fighting);
            Flying.AddResistance(Grass);
            Flying.AddWeakness(Electric);
            Flying.AddWeakness(Ice);
            Flying.AddWeakness(Rock);
            Flying.AddImmunity(Ground);

            Poison.AddResistance(Bug);
            Poison.AddResistance(Poison);
            Poison.AddResistance(Fighting);
            Poison.AddResistance(Grass);
            Poison.AddResistance(Fairy);
            Poison.AddWeakness(Ground);
            Poison.AddWeakness(Psychic);

            Ground.AddResistance(Rock);
            Ground.AddResistance(Poison);
            Ground.AddWeakness(Grass);
            Ground.AddWeakness(Ice);
            Ground.AddWeakness(Water);
            Ground.AddImmunity(Electric);

            Rock.AddResistance(Fire);
            Rock.AddResistance(Normal);
            Rock.AddResistance(Flying);
            Rock.AddResistance(Poison);
            Rock.AddWeakness(Fighting);
            Rock.AddWeakness(Grass);
            Rock.AddWeakness(Ground);
            Rock.AddWeakness(Water);

            Bug.AddResistance(Fighting);
            Bug.AddResistance(Grass);
            Bug.AddResistance(Ground);
            Bug.AddWeakness(Fire);
            Bug.AddWeakness(Rock);
            Bug.AddWeakness(Flying);

            Ghost.AddResistance(Bug);
            Ghost.AddResistance(Poison);
            Ghost.AddWeakness(Dark);
            Ghost.AddWeakness(Ghost);
            Ghost.AddImmunity(Normal);
            Ghost.AddImmunity(Fighting);

            Steel.AddResistance(Bug);
            Steel.AddResistance(Dark);
            Steel.AddResistance(Dragon);
            Steel.AddResistance(Flying);
            Steel.AddResistance(Ghost);
            Steel.AddResistance(Grass);
            Steel.AddResistance(Ice);
            Steel.AddResistance(Normal);
            Steel.AddResistance(Psychic);
            Steel.AddResistance(Rock); 
            Steel.AddResistance(Steel);  
            Steel.AddWeakness(Fire);
            Steel.AddWeakness(Fighting);
            Steel.AddWeakness(Ground);          

        }




    }


}