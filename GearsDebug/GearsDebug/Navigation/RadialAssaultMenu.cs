using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gears.Navigation;
using GearsDebug.Cartography;
using GearsDebug.Playable.RadialAssault;

namespace GearsDebug.Navigation
{
    internal sealed class RadialAssaultMenu
    {
        internal IMenuItem[] sub = new IMenuItem[3];

        internal RadialAssaultMenu()
        {
            init();
        }
        private void init()
        {
            sub[0] = new RadialAssaultGame();
            sub[1] = new HardExitGameState();
            sub[2] = new BackMenuOption();
        }
        internal Menu GetMenu()
        {
            return new Menu("RadialAssaultMenu", sub);
        }
    }
}
