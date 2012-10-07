using Gears.Cloud;
using Gears.Navigation;

namespace GearsDebug.Navigation
{
    internal sealed class DebugMenu
    {
        //Main debug menu
        private IMenuItem[] imi;

        //Personal testing menus below.
        private SpectrumTestMenu spectrum = new SpectrumTestMenu();
        private DevelopmentMenu unsorted = new DevelopmentMenu();
        private JoeTest tatltael = new JoeTest();
        //private SteveTest navi = new SteveTest();
        private MattMenu mvmenu = new MattMenu();

        internal DebugMenu()
        {
            //create
            imi = new IMenuItem[5];

            //populate
            imi[0] = unsorted.GetMenu();
            imi[1] = spectrum.GetMenu();
            imi[2] = tatltael.GetMenu();
            //imi[3] = navi.GetMenu();
            imi[3] = mvmenu.GetMenu();
            imi[4] = new HardExitGameState();

            //insert into a MenuState
            Menu debugMenu = new Menu("Debugger Menu",imi);
            Master.Push(debugMenu);
        }
    }    
}
