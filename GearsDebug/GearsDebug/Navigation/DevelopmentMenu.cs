using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gears.Navigation;
using GearsDebug.Cartography;
using GearsDebug.Playable.RadialAssault;

namespace GearsDebug.Navigation
{
    internal sealed class DevelopmentMenu
    {
        internal IMenuItem[] sub = new IMenuItem[5];

        private RadialAssaultMenu radialAssault = new RadialAssaultMenu();

        internal DevelopmentMenu()
        {
            init();
        }
        private void init()
        {
            sub[0] = radialAssault.GetMenu();
            sub[1] = new PolarCoordinates();
            sub[2] = new ViewportHandlerTest();
            sub[3] = new HardExitGameState();
            sub[4] = new BackMenuOption();
        }
        internal Menu GetMenu()
        {
            return new Menu("Development", sub);
        }
    }
}
