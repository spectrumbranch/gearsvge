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

        internal DebugMenu()
        {
            //create
            imi = new IMenuItem[3];

            //populate
            imi[0] = unsorted.GetMenu();
            imi[1] = spectrum.GetMenu();
            imi[2] = new HardExitGameState();

            //insert into a MenuState
            Menu debugMenu = new Menu("Debugger Menu",imi);
            Master.Push(debugMenu);
        }
    }    
}
