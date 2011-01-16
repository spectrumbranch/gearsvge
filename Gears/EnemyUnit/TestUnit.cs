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

namespace GearsDebug
{
    sealed internal class TestUnit : Unit
    {
        private string fileloc = @"Debug\Zone\Unit\example";
        protected internal override string TextureFileLocation { get { return fileloc; } }

        private int moveCounter = -150;

        internal TestUnit()
            : base() { }
        internal TestUnit(Vector2 origin, Color color, float rotation, string textureFileName)
            : base(origin, color, rotation, textureFileName) { }

        //Put all updates for the specific unit in an override update function like so
        internal override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        //Controller for onFrame event.
        internal override void onFrame()
        {
            base.onFrame(); //necessary?
            Movement();
        }

        //Movement subcontroller
        private void Movement()
        {
            
            //this is just an example.
            if ((moveCounter >= 0 && moveCounter < 100) || moveCounter < 0)
            {
                base._position.X++;
                base._position.Y++;
            }
            else if (moveCounter >= 100 && moveCounter < 200)
            {
                base._position.X++;
                base._position.Y--;
            }
            else if (moveCounter >= 200 && moveCounter < 300)
            {
                base._position.X--;
                base._position.Y--;
            }
            else if (moveCounter >= 300 && moveCounter < 400)
            {
                base._position.X--;
                base._position.Y++;
            }
            if (moveCounter != 400)
            {
                moveCounter++;
            }
            else
            {
                moveCounter = 0;
            }
        }

    }
}
