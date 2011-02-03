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
}
