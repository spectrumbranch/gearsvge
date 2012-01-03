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
using System.Text;
using Gears.Playable;
using Gears.Cloud;
using Gears.Navigation;

namespace GearsDebug.Playable.RadialAssault
{
    internal sealed class RAPlayer : Player
    {
        private Vector2 originOfCircle = new Vector2(ViewportHandler.GetWidth() / 2, ViewportHandler.GetHeight() / 2);
        private float theta = MathHelper.TwoPi;
        private float imageOffset;
        private float x = 0;
        private float y = 0;
        private float deltaScalar = MathHelper.PiOver4 / 32;
        private float radius;



        private bool _playerHasControl;
        private bool _isAlive;
        //private Vector2 _position;

        private string fileloc = @"RadialAssault\spaceship";
        protected override string TextureFileLocation { get { return fileloc; } }

        internal RAPlayer(Vector2 origin, Color color, float rotation, Vector2 imageOrigin/*, string textureFileName*/)
            : base(origin, color, rotation, imageOrigin/*, textureFileName*/) 
        {
            InitializeLocal(); 
        }

        private void InitializeLocal()
        {
            imageOffset = 196 + this._imageOrigin.Y;
            radius = (ViewportHandler.GetHeight() / 2) + imageOffset;// bad chris
        }       

        public override void onFrame()
        {
            //base.onFrame();
            //CalculateMovement();

            MoveClockwise(); //TODO: Hook this into input instead of doing it automatically.
        }

        internal void MoveClockwise()
        {
            RotateAroundOrigin(true);
        }
        internal void MoveCounterClockwise()
        {
            RotateAroundOrigin(false);
        }

        private void RotateAroundOrigin(bool isClockwise)
        {
            if (isClockwise)
            {
                theta -= deltaScalar; // - is clockwise
                this._rotation += deltaScalar;// + is for clockwise
            }
            else //isCounterClockwise
            {
                theta += deltaScalar; // + is counterclockwise.
                this._rotation -= deltaScalar;// - is for counterclockwise
            }
            float sinTheta = (float)Math.Sin(theta);
            float cosTheta = (float)Math.Cos(theta);

            x = imageOffset * sinTheta + originOfCircle.X;
            y = imageOffset * cosTheta + originOfCircle.Y;

            this._position.X = x;
            this._position.Y = y;
        }
        //public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
       // {
        //    base.Update(gameTime);
        //}
    }
}
