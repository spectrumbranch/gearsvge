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

        }
        private void Initialize()
        {
            player = new Player();
        }
        internal void Update(GameTime gameTime)
        {

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

        void walk();
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

        void guard(); //based on baseDefense and armor worn
        void attack();//attack with current weapon.  Based on baseAttack and the weapon used



        //Ability[] abilities;
        //Weapon[] weapon = new Weapon[1]; //check syntax. this is here to give the idea
        //Armor[] armor; //etc
        //Skill[] skills;
        //Item[] items;
        //PlState state; //Hidden, sneaking, compromised etc? This should be able to hold more than one state.  For example, a player can be both hidden as well as compromised
                         //Can also lead into special moves, such as a sneak attack

        internal Player()
        {

        }

    }
}
