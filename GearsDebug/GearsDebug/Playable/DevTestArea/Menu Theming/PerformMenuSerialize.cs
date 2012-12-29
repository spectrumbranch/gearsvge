using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gears.Navigation;
using Gears.Cloud.Utility;
using Gears.Cloud;
using Microsoft.Xna.Framework;

namespace GearsDebug.Playable.DevTestArea.MenuTheming
{
    internal class PerformMenuSerialize : MenuUserControl
    {
        internal PerformMenuSerialize() : base("SaveMenuElement")
        {

        }

        public override void ThrowPushEvent()
        {
            Menu menu = new Menu();

            MenuElement menuElement = new MenuElement();
            menuElement.SetThrowPushEvent(new Action(() => { Master.Pop(); }));
            menuElement.ActiveArea = new Rectangle(100,200,800,600);
            menuElement.ForegroundColor = Color.Aquamarine;
            menuElement.BackgroundColor = Color.Indigo;

            menu.AddMenuElement(menuElement);

            XMLEngine<Menu>.SaveToFile("testSaveMenu-001.xml", menu);
        }
    }
}
