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
            MenuElement menuElement = new MenuElement();
            menuElement.SetThrowPushEvent(new Action(() => { Master.Pop(); }));
            menuElement.ActiveArea = new Rectangle(100,200,800,600);
            menuElement.ForegroundColor = Color.Aquamarine;
            menuElement.BackgroundColor = Color.Indigo;

            XMLEngine<MenuElement>.SaveToFile("testSaveMenuElement-001.xml", menuElement);
        }
    }
}
