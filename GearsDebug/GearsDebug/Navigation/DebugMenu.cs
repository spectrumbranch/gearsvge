using Gears.Cloud;
using Gears.Navigation;
using System.Collections.Generic;

namespace GearsDebug.Navigation
{
    internal sealed class DebugMenu
    {
        //Main debug menu
        private List<IMenuItem> imi = new List<IMenuItem>();

        //Menus themselves
        private TestsMenu tests = new TestsMenu();
        private DevelopmentMenu development = new DevelopmentMenu();

        internal DebugMenu()
        {
            //populate
            imi.Add(development.GetMenu());
            imi.Add(tests.GetMenu());
            imi.Add(new HardExitGameState());

            //insert into a MenuState
            Old_Menu debugMenu = new Old_Menu("Debugger Menu",imi);
            Master.Push(debugMenu);
        }
    }    
}
