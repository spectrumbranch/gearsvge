using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gears.Navigation;
using GearsDebug.Cartography;
using GearsDebug.Playable.RadialAssault;
using GearsDebug.Playable.RadialAssault.Credits;
using Gears.Cloud;

namespace GearsDebug.Navigation
{
    internal sealed class DevelopmentMenu
    {
        internal IMenuItem[] sub = new IMenuItem[6];

        private RadialAssaultMenu radialAssault = new RadialAssaultMenu();

        internal DevelopmentMenu()
        {
            init();
        }
        private void init()
        {
            TestCreditState creditsState = new TestCreditState();
            CreditsHaveCompletedEventHandler creditsCompletedEventHandler = CreditsCompletedHandler;
            creditsState.Completed += creditsCompletedEventHandler;

            sub[0] = radialAssault.GetMenu();
            sub[1] = new PolarCoordinates();
            sub[2] = new ViewportHandlerTest();
            sub[3] = creditsState;
            sub[4] = new HardExitGameState();
            sub[5] = new BackMenuOption();
        }
        internal Old_Menu GetMenu()
        {
            return new Old_Menu("Development", sub);
        }
        internal void CreditsCompletedHandler()
        {
            Master.Pop();
        }
    }
}
