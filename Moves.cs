
namespace PokemonGame
{

    public class Move
    {

        public string moveName;
        public int moveBasePower;
        public Types movetype;

        public Move(string move, int power, Types thistype)
        {

            this.moveName = move;
            this.moveBasePower = power;
            this.movetype = thistype;
        }


        //NOTE TO SELF: If you find yourself using this method of making moves, compute the moveDamage with
        // "moveDamage * Trainer.ActivePokemon[0].atk) / 100;" in Battle


        //Water Types Moves
        public static Move HydroPump = new Move("Hydro Pump", 100, Types.Water);
        public static Move AquaTail = new Move("Aqua Tail", 90, Types.Water);
        public static Move Waterfall = new Move("Waterfall", 80, Types.Water);
        public static Move Surf = new Move("Surf", 90, Types.Water);
        public static Move WaterPulse = new Move("Water Pulse", 60, Types.Water);
        public static Move WaterShuriken = new Move("Water Shuriken", 60, Types.Water);
        public static Move WaterGun = new Move("Water Gun", 40, Types.Water);

        //Fire Types Moves
        public static Move FireBlast = new Move("Fire Blast", 100, Types.Fire);
        public static Move Flamethrower = new Move("Flamethrower", 90, Types.Fire);
        public static Move FireFang = new Move("Fire Fang", 65, Types.Fire);
        public static Move Ember = new Move("Ember", 40, Types.Fire);

        //Grass Types Moves
        public static Move PetalDance = new Move("Petal Dance", 100, Types.Grass);
        public static Move SolarBeam = new Move("Solar Beam", 100, Types.Grass);
        public static Move LeafBlade = new Move("Leaf Blade", 90, Types.Grass);
        public static Move EnergyBall = new Move("Energy Ball", 90, Types.Grass);
        public static Move TropKick = new Move("Trop Kick", 80, Types.Grass);
        public static Move RazorLeaf = new Move("Razor Leaf", 55, Types.Grass);

        //Steel Types Moves
        public static Move IronTail = new Move("Iron Tail", 100, Types.Steel);
        public static Move MeteorMash = new Move("Meteor Mash", 90, Types.Steel);
        public static Move IronHead = new Move("Iron Head", 80, Types.Steel);
        public static Move FlashCannon = new Move("Flash Cannon", 80, Types.Steel);
        public static Move HeavySlam = new Move("Heavy Slam", 80, Types.Steel);
        public static Move MetalClaw = new Move("Metal Claw", 50, Types.Steel);

        //Psychic Types Moves
        public static Move Psychic = new Move("Psychic", 90, Types.Psychic);
        public static Move ZenHeadbutt = new Move("Zen Headbutt", 80, Types.Psychic);
        public static Move PsychoCut = new Move("Psycho Cut", 70, Types.Psychic);
        public static Move Psybeam = new Move("Psybeam", 65, Types.Psychic);
        public static Move Confusion = new Move("Confusion", 50, Types.Psychic);

        //Fairy Types Moves
        public static Move MoonBlast = new Move("Moonblast", 90, Types.Fairy);
        public static Move PlayRough = new Move("Play Rough", 90, Types.Fairy);
        public static Move DazzlingGleam = new Move("Dazzling Gleam", 80, Types.Fairy);
        public static Move DisarmingVoice = new Move("Disarming Voice", 40, Types.Fairy);

        //Dark Type Moves
        public static Move Crunch = new Move("Crunch", 80, Types.Dark);
        public static Move DarkPulse = new Move("Dark Pulse", 80, Types.Dark);
        public static Move NightSlash = new Move("Night Slash", 70, Types.Dark);
        public static Move SuckerPunch = new Move("Sucker Punch", 70, Types.Dark);
        public static Move Bite = new Move("Bite", 60, Types.Dark);
        public static Move FaintAttack = new Move("Faint Attack", 60, Types.Dark);

        //Ghost Type Moves
        public static Move PhantomForce = new Move("Phantom Force", 90, Types.Ghost);
        public static Move ShadowBall = new Move("Shadow Ball", 80, Types.Ghost);
        public static Move NightShade = new Move("Night Shade", 55, Types.none);
        public static Move ShadowPunch = new Move("Shadow Punch", 60, Types.Ghost);

