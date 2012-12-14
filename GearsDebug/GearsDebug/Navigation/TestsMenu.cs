using Gears.Navigation;
using GearsDebug.Cartography;
using GearsDebug.Media;

namespace GearsDebug.Navigation
{
    internal sealed class TestsMenu
    {
        internal IMenuItem[] sub = new IMenuItem[8];

        internal TestsMenu()
        {
            init();
        }
        private void init()
        {
            sub[0] = new XMLEngineExample();
            sub[1] = new TestPlayState();
            sub[2] = new TestMapLoader();
            sub[3] = new PerformMapSerialize();
            sub[4] = new PerformMapDeserialize();
            sub[5] = new PlayTestMusic();
            sub[6] = new HardExitGameState();
            sub[7] = new BackMenuOption();
        }
        internal Menu GetMenu()
        {
            return new Menu("Tests", sub);
        }
    }
}
