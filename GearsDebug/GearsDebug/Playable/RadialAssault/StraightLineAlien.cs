using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gears.Playable;
using Microsoft.Xna.Framework;

namespace GearsDebug.Playable.RadialAssault
{
    sealed class StraightLineAlien : Unit
    {
        //Added the two variables below to determine alien path on spawn
        Random rand = new Random();
        public double theta = 0;
        double t = 0;
     
 
        

        private string fileloc = @"RadialAssault\straightlinealien";
        protected override string TextureFileLocation { get { return fileloc; } }

        private int moveCounter = -150;


        internal StraightLineAlien(Vector2 origin, Color color, float rotation)
            : base(origin, color, rotation)
        {
            theta = 360 * rand.NextDouble();
            this._rotation = (float)(theta + 90);
        }

        //Put all updates for the specific unit in an override update function like so
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        //Controller for onFrame event.
        public override void onFrame()
        {
            Movement();
        }

        //Movement subcontroller
        private void Movement()
        {
            //The following takes the origin coordinates and adds the rotation matrix model to it
            //base._position.X += (float)(t*Math.Cos(theta) - 5*Math.Sin(5*t) * Math.Sin(theta));
            //base._position.Y += (float)(t * Math.Sin(theta) + 5*Math.Sin(5*t) * Math.Cos(theta));

            base._position.X += (float)(t*Math.Cos(theta) -t*Math.Sin(theta));
            base._position.Y += (float)(t * Math.Sin(theta) + t* Math.Cos(theta));
            t += .01;
        }

    }
}
