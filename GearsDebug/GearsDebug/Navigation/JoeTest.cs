using Gears.Navigation;
using GearsDebug.Cartography;
using GearsDebug.Playable.RadialAssault;

namespace GearsDebug.Navigation
{
    internal sealed class JoeTest
    {
        internal IMenuItem[] sub = new IMenuItem[3];

        internal JoeTest()
        {
            init();
        }
        private void init()
        {
            sub[0] = new JoeState();
            sub[1] = new BackMenuOption();
            sub[2] = new HardExitGameState();
        }
        internal Menu GetMenu()
        {
            return new Menu("Joe's Tests", sub);
        }
    }
}
