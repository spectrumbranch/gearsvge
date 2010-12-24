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
        float stamina; //       energy
        float topspeed; //      
        float accel; //         
        float controlradius; // radius that controlled 

        //Ability[] abilities;
        //Weapon[] weapon = new Weapon[1]; //check syntax. this is here to give the idea
        //Armor armor; //etc

        internal Player()
        {

        }

    }
}
