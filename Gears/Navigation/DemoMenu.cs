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
using Gears.Cloud._Debug;

namespace Gears.Navigation
{
    internal sealed class DemoMenu : MenuItem
    {
        public DemoMenu()
        {
            base.SetName("DemoMenu");
            base.SetAction(MenuItemAction.PushState);//

            //?>STACK OVERFLOW. RESTRUCTURE ME!
            base.menu = new GameState[1]; //TODO: MAGIC NUMBER
            base.menu[0] = new MenuUpOneLevel();

            //?>menu is null.
        }
        protected internal override void Draw(SpriteBatch spriteBatch)
        {
            //has not been tested or anything
            base.DrawMenu(spriteBatch);
        }
        protected internal override void Update(GameTime gameTime)
        {
            //nothing established yet
            //INPUT
            base.ProcessKeyboard(gameTime);
        }
    }
    internal sealed class MenuUpOneLevel : MenuItem
    {
        public MenuUpOneLevel()
        {
            base.SetName("BACK");
            base.SetAction(MenuItemAction.PopStack);
        }
        protected internal override void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
        protected internal override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

    }
    internal sealed class DemoUserControl : MenuItem
    {
        public DemoUserControl()
        {

        }
        protected internal override void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
        protected internal override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
