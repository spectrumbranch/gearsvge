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

using GearsDebug;
using Gears.Cloud._Debug;

namespace Gears.Navigation
{
    //becoming deprecated
    class DebugMenu : MenuEngine
    {
        private bool _init = false; //whether or not this has been initialized

        OLD_MenuItem[] debugMenuItemList;
        
        //WORK NEEDS DONE TO MAKE IT PROPERLY POLYMORPHIC
        public DebugMenu(OLD_MenuItem[] menuItemList) : base(menuItemList)
        {
            Debug.Out("DebugMenu Constructor");
            Initialize();
        }
        private void Initialize()
        {
            ////LoadContent();
            //base.Initialize(debugMenuItemList);
            _init = true;
        }
        protected internal override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            if (_init)
            {
                //spriteBatch.DrawString(menuFont, "Catalyst", menuTitlePosition, menuTitleColor);
                //spriteBatch.DrawString(menuItemFont, "start game", menuItem1Position, Color.WhiteSmoke);
                //spriteBatch.DrawString(menuItemFont, "options", menuItem2Position, Color.WhiteSmoke);
            }
            //base.Draw(spriteBatch);
        }
        protected internal override void Update(GameTime gameTime)
        {
            if (!_init) // if we haven't yet initialized.
            {
                Initialize();
            }
            else // we have initialized our menu already.
            {
                //
            }
            //base.Update(gameTime);
        }
    }
}
