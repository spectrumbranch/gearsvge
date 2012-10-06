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
    sealed internal class SineAlienFactory : UnitTypeFactory
    {
        //TEMPORARY
        private Vector2 WORMHOLE_COORDINATES = new Vector2(ViewportHandler.GetWidth() / 2, ViewportHandler.GetHeight() / 2);
        private Vector2 PLAYER_STARTING_LOCATION;//move to playermanager
        private Vector2 PLAYER_IMAGE_ORIGIN = new Vector2(32, 32);//hardcoded, bad chris
        private Vector2 originOfCircle = new Vector2(ViewportHandler.GetWidth() / 2, ViewportHandler.GetHeight() / 2);

        private List<Unit> _enemies = new List<Unit>();
        //private SineAlien[] enemies;

        internal SineAlienFactory()
        {
            //PLAYER_STARTING_LOCATION = new Vector2(WORMHOLE_COORDINATES.X, 1); //hardcode magic
            PLAYER_STARTING_LOCATION = new Vector2(WORMHOLE_COORDINATES.X, WORMHOLE_COORDINATES.Y + (196 + PLAYER_IMAGE_ORIGIN.Y)); //hardcode magic
            Register();
        }
        private void Register()
        {
            base.Register(_enemies);
        }
        public void Spawn()
        {
            _enemies.Add(new SineAlien(originOfCircle, Color.White, 0.0f));
            Register();
        }
    }
}
