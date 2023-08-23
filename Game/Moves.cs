
namespace PokemonGame
{

    public class Move
    {

        public string moveName;
        public int moveBasePower;
        public string attackType;
        public Types movetype;
        public Move(string move, int power, string thisatktype, Types thistype)
        {
            this.moveName = move;
            this.moveBasePower = power;
            this.attackType = thisatktype;
            this.movetype = thistype;
        }


        //NOTE TO SELF: If you find yourself using this method of making moves, compute the moveDamage with
        // "moveDamage * Trainer.ActivePokemon[0].atk) / 100;" in Battle


        //Water Types Moves
        public static Move HydroPump = new Move("Hydro Pump", 100, "Special", Types.Water);
        public static Move AquaTail = new Move("Aqua Tail", 90, "Physical", Types.Water);
        public static Move Waterfall = new Move("Waterfall", 80, "Physical", Types.Water);
        public static Move Surf = new Move("Surf", 90, "Special", Types.Water);
        public static Move WaterPulse = new Move("Water Pulse", 60, "Special", Types.Water);
        public static Move WaterShuriken = new Move("Water Shuriken", 60, "Special", Types.Water);
        public static Move WaterGun = new Move("Water Gun", 40, "Special", Types.Water);

        //Fire "Physical", Types Moves
        public static Move FireBlast = new Move("Fire Blast", 100, "Special", Types.Fire);
        public static Move Flamethrower = new Move("Flamethrower", 90, "Special", Types.Fire);
        public static Move FireFang = new Move("Fire Fang", 65, "Physical", Types.Fire);
        public static Move Ember = new Move("Ember", 40, "Special", Types.Fire);

        //Grass "Physical", Types Moves
        public static Move PetalDance = new Move("Petal Dance", 100, "Physical", Types.Grass);
        public static Move SolarBeam = new Move("Solar Beam", 100, "Special", Types.Grass);
        public static Move LeafBlade = new Move("Leaf Blade", 90, "Physical", Types.Grass);
        public static Move EnergyBall = new Move("Energy Ball", 90, "Special", Types.Grass);
        public static Move TropKick = new Move("Trop Kick", 80, "Physical", Types.Grass);
        public static Move RazorLeaf = new Move("Razor Leaf", 55, "Physical", Types.Grass);

        //Steel "Physical", Types Moves
        public static Move IronTail = new Move("Iron Tail", 100, "Physical", Types.Steel);
        public static Move MeteorMash = new Move("Meteor Mash", 90, "Physical", Types.Steel);
        public static Move IronHead = new Move("Iron Head", 80, "Physical", Types.Steel);
        public static Move FlashCannon = new Move("Flash Cannon", 80, "Special", Types.Steel);
        public static Move HeavySlam = new Move("Heavy Slam", 80, "Physical", Types.Steel);
        public static Move MetalClaw = new Move("Metal Claw", 50, "Physical", Types.Steel);

        //Psychic "Physical", Types Moves
        public static Move Psychic = new Move("Psychic", 90, "Special", Types.Psychic);
        public static Move ZenHeadbutt = new Move("Zen Headbutt", 80, "Physical", Types.Psychic);
        public static Move PsychoCut = new Move("Psycho Cut", 70, "Physical", Types.Psychic);
        public static Move Psybeam = new Move("Psybeam", 65, "Special", Types.Psychic);
        public static Move Confusion = new Move("Confusion", 50, "Special", Types.Psychic);

        //Fairy "Physical", Types Moves
        public static Move MoonBlast = new Move("Moonblast", 90, "Special", Types.Fairy);
        public static Move PlayRough = new Move("Play Rough", 90, "Physical", Types.Fairy);
        public static Move DazzlingGleam = new Move("Dazzling Gleam", 80, "Special", Types.Fairy);
        public static Move DisarmingVoice = new Move("Disarming Voice", 40, "Special", Types.Fairy);

        //Dark Type Moves
        public static Move Crunch = new Move("Crunch", 80, "Physical", Types.Dark);
        public static Move DarkPulse = new Move("Dark Pulse", 80, "Special", Types.Dark);
        public static Move NightSlash = new Move("Night Slash", 70, "Physical", Types.Dark);
        public static Move SuckerPunch = new Move("Sucker Punch", 70, "Physical", Types.Dark);
        public static Move Bite = new Move("Bite", 60, "Physical", Types.Dark);
        public static Move FaintAttack = new Move("Faint Attack", 60, "Physical", Types.Dark);

        //Ghost Type Moves
        public static Move PhantomForce = new Move("Phantom Force", 90, "Physical", Types.Ghost);
        public static Move ShadowBall = new Move("Shadow Ball", 80, "Special", Types.Ghost);
        public static Move NightShade = new Move("Night Shade", 55, "Special", Types.none);
        public static Move ShadowPunch = new Move("Shadow Punch", 60, "Physical", Types.Ghost);

