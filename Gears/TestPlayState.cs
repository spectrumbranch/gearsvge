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
    /// <summary>
    /// TestPlayState is for testing via the debugger state menu ONLY.
    /// </summary>
    sealed internal class TestPlayState : GameState
    {
        //temporary and bad name scheme. this zone is for testing via the menu
        public TestZone exampleZone; // a real playstate template would have this setup properly!!!

        public TestPlayState()
        {
            base.SetName("TestPlayState");

            Initialize();
        }

        private void Initialize()
        {
            //example
            exampleZone = new TestZone();
        }
        protected internal override void Update(GameTime gameTime)
        {
            exampleZone.Update(gameTime);
        }
        protected internal override void Draw(SpriteBatch spriteBatch)
        {
            exampleZone.Draw(spriteBatch);
        }
    }
}
