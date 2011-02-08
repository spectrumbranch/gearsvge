using Gears;
using Gears.Cloud;
using Gears.Navigation;

using GearsDebug.Cartography;

namespace GearsDebug.Navigation
{
    internal sealed class DebugMenu
    {
        private IMenuItem[] imi;
        private IMenuItem[] submenu;

        internal DebugMenu()
        {
            //create
            imi = new IMenuItem[6];
            submenu = new IMenuItem[1];
            //populate
            imi[0] = new TestPlayState();
            imi[1] = new ViewportHandlerTest();

            //create submenu, populate with menuitems
            submenu[0] = new BackMenuOption();
            Menu testSubMenu = new Menu("Example Submenu", submenu);

            imi[2] = testSubMenu;
            imi[3] = new PerformMapSerialize();
            imi[4] = new PerformMapDeserialize();
            imi[5] = new HardExitGameState();

            //insert into a MenuState
            Menu debugMenu = new Menu("Debugger Menu",imi);
            Master.Push(debugMenu);
        }
    }    
}
