using Gears.Navigation;
using GearsDebug.Cartography;
using GearsDebug.Playable.RadialAssault;
using GearsDebug.Playable.Matt;
using Gears.Cloud;


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
            MattCreditState creditsState = new MattCreditState();
            CreditsHaveCompletedEventHandler creditsCompletedEventHandler = CreditsCompletedHandler;
            creditsState.Completed += creditsCompletedEventHandler;

            //creditsState.Completed
            sub[0] = creditsState;
            sub[1] = new MattState();
            sub[2] = new BackMenuOption();
            sub[3] = new HardExitGameState();


        }
        internal Menu GetMenu()
        {
            return new Menu("Matt's Tests", sub);
        }

        internal void CreditsCompletedHandler()
        {
            Master.Pop();
        }


    }
}
