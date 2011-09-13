using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gears.Navigation;
using GearsDebug.Cartography;
using GearsDebug.Playable.PolarCoordinates;

namespace GearsDebug.Navigation
{
    internal sealed class DevelopmentMenu
    {
        internal IMenuItem[] sub = new IMenuItem[4];

        internal DevelopmentMenu()
        {
            init();
        }
        private void init()
        {
            sub[0] = new PolarCoordinates();
            sub[1] = new ViewportHandlerTest();
            sub[2] = new HardExitGameState();
            sub[3] = new BackMenuOption();
        }
        internal Menu GetMenu()
        {
            return new Menu("Development", sub);
        }
    }
}
