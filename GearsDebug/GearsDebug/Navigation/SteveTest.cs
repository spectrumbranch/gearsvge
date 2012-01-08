using Gears.Navigation;
using GearsDebug.Cartography;

namespace GearsDebug.Navigation
{
    internal sealed class SteveTest
    {
        internal IMenuItem[] sub = new IMenuItem[2];

        internal SteveTest()
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
            return new Menu("Steve's Tests", sub);
        }
    }
}
