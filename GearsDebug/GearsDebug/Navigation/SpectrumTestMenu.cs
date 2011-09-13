using Gears.Navigation;
using GearsDebug.Cartography;

namespace GearsDebug.Navigation
{
    internal sealed class SpectrumTestMenu
    {
        internal IMenuItem[] sub = new IMenuItem[7];

        internal SpectrumTestMenu()
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
            sub[5] = new HardExitGameState();
            sub[6] = new BackMenuOption();
        }
        internal Menu GetMenu()
        {
            return new Menu("Spectrum's Tests", sub);
        }
    }
}
