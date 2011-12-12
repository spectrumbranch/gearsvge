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



        private bool _playerHasControl;
        private bool _isAlive;
        //private Vector2 _position;

        private string fileloc = @"RadialAssault\spaceship";
        protected override string TextureFileLocation { get { return fileloc; } }

        internal RAPlayer(Vector2 origin, Color color, float rotation, Vector2 imageOrigin/*, string textureFileName*/)
            : base(origin, color, rotation, imageOrigin/*, textureFileName*/) 
        {
            //InitializeLocal(); 
        }

        //internal RAPlayer(Vector2 origin)
        //{
        //
        //}

        public override void onFrame()
        {
            base.onFrame();


        }

        //public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
       // {
        //    base.Update(gameTime);
        //}
    }
}
