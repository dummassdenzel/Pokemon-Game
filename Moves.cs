
namespace PokemonGame
{

    public class Move
    {

        public string moveName;
        public int moveDamage;
        public Types movetype;

        public Move(string move, int damage, Types thistype)
        {

            this.moveName = move;
            this.moveDamage = damage;
            this.movetype = thistype;
        }


        //NOTE TO SELF: If you find yourself using this method of making moves, compute the moveDamage with
        // "moveDamage * Trainer.ActivePokemon[0].atk) / 100;" in Battle


        //Water Types Moves
        public static Move AquaTail = new Move("Aqua Tail", 90, Types.Water);
        public static Move Waterfall = new Move("Waterfall", 90, Types.Water);
        public static Move Surf = new Move("Surf", 90, Types.Water);

        //Fire Types Moves
        public static Move Flamethrower = new Move("Flamethrower", 90, Types.Fire);
        public static Move FireFang = new Move("Fire Fang", 65, Types.Fire);

        //Grass Types Moves
        public static Move PetalDance = new Move("Solar Beam", 100, Types.Grass);
        public static Move TropKick = new Move("Trop Kick", 80, Types.Grass);

        //Steel Types Moves
        public static Move IronHead = new Move("Iron Head", 80, Types.Steel);
        public static Move MeteorMash = new Move("Meteor Mash", 90, Types.Steel);

        //Psychic Types Moves
        public static Move Psychic = new Move("Psychic", 90, Types.Psychic);

        //Fairy Types Moves
        public static Move MoonBlast = new Move("Moonblast", 90, Types.Fairy);
        public static Move PlayRough = new Move("Play Rough", 90, Types.Fairy);

        //Dark Types Moves
        public static Move Crunch = new Move("Crunch", 80, Types.Dark);
        public static Move DarkPulse = new Move("Dark Pulse", 80, Types.Dark);

        //Ghost Types Moves
        public static Move ShadowBall = new Move("Shadow Ball", 80, Types.Ghost);
        public static Move PhantomForce = new Move("Phantom Force", 90, Types.Ghost);

        //Ground Types Moves
        public static Move Earthquake = new Move("Earthquake", 100, Types.Ground);

        //Electric Types Moves
        public static Move Thunderbolt = new Move("Thunderbolt", 100, Types.Electric);

        //Dragon Types Moves
        public static Move DragonClaw = new Move("Dragon Claw", 80, Types.Dragon);
        public static Move DragonPulse = new Move("Dragon Pulse", 85, Types.Dragon);

        //Flying Types Moves
        public static Move Fly = new Move("Fly", 90, Types.Flying);
        public static Move BraveBird = new Move("Brave Bird", 100, Types.Flying);

        //Fighting Types Moves
        public static Move CloseCombat = new Move("Close Combat", 100, Types.Fighting);
        public static Move HighJumpKick = new Move("High Jump Kick", 85, Types.Fighting);
        public static Move HammerArm = new Move("Hammer Arm", 100, Types.Fighting);

        //Normal Types Moves
        public static Move BodySlam = new Move("Body Slam", 85, Types.Normal);
        public static Move QuickAttack = new Move("Quick Attack", 40, Types.Normal);

        //Rock Type Moves
        public static Move StoneEdge = new Move("Stone Edge", 100, Types.Rock);


    }



}