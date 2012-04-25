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
        private Random rand = new Random();
        private double theta = 0;
        private float speed = 0.1f;
        private Vector2 originalcoord = new Vector2();
       
        

        private string fileloc = @"RadialAssault\straightlinealien";
        protected override string TextureFileLocation { get { return fileloc; } }

        internal StraightLineAlien(Vector2 origin, Color color, float rotation)
            : base(origin, color, rotation)
        {
            theta = 360 * rand.NextDouble();
            this._rotation = (float)(theta + 90);
            originalcoord = base._position;
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
            base._position.X = originalcoord.X + (float)(speed * Math.Cos(theta) - (speed) * Math.Sin(theta));
            base._position.Y = originalcoord.Y + (float)(speed * Math.Sin(theta) + (speed) * Math.Cos(theta));
            speed += 2;
        }

    }
}
