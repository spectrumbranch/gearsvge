using Gears.Cloud;
using Gears.Navigation;

namespace Gears
{
    public sealed class HardExitGameState : IMenuItem
    {
        private string menuText;
        public string MenuText
        {
            get { return menuText; }
            set
            {
                //15 chars or less to fit release 2 of menu implementation
                if (value.Length <= 15)
                {
                    menuText = value;
                }
                else
                {
                    //do nothing currently
                }
            }
        }
        public HardExitGameState()
        {
            MenuText = "Exit Game";
        }

        public void ThrowPushEvent()
        {
            ContentButler.GetGame().Exit();
        }
    }
}
