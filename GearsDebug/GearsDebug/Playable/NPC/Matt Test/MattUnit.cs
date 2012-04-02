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

namespace GearsDebug.Playable.Matt
{
    sealed internal class MattUnit : Unit
    {
        //Added the two variables below to determine alien path on spawn
        Random rand = new Random();
        public double theta = 0;
        double t = 0;
     
 
        

        private string fileloc = @"RadialAssault\spaceship";
        protected override string TextureFileLocation { get { return fileloc; } }

        private int moveCounter = -150;
        
      
        internal MattUnit(Vector2 origin, Color color, float rotation, string textureFileName)
            : base(origin, color, rotation/*, textureFileName*/) 
        {
            theta = 360 * rand.NextDouble();
            this._rotation = (float)(theta+90);
        }

        //Put all updates for the specific unit in an override update function like so
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        //Controller for onFrame event.
        public override void onFrame()
        {
            //base.onFrame(); //necessary? Steve: For now, no.  If base.onFrame() ends up having functionality in the future, then yes.
            Movement();
        }

        //Movement subcontroller
        private void Movement()
        {
            //The following takes the origin coordinates and adds the rotation matrix model to it
            base._position.X += (float)(t*Math.Cos(theta) - 5*Math.Sin(5*t)*Math.Sin(theta));
            base._position.Y += (float)(t * Math.Sin(theta) + 5*Math.Sin(5*t) * Math.Cos(theta));
            t += .01;
            #region
            //this is just an example.

            /*if ((moveCounter >= 0 && moveCounter < 100) || moveCounter < 0)
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
            }*/
            #endregion
        }

    }
}
