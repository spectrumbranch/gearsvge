using Gears.Cloud;

namespace Gears.Navigation
{
    internal sealed class BackMenuOption : MenuUserControl
    {
        internal BackMenuOption() : base("Back") { }
        public override void ThrowPushEvent()
        {
            Master.Pop();
        }
    }
}
