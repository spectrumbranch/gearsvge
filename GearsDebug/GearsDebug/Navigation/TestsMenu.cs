using Gears.Navigation;
using GearsDebug.Cartography;
using GearsDebug.Media;
using GearsDebug.Playable.DevTestArea.Collision;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using GearsDebug.Playable.DevTestArea.MenuTheming;

namespace GearsDebug.Navigation
{
    internal sealed class TestsMenu
    {
        internal List<IMenuItem> submenu = new List<IMenuItem>();

        internal TestsMenu()
        {
            init();
        }
        private void init()
        {
            submenu.Add(new CollisionTestState());
            submenu.Add(new XMLEngineExample());
            submenu.Add(new TestMapLoader());
            submenu.Add(new PerformMapSerialize());
            submenu.Add(new PerformMapDeserialize());
            submenu.Add(new PlayTestMusic());
            submenu.Add(new PerformMenuSerialize());
            submenu.Add(new HardExitGameState());
            submenu.Add(new BackMenuOption());
        }
        internal Menu GetMenu()
        {
            Menu theMenu = new Menu("Tests", submenu);
            theMenu.ItemColor = Color.Blue;
            return theMenu;
        }
    }
}
