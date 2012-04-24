using Gears.Navigation;
using GearsDebug.Cartography;
using GearsDebug.Playable.RadialAssault;
using GearsDebug.Playable.Matt;


namespace GearsDebug.Navigation
{
    internal sealed class MattMenu
    {
        internal IMenuItem[] sub = new IMenuItem[4];

        internal MattMenu()
        {
            init();
        }
        private void init()
        {
            sub[0] = new MattState();
            sub[1] = new BackMenuOption();
            sub[2] = new HardExitGameState();
            sub[3] = new MattCreditState();
        }
        internal Menu GetMenu()
        {
            return new Menu("Matt's Tests", sub);
        }
    }
}
