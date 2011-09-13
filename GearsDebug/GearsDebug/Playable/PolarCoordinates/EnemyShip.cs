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
    sealed internal class EnemyShip : Unit
    {
        private string fileloc = @"Debug\Zone\Unit\enemyship";
        protected override string TextureFileLocation { get { return fileloc; } }

        //internal EnemyShip() { }
        internal EnemyShip(Vector2 origin, Color color, float rotation/*, string textureFileName*/)
            : base(origin, color, rotation/*, textureFileName*/) { }

        public override void onFrame()
        {
            base.onFrame();
            //AI();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
        }

    }
}
