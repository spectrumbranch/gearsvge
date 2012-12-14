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
    // Change to Alien and give it a specific type
    sealed internal class EnemyShip : Unit
    {
        //stuff to store outside of the CalculateMovement() function for use.
        private Vector2 originOfCircle = new Vector2(ViewportHandler.GetWidth() / 2, ViewportHandler.GetHeight() / 2);
        private float theta = MathHelper.TwoPi;
        private float imageOffset;
        private float x = 0;
        private float y = 0;
        private float deltaScalar = MathHelper.PiOver4 / 32;
        private float radius;


        private string fileloc = @"RadialAssault\spaceship";
        protected override string TextureFileLocation { get { return fileloc; } }

        //internal EnemyShip() { }
        internal EnemyShip(Vector2 origin, Color color, float rotation, Vector2 imageOrigin/*, string textureFileName*/)
            : base(origin, color, rotation, imageOrigin/*, textureFileName*/) { InitializeLocal(); }

        private void InitializeLocal()
        {
            imageOffset = 196 + this._imageOrigin.Y;
            radius = (ViewportHandler.GetHeight() / 2) + imageOffset;// bad chris
        }

        public override void onUpdate(GameTime gameTime)
        {
            //base.onFrame();
            //AI();
            CalculateMovement();
        }

        private void CalculateMovement()
        {
            
            theta -= deltaScalar; //- is clockwise, + is counterclockwise.

            float sinTheta = (float)Math.Sin(theta);
            float cosTheta = (float)Math.Cos(theta);

            x = imageOffset * sinTheta + originOfCircle.X;
            y = imageOffset * cosTheta + originOfCircle.Y;

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
