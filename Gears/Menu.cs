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

namespace GearsDebug
{
    //TODO: Move this into content-containing class section. 
    //          Menu should belong to Gears.Navigation.MenuEngine.
    internal class MainMenu : GameState
    {
        private bool _init = false; //whether or not this has been initialized

        private SpriteFont menuFont;
        private SpriteFont menuItemFont;

        private Vector2 menuTitlePosition = new Vector2(540, 120);
        private Color menuTitleColor = new Color(255, 255, 255);
        private bool menuTitleToggle = false;

        private Vector2 menuItem1Position = new Vector2(800, 240);
        private Vector2 menuItem2Position = new Vector2(858, 268); //y offset: (16px font + 12px spacing)


        public MainMenu()
        {

        }
        private void Initialize()
        {
            LoadContent();

            _init = true;
        }
        private void LoadContent()
        {
            menuFont = ContentButler.GetGame().Content.Load<SpriteFont>(@"Fonts\MenuFont");
            menuItemFont = ContentButler.GetGame().Content.Load<SpriteFont>(@"Fonts\MenuItem");
        }

        protected internal override void Draw(SpriteBatch spriteBatch)
        {
            if (_init)
            {
                spriteBatch.DrawString(menuFont, "Catalyst", menuTitlePosition, menuTitleColor);
                spriteBatch.DrawString(menuItemFont, "start game", menuItem1Position, Color.WhiteSmoke);
                spriteBatch.DrawString(menuItemFont, "options", menuItem2Position, Color.WhiteSmoke);
            }
        }
        protected internal override void Update(GameTime gameTime)
        {
            if (!_init) // if we haven't yet initialized.
            {
                Initialize();
            }
            else // we have initialized our menu already.
            {
                Update_MenuTitleFontColor();
            }
        }

        private void Update_MenuTitleFontColor()
        {
            if (!menuTitleToggle)
            {
                menuTitleColor.B--;
                menuTitleColor.G--;
                menuTitleColor.R--;
            }
            else
            {
                menuTitleColor.B++;
                menuTitleColor.G++;
                menuTitleColor.R++;
            }

            if (menuTitleColor.R == 0)
            {
                menuTitleToggle = true;
            }
            if (menuTitleColor.R == 255)
            {
                menuTitleToggle = false;
            }
        }
    }
}
