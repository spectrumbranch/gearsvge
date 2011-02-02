using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Gears;
using Gears.Cloud;
using Gears.Navigation;

namespace GearsDebug.Navigation
{
    internal sealed class TestMenuData
    {
        private IMenuItem[] imi;

        private IMenuItem[] submenu;

        internal TestMenuData()
        {
            //create
            imi = new IMenuItem[4];
            submenu = new IMenuItem[1];
            //populate
            imi[0] = new TestPlayState();
            imi[1] = new ViewportHandlerTest();

            //create submenu, populate with menuitems
            submenu[0] = new BackMenuOption();
            Menu testSubMenu = new Menu("Example Submenu", submenu);

            imi[2] = testSubMenu;
            imi[3] = new HardExitGameState();

            //insert into a MenuState
            Menu debugMenu = new Menu("Debugger Menu",imi);
            Master.Push(debugMenu);
        }
    }

    //TODO: Allow more parameters later on down the line.
    /// <summary>
    /// Menu is an instantiable class that allows you to create your own menus!
    /// TODO: Params and constructor doc.
    /// </summary>
    internal sealed class Menu : MenuState
    {
        internal Menu(string menuText, IMenuItem[] menuItemList) : base(menuText, menuItemList) { }
        protected internal override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
        }
        protected internal override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }

    internal sealed class BackMenuOption : MenuUserControl
    {
        internal BackMenuOption() : base("Back") { }
        public override void ThrowPushEvent()
        {
            Master.Pop();
            //base.ThrowPushEvent();
        }
    }
    
}
