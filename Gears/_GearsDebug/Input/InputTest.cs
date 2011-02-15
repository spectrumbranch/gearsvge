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

using Gears.Navigation;
using Gears.Cloud;

namespace GearsDebug
{
    /// <summary>
    /// ViewportHandlerTest is for testing via the debugger state menu ONLY.
    /// </summary>
    internal sealed class InputTest : GameState, IMenuItem
    {
        
        private Vector2 coords = new Vector2(0,0);
        private static SpriteFont menuItemFont;
        private string menuText;

        public string MenuText
        {
            get { return menuText; }
            set
            {
                //15 chars or less to fit release 2 of menu implementation
                if (value.Length <= 15)
                {
                    menuText = value;
                }
                else
                {
                    //do nothing currently
                }
            }
        }
        public InputTest()
        {
            MenuText = "Input";
            Initialize();
        }
        private void Initialize()
        {
            menuItemFont = ContentButler.GetGame().Content.Load<SpriteFont>(@"Fonts\MenuItem");
            KeyboardInput.keyDown += new KeyboardInput.KeyStateEvent(KeyDown);
        }
        protected internal override void Update(GameTime gameTime)
        {
            KeyboardInput.UpdateInput();
        }
        protected internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(menuItemFont, "Character", coords, Color.White);
        }

        internal void KeyDown(Keys key)
        {
            switch (key)
            {
                case Keys.Down:
                    coords.Y++;
                    break;
                case Keys.Up:
                    coords.Y--;
                    break;
                case Keys.Left:
                    coords.X--;
                    break;
                case Keys.Right:
                    coords.X++;
                    break;
            }
        }

        public void ThrowPushEvent()
        {

        }
    }
}