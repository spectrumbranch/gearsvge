using Gears.Cloud;
using Gears.Navigation;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace GearsDebug.Navigation
{
    internal sealed class DebugMenu
    {
        //Main debug menu
        //private List<IMenuItem> imi = new List<IMenuItem>();

        //Menus themselves
        private TestsMenu tests = new TestsMenu();
        private DevelopmentMenu development = new DevelopmentMenu();

        internal DebugMenu()
        {
            //This is the low-level version of doing this.
            //Essentially, you have to do all the work, but it is highly customizable.
            Menu newDebugMenu = new Menu();

            MenuElement titleMenuElement = new MenuElement();
            titleMenuElement.MenuText = "Debugger Menu";
            titleMenuElement.Selectable = false;
            titleMenuElement.Hidden = false;
            titleMenuElement.ActiveArea = new Rectangle(85, 30, 600, 100);
            titleMenuElement.ForegroundColor = new Color(225, 225, 225);
            titleMenuElement.SpriteFont = @"Fonts\MenuFont";

            MenuElement developmentProxyMenuElement = new MenuElement();
            developmentProxyMenuElement.MenuText = "Development Menu";
            developmentProxyMenuElement.Selectable = true;
            developmentProxyMenuElement.Hidden = false;
            developmentProxyMenuElement.ActiveArea = new Rectangle(35, 134, 200, 40);
            developmentProxyMenuElement.ForegroundColor = new Color(225,225,225);
            developmentProxyMenuElement.ActiveForegroundColor = new Color(200, 125, 125);
            developmentProxyMenuElement.SpriteFont = @"Fonts\MenuItem";
            developmentProxyMenuElement.SetThrowPushEvent(new System.Action(() => { Master.Push(development.GetMenu()); }));

            MenuElement testsProxyMenuElement = new MenuElement();
            testsProxyMenuElement.MenuText = "Tests Menu";
            testsProxyMenuElement.Selectable = true;
            testsProxyMenuElement.Hidden = false;
            testsProxyMenuElement.ActiveArea = new Rectangle(35, 180, 200, 40);
            testsProxyMenuElement.ForegroundColor = new Color(225, 225, 225);
            testsProxyMenuElement.ActiveForegroundColor = new Color(200, 125, 125);
            testsProxyMenuElement.SpriteFont = @"Fonts\MenuItem";
            testsProxyMenuElement.SetThrowPushEvent(new System.Action(() => { Master.Push(tests.GetMenu()); }));

            MenuElement hardExitMenuElement = new MenuElement();
            hardExitMenuElement.MenuText = "Exit Game";
            hardExitMenuElement.Selectable = true;
            hardExitMenuElement.Hidden = false;
            hardExitMenuElement.ActiveArea = new Rectangle(35, 226, 200, 40);
            hardExitMenuElement.ForegroundColor = new Color(225, 225, 225);
            hardExitMenuElement.ActiveForegroundColor = new Color(200, 125, 125);
            hardExitMenuElement.SpriteFont = @"Fonts\MenuItem";
            //To add background color, simply add a field like so:
            //hardExitMenuElement.BackgroundColor = new Color(255, 0, 0);
            //If you want to change the background color when active, add a field like this:
            //hardExitMenuElement.ActiveBackgroundColor = new Color(255, 255, 0);
            //To add a texture, you simply assign this field like so:
            //hardExitMenuElement.Texture2D = @"Debug\Zone\Projectile\circle
            hardExitMenuElement.SetThrowPushEvent(new System.Action(() => { Master.GetGame().Exit(); }));

            List<MenuElement> menuElements = new List<MenuElement>();
            menuElements.Add(titleMenuElement);
            menuElements.Add(developmentProxyMenuElement);
            menuElements.Add(testsProxyMenuElement);
            menuElements.Add(hardExitMenuElement);

            newDebugMenu.AddMenuElements(menuElements);
            //private Vector2 menuItemOriginPosition = new Vector2(35, 134);
            //private Vector2 menuItemVerticalOffset = new Vector2(0, 46);
            //private Vector2 menuItemHorizontalOffset = new Vector2(247, 0);
            //private Color defaultMenuItemColor = new Color(225, 225, 225);
            //private uint maxRows = 10;
            //private uint maxColumns = 3;

            //private Color defaultActiveItemColor = new Color(200, 125, 125);

            Master.Push(new MenuState(newDebugMenu));
        }
    }    
}