        //Poison Type Moves
        public static Move SludgeBomb = new Move("Sludge Bomb", 90, Types.Poison);
        public static Move PoisonJab = new Move("Poison Jab", 80, Types.Poison);

        //Bug Type Moves
        public static Move BugBuzz = new Move("Bug Buzz", 90, Types.Bug);
        
        //Ground Type Moves
        public static Move Earthquake = new Move("Earthquake", 100, Types.Ground);
        public static Move Bulldoze = new Move("Earthquake", 60, Types.Ground);
        public static Move MudShot = new Move("Mud Shot", 55, Types.Ground);
        public static Move SandTomb = new Move("SandTomb", 35, Types.Ground);
        public static Move MudSlap = new Move("Mud Slap", 30, Types.Ground);

        //Electric Type Moves
        public static Move Thunderbolt = new Move("Thunderbolt", 90, Types.Electric);
        public static Move WildCharge = new Move("Wild Charge", 80, Types.Electric);
        public static Move Discharge = new Move("Discharge", 80, Types.Electric);
        public static Move Spark = new Move("Spark", 65, Types.Electric);

        //Dragon Types Moves
        public static Move Outrage = new Move("Outrage", 90, Types.Dragon);
        public static Move DragonClaw = new Move("Dragon Claw", 80, Types.Dragon);
        public static Move DragonTail = new Move("Dragon Tail", 70, Types.Dragon);
        public static Move DragonBreath = new Move("Dragon Breath", 60, Types.Dragon);

        //Flying Types Moves
        public static Move Hurricane = new Move("Hurricane", 110, Types.Flying);
        public static Move BraveBird = new Move("Brave Bird", 100, Types.Flying);
        public static Move Fly = new Move("Fly", 90, Types.Flying);
        public static Move AerialAce = new Move("Aerial Ace", 60, Types.Flying);
        public static Move WingAttack = new Move("Wing Attack", 60, Types.Flying);
        public static Move Peck = new Move("Peck", 35, Types.Flying);

        //Fighting Types Moves
        public static Move CloseCombat = new Move("Close Combat", 100, Types.Fighting);
        public static Move HammerArm = new Move("Hammer Arm", 100, Types.Fighting);
        public static Move CrossChop = new Move("CrossChop", 100, Types.Fighting);
        public static Move HighJumpKick = new Move("High Jump Kick", 90, Types.Fighting);
        public static Move AuraSphere = new Move("Aura Sphere", 80, Types.Fighting);
        public static Move Submission = new Move("Submission", 75, Types.Fighting);
        public static Move DoubleKick = new Move("Double Kick", 60, Types.Fighting);
        public static Move ForcePalm = new Move("Force Palm", 60, Types.Fighting);
        public static Move KarateChop = new Move("Karate Chop", 50, Types.Fighting);

        //Normal Types Moves
        public static Move DoubleEdge = new Move("Double Edge", 100, Types.Normal);
        public static Move BodySlam = new Move("Body Slam", 85, Types.Normal);
        public static Move Extremespeed = new Move("Extremespeed", 80, Types.Normal);
        public static Move Slam = new Move("Slam", 80, Types.Normal);
        public static Move TakeDown = new Move("Take Down", 75, Types.Normal);
        public static Move Slash = new Move("Slash", 70, Types.Normal);
        public static Move Stomp = new Move("Stomp", 65, Types.Normal);
        public static Move QuickAttack = new Move("Quick Attack", 40, Types.Normal);
        public static Move Pound = new Move("Pound", 40, Types.Normal);
        public static Move Tackle = new Move("Tackle", 40, Types.Normal);
        public static Move Scratch = new Move("Scratch", 40, Types.Normal);
        public static Move Flail = new Move("Flail", 80, Types.Normal);

        //Rock Type Moves
        public static Move StoneEdge = new Move("Stone Edge", 100, Types.Rock);
        public static Move RockSlide = new Move("Rock Slide", 75, Types.Rock);
        public static Move RockThrow = new Move("Rock Throw", 50, Types.Rock);


    }



}