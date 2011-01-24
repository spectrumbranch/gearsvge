using Microsoft.Xna.Framework;

using Gears.Navigation;
using Gears.Cloud._Debug;

namespace GearsDebug
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
