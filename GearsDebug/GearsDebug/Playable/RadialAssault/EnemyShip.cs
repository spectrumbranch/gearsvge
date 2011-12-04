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
    sealed internal class EnemyShip : Unit
    {
        private float theta = MathHelper.TwoPi;

        private string fileloc = @"RadialAssault\spaceship";
        protected override string TextureFileLocation { get { return fileloc; } }

        //internal EnemyShip() { }
        internal EnemyShip(Vector2 origin, Color color, float rotation, Vector2 imageOrigin/*, string textureFileName*/)
            : base(origin, color, rotation, imageOrigin/*, textureFileName*/) { }

        public override void onFrame()
        {
            base.onFrame();
            //AI();
            CalculateMovement();
        }

        private void CalculateMovement()
        {
            //this._position;
            Vector2 originOfCircle = new Vector2(ViewportHandler.GetWidth() / 2, ViewportHandler.GetHeight() / 2);
            float imageOffset = 196 + this._imageOrigin.Y;
            float radius = (ViewportHandler.GetHeight() / 2) + imageOffset;// bad chris
            //float theta = MathHelper.PiOver2;

            float deltaScalar = MathHelper.PiOver4 / 32;
            theta -= deltaScalar;


            float x = 0;
            float y = 0;

            float cachedSinTheta = (float)Math.Sin(theta);
            float cachedCosTheta = (float)Math.Cos(theta);

            x = imageOffset * cachedSinTheta + originOfCircle.X;
            y = imageOffset * cachedCosTheta + originOfCircle.Y;


            this._position.X = x;
            this._position.Y = y;

            this._rotation += deltaScalar;
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
        }

    }
}