        //Poison Type Moves
        public static Move SludgeBomb = new Move("Sludge Bomb", 90, "Special", Types.Poison);
        public static Move PoisonJab = new Move("Poison Jab", 80, "Physical", Types.Poison);

        //Bug Type Moves
        public static Move BugBuzz = new Move("Bug Buzz", 90, "Special", Types.Bug);
        
        //Ground Type Moves
        public static Move Earthquake = new Move("Earthquake", 100, "Physical", Types.Ground);
        public static Move Bulldoze = new Move("Earthquake", 60, "Physical", Types.Ground);
        public static Move MudShot = new Move("Mud Shot", 55, "Special", Types.Ground);
        public static Move SandTomb = new Move("SandTomb", 35, "Physical", Types.Ground);
        public static Move MudSlap = new Move("Mud Slap", 30, "Physical", Types.Ground);

        //Electric Type Moves
        public static Move Thunderbolt = new Move("Thunderbolt", 90, "Special", Types.Electric);
        public static Move WildCharge = new Move("Wild Charge", 80, "Physical", Types.Electric);
        public static Move Discharge = new Move("Discharge", 80, "Special", Types.Electric);
        public static Move Spark = new Move("Spark", 65, "Physical", Types.Electric);

        //Dragon "Physical", Types Moves
        public static Move Outrage = new Move("Outrage", 90, "Physical", Types.Dragon);
        public static Move DragonClaw = new Move("Dragon Claw", 80, "Physical", Types.Dragon);
        public static Move DragonTail = new Move("Dragon Tail", 70, "Physical", Types.Dragon);
        public static Move DragonBreath = new Move("Dragon Breath", 60, "Special", Types.Dragon);

        //Flying "Physical", Types Moves
        public static Move Hurricane = new Move("Hurricane", 110, "Special", Types.Flying);
        public static Move BraveBird = new Move("Brave Bird", 100, "Physical", Types.Flying);
        public static Move Fly = new Move("Fly", 90, "Physical", Types.Flying);
        public static Move AerialAce = new Move("Aerial Ace", 60, "Physical", Types.Flying);
        public static Move WingAttack = new Move("Wing Attack", 60, "Physical", Types.Flying);
        public static Move Peck = new Move("Peck", 35, "Physical", Types.Flying);

        //Fighting "Physical", Types Moves
        public static Move CloseCombat = new Move("Close Combat", 100, "Physical", Types.Fighting);
        public static Move HammerArm = new Move("Hammer Arm", 100, "Physical", Types.Fighting);
        public static Move CrossChop = new Move("CrossChop", 100, "Physical", Types.Fighting);
        public static Move HighJumpKick = new Move("High Jump Kick", 90, "Physical", Types.Fighting);
        public static Move AuraSphere = new Move("Aura Sphere", 80, "Special", Types.Fighting);
        public static Move Submission = new Move("Submission", 75, "Physical", Types.Fighting);
        public static Move DoubleKick = new Move("Double Kick", 60, "Physical", Types.Fighting);
        public static Move ForcePalm = new Move("Force Palm", 60, "Physical", Types.Fighting);
        public static Move KarateChop = new Move("Karate Chop", 50, "Physical", Types.Fighting);

        //Normal "Physical", Types Moves
        public static Move DoubleEdge = new Move("Double Edge", 100, "Physical", Types.Normal);
        public static Move BodySlam = new Move("Body Slam", 85, "Physical", Types.Normal);
        public static Move Extremespeed = new Move("Extremespeed", 80, "Physical", Types.Normal);
        public static Move Slam = new Move("Slam", 80, "Physical", Types.Normal);
        public static Move TakeDown = new Move("Take Down", 75, "Physical", Types.Normal);
        public static Move Slash = new Move("Slash", 70, "Physical", Types.Normal);
        public static Move Stomp = new Move("Stomp", 65, "Physical", Types.Normal);
        public static Move QuickAttack = new Move("Quick Attack", 40, "Physical", Types.Normal);
        public static Move Pound = new Move("Pound", 40, "Physical", Types.Normal);
        public static Move Tackle = new Move("Tackle", 40, "Physical", Types.Normal);
        public static Move Scratch = new Move("Scratch", 40, "Physical", Types.Normal);
        public static Move Flail = new Move("Flail", 80, "Physical", Types.Normal);

        //Rock Type Moves
        public static Move StoneEdge = new Move("Stone Edge", 100, "Physical", Types.Rock);
        public static Move RockSlide = new Move("Rock Slide", 75, "Physical", Types.Rock);
        public static Move RockThrow = new Move("Rock Throw", 50, "Physical", Types.Rock);


    }



}