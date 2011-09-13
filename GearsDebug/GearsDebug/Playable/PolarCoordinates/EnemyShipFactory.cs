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

namespace GearsDebug.Playable.PolarCoordinates
{
    sealed internal class EnemyShipFactory : UnitTypeFactory
    {
        //TEMPORARY
        Vector2 WORMHOLE_COORDINATES = new Vector2(ViewportHandler.GetWidth(), ViewportHandler.GetHeight());
        
        private EnemyShip[] es;

        internal EnemyShipFactory()
        {
            Register();
        }
        private void Register()
        {
            es = new EnemyShip[1];      //hardcode magic

            es[0] = new EnemyShip(WORMHOLE_COORDINATES,Color.Azure,0.0f);    //TODO: fix up constructor.
                                        //note that this constructor is default for testing only. 
                                        //each unit will DEFINITELY have a different constructor.

            base.Register(es);
        }
    }
}
