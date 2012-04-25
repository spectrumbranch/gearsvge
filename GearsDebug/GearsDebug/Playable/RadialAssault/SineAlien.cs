using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gears.Playable;
using Microsoft.Xna.Framework;

namespace GearsDebug.Playable.RadialAssault
{
    //Migrated from MattUnit. Need to cleanup
    sealed class SineAlien : Unit
    {
        //Added the two variables below to determine alien path on spawn
        private Random rand = new Random();
        private double theta = 0;
        private float yAmplitude = 100.0f;
        private float frequency = 0.03f;
        private float speed = 0.1f;

       // private float phasor = 0.0f;

        private Vector2 originalcoord = new Vector2();
       
     

        private string fileloc = @"RadialAssault\sinealien";
        protected override string TextureFileLocation { get { return fileloc; } }

        internal SineAlien(Vector2 origin, Color color, float rotation)
            : base(origin, color, rotation)
        {
            theta = 360 * rand.NextDouble();
            this._rotation = (float)(theta + 90);
            originalcoord = base._position;
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
           
            float phasor = speed* frequency;

            base._position.X = originalcoord.X + (float)(speed * Math.Cos(theta) - (yAmplitude * Math.Sin(phasor)) * Math.Sin(theta));
            base._position.Y = originalcoord.Y + (float)(speed * Math.Sin(theta) + (yAmplitude * Math.Sin(phasor)) * Math.Cos(theta));                

            speed += 1.8f;
            
            //phasor += 0.1f;
        }

    }
}
