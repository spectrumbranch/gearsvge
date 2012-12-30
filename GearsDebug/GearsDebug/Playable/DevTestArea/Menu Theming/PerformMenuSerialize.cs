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
        internal PerformMenuSerialize() : base("SaveMenuElement") { }

        public override void ThrowPushEvent()
        {
            Menu menu = new Menu();

            MenuElement backMenuElement = new MenuElement();
            backMenuElement.SetThrowPushEvent(new Action(() => { Master.Pop(); }));
            backMenuElement.ActiveArea = new Rectangle(100,200,300,100);
            backMenuElement.ForegroundColor = Color.Aquamarine;
            backMenuElement.BackgroundColor = Color.Indigo;
            backMenuElement.MenuText = "Back";
            backMenuElement.Selectable = true;
            backMenuElement.Hidden = false;
            backMenuElement.SpriteFont = @"Fonts\MenuItem";

            MenuElement exitMenuElement = new MenuElement();
            exitMenuElement.SetThrowPushEvent(new Action(() => { Master.GetGame().Exit(); }));
            exitMenuElement.ActiveArea = new Rectangle(100, 450, 300, 100);
            exitMenuElement.ForegroundColor = Color.Azure;
            exitMenuElement.ActiveForegroundColor = Color.Gold;
            exitMenuElement.BackgroundColor = Color.AntiqueWhite;
            exitMenuElement.ActiveBackgroundColor = Color.LightCyan;
            exitMenuElement.Hidden = false;
            exitMenuElement.MenuText = "Exit Game";
            exitMenuElement.Selectable = true;
            exitMenuElement.SpriteFont = @"Fonts\MenuItem";
            exitMenuElement.Texture2D = @"Debug\Collision\collisionUnitA";


            List<MenuElement> menuElements = new List<MenuElement>();

            menuElements.Add(backMenuElement);
            menuElements.Add(exitMenuElement);

            menu.AddMenuElements(menuElements);

            XMLEngine<Menu>.SaveToFile("testSaveMenu-001.xml", menu);
        }
    }
}
