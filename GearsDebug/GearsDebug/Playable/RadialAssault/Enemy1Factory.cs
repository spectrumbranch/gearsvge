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

using Gears.Cloud;
using Gears.Navigation;
using Gears.Playable;

namespace GearsDebug.Playable.RadialAssault
{
    sealed internal class Enemy1Factory : UnitTypeFactory
    {
        //TEMPORARY
        Vector2 WORMHOLE_COORDINATES = new Vector2(ViewportHandler.GetWidth()/2, ViewportHandler.GetHeight()/2);
        Vector2 ENEMY_STARTING_LOCATION;//move to unitmanager
        Vector2 ENEMY_IMAGE_ORIGIN = new Vector2(32,32);//hardcoded
        
        private Enemy1[] es; 

        internal Enemy1Factory()
        {
            ENEMY_STARTING_LOCATION = new Vector2(WORMHOLE_COORDINATES.X, WORMHOLE_COORDINATES.Y); //hardcode magic
            Register();
        }
        private void Register()
        {
            es = new Enemy1[1];      //hardcode magic

             es[0] = new Enemy1(ENEMY_STARTING_LOCATION, Color.Azure, 0.0f, ENEMY_IMAGE_ORIGIN);    //TODO: fix up constructor.
                                        //note that this constructor is default for testing only. 
                                        //each unit will DEFINITELY have a different constructor.

            base.Register(es);
        }
    }
}
