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
    sealed internal class Enemy1 : Unit
    {
        private float gridModifierX = 0; //X position of the image initially --> used to make exact center the "0" origin (adds to slope result)
        private float gridModifierY = 0; //Y position of the image initially --> used to make exact center the "0" origin (adds to slope result)
        private float x = 0;
        private float y = 0;
        private float m = 0; //slope --> hardcoded atm


        private string fileloc = @"Debug\Zone\Unit\Dot\dot";
        protected override string TextureFileLocation { get { return fileloc; } }

        internal Enemy1(Vector2 origin, Color color, float rotation, Vector2 imageOrigin/*, string textureFileName*/)
            : base(origin, color, rotation, imageOrigin/*, textureFileName*/) { InitializeLocal(); }

        private void InitializeLocal()
        {
            gridModifierX = this._position.X;
            gridModifierY = this._position.Y;
        }       

        public override void onUpdate(GameTime gameTime)
        {
            base.onUpdate(gameTime);
            //AI();
            CalculateMovement();
        }

        private void CalculateMovement()
        {
            /* y = mx + b --> slope formula
             * 
             * +x --> rightward movement
             * -x --> leftward movement
             * -m --> upward movement
             * +m --> downward movement
             * 
             * combining the x and m will result in a diagonal movement
             * ie: +x, +m, down-right movement, etc.
             * 
             * 0 slope --> horizonal movement
             */
            
            x += 1;
            y = (float) m * x;

            this._position.X = x + gridModifierX;
            this._position.Y = y + gridModifierY;
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
        }

    }
}
