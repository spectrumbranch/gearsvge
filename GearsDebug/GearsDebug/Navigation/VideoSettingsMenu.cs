using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gears.Navigation;
using Microsoft.Xna.Framework;
using Gears.Cloud;

namespace GearsDebug.Navigation
{
    internal sealed class VideoSettingsMenu : Menu
    {
        private Menu menu = new Menu();

        public VideoSettingsMenu()
        {
            MenuElement titleMenuElement = new MenuElement();
            titleMenuElement.MenuText = "Video Settings";
            titleMenuElement.Selectable = false;
            titleMenuElement.Hidden = false;
            titleMenuElement.ActiveArea = new Rectangle(85, 30, 600, 100);
            titleMenuElement.ForegroundColor = new Color(225, 225, 225);
            titleMenuElement.SpriteFont = @"Fonts\MenuFont";



            MenuElement setResolutionMenuElement = new MenuElement();
            setResolutionMenuElement.SetThrowPushEvent(new Action(() => 
            {
                //Master.Pop();
            }));
            setResolutionMenuElement.ActiveArea = new Rectangle(35, 134, 200, 40);
            setResolutionMenuElement.ForegroundColor = new Color(225, 225, 225);
            setResolutionMenuElement.ActiveForegroundColor = new Color(200, 125, 125);
            setResolutionMenuElement.MenuText = "Set Resolution";
            setResolutionMenuElement.Selectable = true;
            setResolutionMenuElement.Hidden = false;
            setResolutionMenuElement.SpriteFont = @"Fonts\MenuItem";



            MenuElement backMenuElement = new MenuElement();
            backMenuElement.SetThrowPushEvent(new Action(() => { Master.Pop(); }));
            backMenuElement.ActiveArea = new Rectangle(35, 180, 200, 40);
            backMenuElement.ForegroundColor =  new Color(225, 225, 225);
            backMenuElement.ActiveForegroundColor = new Color(200, 125, 125);
            backMenuElement.MenuText = "Back";
            backMenuElement.Selectable = true;
            backMenuElement.Hidden = false;
            backMenuElement.SpriteFont = @"Fonts\MenuItem";




            List<MenuElement> menuElements = new List<MenuElement>();
            menuElements.Add(titleMenuElement);
            menuElements.Add(setResolutionMenuElement);
            menuElements.Add(backMenuElement);

            menu.AddMenuElements(menuElements);
        }

        public Menu GetMenu()
        {
            return this.menu;
        }
    }
}
