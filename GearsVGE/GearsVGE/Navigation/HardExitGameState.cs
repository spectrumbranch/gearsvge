using Gears.Cloud;

namespace Gears.Navigation
{
    public sealed class HardExitGameState : MenuUserControl
    {
        public HardExitGameState() : base("Exit Game") { }

        public override void ThrowPushEvent()
        {
            ContentButler.GetGame().Exit();
        }
    }
}
