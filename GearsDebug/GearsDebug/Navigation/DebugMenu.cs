using Gears.Cloud;
using Gears.Navigation;

namespace GearsDebug.Navigation
{
    internal sealed class DebugMenu
    {
        //Main debug menu
        private IMenuItem[] imi;

        //Personal testing menus below.
        private SpectrumMenuCollection spectrum = new SpectrumMenuCollection();
        private BatchfileDebugMenu batchfile = new BatchfileDebugMenu();

        internal DebugMenu()
        {
            //create
            imi = new IMenuItem[3];

            //populate
            imi[0] = batchfile.GetMenu();
            imi[1] = spectrum.GetMenu();
            imi[2] = new HardExitGameState();

            //insert into a MenuState
            Menu debugMenu = new Menu("Debugger Menu",imi);
            Master.Push(debugMenu);
        }
    }    
}
