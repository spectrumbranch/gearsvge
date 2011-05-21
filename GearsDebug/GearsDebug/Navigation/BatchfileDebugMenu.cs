using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gears.Navigation;
using GearsDebug.Cartography;
using GearsDebug.Forms;

namespace GearsDebug.Navigation
{
    internal sealed class BatchfileDebugMenu
    {
        internal IMenuItem[] sub = new IMenuItem[4];

        internal BatchfileDebugMenu()
        {
            init();
        }
        private void init()
        {
            sub[0] = new ViewportHandlerTest();
            sub[1] = new TestWinForms();
            sub[2] = new HardExitGameState();
            sub[3] = new BackMenuOption();
        }
        internal Menu GetMenu()
        {
            return new Menu("Batchfile Debug", sub);
        }
    }
}
