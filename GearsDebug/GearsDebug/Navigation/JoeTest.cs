using Gears.Navigation;
using GearsDebug.Cartography;

namespace GearsDebug.Navigation
{
    internal sealed class JoeTest
    {
        internal IMenuItem[] sub = new IMenuItem[2];

        internal JoeTest()
        {
            init();
        }
        private void init()
        {
            sub[0] = new BackMenuOption();
            sub[1] = new HardExitGameState();
        }
        internal Menu GetMenu()
        {
            return new Menu("Joe's Tests", sub);
        }
    }
}
