using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

using Gears.Cloud._Debug;

namespace Gears.Playable.Player
{
    internal class PlayerManager
    {
        private Player player;

        internal PlayerManager()
        {
            Initialize();
        }
        private void Initialize()
        {
            player = new Player();
        }

        internal void Update(GameTime gameTime)
        {
            //check player events from here and execute appropriate handlers   
        }
        internal void Draw(SpriteBatch spriteBatch)
        {

        }
    }
    internal class Player
    {
        bool IsAlive;
        Vector2 position;

        float baseAttack;
        float baseDefense;
        float defenseBonus; //I havent figured how to determine this yet.  This is applied when guarding

        float health; //        life
        float stamina; //       energy: -2 <= stamina <= 2? Might want to work on this range
        float topspeed; //      
        Vector2 velocity;
        Vector2 accel; //         
        float controlradius; // radius that controlled STEVE: wat?

        void controlAccel() //acceleration is based on current stamina
        {
            //the stamina range will allow acceleration to be adjusted based on y = x^3
            //as it approaches 0, the player will continue to lose acceleration.  
            //once it drops below 0, the player will deccelerate until they've returned to walking speed
            //accel.X = stamina * stamina * stamina;
        }

        void walk(){}
        void sprint()
        {
            stamina -= .2f;
            controlAccel();

            velocity.X += accel.X;
            velocity.Y += accel.Y;

            if (velocity.X > topspeed)
            {
                velocity.X = topspeed;
            }

            if (velocity.Y > topspeed)
            {
                velocity.Y = topspeed;
            }
            position.X += velocity.X;
            position.Y += velocity.Y;


        }

        void guard(){} //based on baseDefense, armor worn, and defense mode bonus
        
        
        
        double attack(float opposingDefense)
        {
            //I had some fun with this and did some calculus, rofl...
            /*ok, so explanation...
            attack and defense are modeled by y = sqrt(x)
            y = defense
            x = attack
            Integrate f(x) wrt x from 0 to totalAttack...you get x^(3/2)/(3/2)
            Integrate f(y) wrt y from 0 to totalDefense...you get y^3/3
            Evaluate them and subtract the x integral from the y integral to get your damage.*/

            double def = opposingDefense, atk = baseAttack;

            def = Math.Pow(def, 1.5) / 1.5;
            atk = Math.Pow(atk, 3) / 3;
            return atk - def;

        }



        //Ability[] abilities;
        //Weapon[] weapon = new Weapon[1]; //check syntax. this is here to give the idea
        //Armor[] armor; //etc
        //Skill[] skills;
        //Item[] items;
        //PlState state; //Hidden, sneaking, compromised etc? This should be able to hold more than one state.  For example, a player can be both hidden as well as compromised
                         //Can also lead into special moves, such as a sneak attack
        //Item currentItem; //the item equipped
        //Weapon currentWeapon; //the weapon equipped

        internal Player()
        {

        }

    }
}
